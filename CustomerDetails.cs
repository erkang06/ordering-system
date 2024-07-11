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


		public CustomerDetails()
		{
			InitializeComponent();
		}

		private void acceptAddressButton_Click(object sender, EventArgs e)
		{
			MainMenu.con.Open();
			SqlCommand checkIfCustomerExists = new SqlCommand("SELECT COUNT(*) FROM CustomerTbl WHERE phoneNumber = @PN", MainMenu.con); // checks number of customers in database w/ same phone number
			checkIfCustomerExists.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
			int customerExists = (int)checkIfCustomerExists.ExecuteScalar();
			if (customerExists == 0) // if customer doesnt alr exist in database
			{
				SqlCommand addCustomerToDatabase = new SqlCommand("INSERT INTO CustomerTbl(customerName, phoneNumber, houseNumber, streetName, village, city, postcode) VALUES(@CN, @PN, @HN, @SN, @VL, @CT, @PC)", MainMenu.con); // add customer details to database
				addCustomerToDatabase.Parameters.AddWithValue("@CN", customerNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@HN", billingHouseNumberTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@SN", billingStreetNameTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@VL", billingVillageTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@CT", billingCityTextBox.Text);
				addCustomerToDatabase.Parameters.AddWithValue("@PC", billingPostcodeTextBox.Text);
				addCustomerToDatabase.ExecuteNonQuery();
			}
			if (deliveryButton.BackColor == Color.Yellow) // if its a delivery by the end
			{
				// check if delivery address is in database by finding customer id to search through addresstbl
				SqlCommand findcustomerID = new SqlCommand("SELECT CustomerID FROM CustomerTbl WHERE phoneNumber = @PN", MainMenu.con);
				findcustomerID.Parameters.AddWithValue("@PN", phoneNumberTextBox.Text);
				int customerID = (int)findcustomerID.ExecuteScalar();
				SqlCommand addAddressToDatabase = new SqlCommand("INSERT INTO AddressTbl(customerID, houseNumber, streetName, village, city, postcode, deliveryCharge) VALUES(@CID, @CN, @PN, @HN, @SN, @VL, @CT, @PC, @DC)", MainMenu.con); // add customer details to database
				addAddressToDatabase.Parameters.AddWithValue("@CID", customerID);
				addAddressToDatabase.Parameters.AddWithValue("@HN", deliveryHouseNumberTextBox.Text);
				addAddressToDatabase.Parameters.AddWithValue("@SN", deliveryStreetNameTextBox.Text);
				addAddressToDatabase.Parameters.AddWithValue("@VL", deliveryVillageTextBox.Text);
				addAddressToDatabase.Parameters.AddWithValue("@CT", deliveryCityTextBox.Text);
				addAddressToDatabase.Parameters.AddWithValue("@PC", deliveryPostcodeTextBox.Text);
				addAddressToDatabase.Parameters.AddWithValue("@DC", Convert.ToDecimal(deliveryDeliveryChargeTextBox.Text));
				addAddressToDatabase.ExecuteNonQuery();
				CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(phoneNumberTextBox.Text, "Delivery", houseNumber: deliveryHouseNumberTextBox.Text, streetName: deliveryStreetNameTextBox.Text, postcode: deliveryPostcodeTextBox.Text);
				CustomerDetailsUpdate(this, args);
			}
			else if (collectionButton.BackColor == Color.Yellow) // if its a collection by the end
			{
				CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(phoneNumberTextBox.Text, "Collection", customerName: customerNameTextBox.Text);
				CustomerDetailsUpdate(this, args);
			}
			this.Close();
		}

		private void cancelAddressButton_Click(object sender, EventArgs e)
		{
			this.Close();
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
			try
			{
				MessageBox.Show("slay");
				MainMenu.con.Open();
				MessageBox.Show("slay");
				SqlDataAdapter sda = new SqlDataAdapter(@$"SELECT * FROM Customer WHERE phoneNumber = @PN", MainMenu.con);
				MessageBox.Show("slay");
				sda.SelectCommand.Parameters.AddWithValue("@PN", SqlDbType.Text).Value = phoneNumberTextBox.Text;
				MessageBox.Show("slay");
				SqlCommandBuilder scb = new SqlCommandBuilder(sda);
				MessageBox.Show("slay");
				DataSet ds = new DataSet();
				MessageBox.Show("slay");
				sda.Fill(ds);
				MessageBox.Show("slay");
				deliveryAddressDataView.DataSource = ds.Tables[0];
				MessageBox.Show("slay");
				MainMenu.con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("flopped");
			}
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
	}
}
