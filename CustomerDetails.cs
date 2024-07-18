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
using System.Xml.Serialization;

namespace ordering_system
{
	public partial class CustomerDetails : Form
	{
		public delegate void CustomerDetailsUpdateHandler(object sender, CustomerDetailsUpdateEventArgs e); // kinda how data links between here and the main form

		public event CustomerDetailsUpdateHandler CustomerDetailsUpdate;

		public delegate void CustomerDetailsCancelHandler();

		public CustomerDetailsCancelHandler CustomerDetailsCancel;

		int customerID, addressID;
		string orderType;
		DataView addressesDataView; // allows an unfiltered address list to exist when filling in delivery the 
																// the connection string to the database
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		public CustomerDetails(string orderType)
		{
			InitializeComponent();
			if (orderType == "Delivery")
			{
				changeToDelivery();
			}
			else if (orderType == "Collection")
			{
				changeToCollection();
			}
		}

		private void findCustomerID() // find customerid from phonenumber
		{
			SqlCommand findcustomerID = new SqlCommand("SELECT CustomerID FROM CustomerTbl WHERE phoneNumber = @PN", con);
			findcustomerID.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
			customerID = (int)findcustomerID.ExecuteScalar();
		}

		private void findAddressID() // find addressid from customer# house# postcode
		{
			SqlCommand findAddressID = new SqlCommand("SELECT AddressID FROM AddressTbl WHERE CustomerID = @CID AND houseNumber = @HN AND postcode = @PC", con);
			findAddressID.Parameters.AddWithValue("@CID", customerID);
			findAddressID.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
			findAddressID.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
			addressID = (int)findAddressID.ExecuteScalar();
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

		private DataSet getCustomer(int customerID) // get customer details from customerid
		{
			SqlDataAdapter getCustomer = new SqlDataAdapter("SELECT * FROM CustomerTbl WHERE customerID = @CID", con);
			getCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			DataSet customer = new DataSet();
			getCustomer.Fill(customer);
			return customer;
		}

		private bool areAllCustomerFieldsFilled() // checks if all required fields have been filled in
		{
			if (customerNameTextBox.Text != "" && phoneNumberTextBox.Text != "" && billingHouseNumberTextBox.Text != "" && billingStreetNameTextBox.Text != "" && billingCityTextBox.Text != "" && billingPostcodeTextBox.Text != "")
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

		private void acceptAddressButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesCustomerExist() == false && areAllCustomerFieldsFilled() == true) // if customer doesnt alr exist in database
			{
				// add customer details to database
				SqlCommand addCustomerToDatabase = new SqlCommand("INSERT INTO CustomerTbl(customerName, phoneNumber, houseNumber, streetName, village, city, postcode) VALUES(@CN, @PN, @HN, @SN, @VL, @CT, @PC)", con);
				addCustomerToDatabase.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				addCustomerToDatabase.ExecuteNonQuery();
				findCustomerID();
			}
			else if (areAllCustomerFieldsFilled() == true) // update just in case details have changed
			{
				findCustomerID();
				SqlCommand updateCustomerDetails = new SqlCommand("UPDATE CustomerTbl SET customerName = @CN, houseNumber = @HN, streetName = @SN, village = @VL, city = @CT, postcode = @PC WHERE customerID = @CID", con);
				updateCustomerDetails.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@CID", customerID);
				updateCustomerDetails.ExecuteNonQuery();
			}
			else // cant continue w/out all fields filled in
			{
				MessageBox.Show("Not all customer fields filled in", "Ordering System");
				return;
			}

			if (deliveryButton.BackColor == Color.Yellow) // if its a delivery by the end
			{

				if (doesAddressExist() == false && areAllAddressFieldsFilled() == true) // address doesnt exist in addresstbl
				{
					// add customer details to database
					SqlCommand addAddressToDatabase = new SqlCommand("INSERT INTO AddressTbl(customerID, houseNumber, streetName, village, city, postcode, deliveryCharge) VALUES(@CID, @HN, @SN, @VL, @CT, @PC, @DC)", con);
					addAddressToDatabase.Parameters.AddWithValue("@CID", customerID);
					addAddressToDatabase.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@SN", deliveryStreetNameTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@VL", deliveryVillageTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@CT", deliveryCityTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
					addAddressToDatabase.Parameters.AddWithValue("@DC", Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
					addAddressToDatabase.ExecuteNonQuery();
					findAddressID();
				}
				else if (areAllAddressFieldsFilled() == true) // update just in case details have changed
				{
					findAddressID();
					SqlCommand updateDeliveryAddress = new SqlCommand("UPDATE AddressTbl SET customerID = @CID, houseNumber = @HN, streetName = @SN, village = @VL, @city = @CT, postcode = @PC, deliveryCharge = @DC WHERE addressID = @AID", con);
					updateDeliveryAddress.Parameters.AddWithValue("@CID", customerID);
					updateDeliveryAddress.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@SN", deliveryStreetNameTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@VL", deliveryVillageTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@CT", deliveryCityTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@DC", Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
					updateDeliveryAddress.Parameters.AddWithValue("@AID", addressID);
					updateDeliveryAddress.ExecuteNonQuery();
				}
				else // cant continue w/out all fields filled in
				{
					MessageBox.Show("Not all customer fields filled in", "Ordering System");
					return;
				}
				orderType = "Delivery";
				// send delivery details back to main menu
			}
			else if (collectionButton.BackColor == Color.Yellow) // if its a collection by the end
			{
				orderType = "Collection";
			}

			CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(customerID, orderType, addressID);
			CustomerDetailsUpdate(this, args);
			con.Close();
			Close();
		}

		private void cancelAddressButton_Click(object sender, EventArgs e)
		{
			CustomerDetailsCancel();
			Close();
		}

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			// this is weird to allow deliveries passed through main menu to change customer details too
			changeToDelivery();
		}

