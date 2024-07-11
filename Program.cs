using System.Data.SqlClient;

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
			var main_form = new MainLogin();
			main_form.Show();
			Application.Run();
		}
	}

	public struct Order
	{
		public string orderType;
		public int customerID;
		public int addressID;
		public DateOnly orderDate;
		public TimeOnly orderTime;
		public TimeOnly estimatedTime;
	}

	public struct OrderItem
	{
		public string itemID;
		public int quantity;
		public string size;
		public string memo;
		public decimal discount;
	}

	public class CustomerDetailsUpdateEventArgs : EventArgs
	{
		private string _phoneNumber;
		private string _orderType;
		private string _customerName;
		private string _houseNumber;
		private string _streetName;
		private string _postcode;
		private string _deliveryCharge;

		public CustomerDetailsUpdateEventArgs(string phoneNumber, string orderType, string customerName = "", string houseNumber = "", string streetName = "", string postcode = "", string deliveryCharge = "")
		{
			_phoneNumber = phoneNumber;
			_orderType = orderType;
			if (orderType == "Delivery")
			{
				_houseNumber = houseNumber;
				_streetName = streetName;
				_postcode = postcode;
				_deliveryCharge = deliveryCharge;
			}
			else if (orderType == "Collection")
			{
				_customerName = customerName;
			}
		}

		public string phoneNumber
		{
			get
			{
				return _phoneNumber;
			}
		}

		public string orderType
		{
			get
			{
				return _orderType;
			}
		}

		public string customerName
		{
			get
			{
				return _customerName;
			}
		}

		public string houseNumber
		{
			get
			{
				return _houseNumber;
			}
		}

		public string streetName
		{
			get
			{
				return _streetName;
			}
		}

		public string postcode
		{
			get
			{
				return _postcode;
			}
		}
		public string deliveryCharge
		{
			get
			{
				return deliveryCharge;
			}
		}
	}
}