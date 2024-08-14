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
		DataView foodItemsDataViewByCategory, setMealsDataView; // full database compared to whats shown in datagridview
		DataSet categoriesDataSet; // same as above xoxo
		DataTable setMealFoodItemsDataTable; // separate table to work through the setmeal items while in progress; reduces number of edits to main table
		string foodItemID, setMealID; // id of currently selected item/setmeal from datagridview

		public UpdateSetMeals()
		{
			InitializeComponent();
		}

		private string getCategoryNameFromCategoryID(int categoryID)
		{
			DataView categoriesDataViewSortByID = new DataView(categoriesDataSet.Tables[0], "", "categoryID", DataViewRowState.CurrentRows);
			int categoryIDIndex = categoriesDataViewSortByID.Find(categoryID);
			if (categoryIDIndex != -1) // if category exists lmao
			{
				return categoriesDataViewSortByID[categoryIDIndex]["categoryName"].ToString();
			}
			return null;
		}

		private int getCategoryIDFromCategoryName(string categoryName)
		{
			DataView categoriesDataViewSortByName = new DataView(categoriesDataSet.Tables[0], "", "categoryName", DataViewRowState.CurrentRows);
			int categoryNameIndex = categoriesDataViewSortByName.Find(categoryName);
			if (categoryNameIndex != -1) // if category exists lmao
			{
				return Convert.ToInt32(categoriesDataViewSortByName[categoryNameIndex]["categoryID"]);
			}
			return categoryNameIndex;
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

		private bool doesItemExist() // checks if item exists in database w/ same name
		{
			SqlCommand checkIfItemExists = new SqlCommand("SELECT COUNT(*) FROM SetMealTbl WHERE setMealName = @SMN OR setMealID = @SMID", con);
			checkIfItemExists.Parameters.AddWithValue("@SMN", setMealNameTextBox.Text);
			checkIfItemExists.Parameters.AddWithValue("@SMID", setMealIDTextBox.Text);
			int categoryExists = (int)checkIfItemExists.ExecuteScalar();
			if (categoryExists == 0)
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
			categoriesDataSet = new DataSet();
			getCategories.Fill(categoriesDataSet);
			DataView categoriesDataView = new DataView(categoriesDataSet.Tables[0]);
			// put all names from data reader into category list
			List<string> categoryNames = new List<string>();
			foreach (DataRowView category in categoriesDataView)
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
			setMealFoodItemsDataTable = new DataTable();
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
			SqlDataAdapter getSetMeals = new SqlDataAdapter("SELECT * FROM SetMealTbl ORDER BY SetMealID", con);
			DataSet setMealsDataSet = new DataSet();
			getSetMeals.Fill(setMealsDataSet);
			setMealsDataView = new DataView(setMealsDataSet.Tables[0]);
			// fill in set meals datagridview
			DataTable setMealsDataTable = setMealsDataView.ToTable(true, "setMealID", "setMealName", "price");
			setMealDataGridView.DataSource = setMealsDataTable;
			setMealDataGridView.ClearSelection();
		}

		private void updateItemQuantitySize() // update item quantity and size after adding/selecting fooditem
		{
			int selectedIndex = setMealItemDataGridView.SelectedRows[0].Index;
			itemQuantityValueLabel.Text = setMealFoodItemsDataTable.Rows[selectedIndex]["quantity"].ToString();
			itemSizeComboBox.Text = setMealFoodItemsDataTable.Rows[selectedIndex]["size"].ToString();
		}

		private void increaseQuantityButton_Click(object sender, EventArgs e)
		{
			int currentQuantity = Convert.ToInt32(itemQuantityValueLabel.Text);
			currentQuantity++;
			int selectedIndex = setMealItemDataGridView.SelectedRows[0].Index;
			setMealFoodItemsDataTable.Rows[selectedIndex]["quantity"] = currentQuantity;
			itemQuantityValueLabel.Text = currentQuantity.ToString();
		}

		private void decreaseQuantityButton_Click(object sender, EventArgs e)
		{
			int currentQuantity = Convert.ToInt32(itemQuantityValueLabel.Text);
			currentQuantity--;
			if (currentQuantity > 0) // quantity cant go below 1
			{
				int selectedIndex = setMealItemDataGridView.SelectedRows[0].Index;
				setMealFoodItemsDataTable.Rows[selectedIndex]["quantity"] = currentQuantity;
				itemQuantityValueLabel.Text = currentQuantity.ToString();
			}
		}

		private void itemSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = setMealItemDataGridView.SelectedRows[0].Index;
			setMealFoodItemsDataTable.Rows[selectedIndex]["size"] = itemSizeComboBox.Text;
		}

		private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through fooditemsdataview to find the full deets
			int selectedRowIndex = itemDataGridView.SelectedCells[0].RowIndex;
			if (itemDataGridView.RowCount > 1 && selectedRowIndex < itemDataGridView.RowCount - 1) // just in case theres no rows
			{
				setMealItemDataGridView.ClearSelection();
				// find food item id to search through tbl
				DataRowView selectedRow = foodItemsDataViewByCategory[selectedRowIndex];
				foodItemID = selectedRow["foodItemID"].ToString();
				int foodItemIndex = doesFoodItemExist(foodItemID); // find index of food in set meal datatable if exists
				if (foodItemIndex == -1) // food item doesnt alr exist in set meal
				{
					// creating record for datagridview
					DataRow setMealFoodItemNewRow = setMealFoodItemsDataTable.NewRow();
					setMealFoodItemNewRow[0] = foodItemID;
					setMealFoodItemNewRow[1] = selectedRow["foodName"].ToString();
					string size = "Large"; // size defaults to large unless default is small
					if (Convert.ToBoolean(selectedRow["defaultToLargePrice"]) == false)
					{
						size = "Small";
					}
					setMealFoodItemNewRow[2] = size;
					setMealFoodItemNewRow[3] = 1; // default to 1
					setMealFoodItemsDataTable.Rows.Add(setMealFoodItemNewRow);
					setMealItemDataGridView.ClearSelection();
					// select new row in datatable
					int newRowIndex = setMealFoodItemsDataTable.Rows.IndexOf(setMealFoodItemNewRow);
					setMealItemDataGridView.Rows[newRowIndex].Selected = true;
				}
				else // if exists, add 1 to quantity instead
				{
					int quantity = Convert.ToInt32(setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"]);
					quantity++;
					setMealFoodItemsDataTable.Rows[foodItemIndex]["quantity"] = quantity;
					setMealItemDataGridView.Rows[foodItemIndex].Selected = true;
				}
				updateItemQuantitySize();
			}
			else // unselect flop row
			{
				itemDataGridView.ClearSelection();
			}
		}

		private void setMealDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through setmealdataview to find the full deets
			int selectedRowIndex = setMealDataGridView.SelectedCells[0].RowIndex;
			if (setMealDataGridView.RowCount > 1 && selectedRowIndex < setMealDataGridView.RowCount - 1) // just in case theres no rows
			{
				setMealFoodItemsDataTable.Clear(); // clear prev set meal
				// get set meal id
				DataRowView selectedRow = setMealsDataView[selectedRowIndex];
				setMealID = selectedRow.Row["setMealID"].ToString();
				// fill in text boxes
				setMealIDTextBox.Text = selectedRow.Row["setMealID"].ToString();
				setMealNameTextBox.Text = selectedRow.Row["setMealName"].ToString();
				setMealPriceTextBox.Text = selectedRow.Row["price"].ToString();
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
			else // unselect flop row
			{
				setMealDataGridView.ClearSelection();
				clearSetMealScreen();
			}
			con.Close();
		}

		private void setMealitemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through setmealfooditemsdataview to find the full deets
			int selectedRowIndex = setMealItemDataGridView.SelectedCells[0].RowIndex;
			if (setMealItemDataGridView.RowCount > 1 && selectedRowIndex < setMealItemDataGridView.RowCount - 1) // just in case theres no rows
			{
				updateItemQuantitySize();
			}
			else // unselect flop row
			{
				setMealItemDataGridView.ClearSelection();
			}
		}

		private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			con.Open();
			int categoryID = getCategoryIDFromCategoryName(categoryComboBox.Text);
			SqlDataAdapter getFoodItemsByCategory = new SqlDataAdapter("SELECT * FROM FoodItemTbl WHERE categoryID = @CID ORDER BY foodItemID", con);
			getFoodItemsByCategory.SelectCommand.Parameters.AddWithValue("@CID", categoryID);
			DataSet foodItemsDataSet = new DataSet();
			getFoodItemsByCategory.Fill(foodItemsDataSet);
			foodItemsDataViewByCategory = new DataView(foodItemsDataSet.Tables[0]);
			// fill in set meals datagridview
			DataTable foodItemsDataTable = foodItemsDataViewByCategory.ToTable(true, "foodItemID", "foodName");
			itemDataGridView.DataSource = foodItemsDataTable;
			itemDataGridView.ClearSelection();
			con.Close();
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

		private void addSetMealButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesItemExist() == false && areAllFieldsFilled() == true)
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
			else if (areAllFieldsFilled() == true) // if item exists
			{
				MessageBox.Show("Set meal already exists with same name or ID", "Ordering System");
			}
			else // if not all fields filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			con.Close();
		}

		private void updateSetMealButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllFieldsFilled() == true && setMealID != null) // if all fields filled in
			{
				// update set meal
				SqlCommand updateSetMeal = new SqlCommand("UPDATE SetMealTbl SET setMealID = @SMID, setMealName = @SMN, price = @PR", con);
				updateSetMeal.Parameters.AddWithValue("@SMID", setMealIDTextBox.Text);
				updateSetMeal.Parameters.AddWithValue("@SMN", setMealNameTextBox.Text);
				updateSetMeal.Parameters.AddWithValue("@PR", setMealPriceTextBox.Text);
				updateSetMeal.ExecuteNonQuery();
				// update food items
				// remove existing fooditems
				deleteSetMealFoodItems();
				// add new fooditems
				addSetMealFoodItems();
				MessageBox.Show("Set meal updated", "Ordering System");
				clearSetMealScreen();
				updateDataGridView();
			}
			else if (setMealID != null) // incomplete form
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else // item not selected
			{
				MessageBox.Show("Set meal not selected", "Ordering System");
			}
			con.Close();
		}

		private void deleteSetMealButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesItemExist() == false) // set meal not found
			{
				MessageBox.Show("Set meal not found in database", "Ordering System");
			}
			else if (setMealID == null) // no set meal selected
			{
				MessageBox.Show("Set meal not selected", "Ordering System");
			}
			else // set meal found
			{
				// delete set meal from setmealtbl
				SqlCommand deleteSetMeal = new SqlCommand("DELETE FROM SetMealTbl WHERE setMealID = @SMID", con);
				deleteSetMeal.Parameters.AddWithValue("@SMID", setMealID);
				deleteSetMeal.ExecuteNonQuery();
				// delete setmealfooditems from setmealfooditemtbl
				deleteSetMealFoodItems();
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
