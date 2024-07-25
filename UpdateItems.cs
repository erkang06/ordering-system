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
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		DataView foodItemsDataView; // full database compared to whats shown in datagridview
		DataSet categoriesDataSet; // same as above xoxo
		string foodItemID; // id of currently selected item from datagridview
		public UpdateItems()
		{
			InitializeComponent();
		}

		private bool doesCategoryExist() // checks if category exists in database w/ same name
		{
			SqlCommand checkIfCategoryExists = new SqlCommand("SELECT COUNT(*) FROM CategoryTbl WHERE categoryName = @CN", con);
			checkIfCategoryExists.Parameters.AddWithValue("@CN", categoryComboBox.Text);
			int categoryExists = (int)checkIfCategoryExists.ExecuteScalar();
			if (categoryExists == 0)
			{
				return false;
			}
			return true;
		}

		private bool doesItemExist() // checks if item exists in database w/ same name
		{
			SqlCommand checkIfItemExists = new SqlCommand("SELECT COUNT(*) FROM FoodItemTbl WHERE foodName = @FN", con);
			checkIfItemExists.Parameters.AddWithValue("@FN", itemNameTextBox.Text);
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
				return Convert.ToInt32(categoriesDataViewSortByName[categoryNameIndex]["categoryName"]);
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
				categoryNames.Add(category["categoryName"].ToString());
			}
			// fill in category combobox
			foreach (string categoryName in categoryNames)
			{
				categoryComboBox.Items.Add(categoryName.Trim());
			}
			updateDataGridView();
			con.Close();
		}

		private void updateDataGridView()
		{
			SqlDataAdapter getFoodItems = new SqlDataAdapter("SELECT FoodItemTbl.* FROM FoodItemTbl, CategoryTbl WHERE FoodItemTbl.categoryID = CategoryTbl.categoryID ORDER BY CategoryTbl.categoryIndex, FoodItemTbl.foodItemID", con);
			DataSet foodItemsDataSet = new DataSet();
			getFoodItems.Fill(foodItemsDataSet);
			foodItemsDataView = new DataView(foodItemsDataSet.Tables[0]);
			// fill in category datagridview
			DataTable foodItemsDataTable = foodItemsDataView.ToTable(true, "foodItemID", "foodName", "smallItemPrice", "largeItemPrice");
			itemDataGridView.DataSource = foodItemsDataTable;
		}

		private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through fooditemsdatagridview to find the full deets
			int selectedRowIndex = itemDataGridView.SelectedCells[0].RowIndex;
			DataRowView selectedRow = foodItemsDataView[selectedRowIndex];
			foodItemID = selectedRow.Row["foodItemID"].ToString().Trim();
			// update textboxes and checkboxes
			itemIDTextBox.Text = foodItemID;
			itemNameTextBox.Text = selectedRow.Row["categoryIndex"].ToString().Trim();
			hasSmallPriceCheckBox.Checked = Convert.ToBoolean(selectedRow.Row["hasSmallOption"]);
			smallPriceTextBox.Text = selectedRow.Row["smallItemPrice"].ToString().Trim();
			hasSmallPriceCheckBox_CheckedChanged(sender, new EventArgs()); // if theres no small option, can clear
			largePriceTextBox.Text = selectedRow.Row["largeItemPrice"].ToString().Trim();
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

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void hasSmallPriceCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (hasSmallPriceCheckBox.Checked == false)
			{
				// clear and disable if doesnt have small price
				smallPriceTextBox.Text = string.Empty;
				smallPriceTextBox.Enabled = false;
			}
			else
			{
				// enable if has
				smallPriceTextBox.Enabled = true;
			}
		}

		private void addItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesItemExist() == false && areAllFieldsFilled() == true && getCategoryIDFromCategoryName(categoryComboBox.Text) != -1) // if category doesnt alr exist and all required textboxes filled in
			{
				int categoryID = getCategoryIDFromCategoryName(categoryComboBox.Text);
				SqlCommand addFoodItemToDatabase = new SqlCommand();
				addFoodItemToDatabase.Parameters.AddWithValue("@FN", itemNameTextBox.Text);
				addFoodItemToDatabase.Parameters.AddWithValue("@DLP", defaultToLargePriceCheckBox.Checked);
				addFoodItemToDatabase.Parameters.AddWithValue("@LIP", largePriceTextBox.Text);
				addFoodItemToDatabase.Parameters.AddWithValue("@OOS", isOutOfStockCheckBox.Checked);
				addFoodItemToDatabase.Parameters.AddWithValue("@CID", categoryID);
				if (hasSmallPriceCheckBox.Checked) // has small price
				{
					addFoodItemToDatabase.CommandText = "INSERT INTO FoodItemTbl(foodName, defaultToLargePrice, hasSmallOption, smallItemPrice, largeItemPrice, isOutOfStock, categoryID) VALUES(@FN, @DLP, 1, @SIP, @LIP, @OOS, @CID)";
					addFoodItemToDatabase.Parameters.AddWithValue("@SIP", smallPriceTextBox.Text);
				}
				else // no small price
				{
					addFoodItemToDatabase.CommandText = "INSERT INTO FoodItemTbl(foodName, defaultToLargePrice, hasSmallOption, largeItemPrice, isOutOfStock, categoryID) VALUES(@FN, @DLP, 0, @LIP, @OOS, @CID)";
				}
				addFoodItemToDatabase.ExecuteNonQuery();
				MessageBox.Show("Item added to database", "Ordering System");
				updateDataGridView();
			}
			else if (areAllFieldsFilled() == true) // if category exists
			{
				MessageBox.Show("Category already exists with same name", "Ordering System");
			}
			else // if not all fields filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			con.Close();
		}

		private void updateItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllFieldsFilled() == true && getCategoryIDFromCategoryName(categoryComboBox.Text) != -1) // if all fields filled in
			{
				SqlCommand updateItem = new SqlCommand("UPDATE CategoryTbl SET categoryName = @CN, categoryIndex = @CI WHERE categoryID = @CID", con);
				updateItem.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
				updateItem.Parameters.AddWithValue("@CI", Convert.ToInt32(categoryIndexTextBox.Text));
				updateItem.Parameters.AddWithValue("@CID", categoryID);
				updateItem.ExecuteNonQuery();
				MessageBox.Show("Item updated", "Ordering System");
				updateDataGridView();
			}
			else
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			con.Close();
		}

		private void deleteItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			updateDataGridView();
			con.Close();
		}
	}
}
