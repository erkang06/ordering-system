using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ordering_system
{
	public partial class CustomerDetails : Form
	{
		public delegate void CustomerDetailsUpdateHandler(object sender, CustomerDetailsUpdateEventArgs e); // kinda how data links between here and the main form

		public event CustomerDetailsUpdateHandler CustomerDetailsUpdate;

		int customerID, addressID, customerExists;
		DataView addressesDataView; // allows an unfiltered address list to exist when filling in delivery the address
		public CustomerDetails()
		{
			InitializeComponent();
		}

		private void findCustomerID()
		{
			SqlCommand findcustomerID = new SqlCommand("SELECT CustomerID FROM CustomerTbl WHERE phoneNumber = @PN", MainMenu.con);
			findcustomerID.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
			customerID = (int)findcustomerID.ExecuteScalar();
		}

		private void findAddressID()
		{
			SqlCommand findAddressID = new SqlCommand("SELECT AddressID FROM AddressTbl WHERE CustomerID = @CID AND houseNumber = @HN AND postcode = @PC", MainMenu.con);
			findAddressID.Parameters.AddWithValue("@CID", customerID);
			findAddressID.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
			findAddressID.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
			addressID = (int)findAddressID.ExecuteScalar();
		}

		private void checkIfCustomerExists() // checks if customer exists in database w/ same phone number
		{
			SqlCommand checkIfCustomerExists = new SqlCommand("SELECT COUNT(*) FROM CustomerTbl WHERE phoneNumber = @PN", MainMenu.con);
			checkIfCustomerExists.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
			customerExists = (int)checkIfCustomerExists.ExecuteScalar();
		}

		private void acceptAddressButton_Click(object sender, EventArgs e)
		{
			MainMenu.con.Open();
			checkIfCustomerExists();
			if (customerExists == 0) // if customer doesnt alr exist in database
			{
				// add customer details to database
				SqlCommand addCustomerToDatabase = new SqlCommand("INSERT INTO CustomerTbl(customerName, phoneNumber, houseNumber, streetName, village, city, postcode) VALUES(@CN, @PN, @HN, @SN, @VL, @CT, @PC)", MainMenu.con);
				addCustomerToDatabase.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				addCustomerToDatabase.ExecuteNonQuery();
			}
			findCustomerID();
			MainMenu.currentOrder.customerID = customerID; // add customerid to running order

			if (deliveryButton.BackColor == Color.Yellow) // if its a delivery by the end
			{
				// see if address exists for customerid w/ same house # and postcode
				SqlCommand checkIfAddressExists = new SqlCommand("SELECT COUNT(*) FROM AddressTbl WHERE CustomerID = @CID AND houseNumber = @HN AND postcode = @PC", MainMenu.con);
				checkIfAddressExists.Parameters.AddWithValue("@CID", customerID);
				checkIfAddressExists.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
				checkIfAddressExists.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
				int addressExists = (int)checkIfAddressExists.ExecuteScalar();

				if (addressExists == 0) // address doesnt exist in addresstbl
				{
					// add customer details to database
					SqlCommand addAddressToDatabase = new SqlCommand("INSERT INTO AddressTbl(customerID, houseNumber, streetName, village, city, postcode, deliveryCharge) VALUES(@CID, @HN, @SN, @VL, @CT, @PC, @DC)", MainMenu.con);
					addAddressToDatabase.Parameters.AddWithValue("@CID", customerID);
					addAddressToDatabase.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@SN", deliveryStreetNameTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@VL", deliveryVillageTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@CT", deliveryCityTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@DC", Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
					addAddressToDatabase.ExecuteNonQuery();
				}
				findAddressID();
				MainMenu.currentOrder.addressID = addressID; // add addressid to running order

				// send delivery details back to main menu
				CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(phoneNumberTextBox.Text, "Delivery", houseNumber: deliveryHouseNumberTextBox.Text, streetName: deliveryStreetNameTextBox.Text, postcode: deliveryPostcodeTextBox.Text, deliveryCharge: Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
				CustomerDetailsUpdate(this, args);
			}
			else if (collectionButton.BackColor == Color.Yellow) // if its a collection by the end
			{
				// send collection details back to main menu
				CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(phoneNumberTextBox.Text, "Collection", customerName: customerNameTextBox.Text);
				CustomerDetailsUpdate(this, args);
			}
			MainMenu.con.Close();
			Close();
		}

		private void cancelAddressButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			deliveryButton.BackColor = Color.Yellow;
			collectionButton.BackColor = Color.Transparent;
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			collectionButton.BackColor = Color.Yellow;
			deliveryButton.BackColor = Color.Transparent;
		}

		private void CustomerDetails_Load(object sender, EventArgs e) // presets whether order type is delivery or collection if form not opened by cust deets panel
		{
			if (MainMenu.currentOrder.orderType == "Delivery")
			{
				deliveryButton_Click(sender, e);
			}
			else if (MainMenu.currentOrder.orderType == "Collection")
			{
				collectionButton_Click(sender, e);
			}
		}

		private void findCustomerButton_Click(object sender, EventArgs e) // wtf help xoxo
		{
			MainMenu.con.Open();
			checkIfCustomerExists();
			if (customerExists == 0) // if no customer exists for the number given
			{
				MessageBox.Show("No customer exists with the phone number given", "Ordering System");
			}
			else
			{
				// fill in customer details and billing address
				findCustomerID();
				SqlDataAdapter getCustomer = new SqlDataAdapter("SELECT * FROM CustomerTbl WHERE customerID = @CID", MainMenu.con);
				getCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
				DataSet customer = new DataSet();
				getCustomer.Fill(customer);
				customerNameTextBox.Text = customer.Tables[0].Rows[0]["customerName"].ToString().Trim();
				blacklistedCheckBox.Checked = Convert.ToBoolean(customer.Tables[0].Rows[0]["isBlackListed"]);
				billingHouseNumberTextBox.Text = customer.Tables[0].Rows[0]["houseNumber"].ToString().Trim();
				billingStreetNameTextBox.Text = customer.Tables[0].Rows[0]["streetName"].ToString().Trim();
				billingVillageTextBox.Text = customer.Tables[0].Rows[0]["village"].ToString().Trim();
				billingCityTextBox.Text = customer.Tables[0].Rows[0]["city"].ToString().Trim();
				billingPostcodeTextBox.Text = customer.Tables[0].Rows[0]["postcode"].ToString().Trim();

				// fill in address dataview
				SqlDataAdapter getAddresses = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE customerID = @CID", MainMenu.con);
				getAddresses.SelectCommand.Parameters.AddWithValue("@CID", customerID);
				DataSet addresses = new DataSet();
				getAddresses.Fill(addresses);
				addressesDataView = new DataView(addresses.Tables[0]);
				DataTable addressesDataTable = addressesDataView.ToTable(true, "houseNumber", "streetName", "postCode");
				deliveryAddressDataGridView.DataSource = addressesDataTable;

			}
			MainMenu.con.Close();
		}

		private void billingAsDeliveryCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (billingAsDeliveryCheckBox.Checked == true)
			{
				deliveryHouseNumberTextBox.Text = billingHouseNumberTextBox.Text;
				deliveryStreetNameTextBox.Text = billingStreetNameTextBox.Text;
				deliveryVillageTextBox.Text = billingVillageTextBox.Text;
				deliveryCityTextBox.Text = billingCityTextBox.Text;
				deliveryPostcodeTextBox.Text = billingPostcodeTextBox.Text;
			}
		}

		private void deliveryAddressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through addressesdataview to find the full deets
			int selectedRowIndex = deliveryAddressDataGridView.SelectedCells[0].RowIndex;
			DataRowView selectedRow = addressesDataView[selectedRowIndex];
			addressID = Convert.ToInt32(selectedRow.Row["addressID"]);
			// update delivery address
			deliveryHouseNumberTextBox.Text = selectedRow.Row["houseNumber"].ToString().Trim();
			deliveryStreetNameTextBox.Text = selectedRow.Row["streetName"].ToString().Trim();
			deliveryVillageTextBox.Text = selectedRow.Row["village"].ToString().Trim();
			deliveryCityTextBox.Text = selectedRow.Row["city"].ToString().Trim();
			deliveryPostcodeTextBox.Text = selectedRow.Row["postcode"].ToString().Trim();
			deliveryDeliveryChargeTextBox.Text = Convert.ToDecimal(selectedRow.Row["deliveryCharge"]).ToString("0.00").Trim();
			deliveryAddressDataGridView.ClearSelection(); // unselect row
		}
	}
}
