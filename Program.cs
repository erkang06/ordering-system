using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
				return _customerID;
			}
		}
	}

	// class that lets ordertype be sent from main menu to customer details
	public class CustomerDetailsOrderTypeEventArgs : EventArgs
	{
		public string _orderType;

		public CustomerDetailsOrderTypeEventArgs(string orderType)
		{
			_orderType = orderType;
		}

		public string orderType
		{
			get
			{
				return _orderType;
			}
		}
	}
}