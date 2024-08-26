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
		DataTable customersDataTable; // full datatable compared to whats shown in datagridview
		DataTable addressesDataTable;
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
			customersDataTable = new DataTable();
			SqlDataAdapter getCustomers = new SqlDataAdapter("SELECT * FROM CustomerTbl ORDER BY customerID", con);
			getCustomers.Fill(customersDataTable);
			DataView customersDataView = new DataView(customersDataTable);
			// fill in category datagridview
			customerDataGridView.DataSource = customersDataView.ToTable(true, "customerName", "phoneNumber", "houseNumber", "postcode");
			customerDataGridView.Columns["houseNumber"].Width = 100;
			customerDataGridView.Columns["postcode"].Width = 150;
			// hide deliveryaddress panel by default
			addressPanel.Visible = false;
			addressPanel.SendToBack();
		}

		private void updateAddressDataGridView()
		{
			addressesDataTable = new DataTable();
			SqlDataAdapter getAddressesForCustomer = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE customerID = @CID", con);
			getAddressesForCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			getAddressesForCustomer.Fill(addressesDataTable);
			DataView addressesDataView = new DataView(addressesDataTable);
			// fill in address datagridview
			addressDataGridView.DataSource = addressesDataView.ToTable(true, "addressID", "houseNumber", "streetName", "postcode");
			addressDataGridView.Columns["addressID"].Width = 50;
			addressDataGridView.Columns["postcode"].Width = 150;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through customerdatatable to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				// get customerid through phonenumber
				string phoneNumber = customerDataGridView.Rows[selectedRowIndex].Cells["phoneNumber"].Value.ToString();
				DataRow selectedRow = customersDataTable.Select($"phoneNumber = '{phoneNumber}'")[0];
				customerID = Convert.ToInt32(selectedRow["customerID"]);
				// update textboxes
				customerNameTextBox.Text = selectedRow["customerName"].ToString();
				phoneNumberTextBox.Text = selectedRow["phoneNumber"].ToString();
				blacklistedCheckBox.Checked = Convert.ToBoolean(selectedRow["isBlackListed"]);
				billingHouseNumberTextBox.Text = selectedRow["houseNumber"].ToString();
				billingStreetNameTextBox.Text = selectedRow["streetName"].ToString();
				billingVillageTextBox.Text = selectedRow["village"].ToString();
				billingCityTextBox.Text = selectedRow["city"].ToString();
				billingPostcodeTextBox.Text = selectedRow["postcode"].ToString();
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
			// find clicked row of table in order to search through addressesdatatable to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				// get addressid
				addressID = Convert.ToInt32(addressDataGridView.Rows[selectedRowIndex].Cells["addressID"].Value);
				DataRow selectedRow = addressesDataTable.Select($"addressID = '{addressID}'")[0];
				// fill in textboxes
				deliveryHouseNumberTextBox.Text = selectedRow["houseNumber"].ToString();
				deliveryStreetNameTextBox.Text = selectedRow["streetName"].ToString();
				deliveryVillageTextBox.Text = selectedRow["village"].ToString();
				deliveryCityTextBox.Text = selectedRow["city"].ToString();
				deliveryPostcodeTextBox.Text = selectedRow["postcode"].ToString();
				deliveryDeliveryChargeTextBox.Text = selectedRow["deliveryCharge"].ToString();
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
			if (areAllCustomerFieldsFilled() == false) // not all fields filled in
			{
				MessageBox.Show("Not all required customer fields filled in", "Ordering System");
			}
			else if (customerID > 0) // customer not selected
			{
				MessageBox.Show("Customer not selected", "Ordering System");
			}
			else if (doesCustomerExist()) // if new phone number has already been used in tbl
			{
				MessageBox.Show("Customer already exists with the same phone number", "Ordering System");
			}
			else // update just in case details have changed
			{
				SqlCommand updateCustomerDetails = new SqlCommand("UPDATE CustomerTbl SET customerName = @CN, phoneNumber = @PN, isBlackListed = @IBL, houseNumber = @HN, streetName = @SN, village = @VL, city = @CT, postcode = @PC WHERE customerID = @CID", con);
				updateCustomerDetails.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@IBL", blacklistedCheckBox.Checked);
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
			else if (hasCustomerBeenUsedInAddress()) // customer exists in addresstbl
			{
				MessageBox.Show("There is at least one address that is associated with this customer. Remove them before deleting this customer", "Ordering System");
			}
			else if (hasCustomerBeenUsedInOrder()) // customer exists in an order
			{
				MessageBox.Show("There is at least one order that has been placed by this customer. Remove them before deleting this customer", "Ordering System");
			}
			else // doesnt exist - can delete
			{
				// delete all addresses w/ same customerid
				SqlCommand deleteAssociatedAddresses = new SqlCommand("DELETE FROM AddressTbl WHERE customerID = @CID", con);
				deleteAssociatedAddresses.Parameters.AddWithValue("@CID", customerID);
				deleteAssociatedAddresses.ExecuteNonQuery();
				// delete customer
				SqlCommand deleteCustomer = new SqlCommand("DELETE FROM CustomerTbl WHERE customerID = @CID", con);
				deleteCustomer.Parameters.AddWithValue("@CID", customerID);
				deleteCustomer.ExecuteNonQuery();
				MessageBox.Show("Customer deleted", "Ordering System");
				clearCustomerScreen();
				updateCustomerDataGridView();
			}
			con.Close();
		}

		private bool hasCustomerBeenUsedInAddress()
		{
			// check if customer used in addresstbl
			SqlCommand checkIfAddressUsed = new SqlCommand("SELECT COUNT(*) FROM AddressTbl WHERE customerID = @CID", con);
			checkIfAddressUsed.Parameters.AddWithValue("@CID", customerID);
			int instancesOfAddressUsed = (int)checkIfAddressUsed.ExecuteScalar();
			if (instancesOfAddressUsed > 0) // exists
			{
				return true;
			}
			return false;
		}

		private bool hasCustomerBeenUsedInOrder()
		{
			// check if customer used in ordertbl
			SqlCommand checkIfCustomerUsed = new SqlCommand("SELECT COUNT(*) FROM OrderTbl WHERE customerID = @CID", con);
			checkIfCustomerUsed.Parameters.AddWithValue("@CID", customerID);
			int instancesOfCustomerUsed = (int)checkIfCustomerUsed.ExecuteScalar();
			if (instancesOfCustomerUsed > 0) // exists
			{
				return true;
			}
			return false;
		}

		private void clearCustomerScreen() // clears textboxes and customerid
		{
			customerID = -1;
			customerNameTextBox.Text = string.Empty;
			phoneNumberTextBox.Text = string.Empty;
			blacklistedCheckBox.Checked = false;
			billingHouseNumberTextBox.Text = string.Empty;
			billingStreetNameTextBox.Text = string.Empty;
			billingVillageTextBox.Text = string.Empty;
			billingCityTextBox.Text = string.Empty;
			billingPostcodeTextBox.Text = string.Empty;
		}

		private void updateAddressButton_Click(object sender, EventArgs e)
		{
			con.Open();
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
			con.Close();
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
			else if (hasAddressBeenUsedInOrder()) // exists in an order
			{
				MessageBox.Show("There is at least one order that uses this address. Remove them before deleting this address", "Ordering System");
			}
			else // doesnt exist - can delete
			{
				SqlCommand deleteAddress = new SqlCommand("DELETE FROM AddressTbl WHERE addressID = @AID", con);
				deleteAddress.Parameters.AddWithValue("@AID", addressID);
				deleteAddress.ExecuteNonQuery();
				MessageBox.Show("Address deleted", "Ordering System");
				clearAddressScreen();
				updateAddressDataGridView();
			}
			con.Close();
		}

		private bool hasAddressBeenUsedInOrder()
		{
			// check if address used in ordertbl
			SqlCommand checkIfAddressUsed = new SqlCommand("SELECT COUNT(*) FROM OrderTbl WHERE addressID = @AID", con);
			checkIfAddressUsed.Parameters.AddWithValue("@AID", addressID);
			int instancesOfAddressUsed = (int)checkIfAddressUsed.ExecuteScalar();
			if (instancesOfAddressUsed > 0) // exists
			{
				return true;
			}
			return false;
		}

		private void clearAddressScreen() // clears textboxes and customerid
		{
			addressID = -1;
			deliveryHouseNumberTextBox.Text = string.Empty;
			deliveryStreetNameTextBox.Text = string.Empty;
			deliveryVillageTextBox.Text = string.Empty;
			deliveryCityTextBox.Text = string.Empty;
			deliveryPostcodeTextBox.Text = string.Empty;
			deliveryDeliveryChargeTextBox.Text = string.Empty;
		}
	}
}
