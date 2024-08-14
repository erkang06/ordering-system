using ordering_system.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordering_system
{
	public partial class UpdateCustomers : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataView customersDataView, addressesDataView; // full databases compared to whats shown in datagridview
		int customerID = -1; // id of selected customer from datagridview
		int addressID = -1; // id of selected address from datagridview
		public UpdateCustomers()
		{
			InitializeComponent();
		}

		private bool hasDeliveryAddresses() // checks if customer has at least 1 delivery address
		{
			SqlCommand hasDeliveryAddresses = new SqlCommand("SELECT COUNT(*) FROM AddressTbl WHERE customerID = @CID", con);
			hasDeliveryAddresses.Parameters.AddWithValue("@CID", customerID);
			int numberOfAddresses = (int)hasDeliveryAddresses.ExecuteScalar();
			if (numberOfAddresses == 0)
			{
				return false;
			}
			return true;
		}

		private bool areAllCustomerFieldsFilled() // checks if all required fields have been filled in
		{
			if (customerNameTextBox.Text != "" && phoneNumberTextBox.Text != "")
			{
				return true;
			}
			return false;
		}

		private bool areAllAddressFieldsFilled() // checks if all required fields have been filled in
		{
			if (deliveryHouseNumberTextBox.Text != "" && deliveryStreetNameTextBox.Text != "" && deliveryCityTextBox.Text != "" && deliveryPostcodeTextBox.Text != "" && deliveryDeliveryChargeTextBox.Text != "")
			{
				return true;
			}
			return false;
		}

		private bool doesCustomerExist() // checks if customer exists in database w/ same phone number
		{
			SqlCommand checkIfCustomerExists = new SqlCommand("SELECT COUNT(*) FROM CustomerTbl WHERE phoneNumber = @PN", con);
			checkIfCustomerExists.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
			int customerExists = (int)checkIfCustomerExists.ExecuteScalar();
			if (customerExists == 0)
			{
				return false;
			}
			return true;
		}

		private bool doesAddressExist() // see if address exists for customerid w/ same house # and postcode
		{
			SqlCommand checkIfAddressExists = new SqlCommand("SELECT COUNT(*) FROM AddressTbl WHERE CustomerID = @CID AND houseNumber = @HN AND postcode = @PC", con);
			checkIfAddressExists.Parameters.AddWithValue("@CID", customerID);
			checkIfAddressExists.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
			checkIfAddressExists.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
			int addressExists = (int)checkIfAddressExists.ExecuteScalar();
			if (addressExists == 0)
			{
				return false;
			}
			return true;
		}

		private void UpdateCustomers_Load(object sender, EventArgs e)
		{
			con.Open();
			updateCustomerDataGridView();
			con.Close();
		}

		private void updateCustomerDataGridView()
		{
			SqlDataAdapter getCustomers = new SqlDataAdapter("SELECT * FROM CustomerTbl ORDER BY customerID", con);
			DataSet customersDataSet = new DataSet();
			getCustomers.Fill(customersDataSet);
			customersDataView = new DataView(customersDataSet.Tables[0]);
			// fill in category datagridview
			DataTable customersDataTable = customersDataView.ToTable(true, "customerName", "phoneNumber", "houseNumber", "postcode");
			customerDataGridView.DataSource = customersDataTable;
			// hide deliveryaddress panel by default
			addressPanel.Visible = false;
			addressPanel.SendToBack();
		}

		private void updateAddressDataGridView()
		{
			SqlDataAdapter getAddressesForCustomer = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE customerID = @CID ORDER BY addressID", con);
			getAddressesForCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			DataSet addressesDataSet = new DataSet();
			getAddressesForCustomer.Fill(addressesDataSet);
			addressesDataView = new DataView(addressesDataSet.Tables[0]);
			// fill in address datagridview
			DataTable addressesDataTable = addressesDataView.ToTable(true, "houseNumber", "streetName", "postcode");
			addressDataGridView.DataSource = addressesDataTable;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through customerdataview to find the full deets
			int selectedRowIndex = customerDataGridView.SelectedCells[0].RowIndex;
			if (customerDataGridView.RowCount > 1 && selectedRowIndex < customerDataGridView.RowCount - 1) // just in case theres no selectable rows or u click the blank row
			{
				DataRowView selectedRow = customersDataView[selectedRowIndex];
				customerID = Convert.ToInt32(selectedRow.Row["customerID"]);
				// update textboxes
				customerNameTextBox.Text = selectedRow.Row["customerName"].ToString();
				phoneNumberTextBox.Text = selectedRow.Row["phoneNumber"].ToString();
				blacklistedCheckBox.Checked = Convert.ToBoolean(selectedRow.Row["isBlackListed"]);
				billingHouseNumberTextBox.Text = selectedRow.Row["houseNumber"].ToString();
				billingStreetNameTextBox.Text = selectedRow.Row["streetName"].ToString();
				billingVillageTextBox.Text = selectedRow.Row["village"].ToString();
				billingCityTextBox.Text = selectedRow.Row["city"].ToString();
				billingPostcodeTextBox.Text = selectedRow.Row["postcode"].ToString();
				if (hasDeliveryAddresses()) // show delivery addresses if there are any
				{
					addressPanel.BringToFront();
					addressPanel.Visible = true;
					updateAddressDataGridView();
				}
			}
			else // unselect flop row
			{
				customerDataGridView.ClearSelection();
			}
			con.Close();
		}

		private void addressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through addressesdataview to find the full deets
			int selectedRowIndex = addressDataGridView.SelectedCells[0].RowIndex;
			if (addressDataGridView.RowCount > 1 && selectedRowIndex < addressDataGridView.RowCount - 1) // just in case theres no selectable rows or u click the blank row
			{
				DataRowView selectedRow = addressesDataView[selectedRowIndex];
				addressID = Convert.ToInt32(selectedRow.Row["addressID"]);
				deliveryHouseNumberTextBox.Text = selectedRow.Row["houseNumber"].ToString();
				deliveryStreetNameTextBox.Text = selectedRow.Row["streetName"].ToString();
				deliveryVillageTextBox.Text = selectedRow.Row["village"].ToString();
				deliveryCityTextBox.Text = selectedRow.Row["city"].ToString();
				deliveryPostcodeTextBox.Text = selectedRow.Row["postcode"].ToString();
				deliveryDeliveryChargeTextBox.Text = selectedRow.Row["deliveryCharge"].ToString();
			}
			else // unselect flop row
			{
				customerDataGridView.ClearSelection();
			}
			con.Close();
		}

		private void goBackButton_Click(object sender, EventArgs e)
		{
			addressPanel.Visible = false;
			addressPanel.SendToBack();
		}

		private void updateCustomerButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllCustomerFieldsFilled() == true && customerID != -1) // update just in case details have changed
			{
				SqlCommand updateCustomerDetails = new SqlCommand("UPDATE CustomerTbl SET customerName = @CN, houseNumber = @HN, streetName = @SN, village = @VL, city = @CT, postcode = @PC WHERE customerID = @CID", con);
				updateCustomerDetails.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@CID", customerID);
				updateCustomerDetails.ExecuteNonQuery();
				MessageBox.Show("Customer updated", "Ordering System");
				clearCustomerScreen();
				updateCustomerDataGridView();
			}
			else if (customerID != -1) // cant continue w/out all fields filled in
			{
				MessageBox.Show("Not all required customer fields filled in", "Ordering System");
			}
			else
			{
				MessageBox.Show("Customer not selected", "Ordering System");
			}
			con.Close();
		}

		private void deleteCustomerButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesCustomerExist() == false) // customer not found
			{
				MessageBox.Show("Customer not found in database", "Ordering System");
			}
			else if (customerID == -1) // no customer selected
			{
				MessageBox.Show("Customer not selected", "Ordering System");
			}
			else // customer found
			{
				// check if customer used in ordertbl
				SqlCommand checkIfCustomerUsed = new SqlCommand("SELECT COUNT(*) FROM OrderTbl WHERE customerID = @CID", con);
				checkIfCustomerUsed.Parameters.AddWithValue("@CID", customerID);
				int instancesOfCustomerUsed = (int)checkIfCustomerUsed.ExecuteScalar();
				if (instancesOfCustomerUsed > 0) // exists
				{
					MessageBox.Show("There is at least one order that has been placed by this customer. Remove them before deleting this customer", "Ordering System");
				}
				else // doesnt exist - can delete
				{
					SqlCommand deleteCustomer = new SqlCommand("DELETE FROM CustomerTbl WHERE customerID = @CID", con);
					deleteCustomer.Parameters.AddWithValue("@CID", customerID);
					deleteCustomer.ExecuteNonQuery();
					MessageBox.Show("Customer deleted", "Ordering System");
					clearCustomerScreen();
					updateCustomerDataGridView();
				}
			}
			con.Close();
		}

		private void clearCustomerScreen() // clears textboxes and customerid
		{
			customerID = -1;
			customerNameTextBox.Text = "";
			phoneNumberTextBox.Text = "";
			blacklistedCheckBox.Checked = false;
			billingHouseNumberTextBox.Text = "";
			billingStreetNameTextBox.Text = "";
			billingVillageTextBox.Text = "";
			billingCityTextBox.Text = "";
			billingPostcodeTextBox.Text = "";
		}

		private void updateAddressButton_Click(object sender, EventArgs e)
		{
			if (areAllAddressFieldsFilled() == true) // update just in case details have changed
			{
				SqlCommand updateDeliveryAddress = new SqlCommand("UPDATE AddressTbl SET houseNumber = @HN, streetName = @SN, village = @VL, city = @CT, postcode = @PC, deliveryCharge = @DC WHERE addressID = @AID", con);
				updateDeliveryAddress.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
				updateDeliveryAddress.Parameters.AddWithValue("@SN", deliveryStreetNameTextBox.Text);
				updateDeliveryAddress.Parameters.AddWithValue("@VL", deliveryVillageTextBox.Text);
				updateDeliveryAddress.Parameters.AddWithValue("@CT", deliveryCityTextBox.Text);
				updateDeliveryAddress.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
				updateDeliveryAddress.Parameters.AddWithValue("@DC", Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
				updateDeliveryAddress.Parameters.AddWithValue("@AID", addressID);
				updateDeliveryAddress.ExecuteNonQuery();
				MessageBox.Show("Address updated", "Ordering System");
				clearAddressScreen();
				updateAddressDataGridView();
			}
			else // cant continue w/out all fields filled in
			{
				MessageBox.Show("Not all customer fields filled in", "Ordering System");
			}
		}

		private void deleteAddressButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesAddressExist() == false) // address not found
			{
				MessageBox.Show("Address not found in database", "Ordering System");
			}
			else if (addressID == -1) // no address selected
			{
				MessageBox.Show("Address not selected", "Ordering System");
			}
			else // address found
			{
				// check if address used in ordertbl
				SqlCommand checkIfAddressUsed = new SqlCommand("SELECT COUNT(*) FROM OrderTbl WHERE addressID = @AID", con);
				checkIfAddressUsed.Parameters.AddWithValue("@AID", addressID);
				int instancesOfAddressUsed = (int)checkIfAddressUsed.ExecuteScalar();
				if (instancesOfAddressUsed > 0) // exists
				{
					MessageBox.Show("There is at least one order that uses this address. Remove them before deleting this address", "Ordering System");
				}
				else // doesnt exist - can delete
				{
					SqlCommand deleteAddress = new SqlCommand("DELETE FROM AddressTbl WHERE addressID = @AID", con);
					deleteAddress.Parameters.AddWithValue("@CID", addressID);
					deleteAddress.ExecuteNonQuery();
					MessageBox.Show("Address deleted", "Ordering System");
					clearAddressScreen();
					updateAddressDataGridView();
				}
			}
			con.Close();
		}

		private void clearAddressScreen() // clears textboxes and customerid
		{
			addressID = -1;
			deliveryHouseNumberTextBox.Text = "";
			deliveryStreetNameTextBox.Text = "";
			deliveryVillageTextBox.Text = "";
			deliveryCityTextBox.Text = "";
			deliveryPostcodeTextBox.Text = "";
			deliveryDeliveryChargeTextBox.Text = "";
		}
	}
}
