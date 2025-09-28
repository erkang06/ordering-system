using ordering_system.Properties;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace ordering_system
{
	public partial class OrderSummary : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataTable ordersDataTable = new DataTable(); // full datatable compared to whats shown in datagridview
		Dictionary<int, DataTable> dailyOrderItemsDictionary = new Dictionary<int, DataTable>(); // keeps all orders by dailyordernumber
		int dailyOrderNumber = -1; // id of currently selected order in ordersdatagridview
		public OrderSummary()
		{
			InitializeComponent();
		}

		// weird functions

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

		private DataRow getCustomer(int customerID) // get customer details from customerid
		{
			SqlDataAdapter getCustomer = new SqlDataAdapter("SELECT * FROM CustomerTbl WHERE customerID = @CID", con);
			getCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			DataTable customerDataTable = new DataTable();
			getCustomer.Fill(customerDataTable);
			DataRow customerDataRow = customerDataTable.Rows[0];
			return customerDataRow;
		}

		private DataRow getAddress(int addressID) // get address from addressid
		{
			SqlDataAdapter getAddress = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE addressID = @AID", con);
			getAddress.SelectCommand.Parameters.AddWithValue("@AID", addressID);
			DataTable addressDataTable = new DataTable();
			getAddress.Fill(addressDataTable);
			DataRow addressDataRow = addressDataTable.Rows[0];
			return addressDataRow;
		}

		private DataTable getSetMealFoodItems(string setMealID)
		{
			SqlDataAdapter getSetMealFoodItems = new SqlDataAdapter("SELECT foodItemID, size, quantity FROM SetMealFoodItemTbl WHERE setMealID = @SMID ORDER BY foodItemID", con);
			getSetMealFoodItems.SelectCommand.Parameters.AddWithValue("@SMID", setMealID);
			DataTable setMealFoodItemsDataTable = new DataTable();
			getSetMealFoodItems.Fill(setMealFoodItemsDataTable);
			return setMealFoodItemsDataTable;
		}

		private string getFoodItemName(string foodItemID)
		{
			SqlCommand getFoodItemName = new SqlCommand("SELECT foodName FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			getFoodItemName.Parameters.AddWithValue("@FIID", foodItemID);
			string foodItemName = getFoodItemName.ExecuteScalar().ToString();
			return foodItemName;
		}

		private string getSetMealName(string setMealID)
		{
			SqlCommand getSetMealName = new SqlCommand("SELECT setMealName FROM SetMealTbl WHERE setMealID = @SMID", con);
			getSetMealName.Parameters.AddWithValue("@SMID", setMealID);
			string setMealName = getSetMealName.ExecuteScalar().ToString();
			return setMealName;
		}

		private void clearDisplayedOrder() // remove shown order and reset to default
		{
			dailyOrderNumber = -1;
			subtotalPriceLabel.Text = "0000.00";
			deliveryChargePriceLabel.Text = "00.00";
			deliveryChargePriceLabel.Enabled = true;
			totalPriceLabel.Text = "0000.00";
			phoneNumberFieldLabel.Text = string.Empty;
			customerNameFieldLabel.Text = string.Empty;
			houseNumberFieldLabel.Text = string.Empty;
			streetNameFieldLabel.Text = string.Empty;
			villageFieldLabel.Text = string.Empty;
			cityFieldLabel.Text = string.Empty;
			postcodeFieldLabel.Text = string.Empty;
			orderTypeFieldLabel.Text = string.Empty;
			singleOrderDataGridView.DataSource = null;
		}

		// stuff on the form

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

		private void orderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			clearDisplayedOrder();
			// find clicked row of table in order to search through orderdictionary to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				dailyOrderNumber = Convert.ToInt32(orderDataGridView.Rows[selectedRowIndex].Cells["dailyOrderNumber"].Value);
				DataRow order = ordersDataTable.Select($"dailyOrderNumber = '{dailyOrderNumber}'")[0];
				// fill in order type
				orderTypeFieldLabel.Text = order["orderType"].ToString();
				// fill in top fields for collections and deliveries
				if (order["orderType"].ToString() != "Counter")
				{
					DataRow customerDataRow = getCustomer(Convert.ToInt32(order["customerID"]));
					phoneNumberFieldLabel.Text = customerDataRow["phoneNumber"].ToString();
					// get name or address
					if (order["orderType"].ToString() == "Collection")
					{
						customerNameFieldLabel.Text = customerDataRow["customerName"].ToString();
					}
					else // delivery
					{
						DataRow addressDataRow = getAddress(Convert.ToInt32(order["addressID"]));
						houseNumberFieldLabel.Text = addressDataRow["houseNumber"].ToString();
						streetNameFieldLabel.Text = addressDataRow["streetName"].ToString();
						villageFieldLabel.Text = addressDataRow["village"].ToString();
						cityFieldLabel.Text = addressDataRow["city"].ToString();
						postcodeFieldLabel.Text = addressDataRow["postcode"].ToString();
					}
				}
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
			}
			con.Close();
		}

		// printing

		private void printOrderSummaryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			printDocument = new PrintDocument();
			printDocument.PrintPage += (sender, e) => printOrderSummary_PrintPage(sender, e);
			printPreviewDialog.Document = printDocument;
			printPreviewDialog.ShowDialog();
			printDocument.Print();
			con.Close();
		}

		private void printOrderSummary_PrintPage(object sender, PrintPageEventArgs e) // ORDER SUMMARY
		{
			int ticketPaperSizeWidth = Convert.ToInt32(Resources.ticketPaperSizeWidth);
			string subTotal, deliveryCharge, total;
			int ypos = 10;
			// get fonts
			Font ticketHeaderFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketHeaderFontSize));
			Font ticketItemFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketItemFontSize));
			Font ticketSetMealFoodItemFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketSetMealFoodItemFontSize));
			Font ticketSmallFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketSmallFontSize));
			// get total number of orders
			int numberOfCounters = ordersDataTable.Select(@"orderType = 'Counter'").Length;
			int numberOfDeliveries = ordersDataTable.Select(@"orderType = 'Delivery'").Length;
			int numberOfCollections = ordersDataTable.Select(@"orderType = 'Collection'").Length;
			int numberOfOrders = ordersDataTable.Rows.Count;
			// add up total profits
			// https://stackoverflow.com/a/11989142
			object subTotalObject;
			subTotalObject = ordersDataTable.Compute("Sum(subTotal)", "");
			subTotal = subTotalObject.ToString();
			if (subTotal == "0")
			{
				subTotal = "0.00";
			}
			object deliveryChargeObject;
			deliveryChargeObject = ordersDataTable.Compute("Sum(deliveryCharge)", "");
			deliveryCharge = deliveryChargeObject.ToString();
			if (deliveryCharge == "0")
			{
				deliveryCharge = "0.00";
			}
			object totalObject;
			totalObject = ordersDataTable.Compute("Sum(total)", "");
			total = totalObject.ToString();
			if (total == "0")
			{
				total = "0.00";
			}

			// date
			string dateString = datePicker.Value.Date.ToString();
			e.Graphics.DrawString(dateString, ticketHeaderFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketHeaderFont.Size + 10;
			// break
			e.Graphics.DrawString("*************************************", new Font("Arial", 14), Brushes.Black, new Point(10, ypos));
			ypos += 20;
			// number of orders - each ordertype as well
			e.Graphics.DrawString("Number of Orders: " + numberOfOrders.ToString(), ticketItemFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketItemFont.Size + 10;
			e.Graphics.DrawString("Number of Counters: " + numberOfCounters.ToString(), ticketSetMealFoodItemFont, Brushes.Black, new Point(30, ypos));
			ypos += (int)ticketSetMealFoodItemFont.Size + 10;
			e.Graphics.DrawString("Number of Deliveries: " + numberOfDeliveries.ToString(), ticketSetMealFoodItemFont, Brushes.Black, new Point(30, ypos));
			ypos += (int)ticketSetMealFoodItemFont.Size + 10;
			e.Graphics.DrawString("Number of Collections: " + numberOfCollections.ToString(), ticketSetMealFoodItemFont, Brushes.Black, new Point(30, ypos));
			ypos += (int)ticketSetMealFoodItemFont.Size + 10;
			// break
			e.Graphics.DrawString("*************************************", new Font("Arial", 14), Brushes.Black, new Point(10, ypos));
			ypos += 20;
			// profits by type
			e.Graphics.DrawString("Sub Total: " + subTotal, ticketItemFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketItemFont.Size + 10;
			e.Graphics.DrawString("Delivery Charge: " + deliveryCharge, ticketItemFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketItemFont.Size + 10;
			e.Graphics.DrawString("Total: " + total, ticketItemFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketItemFont.Size + 10;
			printDocument.DefaultPageSettings.PaperSize = new PaperSize("till", ticketPaperSizeWidth, ypos);
		}

		private void printTicketButton_Click(object sender, EventArgs e)
		{
			con.Open();
			Button ticketButton = (Button)sender;
			if (dailyOrderNumber != -1) // if order acc selected
			{
				printDocument = new PrintDocument();
				if (ticketButton.Text == "Print Kitchen Ticket")
				{
					printDocument.PrintPage += (sender, e) => printTicket_PrintPage(sender, e, "Kitchen");
				}
				else // print customer ticket
				{
					printDocument.PrintPage += (sender, e) => printTicket_PrintPage(sender, e, "Customer");
				}
				printPreviewDialog.Document = printDocument;
				printPreviewDialog.ShowDialog();
				printDocument.Print();
			}
			else
			{
				MessageBox.Show("Order not selected");
			}
			con.Close();
		}

		private void printTicket_PrintPage(object sender, PrintPageEventArgs e, string ticketType)
		{
			// therell only be one daily order number is unique per day lmao
			DataRow order = ordersDataTable.Select($"dailyOrderNumber = '{dailyOrderNumber}'")[0];
			int ypos = 10;
			// get fonts and sizes
			Font ticketHeaderFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketHeaderFontSize));
			Font ticketItemFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketItemFontSize));
			Font ticketSetMealFoodItemFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketSetMealFoodItemFontSize));
			Font ticketSmallFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketSmallFontSize));
			int ticketPaperSizeWidth = Convert.ToInt32(Resources.ticketPaperSizeWidth);
			// get phone number and order type
			// align ordertype to right, https://stackoverflow.com/q/50299682
			int orderTypeWidth = (int)e.Graphics.MeasureString(order["orderType"].ToString(), ticketSmallFont).Width;
			e.Graphics.DrawString(order["orderType"].ToString(), ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - orderTypeWidth, ypos));
			if (order["orderType"].ToString() != "Counter" && ticketType == "Customer") // kitchen orders dont need addresses and customer names
			{
				DataRow customerDataRow = getCustomer(Convert.ToInt32(order["customerID"]));
				e.Graphics.DrawString(customerDataRow["phoneNumber"].ToString(), ticketHeaderFont, Brushes.Black, new Point(10, ypos));
				ypos += (int)ticketHeaderFont.Size + 10;
				// get name or address
				if (order["orderType"].ToString() == "Collection")
				{
					string customerName = customerDataRow["customerName"].ToString();
					e.Graphics.DrawString(customerName, ticketHeaderFont, Brushes.Black, new Point(10, ypos));
					ypos += (int)ticketHeaderFont.Size + 10;
				}
				else if (order["orderType"].ToString() == "Delivery")
				{
					DataRow addressDataRow = getAddress(Convert.ToInt32(order["addressID"]));
					for (int i = 2; i < 7; i++) // from house number to postcode
					{
						if (addressDataRow[i].ToString() != "")
						{
							e.Graphics.DrawString(addressDataRow[i].ToString(), ticketHeaderFont, Brushes.Black, new Point(10, ypos));
							ypos += (int)ticketHeaderFont.Size + 10;
						}
					}
				}
			}

			// get order date and time
			string orderDateTimeString = Convert.ToDateTime(order["orderDate"]).ToString("dd/MM/yyyy") + " " + order["orderTime"].ToString();
			e.Graphics.DrawString(orderDateTimeString, ticketSmallFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketSmallFont.Size + 5;
			// break
			e.Graphics.DrawString("*************************************", new Font("Arial", 14), Brushes.Black, new Point(10, ypos));
			ypos += 20;
			// get order items
			foreach (DataRow runningOrderRow in dailyOrderItemsDictionary[dailyOrderNumber].Rows)
			{
				e.Graphics.DrawString(runningOrderRow["quantity"].ToString(), ticketItemFont, Brushes.Black, new Point(10, ypos));
				// item name
				string itemNameSize = runningOrderRow["itemName"].ToString();
				if (runningOrderRow["size"].ToString() != "") // if item has size add to end of item name
				{
					itemNameSize += " (" + runningOrderRow["size"].ToString()[0] + ")";
				}
				// fit within rectangle in case of overflow
				SizeF itemNameSizeSizeF = e.Graphics.MeasureString(itemNameSize, ticketItemFont, 300);
				e.Graphics.DrawString(itemNameSize, ticketItemFont, Brushes.Black, new RectangleF(new Point(30, ypos), itemNameSizeSizeF));
				// price
				int priceWidth = (int)e.Graphics.MeasureString(runningOrderRow["price"].ToString(), ticketSmallFont).Width;
				e.Graphics.DrawString(runningOrderRow["price"].ToString(), ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - priceWidth, ypos));
				ypos += (int)itemNameSizeSizeF.Height + 5;
				if (runningOrderRow["memo"].ToString() != "") // if theres a memo
				{
					string memo = runningOrderRow["memo"].ToString();
					SizeF memoSizeF = e.Graphics.MeasureString(memo, ticketSmallFont, 250);
					e.Graphics.DrawString(memo, ticketSmallFont, Brushes.Black, new RectangleF(new Point(80, ypos), memoSizeF));
					ypos += (int)memoSizeF.Height + 5;
				}

				if (runningOrderRow["itemType"].ToString() == "setMeal") // set meal needs all items shown
				{
					DataTable setMealFoodItemsDataTable = getSetMealFoodItems(runningOrderRow["itemID"].ToString());
					foreach (DataRow setmealFoodItem in setMealFoodItemsDataTable.Rows)
					{
						e.Graphics.DrawString(setmealFoodItem["quantity"].ToString(), ticketItemFont, Brushes.Black, new Point(50, ypos));
						// get item name from id
						string setMealFoodItemName = getFoodItemName(setmealFoodItem["foodItemID"].ToString());
						// combine name and size
						string setMealFoodItemItemNameSize = setMealFoodItemName + " (" + setmealFoodItem["size"].ToString()[0] + ")";
						// fit within rectangle in case of overflow
						SizeF setMealFoodItemItemNameSizeSizeF = e.Graphics.MeasureString(setMealFoodItemItemNameSize, ticketSetMealFoodItemFont, 250);
						e.Graphics.DrawString(setMealFoodItemItemNameSize, ticketSetMealFoodItemFont, Brushes.Black, new RectangleF(new Point(90, ypos), setMealFoodItemItemNameSizeSizeF));
						ypos += (int)setMealFoodItemItemNameSizeSizeF.Height + 5;
					}
				}
			}
			// break
			e.Graphics.DrawString("*************************************", new Font("Arial", 14), Brushes.Black, new Point(10, ypos));
			ypos += 20;
			// subtotal
			e.Graphics.DrawString("Subtotal:", ticketSmallFont, Brushes.Black, new Point(10, ypos));
			int subtotalWidth = (int)e.Graphics.MeasureString(subtotalPriceLabel.Text, ticketSmallFont).Width;
			e.Graphics.DrawString(subtotalPriceLabel.Text, ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - subtotalWidth, ypos));
			ypos += (int)ticketHeaderFont.Size + 5;
			// delivery charge if delivery
			if (order["orderType"].ToString() == "Delivery")
			{
				e.Graphics.DrawString("Delivery:", ticketSmallFont, Brushes.Black, new Point(10, ypos));
				int deliveryWidth = (int)e.Graphics.MeasureString(deliveryChargePriceLabel.Text, ticketSmallFont).Width;
				e.Graphics.DrawString(deliveryChargePriceLabel.Text, ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - deliveryWidth, ypos));
				ypos += (int)ticketHeaderFont.Size + 5;
			}
			// total
			e.Graphics.DrawString("Total:", ticketHeaderFont, Brushes.Black, new Point(10, ypos));
			int totalWidth = (int)e.Graphics.MeasureString(totalPriceLabel.Text, ticketHeaderFont).Width;
			e.Graphics.DrawString(totalPriceLabel.Text, ticketHeaderFont, Brushes.Black, new Point(ticketPaperSizeWidth - totalWidth, ypos));
			ypos += (int)ticketHeaderFont.Size + 20;
			// get estimated time
			e.Graphics.DrawString("Estimated Time:", ticketHeaderFont, Brushes.Black, new Point(10, ypos));
			string estimatedTime = TimeSpan.Parse(order["estimatedTime"].ToString()).ToString(@"hh\:mm");
			int estimatedTimeWidth = (int)e.Graphics.MeasureString(estimatedTime, ticketHeaderFont).Width;
			e.Graphics.DrawString(estimatedTime, ticketHeaderFont, Brushes.Black, new Point(ticketPaperSizeWidth - estimatedTimeWidth, ypos));
			ypos += (int)ticketHeaderFont.Size + 20;
			printDocument.DefaultPageSettings.PaperSize = new PaperSize("till", ticketPaperSizeWidth, ypos);
		}
	}
}