		private void changeToDelivery()
		{
			deliveryButton.BackColor = Color.Yellow;
			collectionButton.BackColor = Color.Transparent;
			deliveryHouseNumberTextBox.Enabled = true;
			deliveryStreetNameTextBox.Enabled = true;
			deliveryVillageTextBox.Enabled = true;
			deliveryCityTextBox.Enabled = true;
			deliveryPostcodeTextBox.Enabled = true;
			deliveryDeliveryChargeTextBox.Enabled = true;
			deliveryAddressDataGridView.Enabled = true;
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			// this is weird to allow collections passed through main menu to change customer details too
			changeToCollection();
		}

		private void changeToCollection()
		{
			collectionButton.BackColor = Color.Yellow;
			deliveryButton.BackColor = Color.Transparent;
			deliveryHouseNumberTextBox.Enabled = false;
			deliveryStreetNameTextBox.Enabled = false;
			deliveryVillageTextBox.Enabled = false;
			deliveryCityTextBox.Enabled = false;
			deliveryPostcodeTextBox.Enabled = false;
			deliveryDeliveryChargeTextBox.Enabled = false;
			deliveryAddressDataGridView.Enabled = false;
		}

		private void findCustomerButton_Click(object sender, EventArgs e) // wtf help xoxo
		{
			con.Open();
			if (doesCustomerExist() == false) // if no customer exists for the number given
			{
				MessageBox.Show("No customer exists with the phone number given", "Ordering System");
			}
			else
			{
				// fill in customer details and billing address
				findCustomerID();
				DataSet customer = getCustomer(customerID);
				customerNameTextBox.Text = customer.Tables[0].Rows[0]["customerName"].ToString().Trim();
				blacklistedCheckBox.Checked = Convert.ToBoolean(customer.Tables[0].Rows[0]["isBlackListed"]);
				billingHouseNumberTextBox.Text = customer.Tables[0].Rows[0]["houseNumber"].ToString().Trim();
				billingStreetNameTextBox.Text = customer.Tables[0].Rows[0]["streetName"].ToString().Trim();
				billingVillageTextBox.Text = customer.Tables[0].Rows[0]["village"].ToString().Trim();
				billingCityTextBox.Text = customer.Tables[0].Rows[0]["city"].ToString().Trim();
				billingPostcodeTextBox.Text = customer.Tables[0].Rows[0]["postcode"].ToString().Trim();

				if (deliveryButton.BackColor == Color.Yellow) // deliveries need the address data grid view filling in
				{
					SqlDataAdapter getAddresses = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE customerID = @CID", con);
					getAddresses.SelectCommand.Parameters.AddWithValue("@CID", customerID);
					DataSet addressesDataSet = new DataSet();
					getAddresses.Fill(addressesDataSet);
					addressesDataView = new DataView(addressesDataSet.Tables[0]);
					// fill in address datagridview
					DataTable addressesDataTable = addressesDataView.ToTable(true, "houseNumber", "streetName", "postCode");
					deliveryAddressDataGridView.DataSource = addressesDataTable;
				}
			}
			con.Close();
		}

		private void billingAsDeliveryCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// if box is checked and is acc a delivery
			if (billingAsDeliveryCheckBox.Checked == true && deliveryButton.BackColor == Color.Yellow)
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
			// find clicked row of table in order to search through addressesdatagridview to find the full deets
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

