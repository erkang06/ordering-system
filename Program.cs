namespace ordering_system
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			// creates login as a dialog box
			Login obj = new Login("Login");
			if (obj.ShowDialog() == DialogResult.OK) // if password is correct
			{
				MainMenu objMenu = new MainMenu();
				objMenu.Show();
				//objMenu.TopMost = true;
				obj.Close();
				Application.Run();
			}
			else
			{
				Application.Exit();
			}
			obj.Dispose();
		}
	}

	public struct Order
	{
		public string orderType;
		public int customerID;
		public int addressID;
		public bool hasPaid;
	}

	// class that lets customer details be sent from customer details to main menu
	public class CustomerDetailsUpdateEventArgs : EventArgs
	{
		private int _customerID;
		private string _orderType;
		private int _addressID;

		public CustomerDetailsUpdateEventArgs(int customerID, string orderType, int addressID = -1)
		{
			_customerID = customerID;
			_orderType = orderType;
			_addressID = addressID;
		}

		public int customerID
		{
			get
			{
				return _customerID;
			}
		}

		public string orderType
		{
			get
			{
				return _orderType;
			}
		}

		public int addressID
		{
			get
			{
				return _addressID;
			}
		}
	}
}