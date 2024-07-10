using System.Data.SqlClient;

namespace ordering_system
{
	public partial class MainMenu : Form
	{
		public static Order currentOrder = new Order();
		public static List<OrderItem> currentOrderItems = new List<OrderItem>();
		public static SqlConnection con = new SqlConnection(@"Data Source=""C:\Users\benny\Documents\CS\NEA\ordering system\ordering system.accdb""");
		public MainMenu()
		{
			InitializeComponent();
		}

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			if (currentOrder.orderType == string.Empty || currentOrder.orderType == "Counter") // if there hasnt been an address set
			{
				currentOrder.orderType = "Delivery";
				customerDetails_Click(sender, e);
			}
			else
			{
				currentOrder.orderType = "Delivery";
			}
			deliveryButton.BackColor = Color.Yellow; // select delivery, unselect rest
			counterButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
		}

		private void counterButton_Click(object sender, EventArgs e)
		{
			currentOrder.orderType = "Counter";
			customerDetailsLabel.Text = string.Empty;
			counterButton.BackColor = Color.Yellow; // select counter, unselect rest
			deliveryButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			if (currentOrder.orderType == string.Empty || currentOrder.orderType == "Counter") // if there hasnt been a name set
			{
				currentOrder.orderType = "Collection";
				customerDetails_Click(sender, e);
			}
			else
			{
				currentOrder.orderType = "Collection";
			}
			collectionButton.BackColor = Color.Yellow; // select collection, unselect rest
			counterButton.BackColor = Color.Transparent;
			deliveryButton.BackColor = Color.Transparent;
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
			obj.TopMost = true;
		}

		private void customerDetailsChanged(object sender, CustomerDetailsUpdateEventArgs e) // when stuff gets updated in the customer details panel
		{
			currentOrder.orderType = e.orderType; // just in case theyre different yk
			if (e.orderType == "Delivery")
			{
				deliveryButton_Click(sender, e);
				customerDetailsLabel.Text = $"{e.phoneNumber} {e.houseNumber} {e.streetName} {e.postcode}";
			}
			else if (e.orderType == "Collection")
			{
				collectionButton_Click(sender, e);
				customerDetailsLabel.Text = $"{e.phoneNumber} {e.customerName}";
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
