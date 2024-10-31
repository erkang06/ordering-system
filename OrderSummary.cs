using ordering_system.Properties;
using System.Data;
using System.Data.SqlClient;

namespace ordering_system
{
	public partial class OrderSummary : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataTable ordersDataTable = new DataTable(); // full datatable compared to whats shown in datagridview
		Dictionary<int, DataTable> dailyOrderItemsDictionary = new Dictionary<int, DataTable>(); // keeps all orders by dailyordernumber
		DataTable singleOrderDataTable = new DataTable();
		int orderID, dailyOrderNumber; // id of currently selected order in ordersdatagridview
		public OrderSummary()
		{
			InitializeComponent();
		}

		// weird sql functions

		private decimal getPriceOfFoodItem(string foodItemID, string size) // get price from id and size
		{
			// get table parameter
			string foodItemParameter = "largeItemPrice";
			if (size == "S")
			{
				foodItemParameter = "smallItemPrice";
			}

			SqlCommand getPriceOfFoodItem = new SqlCommand($"SELECT {foodItemParameter} FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			getPriceOfFoodItem.Parameters.AddWithValue("@FIID", foodItemID);
			decimal price = (decimal)getPriceOfFoodItem.ExecuteScalar();
			return price;
		}

		private decimal getPriceOfSetMeal(string itemID)
		{
			SqlCommand getPriceOfSetMeal = new SqlCommand($"SELECT price FROM SetMealTbl WHERE setMealID = @SMID", con);
			getPriceOfSetMeal.Parameters.AddWithValue("@SMID", itemID);
			decimal price = (decimal)getPriceOfSetMeal.ExecuteScalar();
			return price;
		}

		private decimal getDeliveryChargeOfAddress(int addressID)
		{
			SqlCommand getDeliveryChargeOfAddress = new SqlCommand($"SELECT deliveryCharge FROM AddressTbl WHERE addressID = @AID", con);
			getDeliveryChargeOfAddress.Parameters.AddWithValue("@AID", addressID);
			decimal deliveryCharge = (decimal)getDeliveryChargeOfAddress.ExecuteScalar();
			return deliveryCharge;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OrderSummary_Load(object sender, EventArgs e)
		{
			datePicker.Value = DateTime.Now;
		}

		private void datePicker_ValueChanged(object sender, EventArgs e)
		{
			con.Open();
			// get orders for the day
			ordersDataTable = new DataTable(); // clear prev
			DateTime date = datePicker.Value.Date;
			SqlDataAdapter getOrdersByDate = new SqlDataAdapter("SELECT * FROM OrderTbl WHERE orderDate = @OD ORDER BY orderTime", con);
			getOrdersByDate.SelectCommand.Parameters.AddWithValue("@OD", date);
			getOrdersByDate.Fill(ordersDataTable);
			ordersDataTable.Columns.Add("totalPrice", typeof(decimal)); // add price onto table
																														 // get order items for the day
			dailyOrderItemsDictionary.Clear(); // clear prev
			SqlDataAdapter getOrderItemsByDate = new SqlDataAdapter("SELECT * FROM OrderItemTbl WHERE orderID = @OID", con);
			getOrderItemsByDate.SelectCommand.Parameters.Add("@OID", SqlDbType.Int);
			DataTable orderItemsDataTable = new DataTable(); // only needs to be temp since im using a dictionary
			for (int i = 0; i < ordersDataTable.Rows.Count; i++) // get order items per order and get total cost
			{
				// get order items in an order
				DataRow order = ordersDataTable.Rows[i];
				orderItemsDataTable = new DataTable();
				int orderID = Convert.ToInt32(order["orderID"]);
				int dailyOrderNumber = Convert.ToInt32(order["dailyOrderNumber"]);
				getOrderItemsByDate.SelectCommand.Parameters["@OID"].Value = orderID;
				getOrderItemsByDate.Fill(orderItemsDataTable);
				orderItemsDataTable.Columns.Add("price", typeof(decimal)); // add price onto table 
				// get price of each item in order
				decimal totalPrice = 0;
				for (int j = 0; j < orderItemsDataTable.Rows.Count; j++) // get cost of each item
				{
					DataRow orderItem = orderItemsDataTable.Rows[j];
					string itemID = orderItem["itemID"].ToString();
					string itemType = orderItem["itemType"].ToString();
					decimal price;
					if (itemType == "foodItem")
					{
						price = getPriceOfFoodItem(itemID, orderItem["size"].ToString()) + Convert.ToDecimal(orderItem["discount"]);
					}
					else // set meal
					{
						price = getPriceOfSetMeal(itemID) + Convert.ToDecimal(orderItem["discount"]);
					}
					orderItemsDataTable.Rows[j]["price"] = totalPrice;
					totalPrice += price;
				}
				// add to dictionary and table
				dailyOrderItemsDictionary.Add(dailyOrderNumber, orderItemsDataTable);
				// add delivery charge if is a delivery
				if (order["orderType"].ToString() == "Delivery")
				{
					int addressID = Convert.ToInt32(order["addressID"]);
					totalPrice += getDeliveryChargeOfAddress(addressID);
				}
				ordersDataTable.Rows[i]["totalPrice"] = totalPrice;
			}
			// fill in orders datagridview
			DataView ordersDataViewByDate = new DataView(ordersDataTable);
			orderDataGridView.DataSource = ordersDataViewByDate.ToTable(true, "dailyOrderNumber", "orderType", "orderTime", "hasPaid", "totalPrice");
			orderDataGridView.Columns["dailyOrderNumber"].Width = 20;
			orderDataGridView.ClearSelection();
			con.Close();
		}

		private void ordersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through orderdictionary to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				dailyOrderNumber = Convert.ToInt32(orderDataGridView.Rows[selectedRowIndex].Cells["dailyOrderNumber"].Value);
				// fill in price fields
			}
			con.Close();
		}
	}
}
