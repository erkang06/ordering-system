using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordering_system
{
	public partial class CustomerDetails : Form
	{
		public delegate void CustomerDetailsUpdateHandler(object sender, CustomerDetailsUpdateEventArgs e);

		public event CustomerDetailsUpdateHandler CustomerDetailsUpdate;
		public CustomerDetails()
		{
			InitializeComponent();
		}

		private void acceptAddressButton_Click(object sender, EventArgs e)
		{
			if (MainMenu.orderType == "Delivery")
			{
				CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(phoneNumberTextBox.Text, "Delivery", houseNumber:deliveryHouseNumberTextBox.Text, streetName:deliveryStreetNameTextBox.Text, postcode:deliveryPostcodeTextBox.Text);
				CustomerDetailsUpdate(this, args);
			}
			else if (MainMenu.orderType == "Collection")
			{
				CustomerDetailsUpdateEventArgs args = new CustomerDetailsUpdateEventArgs(phoneNumberTextBox.Text, "Collection", customerName:customerNameTextBox.Text);
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
			MainMenu.orderType = "Delivery";
			deliveryButton.BackColor = Color.Yellow;
			collectionButton.BackColor = Color.Transparent;
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			MainMenu.orderType = "Collection";
			collectionButton.BackColor = Color.Yellow;
			deliveryButton.BackColor = Color.Transparent;
		}

		private void CustomerDetails_Load(object sender, EventArgs e) // presets whether order type is delivery or collection if form not opened by cust deets panel
		{
			if (MainMenu.orderType == "Delivery")
			{
				deliveryButton_Click(sender, e);
			}
			else if (MainMenu.orderType == "Collection")
			{
				collectionButton_Click(sender, e);
			}
		}
	}
}
