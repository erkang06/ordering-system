using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
	public partial class MainMenu : Form
	{
		public static Order currentOrder = new Order();
		public static List<OrderItem> currentOrderItems = new List<OrderItem>();
		// the connection string to the database
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		DataSet customerDataSet = new DataSet(); // data row for customer
		DataSet addressDataSet = new DataSet();
		public MainMenu()
		{
			InitializeComponent();
		}

		private void getCustomer(int customerID) // get customer details from customerid
		{
			con.Open();
			SqlDataAdapter getCustomer = new SqlDataAdapter("SELECT * FROM CustomerTbl WHERE customerID = @CID", con);
			getCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			getCustomer.Fill(customerDataSet);
			con.Close();
		}

		private void getAddress(int addressID) // get customer details from customerid
		{
			con.Open();
			SqlDataAdapter getAddress = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE addressID = @AID", con);
			getAddress.SelectCommand.Parameters.AddWithValue("@AID", addressID);
			getAddress.Fill(addressDataSet);
			con.Close();
		}

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			deliveryChargePriceLabel.Enabled = true;
			deliveryButton.BackColor = Color.Yellow; // select delivery, unselect rest
			counterButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
			if (currentOrder.orderType != "Delivery") // if there hasnt been an address set
			{
				currentOrder.orderType = "Delivery";
				customerDetails_Click(sender, e);
			}
		}

		private void counterButton_Click(object sender, EventArgs e)
		{
			deliveryChargePriceLabel.Text = "0.00";
			totalPriceLabel.Text = subtotalPriceLabel.Text;
			deliveryChargePriceLabel.Enabled = false; // disables delivery charge
			counterButton.BackColor = Color.Yellow; // select counter, unselect rest
			deliveryButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
			if (currentOrder.orderType != "Counter") // if isnt already a counter
			{
				currentOrder.orderType = "Counter";
				customerDetailsLabel.Text = string.Empty;
			}
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			deliveryChargePriceLabel.Text = "0.00";
			totalPriceLabel.Text = subtotalPriceLabel.Text;
			deliveryChargePriceLabel.Enabled = false; // disables delivery charge
			collectionButton.BackColor = Color.Yellow; // select collection, unselect rest
			counterButton.BackColor = Color.Transparent;
			deliveryButton.BackColor = Color.Transparent;
			if (currentOrder.orderType == "Delivery") // take customer details from delivery and put them into collection
			{
				string phoneNumber = customerDataSet.Tables[0].Rows[0]["phoneNumber"].ToString().Trim();
				string customerName = customerDataSet.Tables[0].Rows[0]["customerName"].ToString().Trim();
				customerDetailsLabel.Text = $"{phoneNumber} - {customerName}";
				currentOrder.orderType = "Collection";
				currentOrder.addressID = -1;
			}
			else if (currentOrder.orderType != "Collection") // if there hasnt been a name set
			{
				currentOrder.orderType = "Collection";
				customerDetails_Click(sender, e);
			}
		}

		private void acceptOrderButton_Click(object sender, EventArgs e)
		{
			if (currentOrder.orderType != "Delivery")
			{
				if (acceptOrderButton.Text == "Accept Order" && viewOrdersButton.Text == "View Orders") // cant open both panels at once lmao
				{
					acceptOrderButton.Text = "Accept Payment";
					paymentPanel.BringToFront();
					paymentPanel.Visible = true;
				}
				else if (acceptOrderButton.Text == "Accept Payment") // order accepted
				{
					currentOrder.orderType = string.Empty; // unselect all order type buttons
					collectionButton.BackColor = Color.Transparent;
					counterButton.BackColor = Color.Transparent;
					deliveryButton.BackColor = Color.Transparent;
					acceptOrderButton.Text = "Accept Order";
					paymentPanel.SendToBack();
					paymentPanel.Visible = false;
				}
			}
			orderNumberLabel.Text = (Convert.ToInt32(orderNumberLabel.Text) + 1).ToString(); // increment order number
		}

		private void viewOrdersButton_Click(object sender, EventArgs e)
		{
			if (viewOrdersButton.Text == "View Orders" && acceptOrderButton.Text == "Accept Order") // cant open both panels at once lmao
			{
				viewOrdersButton.Text = "Cancel";
				viewOrdersPanel.BringToFront();
				viewOrdersPanel.Visible = true;
			}
			else if (viewOrdersButton.Text == "Cancel") // exit view orders mode
			{
				viewOrdersButton.Text = "View Orders";
				viewOrdersPanel.SendToBack();
				viewOrdersPanel.Visible = false;
			}
		}

		private void timer_Tick(object sender, EventArgs e) // the little time bit in the bottom right
		{
			timeLabel.Text = DateTime.Now.ToString("dd/mm/yy HH:mm:ss");
		}

		private void managerFunctionsButton_Click(object sender, EventArgs e)
		{
			ManagerFunctionsLogin obj = new ManagerFunctionsLogin();
			obj.Show();
			obj.TopMost = true;
		}

		private void customerDetails_Click(object sender, EventArgs e)
		{
			CustomerDetails obj = new CustomerDetails();
			obj.CustomerDetailsUpdate += new CustomerDetails.CustomerDetailsUpdateHandler(customerDetailsChanged); // basos update main form when anything in the customer details panel gets updated
			obj.Show();
			//obj.TopMost = true;
		}

		private void customerDetailsChanged(object sender, CustomerDetailsUpdateEventArgs e) // when stuff gets updated in the customer details panel
		{
			currentOrder.customerID = e.customerID;
			currentOrder.orderType = e.orderType;
			getCustomer(e.customerID);
			string phoneNumber = customerDataSet.Tables[0].Rows[0]["phoneNumber"].ToString().Trim();
			if (e.orderType == "Delivery")
			{
				currentOrder.addressID = e.addressID;
				deliveryButton_Click(sender, e);
				getAddress(e.addressID);
				string houseNumber = addressDataSet.Tables[0].Rows[0]["houseNumber"].ToString().Trim();
				string streetName = addressDataSet.Tables[0].Rows[0]["streetName"].ToString().Trim();
				string postcode = addressDataSet.Tables[0].Rows[0]["postcode"].ToString().Trim();
				decimal deliveryCharge = Convert.ToDecimal(addressDataSet.Tables[0].Rows[0]["deliveryCharge"]);
				customerDetailsLabel.Text = $"{phoneNumber} - {houseNumber} {streetName} {postcode}";
				deliveryChargePriceLabel.Text = deliveryCharge.ToString("0.00"); // edit delivery charge
				// add subtotal and delivery charge together
				totalPriceLabel.Text = (deliveryCharge + Convert.ToDecimal(subtotalPriceLabel.Text)).ToString("0.00");
			}
			else if (e.orderType == "Collection")
			{
				collectionButton_Click(sender, e);
				string customerName = customerDataSet.Tables[0].Rows[0]["customerName"].ToString().Trim();
				customerDetailsLabel.Text = $"{phoneNumber} - {customerName}";
			}
		}

		private void cancelOrderButton_Click(object sender, EventArgs e)
		{
			currentOrder = new Order();
			currentOrderItems.Clear();
			deliveryButton.BackColor = Color.Transparent;
			counterButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
		}
	}
}
