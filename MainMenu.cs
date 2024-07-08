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

		private void button1_Click(object sender, EventArgs e)
		{
			ManagerFunctionsLogin obj = new ManagerFunctionsLogin();
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
			counterButton.BackColor= Color.Transparent;
			deliveryButton.BackColor= Color.Transparent;
		}
	}
}
