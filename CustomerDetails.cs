using ordering_system.Properties;
using System.Data;
using System.Data.SqlClient;

namespace ordering_system
{
	public partial class CustomerDetails : Form
	{
		public delegate void CustomerDetailsUpdateHandler(object sender, CustomerDetailsUpdateEventArgs e); // kinda how data links between here and the main form

		public event CustomerDetailsUpdateHandler CustomerDetailsUpdate;

		public delegate void CustomerDetailsCancelHandler();

		public CustomerDetailsCancelHandler CustomerDetailsCancel;

		int customerID, addressID;
		DataTable addressesDataTable; // allows an unfiltered address list to exist when filling in delivery
																	// the connection string to the database
		readonly SqlConnection con = new SqlConnection(Resources.con);
		public CustomerDetails(string orderType, int customerIDFromMainMenu)
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
			if (customerIDFromMainMenu > 0)
			{
				customerID = customerIDFromMainMenu;
				fillInCustomerDetails(false);
			}
		}

		// common use functions
		private int findCustomerID() // find customerid from phonenumber
		{
			SqlCommand findcustomerID = new SqlCommand("SELECT CustomerID FROM CustomerTbl WHERE phoneNumber = @PN", con);
			findcustomerID.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
			return (int)findcustomerID.ExecuteScalar();
		}

		private int findAddressID() // find addressid from customer# house# postcode
		{
			SqlCommand findAddressID = new SqlCommand("SELECT AddressID FROM AddressTbl WHERE CustomerID = @CID AND houseNumber = @HN AND postcode = @PC", con);
			findAddressID.Parameters.AddWithValue("@CID", customerID);
			findAddressID.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
			findAddressID.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
			return (int)findAddressID.ExecuteScalar();
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

		private void clearCustomerScreen() // clears textboxes
		{
			customerNameTextBox.Text = string.Empty;
			phoneNumberTextBox.Text = string.Empty;
			blacklistedCheckBox.Checked = false;
			billingHouseNumberTextBox.Text = string.Empty;
			billingStreetNameTextBox.Text = string.Empty;
			billingVillageTextBox.Text = string.Empty;
			billingCityTextBox.Text = string.Empty;
			billingPostcodeTextBox.Text = string.Empty;
		}

		private void clearAddressScreen() // clears textboxes
		{
			deliveryHouseNumberTextBox.Text = string.Empty;
			deliveryStreetNameTextBox.Text = string.Empty;
			deliveryVillageTextBox.Text = string.Empty;
			deliveryCityTextBox.Text = string.Empty;
			deliveryPostcodeTextBox.Text = string.Empty;
			deliveryDeliveryChargeTextBox.Text = string.Empty;
		}

		private void updateDataGridView()
		{
			addressesDataTable = new DataTable();
			SqlDataAdapter getAddresses = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE customerID = @CID", con);
			getAddresses.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			getAddresses.Fill(addressesDataTable);
			DataView addressesDataView = new DataView(addressesDataTable);
			// fill in address datagridview
			addressDataGridView.DataSource = addressesDataView.ToTable(true, "houseNumber", "streetName", "postcode");
			// sort out column widths
			//addressDataGridView.Columns["houseNumber"].Width = 100;
			//addressDataGridView.Columns["postcode"].Width = 200;
		}

		// form related

		private void acceptAddressButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllCustomerFieldsFilled() == false) // cant continue w/out all fields filled in
			{
				MessageBox.Show("Not all required customer fields filled in", "Ordering System");
				con.Close();
				return;
			}
			else if (doesCustomerExist() == false) // if customer doesnt alr exist in database
			{
				// add customer details to database
				SqlCommand addCustomerToDatabase = new SqlCommand("INSERT INTO CustomerTbl(customerName, phoneNumber, isBlacklisted, houseNumber, streetName, village, city, postcode) VALUES(@CN, @PN, @IBL, @HN, @SN, @VL, @CT, @PC)", con);
				addCustomerToDatabase.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@IBL", blacklistedCheckBox.Checked);
				addCustomerToDatabase.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				addCustomerToDatabase.ExecuteNonQuery();
				customerID = findCustomerID();
			}
			else // update just in case details have changed
			{
				customerID = findCustomerID();
				SqlCommand updateCustomerDetails = new SqlCommand("UPDATE CustomerTbl SET customerName = @CN, isBlackListed = @IBL, houseNumber = @HN, streetName = @SN, village = @VL, city = @CT, postcode = @PC WHERE customerID = @CID", con);
				updateCustomerDetails.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@IBL", blacklistedCheckBox.Checked);
				updateCustomerDetails.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				updateCustomerDetails.Parameters.AddWithValue("@CID", customerID);
				updateCustomerDetails.ExecuteNonQuery();
			}

