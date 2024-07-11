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
			if (deliveryButton.BackColor == Color.Yellow) // if its a delivery by the end
			{
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
				sda.SelectCommand.Parameters.AddWithValue("@PN",SqlDbType.Text).Value = phoneNumberTextBox.Text;
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
	}
}
