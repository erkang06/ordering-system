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
	}
}
