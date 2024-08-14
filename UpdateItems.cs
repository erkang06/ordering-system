using ordering_system.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ordering_system
{
	public partial class UpdateItems : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataView foodItemsDataView; // full database compared to whats shown in datagridview
		DataSet categoriesDataSet; // same as above xoxo
		string foodItemID; // id of currently selected item from datagridview
		public UpdateItems()
		{
			InitializeComponent();
		}

		private bool doesItemExist() // checks if item exists in database w/ same name
		{
			SqlCommand checkIfItemExists = new SqlCommand("SELECT COUNT(*) FROM FoodItemTbl WHERE foodName = @FN OR foodItemID = @FIID", con);
			checkIfItemExists.Parameters.AddWithValue("@FN", itemNameTextBox.Text);
			checkIfItemExists.Parameters.AddWithValue("@FIID", itemIDTextBox.Text);
			int categoryExists = (int)checkIfItemExists.ExecuteScalar();
			if (categoryExists == 0)
			{
				return false;
			}
			return true;
		}

		private bool areAllFieldsFilled() // checks if all fields have been filled in
		{
			if (itemIDTextBox.Text != "" && itemNameTextBox.Text != "" && largePriceTextBox.Text != "" && categoryComboBox.Text != "")
			{
				// check whether small price is filled in or unneeded
				if ((hasSmallPriceCheckBox.Checked == true && smallPriceTextBox.Text != "") || hasSmallPriceCheckBox.Checked == false)
				{
					return true;
				}
			}
			return false;
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

		private void UpdateItems_Load(object sender, EventArgs e)
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
				if (category["categoryName"].ToString() != "Set Meals") // cant add items to set meals yk
				{
					categoryNames.Add(category["categoryName"].ToString());
				}
			}
			// fill in category combobox
			foreach (string categoryName in categoryNames)
			{
				categoryComboBox.Items.Add(categoryName);
			}
			hasSmallPriceCheckBox_CheckedChanged(sender, e); // sorts out weird bits w/ checkboxes
			updateDataGridView();
			con.Close();
		}

		private void updateDataGridView()
		{
			SqlDataAdapter getFoodItems = new SqlDataAdapter("SELECT FoodItemTbl.* FROM FoodItemTbl, CategoryTbl WHERE FoodItemTbl.categoryID = CategoryTbl.categoryID ORDER BY CategoryTbl.categoryIndex, FoodItemTbl.foodItemID", con);
			DataSet foodItemsDataSet = new DataSet();
			getFoodItems.Fill(foodItemsDataSet);
			foodItemsDataView = new DataView(foodItemsDataSet.Tables[0]);
			// fill in item datagridview
			DataTable foodItemsDataTable = foodItemsDataView.ToTable(true, "foodItemID", "foodName", "smallItemPrice", "largeItemPrice");
			itemDataGridView.DataSource = foodItemsDataTable;
			itemDataGridView.ClearSelection();
		}

		private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through fooditemsdataview to find the full deets
			int selectedRowIndex = itemDataGridView.SelectedCells[0].RowIndex;
			if (itemDataGridView.RowCount > 1 && selectedRowIndex < itemDataGridView.RowCount - 1) // just in case theres no rows
			{
				DataRowView selectedRow = foodItemsDataView[selectedRowIndex];
				foodItemID = selectedRow.Row["foodItemID"].ToString();
				// update textboxes and checkboxes
				itemIDTextBox.Text = foodItemID;
				itemNameTextBox.Text = selectedRow.Row["foodName"].ToString();
				hasSmallPriceCheckBox.Checked = Convert.ToBoolean(selectedRow.Row["hasSmallOption"]);
				smallPriceTextBox.Text = selectedRow.Row["smallItemPrice"].ToString();
				hasSmallPriceCheckBox_CheckedChanged(sender, new EventArgs()); // if theres no small option, can clear
				largePriceTextBox.Text = selectedRow.Row["largeItemPrice"].ToString();
				defaultToLargePriceCheckBox.Checked = Convert.ToBoolean(selectedRow.Row["defaultToLargePrice"]);
				isOutOfStockCheckBox.Checked = Convert.ToBoolean(selectedRow.Row["isOutOfStock"]);
				// need to convert categoryid to name
				int categoryID = Convert.ToInt32(selectedRow.Row["categoryID"]);
				string categoryName = getCategoryNameFromCategoryID(categoryID);
				if (categoryName != null) // if category exists lmao
				{
					categoryComboBox.Text = categoryName;
				}
			}
			else // unselect flop row
			{
				itemDataGridView.ClearSelection();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void hasSmallPriceCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (hasSmallPriceCheckBox.Checked == false)
			{
				// clear and disable small price text box if doesnt have small price
				smallPriceTextBox.Text = string.Empty;
				smallPriceTextBox.Enabled = false;
				// has to default to large price if theres no small price
				defaultToLargePriceCheckBox.Checked = true;
				defaultToLargePriceCheckBox.Enabled = false;
			}
			else
			{
				// enable if has
				smallPriceTextBox.Enabled = true;
				defaultToLargePriceCheckBox.Enabled = true;
			}
		}

		private void addItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesItemExist() == false && areAllFieldsFilled() == true && getCategoryIDFromCategoryName(categoryComboBox.Text) != -1) // if item doesnt alr exist and all required textboxes filled in
			{
				int categoryID = getCategoryIDFromCategoryName(categoryComboBox.Text);
				SqlCommand addFoodItemToDatabase = new SqlCommand();
				addFoodItemToDatabase.Connection = con;
				addFoodItemToDatabase.Parameters.AddWithValue("@FIID", itemIDTextBox.Text);
				addFoodItemToDatabase.Parameters.AddWithValue("@FN", itemNameTextBox.Text);
				addFoodItemToDatabase.Parameters.AddWithValue("@DLP", defaultToLargePriceCheckBox.Checked);
				addFoodItemToDatabase.Parameters.AddWithValue("@LIP", largePriceTextBox.Text);
				addFoodItemToDatabase.Parameters.AddWithValue("@OOS", isOutOfStockCheckBox.Checked);
				addFoodItemToDatabase.Parameters.AddWithValue("@CID", categoryID);
				if (hasSmallPriceCheckBox.Checked) // has small price
				{
					addFoodItemToDatabase.CommandText = "INSERT INTO FoodItemTbl(foodItemID, foodName, defaultToLargePrice, hasSmallOption, smallItemPrice, largeItemPrice, isOutOfStock, categoryID) VALUES(@FIID, @FN, @DLP, 1, @SIP, @LIP, @OOS, @CID)";
					addFoodItemToDatabase.Parameters.AddWithValue("@SIP", smallPriceTextBox.Text);
				}
				else // no small price
				{
					addFoodItemToDatabase.CommandText = "INSERT INTO FoodItemTbl(foodItemID, foodName, defaultToLargePrice, hasSmallOption, largeItemPrice, isOutOfStock, categoryID) VALUES(@FIID, @FN, @DLP, 0, @LIP, @OOS, @CID)";
				}
				addFoodItemToDatabase.ExecuteNonQuery();
				foodItemID = null;
				MessageBox.Show("Item added to database", "Ordering System");
				updateDataGridView();
			}
			else if (doesItemExist() == false) // if not all fields filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else // if item exists
			{
				MessageBox.Show("Item already exists with same name or ID", "Ordering System");
			}
			con.Close();
		}

		private void updateItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllFieldsFilled() == true && getCategoryIDFromCategoryName(categoryComboBox.Text) != -1 && foodItemID != null) // if all fields filled in
			{
				int categoryID = getCategoryIDFromCategoryName(categoryComboBox.Text);
				SqlCommand updateFoodItem = new SqlCommand();
				updateFoodItem.Connection = con;
				updateFoodItem.Parameters.AddWithValue("@FN", itemNameTextBox.Text);
				updateFoodItem.Parameters.AddWithValue("@DLP", defaultToLargePriceCheckBox.Checked);
				updateFoodItem.Parameters.AddWithValue("@LIP", largePriceTextBox.Text);
				updateFoodItem.Parameters.AddWithValue("@OOS", isOutOfStockCheckBox.Checked);
				updateFoodItem.Parameters.AddWithValue("@CID", categoryID);
				updateFoodItem.Parameters.AddWithValue("@FIID", foodItemID);
				if (hasSmallPriceCheckBox.Checked) // has small price
				{
					updateFoodItem.CommandText = "UPDATE FoodItemTbl SET foodName = @FN, defaulttoLargePrice = @DLP, hasSmallOption = 1, smallItemPrice = @SIP, largeItemPrice = @LIP, isOutOfStock = @OOS, categoryID = @CID WHERE foodItemID = @FIID";
					updateFoodItem.Parameters.AddWithValue("@SIP", smallPriceTextBox.Text);
				}
				else // no small price
				{
					updateFoodItem.CommandText = "UPDATE FoodItemTbl SET foodName = @FN, defaulttoLargePrice = @DLP, hasSmallOption = 0, largeItemPrice = @LIP, isOutOfStock = @OOS, categoryID = @CID WHERE foodItemID = @FIID";
				}
				updateFoodItem.ExecuteNonQuery();
				foodItemID = null;
				MessageBox.Show("Item updated", "Ordering System");
				updateDataGridView();
			}
			else if (foodItemID != null) // incomplete form
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else // item not selected
			{
				MessageBox.Show("Item not selected", "Ordering System");
			}
			con.Close();
		}

		private void deleteItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesItemExist() == false) // item not found
			{
				MessageBox.Show("Item not found in database", "Ordering System");
			}
			else if (foodItemID == null) // no food item selected
			{
				MessageBox.Show("Item not selected", "Ordering System");
			}
			else // item found
			{
				// check if item used in setmealfooditemtbl
				SqlCommand checkIfFoodItemUsed = new SqlCommand("SELECT COUNT(*) FROM SetMealFoodItemTbl WHERE foodItemID = @FIID", con);
				checkIfFoodItemUsed.Parameters.AddWithValue("@FIID", foodItemID);
				int instancesOfFoodItemUsed = (int)checkIfFoodItemUsed.ExecuteScalar();
				if (instancesOfFoodItemUsed > 0) // exists
				{
					MessageBox.Show("There is at least one set meal that uses this item. Remove them before deleting this item", "Ordering System");
				}
				else // doesnt exist - can delete
				{
					SqlCommand deleteFoodItem = new SqlCommand("DELETE FROM FoodItemTbl WHERE foodItemID = @FIID", con);
					deleteFoodItem.Parameters.AddWithValue("@FIID", foodItemID);
					deleteFoodItem.ExecuteNonQuery();
					foodItemID = null;
					MessageBox.Show("Item deleted", "Ordering System");
					updateDataGridView();
				}
			}
			con.Close();
		}

		private void itemIDTextBox_Leave(object sender, EventArgs e)
		{
			if (itemIDTextBox.Text.Length > 10) // if id too long for database
			{
				MessageBox.Show("Item ID too long", "Ordering System");
				itemIDTextBox.Focus();
			}
		}

		private void itemNameTextBox_Leave(object sender, EventArgs e)
		{
			if (itemNameTextBox.Text.Length > 50) // if item name too long for database
			{
				MessageBox.Show("Item name too long", "Ordering System");
				itemNameTextBox.Focus();
			}
		}

		private void smallPriceTextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				Convert.ToDecimal(smallPriceTextBox.Text); // check if value is acc decimal
				if (Convert.ToDecimal(smallPriceTextBox.Text) < 0 || Convert.ToDecimal(smallPriceTextBox.Text) >= 1000) // not within range
				{
					MessageBox.Show("Small price not within range", "Ordering System");
					smallPriceTextBox.Focus();
				}
			}
			catch // not decimal
			{
				MessageBox.Show("Small price not a decimal", "Ordering System");
				smallPriceTextBox.Focus();
			}
		}

		private void largePriceTextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				Convert.ToDecimal(largePriceTextBox.Text); // check if value is acc decimal
				if (Convert.ToDecimal(largePriceTextBox.Text) < 0 || Convert.ToDecimal(largePriceTextBox.Text) >= 1000) // not within range
				{
					MessageBox.Show("Large price not within range", "Ordering System");
					largePriceTextBox.Focus();
				}
			}
			catch // not decimal
			{
				MessageBox.Show("Large price not a decimal", "Ordering System");
				largePriceTextBox.Focus();
			}
		}
	}
}