		private void deleteCustomerButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesCustomerExist() == false) // phone# not found
			{
				MessageBox.Show("Customer with phone number not found in database", "Ordering System");
			}
			else // phone# found
			{
				findCustomerID();
				SqlCommand deleteCustomer = new SqlCommand("DELETE FROM CustomerTbl WHERE customerID = @CID", con);
				deleteCustomer.Parameters.AddWithValue("@CID", customerID);
				deleteCustomer.ExecuteNonQuery();
				MessageBox.Show("Customer deleted", "Ordering System");
			}
			con.Close();
		}

		private void deleteDeliveryAddressButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesAddressExist() == false)
			{
				MessageBox.Show("Address with house number and postcode not found in database", "Ordering System");
			}
			else
			{
				findAddressID();
				SqlCommand deleteAddress = new SqlCommand("DELETE FROM AddressTbl WHERE addressID = @AID");
				deleteAddress.Parameters.AddWithValue("@AID", addressID);
				deleteAddress.ExecuteNonQuery();
				MessageBox.Show("Address deleted", "Ordering System");
			}
			con.Close();
		}

		private void customerNameTextBox_Leave(object sender, EventArgs e)
		{
			if (customerNameTextBox.Text.Length > 50) // if name too long for database
			{
				MessageBox.Show("Customer name too long", "Ordering System");
				customerNameTextBox.Focus();
			}
		}

		private void phoneNumberTextBox_Leave(object sender, EventArgs e)
		{
			if (phoneNumberTextBox.Text.Length > 20) // if phone# too long for database
			{
				MessageBox.Show("Phone number too long", "Ordering System");
				phoneNumberTextBox.Focus();
			}
		}

		private void billingHouseNumberTextBox_Leave(object sender, EventArgs e)
		{
			if (billingHouseNumberTextBox.Text.Length > 30) // if house number too long for database
			{
				MessageBox.Show("House number too long", "Ordering System");
				billingHouseNumberTextBox.Focus();
			}
		}

		private void billingStreetNameTextBox_Leave(object sender, EventArgs e)
		{
			if (billingStreetNameTextBox.Text.Length > 50) // if street name too long for database
			{
				MessageBox.Show("Street name too long", "Ordering System");
				billingStreetNameTextBox.Focus();
			}
		}

		private void billingVillageTextBox_Leave(object sender, EventArgs e)
		{
			if (billingVillageTextBox.Text.Length > 30) // if village too long for database
			{
				MessageBox.Show("Village too long", "Ordering System");
				billingVillageTextBox.Focus();
			}
		}

		private void billingCityTextBox_Leave(object sender, EventArgs e)
		{
			if (billingCityTextBox.Text.Length > 30) // if city too long for database
			{
				MessageBox.Show("CIty too long", "Ordering System");
				billingCityTextBox.Focus();
			}
		}

		private void billingPostcodeTextBox_Leave(object sender, EventArgs e)
		{
			if (billingPostcodeTextBox.Text.Length > 10) // if postcode too long for database
			{
				MessageBox.Show("Postcode too long", "Ordering System");
				billingPostcodeTextBox.Focus();
			}
		}

		private void deliveryHouseNumberTextBox_Leave(object sender, EventArgs e)
		{
			if (deliveryHouseNumberTextBox.Text.Length > 30) // if house number too long for database
			{
				MessageBox.Show("House number too long", "Ordering System");
				deliveryHouseNumberTextBox.Focus();
			}
		}

		private void deliveryStreetNameTextBox_Leave(object sender, EventArgs e)
		{
			if (deliveryHouseNumberTextBox.Text.Length > 50) // if street name too long for database
			{
				MessageBox.Show("Street name too long", "Ordering System");
				deliveryHouseNumberTextBox.Focus();
			}
		}

		private void deliveryVillageTextBox_Leave(object sender, EventArgs e)
		{
			if (deliveryVillageTextBox.Text.Length > 30) // if village too long for database
			{
				MessageBox.Show("Village too long", "Ordering System");
				deliveryVillageTextBox.Focus();
			}
		}

		private void deliveryCityTextBox_Leave(object sender, EventArgs e)
		{
			if (deliveryCityTextBox.Text.Length > 30) // if city too long for database
			{
				MessageBox.Show("City too long", "Ordering System");
				deliveryCityTextBox.Focus();
			}
		}

		private void deliveryPostcodeTextBox_Leave(object sender, EventArgs e)
		{
			if (deliveryPostcodeTextBox.Text.Length > 10) // if post too long for database
			{
				MessageBox.Show("Postcode too long", "Ordering System");
				deliveryPostcodeTextBox.Focus();
			}
		}

		private void deliveryDeliveryChargeTextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				Convert.ToDecimal(deliveryDeliveryChargeTextBox); // check if value is acc decimal
			}
			catch // not decimal
			{
				MessageBox.Show("Category index not an decimal", "Ordering System");
				deliveryDeliveryChargeTextBox.Focus();
			}
		}
	}
}
