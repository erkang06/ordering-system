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
				return categoriesDataViewSortByID[categoryIDIndex]["categoryName"].ToString().Trim();
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
				categoryNames.Add(category["categoryName"].ToString().Trim());
			}
			// fill in category combobox
			bool setMealExists = false; // checks if set meal exists in categorytbl
			foreach (string categoryName in categoryNames)
			{
				if (categoryName.Trim() != "Set Meals") // you cant add set meals to a set meal xoxo
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
				MessageBox.Show("Set meals didn't exist as a category, so has been added to database", "Ordering System");
			}
			// sort out setmealfooditemsdatatable
			setMealFoodItemsDataTable = new DataTable();
			setMealFoodItemsDataTable.Columns.Add("foodItemID");
			setMealFoodItemsDataTable.Columns.Add("foodName");
			setMealFoodItemsDataTable.Columns.Add("size");
			setMealFoodItemsDataTable.Columns.Add("quantity");
			setMealItemDataGridView.DataSource = setMealFoodItemsDataTable;
			updateSetMealDataGridView();
			con.Close();
		}

		private void updateSetMealDataGridView()
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
				foodItemID = selectedRow["foodItemID"].ToString().Trim();
				int foodItemIndex = doesFoodItemExist(foodItemID); // find index of food in set meal datatable if exists
				if (foodItemIndex == -1) // food item doesnt alr exist in set meal
				{
					// creating record for datagridview
					DataRow setMealFoodItemNewRow = setMealFoodItemsDataTable.NewRow();
					setMealFoodItemNewRow[0] = foodItemID;
					setMealFoodItemNewRow[1] = selectedRow["foodName"].ToString().Trim();
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
			// find clicked row of table in order to search through setmealdataview to find the full deets
			int selectedRowIndex = setMealDataGridView.SelectedCells[0].RowIndex;
			if (setMealDataGridView.RowCount > 1 && selectedRowIndex < setMealDataGridView.RowCount - 1) // just in case theres no rows
			{

			}
			else // unselect flop row
			{
				setMealDataGridView.ClearSelection();
			}
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
	}
}
