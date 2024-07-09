namespace ordering_system
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void customerDetailsLabel_Click(object sender, EventArgs e)
		{
			CustomerDetails obj = new CustomerDetails();
			obj.Show();
			obj.TopMost = true;
		}

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			deliveryButton.BackColor = Color.Yellow;
			counterButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
		}

		private void counterButton_Click(object sender, EventArgs e)
		{
			counterButton.BackColor = Color.Yellow;
			deliveryButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			collectionButton.BackColor = Color.Yellow;
			counterButton.BackColor = Color.Transparent;
			deliveryButton.BackColor = Color.Transparent;
		}

		private void acceptOrderButton_Click(object sender, EventArgs e)
		{
			if (acceptOrderButton.Text == "Accept Order" && viewOrdersButton.Text == "View Orders") // cant open both panels at once lmao
			{
				acceptOrderButton.Text = "Accept Payment";
				paymentPanel.BringToFront();
				paymentPanel.Visible = true;
			}
			else if (acceptOrderButton.Text == "Accept Payment")
			{
				acceptOrderButton.Text = "Accept Order";
				paymentPanel.SendToBack();
				paymentPanel.Visible = false;
			}
		}

		private void viewOrdersButton_Click(object sender, EventArgs e)
		{
			if (viewOrdersButton.Text == "View Orders" && acceptOrderButton.Text == "Accept Order")
			{
				viewOrdersButton.Text = "Cancel";
				viewOrdersPanel.BringToFront();
				viewOrdersPanel.Visible = true;
			}
			else if (viewOrdersButton.Text == "Cancel")
			{
				viewOrdersButton.Text = "View Orders";
				viewOrdersPanel.SendToBack();
				viewOrdersPanel.Visible = false;
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			timeLabel.Text = DateTime.Now.ToString("dd/mm/yy HH:mm:ss");
		}

		private void managerFunctionsButton_Click(object sender, EventArgs e)
		{
			ManagerFunctionsLogin obj = new ManagerFunctionsLogin();
			obj.Show();
			obj.TopMost = true;
		}
	}
}
