using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ordering_system.Properties;
using System.Security.Policy;

namespace ordering_system
{
	public partial class MainMenu : Form
	{
		Order currentOrder = new Order();
		DataTable runningOrderDataTable = new DataTable(); // running order
																											 // the connection string to the database
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataRow customerDataRow; // data row for customer
		DataTable ordersDataTable;
		DataTable categoriesDataTable;
		DataTable itemsDataTable;
		string categoryName; // name of currently selected category
		Button[] categoryButtonArray = new Button[24]; // cant have any more since its hardcoded
		Button[] itemButtonArray = new Button[40];
		int viewOrdersSelectedOrderID = -1;
		public MainMenu()
		{
			InitializeComponent();
		}

		// weird functions that rnt in 1 specific section

		private void getCustomer(int customerID) // get customer details from customerid
		{
			SqlDataAdapter getCustomer = new SqlDataAdapter("SELECT * FROM CustomerTbl WHERE customerID = @CID", con);
			getCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
			DataTable customerDataTable = new DataTable();
			getCustomer.Fill(customerDataTable);
			customerDataRow = customerDataTable.Rows[0];
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

		private int doesItemExist(string itemID, string size) // returns index of food item in running order if exists, else returns -1
		{
			DataRow[] item = runningOrderDataTable.Select($"itemID = '{itemID}' AND size = '{size}' AND memo is null"); // blank memo cuz its difficult to deal w/
			if (item.Length > 0) // theres only 1 cuz its a primary key innit
			{
				int index = runningOrderDataTable.Rows.IndexOf(item[0]);
				return index;
			}
			return -1;
		}

		private DataTable getSetMealFoodItems(string setMealID)
		{
			SqlDataAdapter getSetMealFoodItems = new SqlDataAdapter("SELECT foodItemID, size, quantity FROM SetMealFoodItemTbl WHERE setMealID = @SMID ORDER BY foodItemID", con);
			getSetMealFoodItems.SelectCommand.Parameters.AddWithValue("@SMID", setMealID);
			DataTable setMealFoodItemsDataTable = new DataTable();
			getSetMealFoodItems.Fill(setMealFoodItemsDataTable);
			return setMealFoodItemsDataTable;
		}

		private string getDefaultItemSize(string foodItemID)
		{
			SqlCommand getDefaultItemSize = new SqlCommand("SELECT defaultToLargePrice FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			getDefaultItemSize.Parameters.AddWithValue("@FIID", foodItemID);
			bool defaultToLargePrice = Convert.ToBoolean(getDefaultItemSize.ExecuteScalar());
			if (defaultToLargePrice)
			{
				return "Large";
			}
			return "Small";
		}

		private decimal getSetMealPrice(string setMealID)
		{
			SqlCommand getSetMealPrice = new SqlCommand("SELECT price FROM SetMealTbl WHERE setMealID = @SMID", con);
			getSetMealPrice.Parameters.AddWithValue("@SMID", setMealID);
			decimal setMealPrice = Convert.ToDecimal(getSetMealPrice.ExecuteScalar());
			return setMealPrice;
		}


		private decimal getFoodItemPrice(string foodItemID, string size)
		{
			SqlCommand getFoodItemPrice = new SqlCommand();
			if (size == "Large")
			{
				getFoodItemPrice = new SqlCommand("SELECT largeItemPrice FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			}
			else // small
			{
				getFoodItemPrice = new SqlCommand("SELECT smallItemPrice FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			}
			getFoodItemPrice.Parameters.AddWithValue("@FIID", foodItemID);
			decimal foodItemPrice = Convert.ToDecimal(getFoodItemPrice.ExecuteScalar());
			return foodItemPrice;
		}

		private void updateDataGridView()
		{
			DataView runningOrderDataView = new DataView(runningOrderDataTable);
			runningOrderDataGridView.DataSource = runningOrderDataView.ToTable(true, "itemID", "quantity", "itemName", "price");
		}

		private void updatePriceLabels()
		{
			// https://stackoverflow.com/questions/3779729/how-i-can-show-the-sum-of-in-a-datagridview-column
			decimal subTotal = runningOrderDataGridView.Rows.Cast<DataGridViewRow>()
								.Sum(t => Convert.ToDecimal(t.Cells["price"].Value));
			if (subTotal > 0)
			{
				subtotalPriceLabel.Text = Convert.ToString(subTotal);
			}
			else // looks nicer lmao
			{
				subtotalPriceLabel.Text = "0.00";
			}
			totalPriceLabel.Text = (subTotal + Convert.ToDecimal(deliveryChargePriceLabel.Text)).ToString();
		}

		// startup

		private void MainMenu_Load(object sender, EventArgs e)
		{
			con.Open();
			paymentPanel.SendToBack();
			paymentPanel.Visible = false;
			viewOrdersPanel.SendToBack();
			viewOrdersPanel.Visible = false;
			getCategories();
			loadCategoryButtons();
			// create columns for runningorderdatatable
			runningOrderDataTable.Columns.Add("itemID");
			runningOrderDataTable.Columns.Add("itemName");
			runningOrderDataTable.Columns.Add("size");
			runningOrderDataTable.Columns.Add("quantity");
			runningOrderDataTable.Columns.Add("memo");
			runningOrderDataTable.Columns.Add("regPrice");
			runningOrderDataTable.Columns.Add("discount");
			runningOrderDataTable.Columns.Add("price");
			// resize runningorderdatagridview
			updateDataGridView();
			runningOrderDataGridView.Columns["itemID"].Width = 40;
			runningOrderDataGridView.Columns["quantity"].Width = 40;
			runningOrderDataGridView.Columns["price"].Width = 100;
			con.Close();
		}

		private void getCategories()
		{
			// get category table to fill in category combobox
			categoriesDataTable = new DataTable();
			SqlDataAdapter getCategories = new SqlDataAdapter("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			getCategories.Fill(categoriesDataTable);
		}

		private void loadCategoryButtons() // fill in categorypanel w/ buttons
		{
			// fill in category buttons
			int xpos = 0, ypos = 0;
			for (int i = 0; i < categoriesDataTable.Rows.Count && i < categoryButtonArray.Length; i++) // cant be more than array length
			{
				// create each category button
				categoryButtonArray[i] = new Button();
				categoryButtonArray[i].UseMnemonic = false; // allows for &
				categoryButtonArray[i].Tag = categoriesDataTable.Rows[i]["categoryID"].ToString();
				categoryButtonArray[i].Text = categoriesDataTable.Rows[i]["categoryName"].ToString();
				categoryButtonArray[i].Width = 130;
				categoryButtonArray[i].Height = 80;
				categoryButtonArray[i].Left = xpos;
				categoryButtonArray[i].Top = ypos;
				categoryButtonArray[i].BackColor = Color.Gainsboro;
				categoryButtonArray[i].MouseClick += new MouseEventHandler(categoryButton_Click);
				categoriesPanel.Controls.Add(categoryButtonArray[i]);
				xpos += 130;
				if ((i + 1) % 8 == 0) // new row
				{
					xpos = 0;
					ypos += 80;
				}
			}
		}

		// ordertype

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			deliveryChargePriceLabel.Enabled = true;
			deliveryButton.BackColor = Color.Yellow; // select delivery, unselect rest
			counterButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
			if (currentOrder.orderType != "Delivery") // if there hasnt been an address set
			{
				customerDetailsFormCreate("Delivery", currentOrder.customerID);
			}
		}

		private void counterButton_Click(object sender, EventArgs e)
		{
			deliveryChargePriceLabel.Text = "0.00"; // edit delivery charge
			deliveryChargePriceLabel.Enabled = false; // disables delivery charge
			updatePriceLabels();
			counterButton.BackColor = Color.Yellow; // select counter, unselect rest
			deliveryButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
			if (currentOrder.orderType != "Counter") // if isnt already a counter
			{
				currentOrder.orderType = "Counter";
				customerDetailsLabel.Text = string.Empty;
			}
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			deliveryChargePriceLabel.Enabled = false; // disables delivery charge
			collectionButton.BackColor = Color.Yellow; // select collection, unselect rest
			counterButton.BackColor = Color.Transparent;
			deliveryButton.BackColor = Color.Transparent;
			if (currentOrder.orderType == "Delivery") // take customer details from delivery and put them into collection
			{
				string phoneNumber = customerDataRow["phoneNumber"].ToString();
				string customerName = customerDataRow["customerName"].ToString();
				customerDetailsLabel.Text = $"{phoneNumber} - {customerName}";
				currentOrder.orderType = "Collection";
				currentOrder.addressID = -1;
			}
			else if (currentOrder.orderType != "Collection") // if there hasnt been a name set
			{
				customerDetailsFormCreate("Collection", currentOrder.customerID);
			}
		}

		private void customerDetails_Click(object sender, EventArgs e)
		{
			customerDetailsFormCreate();
		}

		private void customerDetailsFormCreate(string orderType = "", int customerID = -1)
		{
			CustomerDetails obj = new CustomerDetails(orderType, customerID);
			// basos update main form when anything in the customer details panel gets updated
			obj.CustomerDetailsUpdate += new CustomerDetails.CustomerDetailsUpdateHandler(customerDetailsChanged);
			obj.CustomerDetailsCancel += new CustomerDetails.CustomerDetailsCancelHandler(customerDetailsCancelled);
			obj.Show();
			//obj.TopMost = true;
		}

		private void customerDetailsChanged(object sender, CustomerDetailsUpdateEventArgs e) // when stuff gets updated in the customer details panel
		{
			con.Open();
			currentOrder.customerID = e.customerID;
			currentOrder.orderType = e.orderType;
			getCustomer(e.customerID);
			string phoneNumber = customerDataRow["phoneNumber"].ToString();
			if (e.orderType == "Delivery")
			{
				currentOrder.addressID = e.addressID;
				deliveryButton_Click(sender, e);
				// get data for customerdetailslabel
				DataRow addressDataRow = getAddress(e.addressID);
				string houseNumber = addressDataRow["houseNumber"].ToString();
				string streetName = addressDataRow["streetName"].ToString();
				string postcode = addressDataRow["postcode"].ToString();
				decimal deliveryCharge = Convert.ToDecimal(addressDataRow["deliveryCharge"]);
				customerDetailsLabel.Text = $"{phoneNumber} - {houseNumber} {streetName} {postcode}";
				// sort out delivery charge price label
				deliveryChargePriceLabel.Enabled = true;
				deliveryChargePriceLabel.Text = deliveryCharge.ToString(); // edit delivery charge
			}
			else // order type is collection
			{
				collectionButton_Click(sender, e);
				string customerName = customerDataRow["customerName"].ToString();
				customerDetailsLabel.Text = $"{phoneNumber} - {customerName}";
				// sort out delivery charge price label
				deliveryChargePriceLabel.Text = "0.00"; // edit delivery charge
				deliveryChargePriceLabel.Enabled = false;
			}
			updatePriceLabels();
			con.Close();
		}

		private void customerDetailsCancelled() // if you press cancel in customer details panel youve revert to prior order type
		{
			collectionButton.BackColor = Color.Transparent;
			counterButton.BackColor = Color.Transparent;
			deliveryButton.BackColor = Color.Transparent;
			if (currentOrder.orderType == "Delivery")
			{
				deliveryButton.BackColor = Color.Yellow;
			}
			else if (currentOrder.orderType == "Counter")
			{
				counterButton.BackColor = Color.Yellow;
			}
			else if (currentOrder.orderType == "Collection")
			{
				collectionButton.BackColor = Color.Yellow;
			}
		}

		// acc ordering items

		public void categoryButton_Click(object sender, MouseEventArgs e)
		{
			con.Open();
			// remove prev buttons
			for (int i = 0; i < itemButtonArray.Length; i++)
			{
				itemsPanel.Controls.Remove(itemButtonArray[i]);
			}
			Array.Clear(itemButtonArray);
			// create new buttons
			Button categoryButton = (Button)sender;
			int categoryID = Convert.ToInt32(categoryButton.Tag);
			categoryName = categoryButton.Text.ToString();
			itemsDataTable = new DataTable();
			string itemType;
			if (categoryName != "Set Meals") // set meals come from their own tbl
			{
				// get all items in category
				SqlDataAdapter getFoodItemsByCategory = new SqlDataAdapter("SELECT * FROM FoodItemTbl WHERE categoryID = @CID ORDER BY foodItemID", con);
				getFoodItemsByCategory.SelectCommand.Parameters.AddWithValue("@CID", categoryID);
				getFoodItemsByCategory.Fill(itemsDataTable);
				itemType = "Food Item";
			}
			else // get set meals
			{
				SqlDataAdapter getSetMeals = new SqlDataAdapter("SELECT * FROM SetMealTbl", con);
				getSetMeals.Fill(itemsDataTable);
				itemType = "Set Meal";
			}
			loadItemButtons(itemType);
			con.Close();
		}

		private void loadItemButtons(string itemType) // fill in itempanel w/ buttons
		{
			string itemID, itemName;
			// get right field names
			if (itemType == "Food Item")
			{
				itemID = "foodItemID";
				itemName = "foodName";
			}
			else // set meal
			{
				itemID = "setMealID";
				itemName = "setMealName";
			}
			// fill in food buttons
			int xpos = 0, ypos = 0;
			for (int i = 0; i < itemsDataTable.Rows.Count && i < itemButtonArray.Length; i++) // cant be more than array length
			{
				// create each food button
				itemButtonArray[i] = new Button();
				itemButtonArray[i].UseMnemonic = false; // allows for &
				itemButtonArray[i].Tag = itemsDataTable.Rows[i][itemID].ToString();
				itemButtonArray[i].Text = itemsDataTable.Rows[i][itemName].ToString();
				itemButtonArray[i].Width = 260;
				itemButtonArray[i].Height = 76;
				itemButtonArray[i].Left = xpos;
				itemButtonArray[i].Top = ypos;
				itemButtonArray[i].BackColor = Color.AntiqueWhite;
				itemButtonArray[i].MouseClick += new MouseEventHandler(itemButton_Click);
				itemsPanel.Controls.Add(itemButtonArray[i]);
				xpos += 260;
				if ((i + 1) % 4 == 0) // new row
				{
					xpos = 0;
					ypos += 76;
				}
			}
			// check if any food items/set meals r out of stock
			if (itemType == "Food Item")
			{
				for (int i = 0; i < itemsDataTable.Rows.Count && i < itemButtonArray.Length; i++) // cant be more than array length
				{
					if (Convert.ToBoolean(itemsDataTable.Rows[i]["isOutOfStock"]))
					{
						itemButtonArray[i].Enabled = false; // disable out of stock buttons so u cant order them lmao
					}
				}
			}
			else // set meal
			{
				for (int i = 0; i < itemsDataTable.Rows.Count && i < itemButtonArray.Length; i++) // cant be more than array length
				{
					// get food items in each set meal
					SqlDataAdapter getSetMealFoodItems = new SqlDataAdapter("SELECT foodItemID FROM SetMealFoodItemTbl WHERE setMealID = @SMID", con);
					getSetMealFoodItems.SelectCommand.Parameters.AddWithValue("@SMID", itemButtonArray[i].Tag);
					DataTable setMealFoodItemsDataTable = new DataTable();
					getSetMealFoodItems.Fill(setMealFoodItemsDataTable);
					// check each food item
					string setMealFoodItemID;
					SqlCommand checkIfFoodItemIsOutOfStock = new SqlCommand("SELECT isOutOfStock FROM FoodItemTbl WHERE foodItemID = @FIID", con);
					checkIfFoodItemIsOutOfStock.Parameters.Add("@FIID", SqlDbType.NVarChar);
					foreach (DataRow setMealFoodItemDataRow in setMealFoodItemsDataTable.Rows)
					{
						// get fooditemid and add it to sql query
						setMealFoodItemID = setMealFoodItemDataRow["foodItemID"].ToString();
						checkIfFoodItemIsOutOfStock.Parameters["@FIID"].Value = setMealFoodItemID;
						if (Convert.ToBoolean(checkIfFoodItemIsOutOfStock.ExecuteScalar())) // if out of stock
						{
							// make out of stock items red and get a popup showing whats out of stock
							itemButtonArray[i].ForeColor = Color.Red;
							break;
						}
					}
				}
			}
		}

		public void itemButton_Click(object sender, MouseEventArgs e)
		{
			con.Open();
			Button itemButton = (Button)sender;
			string itemID = itemButton.Tag.ToString();
			string itemName = itemButton.Text.ToString();
			if (itemButton.ForeColor == Color.Red) // set meal with items unavailable - create msgbox w/ unavailable items
			{
				outOfStockMessageBox(itemID);
			}
			string size = "Large";
			// get item size bf u shove it into the function thingy
			if (categoryName != "Set Meals")
			{
				size = getDefaultItemSize(itemID);
			}
			int itemIndex = doesItemExist(itemID, size); // find index of item w/ size in running order datatable if exists
			runningOrderDataGridView.ClearSelection();
			if (itemIndex < 0) // item doesnt alr exist in running order
			{
				DataRow runningOrderNewRow = runningOrderDataTable.NewRow();
				runningOrderNewRow["itemID"] = itemID;
				runningOrderNewRow["itemName"] = itemName;
				runningOrderNewRow["size"] = size;
				runningOrderNewRow["quantity"] = 1;
				// get regular price
				if (categoryName == "Set Meals")
				{
					runningOrderNewRow["regPrice"] = getSetMealPrice(itemID);
				}
				else // food items
				{
					runningOrderNewRow["regPrice"] = getFoodItemPrice(itemID, size);
				}
				// you can assume theres no discounts by default so price = regprice
				runningOrderNewRow["price"] = runningOrderNewRow["regPrice"];
				runningOrderDataTable.Rows.Add(runningOrderNewRow);
				updateDataGridView();
				updatePriceLabels();
				// select new row in datagridview
				int newRowIndex = runningOrderDataTable.Rows.IndexOf(runningOrderNewRow);
				runningOrderDataGridView.Rows[newRowIndex].Selected = true;
			}
			else // if exists, add 1 to quantity and redo price instead
			{
				increaseQuantity(itemIndex);
			}
			con.Close();
		}

		private void outOfStockMessageBox(string setMealID)
		{
			// check which items w/in set meal are out of stock 
			List<string> outOfStockItems = new List<string>();
			DataTable setMealFoodItemsDataTable = getSetMealFoodItems(setMealID);
			// sort out sql bf foreach
			SqlCommand checkIfItemIsOutOfStock = new SqlCommand("SELECT isOutOfStock FROM FoodItemTbl WHERE foodItemID = @FIID", con);
			bool isitemOutOfStock;
			foreach (DataRow setmealFoodItem in setMealFoodItemsDataTable.Rows)
			{
				string foodItemID = setmealFoodItem["foodItemID"].ToString();
				checkIfItemIsOutOfStock.Parameters.AddWithValue("@FIID", foodItemID);
				isitemOutOfStock = Convert.ToBoolean(checkIfItemIsOutOfStock.ExecuteScalar());
				if (isitemOutOfStock) // add to list if out of stock
				{
					outOfStockItems.Add(setmealFoodItem["foodName"].ToString());
				}
			}
			string outOfStockItemsString = string.Join("\n", outOfStockItems);
			MessageBox.Show("The Following items are out of stock in this set meal:\n" + outOfStockItemsString, "Ordering System");
		}

		// editing items

		private void increaseQuantityButton_Click(object sender, EventArgs e)
		{
			if (runningOrderDataTable.Rows.Count > 0)
			{
				// get index of item in datagridview
				int selectedIndex = runningOrderDataGridView.SelectedRows[0].Index;
				increaseQuantity(selectedIndex);
			}
		}

		private void increaseQuantity(int selectedIndex) // both incrementing by pressing the + button and the same item button works exactly the same
		{
			int currentQuantity = Convert.ToInt32(runningOrderDataTable.Rows[selectedIndex]["quantity"]);
			currentQuantity++;
			runningOrderDataTable.Rows[selectedIndex]["quantity"] = currentQuantity;
			// update price

			runningOrderDataTable.Rows[selectedIndex]["price"] = updateTotalItemPrice(runningOrderDataTable.Rows[selectedIndex]);
			updateDataGridView();
			updatePriceLabels();
			// this works here but not in set meals since u cant reorder columns here lmao
			runningOrderDataGridView.Rows[selectedIndex].Selected = true;
		}

		private void decreaseQuantityButton_Click(object sender, EventArgs e)
		{
			if (runningOrderDataTable.Rows.Count > 0)
			{
				// get index of item in datagridview
				int selectedIndex = runningOrderDataGridView.SelectedRows[0].Index;
				DataGridViewRow selectedRow = runningOrderDataGridView.Rows[selectedIndex];
				// get current quantity to increment
				int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value);
				if (currentQuantity > 1) // knock one off if theres at least 2
				{
					currentQuantity--;
					runningOrderDataTable.Rows[selectedIndex]["quantity"] = currentQuantity;
					runningOrderDataTable.Rows[selectedIndex]["price"] = updateTotalItemPrice(runningOrderDataTable.Rows[selectedIndex]);
					updateDataGridView();
					runningOrderDataGridView.Rows[selectedIndex].Selected = true;
				}
				else // if theres one left - get rid of the item
				{
					runningOrderDataTable.Rows.RemoveAt(selectedIndex);
					updateDataGridView();
				}
				updatePriceLabels();
			}
		}

		private void smallPriceButton_Click(object sender, EventArgs e)
		{

		}

		private void largePriceButton_Click(object sender, EventArgs e)
		{

		}

		private void priceEditButton_Click(object sender, EventArgs e)
		{

		}

		private decimal updateTotalItemPrice(DataRow runningOrderDataRow)
		{
			decimal regPrice = Convert.ToDecimal(runningOrderDataRow["regPrice"]);
			decimal discount = Convert.ToDecimal(runningOrderDataRow["discount"]);
			int quantity = Convert.ToInt32(runningOrderDataRow["quantity"]);
			decimal totalItemPrice = (regPrice + discount) * quantity;
			return totalItemPrice;
		}

		private void memoButton_Click(object sender, EventArgs e)
		{

		}

		// playing abt w/ orders

		private void cancelOrderButton_Click(object sender, EventArgs e)
		{
			currentOrder = new Order();
			deliveryButton.BackColor = Color.Transparent;
			counterButton.BackColor = Color.Transparent;
			collectionButton.BackColor = Color.Transparent;
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
					deliveryButton.BackColor = Color.Transparent;
					counterButton.BackColor = Color.Transparent;
					collectionButton.BackColor = Color.Transparent;
					acceptOrderButton.Text = "Accept Order";
					paymentPanel.SendToBack();
					paymentPanel.Visible = false;
					orderNumberLabel.Text = (Convert.ToInt32(orderNumberLabel.Text) + 1).ToString(); // increment order number
				}
			}
		}

		// view orders

		private void viewOrdersButton_Click(object sender, EventArgs e)
		{
			viewOrdersDeliveryButton.BackColor = Color.Transparent;
			viewOrdersCounterButton.BackColor = Color.Transparent;
			viewOrdersCollectionButton.BackColor = Color.Transparent;
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

		private void viewOrdersDeliveryButton_Click(object sender, EventArgs e)
		{
			// selects delivery, unselects rest
			viewOrdersDeliveryButton.BackColor = Color.Yellow;
			viewOrdersCounterButton.BackColor = Color.Transparent;
			viewOrdersCollectionButton.BackColor = Color.Transparent;
			// orderid, address, ordertime, price
		}

		private void viewOrdersCounterButton_Click(object sender, EventArgs e)
		{
			con.Open();
			viewOrdersDataGridView.Rows.Clear();
			// selects counter, unselects rest
			viewOrdersDeliveryButton.BackColor = Color.Transparent;
			viewOrdersCounterButton.BackColor = Color.Yellow;
			viewOrdersCollectionButton.BackColor = Color.Transparent;
			// orderid, ordertime, price
			ordersDataTable = new DataTable();
			SqlDataAdapter getOrders = new SqlDataAdapter("SELECT * FROM OrderTbl WHERE orderType = @OT", con);
			getOrders.SelectCommand.Parameters.AddWithValue("@OT", "Counter");
			getOrders.Fill(ordersDataTable);
			DataView ordersDataView = new DataView(ordersDataTable);
			viewOrdersDataGridView.DataSource = ordersDataView.ToTable(true, "orderID", "orderTime");
			con.Close();
		}

		private void viewOrdersCollectionButton_Click(object sender, EventArgs e)
		{
			// selects collection, unselects rest
			viewOrdersDeliveryButton.BackColor = Color.Transparent;
			viewOrdersCounterButton.BackColor = Color.Transparent;
			viewOrdersCollectionButton.BackColor = Color.Yellow;
			// orderid, customername, ordertime, price
		}

		private void viewOrdersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through ordersdatagridview to find the full deets
			int selectedIndex = viewOrdersDataGridView.SelectedCells[0].RowIndex;
			DataRow selectedRow = ordersDataTable.Rows[selectedIndex];
			viewOrdersSelectedOrderID = Convert.ToInt32(selectedRow["orderID"]);
			viewOrdersDataGridView.ClearSelection(); // unselect row
		}

		private void printKitchenTicketButton_Click(object sender, EventArgs e)
		{
			if (viewOrdersSelectedOrderID != -1) // if theres a selected order
			{

			}
			else
			{
				MessageBox.Show("Order hasn't been selected", "Ordering System");
			}
		}

		private void printCustomerTicketButton_Click(object sender, EventArgs e)
		{
			if (viewOrdersSelectedOrderID != -1) // if theres a selected order
			{

			}
			else
			{
				MessageBox.Show("Order hasn't been selected", "Ordering System");
			}
		}

		// cool bottom stuff

		private void managerFunctionsButton_Click(object sender, EventArgs e)
		{
			ManagerFunctionsLogin obj = new ManagerFunctionsLogin();
			obj.Show();
			obj.TopMost = true;
		}

		private void timer_Tick(object sender, EventArgs e) // the little time bit in the bottom right
		{
			timeLabel.Text = DateTime.Now.ToString("dd/mm/yy HH:mm:ss");
		}
	}
}
