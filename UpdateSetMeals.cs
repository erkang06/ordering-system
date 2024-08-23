using ordering_system.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordering_system
{
	public partial class UpdateSetMeals : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataTable categoriesDataTable = new DataTable(); // full datatable compared to whats shown in datagridview
		DataTable foodItemsDataTableByCategory;
		DataTable setMealsDataTable;
		DataTable setMealFoodItemsDataTable = new DataTable(); // separate table to work through the setmeal items while in progress; reduces number of edits to main table
		string foodItemID, setMealID; // id of currently selected item/setmeal from datagridview

		public UpdateSetMeals()
		{
			InitializeComponent();
		}

		private string getCategoryNameFromCategoryID(int categoryID)
		{
			DataRow selectedRow = categoriesDataTable.Select($"categoryID = '{categoryID}'")[0];
			if (selectedRow != null) // if category exists lmao
			{
				return selectedRow["categoryName"].ToString();
			}
			return null;
		}

		private int getCategoryIDFromCategoryName(string categoryName)
		{
			DataRow selectedRow = categoriesDataTable.Select($"categoryName = '{categoryName}'")[0];
			if (selectedRow != null) // if category exists lmao
			{
				return Convert.ToInt32(selectedRow["categoryID"]);
			}
			return -1;
		}

		private int doesFoodItemExist(string foodItemID) // returns index of food item in set meal if exists, else returns -1
		{
			DataRow[] foodItem = setMealFoodItemsDataTable.Select($"foodItemID = '{foodItemID}'");
			if (foodItem.Length > 0) // theres only 1 cuz its a primary key innit
			{
				int index = setMealFoodItemsDataTable.Rows.IndexOf(foodItem[0]);
				return index;
			}
			return -1;
		}

		private bool areAllFieldsFilled() // checks if all fields have been filled in
		{
			if (setMealIDTextBox.Text != "" && setMealNameTextBox.Text != "" && setMealPriceTextBox.Text != "" && setMealFoodItemsDataTable.Rows.Count > 1)
			{
				return true;
			}
			return false;
		}

		private bool doesSetMealExist() // checks if set meal exists in database w/ same name
		{
			SqlCommand checkIfSetMealExists = new SqlCommand("SELECT COUNT(*) FROM SetMealTbl WHERE setMealName = @SMN OR setMealID = @SMID", con);
			checkIfSetMealExists.Parameters.AddWithValue("@SMN", setMealNameTextBox.Text);
			checkIfSetMealExists.Parameters.AddWithValue("@SMID", setMealIDTextBox.Text);
			int setMealExists = (int)checkIfSetMealExists.ExecuteScalar();
			if (setMealExists == 0)
			{
				return false;
			}
			return true;
		}

		private bool doesItemExist() // checks if item exists in database w/ same name
		{
			SqlCommand checkIfItemExists = new SqlCommand("SELECT COUNT(*) FROM FoodItemTbl WHERE foodName = @FN OR foodItemID = @FIID", con);
			checkIfItemExists.Parameters.AddWithValue("@FN", setMealNameTextBox.Text);
			checkIfItemExists.Parameters.AddWithValue("@FIID", setMealIDTextBox.Text);
			int itemExists = (int)checkIfItemExists.ExecuteScalar();
			if (itemExists == 0)
			{
				return false;
			}
			return true;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UpdateSetMeals_Load(object sender, EventArgs e)
		{
			con.Open();
			// get category table to fill in category combobox
			SqlDataAdapter getCategories = new SqlDataAdapter("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			getCategories.Fill(categoriesDataTable);
			// put all names from data reader into category list
			List<string> categoryNames = new List<string>();
			foreach (DataRow category in categoriesDataTable.Rows)
			{
				categoryNames.Add(category["categoryName"].ToString());
			}
			// fill in category combobox
			bool setMealExists = false; // checks if set meal exists in categorytbl
			foreach (string categoryName in categoryNames)
			{
				if (categoryName != "Set Meals") // you cant add set meals to a set meal xoxo
				{
					categoryComboBox.Items.Add(categoryName);
				}
				else
				{
					setMealExists = true;
				}
			}
			if (setMealExists == false) // create set meal in categorytbl if it doesnt exist
			{
				// find next value for categoryindex
				SqlCommand findMaxCategoryIndex = new SqlCommand("SELECT MAX(categoryIndex) FROM CategoryTbl", con);
				int maxCategoryIndex;
				try // get the biggest category index
				{
					maxCategoryIndex = (int)findMaxCategoryIndex.ExecuteScalar();
				}
				catch // if database empty
				{
					maxCategoryIndex = 0;
				}
				maxCategoryIndex++;
				SqlCommand addSetMealToDatabase = new SqlCommand("INSERT INTO CategoryTbl(categoryName, categoryIndex) VALUES(@CN, @CI)", con);
				addSetMealToDatabase.Parameters.AddWithValue("@CN", "Set Meals");
				addSetMealToDatabase.Parameters.AddWithValue("@CI", maxCategoryIndex);
				addSetMealToDatabase.ExecuteNonQuery();
				MessageBox.Show("Set meal didn't exist as a category, so has been added to database", "Ordering System");
			}
			// sort out setmealfooditemsdatatable
			setMealFoodItemsDataTable.Columns.Add("foodItemID");
			setMealFoodItemsDataTable.Columns.Add("foodName");
			setMealFoodItemsDataTable.Columns.Add("size");
			setMealFoodItemsDataTable.Columns.Add("quantity");
			setMealItemDataGridView.DataSource = setMealFoodItemsDataTable;
			updateDataGridView();
			con.Close();
		}

		private void updateDataGridView()
		{
			setMealsDataTable = new DataTable(); // clear prev
			SqlDataAdapter getSetMeals = new SqlDataAdapter("SELECT * FROM SetMealTbl ORDER BY SetMealID", con);
			getSetMeals.Fill(setMealsDataTable);
			DataView setMealsDataView = new DataView(setMealsDataTable);
			// fill in set meals datagridview
			setMealDataGridView.DataSource = setMealsDataView.ToTable(true, "setMealID", "setMealName", "price");
			// check if max # of set meals reached
			if (setMealsDataTable.Rows.Count >= 24)
			{
				addSetMealButton.Enabled = false;
			}
			else
			{
				addSetMealButton.Enabled = true;
			}
			setMealIDTextBox.Text = string.Empty;
			setMealNameTextBox.Text = string.Empty;
			setMealPriceTextBox.Text = string.Empty;
			setMealDataGridView.ClearSelection();
		}

		private void updateItemQuantitySize() // update item quantity and size after adding/selecting fooditem
		{
			int selectedRowIndex = setMealItemDataGridView.SelectedRows[0].Index;
			foodItemID = setMealItemDataGridView.Rows[selectedRowIndex].Cells["foodItemID"].Value.ToString();
			int foodItemIndex = doesFoodItemExist(foodItemID); // find index of food in set meal datatable
			itemQuantityValueLabel.Text = setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"].ToString();
			itemSizeComboBox.Text = setMealFoodItemsDataTable.Rows[foodItemIndex]["size"].ToString();
		}

		private void increaseQuantityButton_Click(object sender, EventArgs e)
		{
			if (setMealFoodItemsDataTable.Rows.Count > 0) // if not empty
			{
				int currentQuantity = Convert.ToInt32(itemQuantityValueLabel.Text);
				currentQuantity++;
				int selectedRowIndex = setMealItemDataGridView.SelectedRows[0].Index;
				foodItemID = setMealItemDataGridView.Rows[selectedRowIndex].Cells["foodItemID"].Value.ToString();
				int foodItemIndex = doesFoodItemExist(foodItemID); // find index of food in set meal datatable
				setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"] = currentQuantity;
				itemQuantityValueLabel.Text = currentQuantity.ToString();
			}
		}

		private void decreaseQuantityButton_Click(object sender, EventArgs e)
		{
			if (setMealFoodItemsDataTable.Rows.Count > 0) // if not empty
			{
				int currentQuantity = Convert.ToInt32(itemQuantityValueLabel.Text);
				currentQuantity--;
				if (currentQuantity > 0) // quantity cant go below 1
				{
					int selectedRowIndex = setMealItemDataGridView.SelectedRows[0].Index;
					foodItemID = setMealItemDataGridView.Rows[selectedRowIndex].Cells["foodItemID"].Value.ToString();
					int foodItemIndex = doesFoodItemExist(foodItemID); // find index of food in set meal datatable
					setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"] = currentQuantity;
					itemQuantityValueLabel.Text = currentQuantity.ToString();
				}
			}
		}

		private void itemSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (setMealFoodItemsDataTable.Rows.Count > 0) // if not empty
			{
				int selectedIndex = setMealItemDataGridView.SelectedRows[0].Index;
				setMealFoodItemsDataTable.Rows[selectedIndex]["size"] = itemSizeComboBox.Text;
			}
		}

		private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through fooditemsdatatable to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				setMealItemDataGridView.ClearSelection();
				// find food item id to search through tbl
				foodItemID = itemDataGridView.Rows[selectedRowIndex].Cells["foodItemID"].Value.ToString();
				DataRow selectedRow = foodItemsDataTableByCategory.Select($"foodItemID = '{foodItemID}'")[0];
				int foodItemIndex = doesFoodItemExist(foodItemID); // find index of food in set meal datatable if exists
				if (foodItemIndex < 0) // food item doesnt alr exist in set meal
				{
					// creating record for datagridview
					DataRow setMealFoodItemNewRow = setMealFoodItemsDataTable.NewRow();
					setMealFoodItemNewRow["foodItemID"] = foodItemID;
					setMealFoodItemNewRow["foodName"] = selectedRow["foodName"].ToString();
					string size = "Large"; // size defaults to large unless default is small
					if (Convert.ToBoolean(selectedRow["defaultToLargePrice"]) == false)
					{
						size = "Small";
					}
					setMealFoodItemNewRow["size"] = size;
					setMealFoodItemNewRow["quantity"] = 1; // default to 1
					setMealFoodItemsDataTable.Rows.Add(setMealFoodItemNewRow);
					setMealItemDataGridView.ClearSelection();
					// select new row in datatable
					int newRowIndex = setMealFoodItemsDataTable.Rows.IndexOf(setMealFoodItemNewRow);
					setMealItemDataGridView.Rows[newRowIndex].Selected = true;
				}
				else // if exists, add 1 to quantity instead
				{
					int currentQuantity = Convert.ToInt32(setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"]);
					currentQuantity++;
					setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"] = currentQuantity;
					setMealItemDataGridView.Rows[findDataGridViewIndex()].Selected = true;
				}
				updateItemQuantitySize();
			}
		}

		private int findDataGridViewIndex() // find index of row in setmealfooditemdatagridview by fooditemid
		{
			for (int i = 0; i < setMealDataGridView.Rows.Count; i++)
			{
				if (setMealItemDataGridView.Rows[i].Cells["foodItemID"].Value.ToString() == foodItemID)
				{
					return i;
				}
			}
			return -1;
		}

		private void setMealDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through setmealdatatable to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				setMealFoodItemsDataTable.Clear(); // clear prev set meal
																					 // get set meal id
				setMealID = setMealDataGridView.Rows[selectedRowIndex].Cells["setMealID"].Value.ToString();
				DataRow selectedRow = setMealsDataTable.Select($"setMealID = '{setMealID}'")[0];
				// fill in text boxes
				setMealIDTextBox.Text = selectedRow["setMealID"].ToString();
				setMealNameTextBox.Text = selectedRow["setMealName"].ToString();
				setMealPriceTextBox.Text = selectedRow["price"].ToString();
				// get set meal from setmealfooditemtbl
				SqlDataAdapter getSetMealFoodItems = new SqlDataAdapter("SELECT foodItemID, size, quantity FROM SetMealFoodItemTbl WHERE setMealID = @SMID ORDER BY foodItemID", con);
				getSetMealFoodItems.SelectCommand.Parameters.AddWithValue("@SMID", setMealID);
				getSetMealFoodItems.Fill(setMealFoodItemsDataTable);
				// add food name to each fooditem
				SqlCommand getFoodItemName = new SqlCommand("SELECT foodName FROM FoodItemTbl WHERE foodItemID = @FIID", con);
				getFoodItemName.Parameters.Add("@FIID", SqlDbType.NVarChar);
				string foodItemName;
				for (int i = 0; i < setMealFoodItemsDataTable.Rows.Count; i++)
				{
					// add fooditemid to sqlcommand
					getFoodItemName.Parameters["@FIID"].Value = setMealFoodItemsDataTable.Rows[i]["foodItemID"];
					foodItemName = getFoodItemName.ExecuteScalar().ToString();
					setMealFoodItemsDataTable.Rows[i]["foodName"] = foodItemName;
				}
				updateItemQuantitySize(); // for some reason datagridviews always highlight a row
			}
			con.Close();
		}

		private void setMealitemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through setmealfooditemsdatatable to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				updateItemQuantitySize();
			}
		}

		private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			con.Open();
			foodItemsDataTableByCategory = new DataTable(); // clear prev
			int categoryID = getCategoryIDFromCategoryName(categoryComboBox.Text);
			SqlDataAdapter getFoodItemsByCategory = new SqlDataAdapter("SELECT * FROM FoodItemTbl WHERE categoryID = @CID ORDER BY foodItemID", con);
			getFoodItemsByCategory.SelectCommand.Parameters.AddWithValue("@CID", categoryID);
			getFoodItemsByCategory.Fill(foodItemsDataTableByCategory);
			DataView foodItemsDataViewByCategory = new DataView(foodItemsDataTableByCategory);
			// fill in set meals datagridview
			itemDataGridView.DataSource = foodItemsDataViewByCategory.ToTable(true, "foodItemID", "foodName");
			itemDataGridView.ClearSelection();
			con.Close();
		}

		private void setMealItemDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			updateItemQuantitySize();
		}

		private void deleteItemButton_Click(object sender, EventArgs e)
		{
			try // in case theres none selected
			{
				int selectedIndex = setMealItemDataGridView.SelectedRows[0].Index;
				setMealFoodItemsDataTable.Rows.RemoveAt(selectedIndex);
			}
			catch
			{
				MessageBox.Show("Item not selected from set meal items", "Ordering System");
			}
		}

		private void clearSetMealButton_Click(object sender, EventArgs e)
		{
			clearSetMealScreen();
		}

		private void addSetMealButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesSetMealExist()) // if set meal exists
			{
				MessageBox.Show("Set meal already exists with same name or ID", "Ordering System");
			}
			else if (doesItemExist()) // has id/name been used as item
			{
				MessageBox.Show("Item already exists with same name or ID", "Ordering System");
			}
			else if (!areAllFieldsFilled()) // if not all fields filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else // acc works
			{
				// add the set meal to setmealtbl
				SqlCommand addSetMealToDatabase = new SqlCommand("INSERT INTO SetMealTbl(setMealID, setMealName, price) VALUES(@SMID, @SMN, @PR)", con);
				addSetMealToDatabase.Parameters.AddWithValue("@SMID", setMealIDTextBox.Text);
				addSetMealToDatabase.Parameters.AddWithValue("@SMN", setMealNameTextBox.Text);
				addSetMealToDatabase.Parameters.AddWithValue("@PR", Convert.ToDecimal(setMealPriceTextBox.Text));
				addSetMealToDatabase.ExecuteNonQuery();
				// add each item to setmealfooditemtbl
				addSetMealFoodItems();
				MessageBox.Show("Set meal added to database", "Ordering System");
				clearSetMealScreen();
				updateDataGridView();
			}
			con.Close();
		}

		private void updateSetMealButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllFieldsFilled() == false) // not all textboxes filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else if (setMealID == null) // set meal not selected
			{
				MessageBox.Show("Set meal not selected", "Ordering System");
			}
			else if (doesSetMealExist()) // if new set meal name has already been used in tbl
			{
				MessageBox.Show("Set meal already exists with the same name", "Ordering System");
			}
			else // if all works fine
			{
				// update set meal
				SqlCommand updateSetMeal = new SqlCommand("UPDATE SetMealTbl SET setMealID = @SMID, setMealName = @SMN, price = @PR", con);
				updateSetMeal.Parameters.AddWithValue("@SMID", setMealIDTextBox.Text);
				updateSetMeal.Parameters.AddWithValue("@SMN", setMealNameTextBox.Text);
				updateSetMeal.Parameters.AddWithValue("@PR", setMealPriceTextBox.Text);
				updateSetMeal.ExecuteNonQuery();
				// remove existing fooditems
				deleteSetMealFoodItems();
				// add new fooditems
				addSetMealFoodItems();
				MessageBox.Show("Set meal updated", "Ordering System");
				clearSetMealScreen();
				updateDataGridView();
			}
			con.Close();
		}

		private void deleteSetMealButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesSetMealExist() == false) // set meal not found
			{
				MessageBox.Show("Set meal not found in database", "Ordering System");
			}
			else if (setMealID == null) // no set meal selected
			{
				MessageBox.Show("Set meal not selected", "Ordering System");
			}
			else // set meal found
			{
				// delete setmealfooditems from setmealfooditemtbl
				deleteSetMealFoodItems();
				// delete set meal from setmealtbl
				SqlCommand deleteSetMeal = new SqlCommand("DELETE FROM SetMealTbl WHERE setMealID = @SMID", con);
				deleteSetMeal.Parameters.AddWithValue("@SMID", setMealID);
				deleteSetMeal.ExecuteNonQuery();
				setMealID = null;
				MessageBox.Show("Set meal deleted", "Ordering System");
				clearSetMealScreen();
				updateDataGridView();
			}
			con.Close();
		}

		private void addSetMealFoodItems()
		{
			SqlCommand addSetMealFoodItemToDatabase = new SqlCommand("INSERT INTO SetMealFoodItemTbl(setMealID, foodItemID, size, quantity) VALUES(@SMID, @FIID, @SZ, @QTT)", con);
			addSetMealFoodItemToDatabase.Parameters.AddWithValue("@SMID", setMealIDTextBox.Text);
			addSetMealFoodItemToDatabase.Parameters.Add("@FIID", SqlDbType.NVarChar);
			addSetMealFoodItemToDatabase.Parameters.Add("@SZ", SqlDbType.NChar);
			addSetMealFoodItemToDatabase.Parameters.Add("@QTT", SqlDbType.Int);
			foreach (DataRow row in setMealFoodItemsDataTable.Rows) // each item just needs parameters to be changed
			{
				addSetMealFoodItemToDatabase.Parameters["@FIID"].Value = row[0];
				addSetMealFoodItemToDatabase.Parameters["@SZ"].Value = row[2];
				addSetMealFoodItemToDatabase.Parameters["@QTT"].Value = row[3];
				addSetMealFoodItemToDatabase.ExecuteNonQuery();
			}
		}

		private void deleteSetMealFoodItems()
		{
			SqlCommand deleteSetMealFoodItems = new SqlCommand("DELETE FROM SetMealFoodItemTbl WHERE setMealID = @SMID", con);
			deleteSetMealFoodItems.Parameters.AddWithValue("@SMID", setMealID);
			deleteSetMealFoodItems.ExecuteNonQuery();
		}

		private void clearSetMealScreen() // clears textboxes and setmealitemdatagridview
		{
			setMealDataGridView.ClearSelection();
			setMealFoodItemsDataTable.Clear();
			setMealIDTextBox.Text = string.Empty;
			setMealNameTextBox.Text = string.Empty;
			setMealPriceTextBox.Text = string.Empty;
		}

		private void setMealIDTextBox_Leave(object sender, EventArgs e)
		{
			if (setMealIDTextBox.Text.Length > 10) // if id too long for database
			{
				MessageBox.Show("Set meal ID too long", "Ordering System");
				setMealIDTextBox.Focus();
			}
		}

		private void setMealNameTextBox_Leave(object sender, EventArgs e)
		{
			if (setMealNameTextBox.Text.Length > 50) // if set meal name too long for database
			{
				MessageBox.Show("Set meal name too long", "Ordering System");
				setMealNameTextBox.Focus();
			}
		}

		private void setMealPriceTextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				Convert.ToDecimal(setMealPriceTextBox.Text); // check if value is acc decimal
				if (Convert.ToDecimal(setMealPriceTextBox.Text) < 0 || Convert.ToDecimal(setMealPriceTextBox.Text) >= 1000) // not within range
				{
					MessageBox.Show("Price not within range", "Ordering System");
					setMealPriceTextBox.Focus();
				}
			}
			catch // not decimal
			{
				MessageBox.Show("Price not a decimal", "Ordering System");
				setMealPriceTextBox.Focus();
			}
		}
	}
}
