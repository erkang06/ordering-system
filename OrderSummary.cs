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

		private string getNameOfFoodItem(string foodItemID)
		{
			SqlCommand getNameOfFoodItem = new SqlCommand($"SELECT foodName FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			getNameOfFoodItem.Parameters.AddWithValue("@FIID", foodItemID);
			string itemName = getNameOfFoodItem.ExecuteScalar().ToString();
			return itemName;
		}

		private decimal getPriceOfSetMeal(string setMealID)
		{
			SqlCommand getPriceOfSetMeal = new SqlCommand($"SELECT price FROM SetMealTbl WHERE setMealID = @SMID", con);
			getPriceOfSetMeal.Parameters.AddWithValue("@SMID", setMealID);
			decimal price = (decimal)getPriceOfSetMeal.ExecuteScalar();
			return price;
		}

		private string getNameOfSetMeal(string setMealID)
		{
			SqlCommand getNameOfSetMeal = new SqlCommand($"SELECT setMealName FROM SetMealTbl WHERE setMealID = @SMID", con);
			getNameOfSetMeal.Parameters.AddWithValue("@SMID", setMealID);
			string setMealName = getNameOfSetMeal.ExecuteScalar().ToString();
			return setMealName;
		}

		private decimal getDeliveryChargeOfAddress(int addressID)
		{
			SqlCommand getDeliveryChargeOfAddress = new SqlCommand($"SELECT deliveryCharge FROM AddressTbl WHERE addressID = @AID", con);
			getDeliveryChargeOfAddress.Parameters.AddWithValue("@AID", addressID);
			decimal deliveryCharge = (decimal)getDeliveryChargeOfAddress.ExecuteScalar();
			return deliveryCharge;
		}

		private void clearDisplayedOrder() // remove shown order and reset to default
		{
			orderID = -1;
			dailyOrderNumber = -1;
			subtotalPriceLabel.Text = "0000.00";
			deliveryChargePriceLabel.Text = "00.00";
			deliveryChargePriceLabel.Enabled = true;
			totalPriceLabel.Text = "0000.00";
			singleOrderDataGridView.DataSource = null;
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
			clearDisplayedOrder();
			// get orders for the day
			ordersDataTable = new DataTable(); // clear prev
			DateTime date = datePicker.Value.Date;
			SqlDataAdapter getOrdersByDate = new SqlDataAdapter("SELECT * FROM OrderTbl WHERE orderDate = @OD ORDER BY orderTime", con);
			getOrdersByDate.SelectCommand.Parameters.AddWithValue("@OD", date);
			getOrdersByDate.Fill(ordersDataTable);
			// add subtotal and delivery and total into table
			ordersDataTable.Columns.Add("subTotal", typeof(decimal));
			ordersDataTable.Columns.Add("deliveryCharge", typeof(decimal));
			ordersDataTable.Columns.Add("total", typeof(decimal));
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
				orderItemsDataTable.Columns.Add("itemName", typeof(string));
				orderItemsDataTable.Columns.Add("price", typeof(decimal)); // add price onto table 
				// get price of each item in order
				decimal subTotal = 0;
				for (int j = 0; j < orderItemsDataTable.Rows.Count; j++) // get cost and name of each item
				{
					DataRow orderItem = orderItemsDataTable.Rows[j];
					string itemID = orderItem["itemID"].ToString();
					string itemType = orderItem["itemType"].ToString();
					decimal price;
					string itemName;
					if (itemType == "foodItem")
					{
						price = (getPriceOfFoodItem(itemID, orderItem["size"].ToString()) + Convert.ToDecimal(orderItem["discount"])) * Convert.ToInt32(orderItem["quantity"]);
						itemName = getNameOfFoodItem(itemID);
					}
					else // set meal
					{
						price = (getPriceOfSetMeal(itemID) + Convert.ToDecimal(orderItem["discount"])) * Convert.ToInt32(orderItem["quantity"]);
						itemName = getNameOfSetMeal(itemID);
					}
					orderItemsDataTable.Rows[j]["price"] = price;
					orderItemsDataTable.Rows[j]["itemName"] = itemName;
					subTotal += price;
				}
				// add to dictionary and table
				dailyOrderItemsDictionary.Add(dailyOrderNumber, orderItemsDataTable);
				ordersDataTable.Rows[i]["subTotal"] = subTotal;
				// get delivery charge if is a delivery and add it to total
				if (order["orderType"].ToString() == "Delivery")
				{
					int addressID = Convert.ToInt32(order["addressID"]);
					decimal deliveryCharge = getDeliveryChargeOfAddress(addressID);
					ordersDataTable.Rows[i]["deliveryCharge"] = deliveryCharge;
					ordersDataTable.Rows[i]["total"] = deliveryCharge + subTotal;
				}
				else // just make total the subtotal
				{
					ordersDataTable.Rows[i]["total"] = subTotal;
				}
			}
			// fill in orders datagridview
			DataView ordersDataViewByDate = new DataView(ordersDataTable);
			orderDataGridView.DataSource = ordersDataViewByDate.ToTable(true, "dailyOrderNumber", "orderType", "orderTime", "hasPaid", "total");
			orderDataGridView.Columns["dailyOrderNumber"].Width = 50;
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
				// theres always only 1 order since dailyordernumber is unique per day
				DataRow order = ordersDataTable.Select($"dailyOrderNumber = '{dailyOrderNumber}'")[0];
				orderID = Convert.ToInt32(order["orderID"]);
				// fill in price fields
				subtotalPriceLabel.Text = order["subTotal"].ToString();
				// get delivery charge else set label to 0
				if (order["orderType"].ToString() == "Delivery")
				{
					deliveryChargePriceLabel.Text = order["deliveryCharge"].ToString();
					deliveryChargePriceLabel.Enabled = true;
				}
				else // just make total the subtotal
				{
					deliveryChargePriceLabel.Text = "0.00";
					deliveryChargePriceLabel.Enabled = false;
				}
				totalPriceLabel.Text = order["total"].ToString();
			}
			// fill in single order datagridview
			DataView singleOrderDataView = new DataView(dailyOrderItemsDictionary[dailyOrderNumber]);
			// for some reason u have to clear bf refilling datagridview for the widths to work right lmao
			singleOrderDataGridView.DataSource = null;
			singleOrderDataGridView.DataSource = singleOrderDataView.ToTable(true, "itemID", "quantity", "itemName", "size", "memo", "price", "orderItemID");
			singleOrderDataGridView.Columns["itemID"].Width = 50;
			singleOrderDataGridView.Columns["quantity"].Width = 50;
			singleOrderDataGridView.Columns["size"].Width = 20;
			singleOrderDataGridView.Columns["price"].Width = 50;
			singleOrderDataGridView.Columns["orderItemID"].Visible = false;
			con.Close();
		}
	}
}