			string orderType = "Collection"; // set default ordertype to collection since theres nothing more that needs to be updated databasewise
			if (deliveryButton.BackColor == Color.Yellow) // if its a delivery by the end
			{
				if (areAllAddressFieldsFilled() == false)// cant continue w/out all fields filled in
				{
					MessageBox.Show("Not all required address fields filled in", "Ordering System");
					con.Close();
					return;
				}
				else if (doesAddressExist() == false) // address doesnt exist in addresstbl
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
					addressID = findAddressID();
				}
				else // update just in case details have changed
				{
					addressID = findAddressID();
					SqlCommand updateDeliveryAddress = new SqlCommand("UPDATE AddressTbl SET houseNumber = @HN, streetName = @SN, village = @VL, city = @CT, postcode = @PC, deliveryCharge = @DC WHERE addressID = @AID", con);
					updateDeliveryAddress.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@SN", deliveryStreetNameTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@VL", deliveryVillageTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@CT", deliveryCityTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
					updateDeliveryAddress.Parameters.AddWithValue("@DC", Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
					updateDeliveryAddress.Parameters.AddWithValue("@AID", addressID);
					updateDeliveryAddress.ExecuteNonQuery();
				}
				orderType = "Delivery";
			}
			else if (collectionButton.BackColor != Color.Yellow) // if order type button isnt selected
			{
				MessageBox.Show("Order type not selected", "Ordering System");
				con.Close();
				return;
			}
			// send delivery details back to main menu
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
			deliveryHouseNumberLabel.Text = "*House Number:";
			deliveryStreetNameTextBox.Enabled = true;
			deliveryStreetNameLabel.Text = "*Street Name:";
			deliveryVillageTextBox.Enabled = true;
			deliveryCityTextBox.Enabled = true;
			deliveryCityLabel.Text = "*City:";
			deliveryPostcodeTextBox.Enabled = true;
			deliveryPostcodeLabel.Text = "*Postcode:";
			deliveryDeliveryChargeTextBox.Enabled = true;
			deliveryDeliveryChargeLabel.Text = "*Delivery Charge:";
			addressDataGridView.Enabled = true;
			billingAsDeliveryCheckBox.Enabled = true;
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
			deliveryHouseNumberTextBox.Text = string.Empty;
			deliveryHouseNumberLabel.Text = "House Number:";
			deliveryStreetNameTextBox.Enabled = false;
			deliveryStreetNameTextBox.Text = string.Empty;
			deliveryStreetNameLabel.Text = "Street Name:";
			deliveryVillageTextBox.Enabled = false;
			deliveryVillageTextBox.Text = string.Empty;
			deliveryCityTextBox.Enabled = false;
			deliveryCityTextBox.Text = string.Empty;
			deliveryCityLabel.Text = "City:";
			deliveryPostcodeTextBox.Enabled = false;
			deliveryPostcodeTextBox.Text = string.Empty;
			deliveryPostcodeLabel.Text = "Postcode:";
			deliveryDeliveryChargeTextBox.Enabled = false;
			deliveryDeliveryChargeTextBox.Text = string.Empty;
			deliveryDeliveryChargeLabel.Text = "Delivery Charge:";
			addressDataGridView.Enabled = false;
			billingAsDeliveryCheckBox.Enabled = false;
			billingAsDeliveryCheckBox.Checked = false;
		}

		private void findCustomerButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesCustomerExist() == false) // if no customer exists for the number given
			{
				MessageBox.Show("No customer exists with the phone number given", "Ordering System");
			}
			else
			{
				customerID = findCustomerID();
				clearAddressScreen();
				fillInCustomerDetails(true);
			}
			con.Close();
		}

		private void fillInCustomerDetails(bool phoneNumberAlreadyInputted) // fill in customer details and billing address
		{
			DataSet customer = getCustomer(customerID);
			customerNameTextBox.Text = customer.Tables[0].Rows[0]["customerName"].ToString();
			blacklistedCheckBox.Checked = Convert.ToBoolean(customer.Tables[0].Rows[0]["isBlackListed"]);
			billingHouseNumberTextBox.Text = customer.Tables[0].Rows[0]["houseNumber"].ToString();
			billingStreetNameTextBox.Text = customer.Tables[0].Rows[0]["streetName"].ToString();
			billingVillageTextBox.Text = customer.Tables[0].Rows[0]["village"].ToString();
			billingCityTextBox.Text = customer.Tables[0].Rows[0]["city"].ToString();
			billingPostcodeTextBox.Text = customer.Tables[0].Rows[0]["postcode"].ToString();
			if (phoneNumberAlreadyInputted == false)
			{
				phoneNumberTextBox.Text = customer.Tables[0].Rows[0]["phoneNumber"].ToString();
			}

			if (deliveryButton.BackColor == Color.Yellow) // deliveries need the address data grid view filling in
			{
				updateDataGridView();
			}
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

		private void addressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through addressesdatagridview to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				// get addressid
				addressID = Convert.ToInt32(addressesDataTable.Rows[selectedRowIndex]["addressID"]);
				DataRow selectedRow = addressesDataTable.Select($"addressID = '{addressID}'")[0];
				// update delivery address
				deliveryHouseNumberTextBox.Text = selectedRow["houseNumber"].ToString();
				deliveryStreetNameTextBox.Text = selectedRow["streetName"].ToString();
				deliveryVillageTextBox.Text = selectedRow["village"].ToString();
				deliveryCityTextBox.Text = selectedRow["city"].ToString();
				deliveryPostcodeTextBox.Text = selectedRow["postcode"].ToString();
				deliveryDeliveryChargeTextBox.Text = selectedRow["deliveryCharge"].ToString();
				addressDataGridView.ClearSelection(); // unselect row
			}
			else // unselect flop row
			{
				addressDataGridView.ClearSelection();
			}
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
				customerID = findCustomerID();
				if (hasCustomerBeenUsedInAddress()) // customer exists in addresstbl
				{
					MessageBox.Show("There is at least one address that is associated with this customer. Remove them through manager functions before deleting this customer", "Ordering System");
				}
				else if (hasCustomerBeenUsedInOrder()) // customer exists in an order
				{
					MessageBox.Show("There is at least one order that has been placed by this customer. Remove them through manager functions before deleting this customer", "Ordering System");
				}
				else
				{
					SqlCommand deleteCustomer = new SqlCommand("DELETE FROM CustomerTbl WHERE customerID = @CID", con);
					deleteCustomer.Parameters.AddWithValue("@CID", customerID);
					deleteCustomer.ExecuteNonQuery();
					MessageBox.Show("Customer deleted", "Ordering System");
					clearCustomerScreen();
				}
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
				addressID = findAddressID();
				if (hasAddressBeenUsedInOrder()) // exists in an order
				{
					MessageBox.Show("There is at least one order that uses this address. Remove them through manager functions before deleting this address", "Ordering System");
				}
				else
				{
					SqlCommand deleteAddress = new SqlCommand("DELETE FROM AddressTbl WHERE addressID = @AID", con);
					deleteAddress.Parameters.AddWithValue("@AID", addressID);
					deleteAddress.ExecuteNonQuery();
					MessageBox.Show("Address deleted", "Ordering System");
					clearAddressScreen();
					updateDataGridView();
				}
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
				Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text); // check if value is acc decimal
				if (Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text) < 0 || Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text) >= 100) // not within range
				{
					MessageBox.Show("Delivery charge not within range", "Ordering System");
					deliveryDeliveryChargeTextBox.Focus();
				}
			}
			catch // not decimal
			{
				MessageBox.Show("Delivery charge not a decimal", "Ordering System");
				deliveryDeliveryChargeTextBox.Focus();
			}
		}
	}
}
