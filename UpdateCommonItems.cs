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
	public partial class UpdateCommonItems : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataTable categoriesDataTable = new DataTable(); // full datatable compared to whats shown in datagridview
		DataTable commonItemsDataTable = new DataTable();
		DataTable itemsDataTableByCategory;
		Button[] commonItemButtonArray = new Button[20];
		string itemID = "", itemType = ""; // id + itemtype of currently selected item/setmeal from datagridview
		int commonItemID = -1; // which space its gonna take in the commonitemarray
		public UpdateCommonItems()
		{
			InitializeComponent();
		}

		private int getCategoryIDFromSelectedIndex()
		{
			int selectedIndex = categoryComboBox.SelectedIndex;
			if (selectedIndex > -1) // if category exists lmao
			{
				return Convert.ToInt32(categoriesDataTable.Rows[selectedIndex]["categoryID"]);
			}
			return -1;
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

		private int doesItemExistInCommonItems(string itemID) // returns index of food item in set meal if exists, else returns -1
		{
			DataRow[] item = commonItemsDataTable.Select($"itemID = '{itemID}'");
			if (item.Length > 0) // theres only max 1 instance of an each item in the common items grid
			{
				int index = Convert.ToInt32(item[0]["commonItemID"]);
				return index;
			}
			return -1;
		}

		private void removeCommonItemFromDatabase()
		{
			SqlCommand removeCommonItemFromDatabase = new SqlCommand("DELETE FROM CommonItemTbl WHERE commonItemID = @CIID", con);
			removeCommonItemFromDatabase.Parameters.AddWithValue("@CIID", commonItemID);
			removeCommonItemFromDatabase.ExecuteNonQuery();
		}

		private void UpdateCommonItems_Load(object sender, EventArgs e)
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
			foreach (string categoryName in categoryNames)
			{
				categoryComboBox.Items.Add(categoryName);
			}
			updateCommonItemsDataTable();
			loadCommonItemButtons();
			con.Close();
		}

		private void updateCommonItemsDataTable() // get common items
		{
			commonItemsDataTable = new DataTable(); // clear prev
			SqlDataAdapter getCommonItems = new SqlDataAdapter("SELECT * FROM CommonItemTbl", con);
			getCommonItems.Fill(commonItemsDataTable);
		}

		private void loadCommonItemButtons() // fill in commonitemspanel w/ buttons
		{
			// sort out sql
			DataRow[] commonItemDataRow;
			// fill in food buttons
			int xpos = 0, ypos = 0;
			for (int i = 0; i < commonItemButtonArray.Length; i++) // cant be more than array length
			{
				// sort out sql
				commonItemDataRow = commonItemsDataTable.Select($"commonItemID = '{i}'");
				// create each food button
				commonItemButtonArray[i] = new Button();
				commonItemButtonArray[i].UseMnemonic = false; // allows for &
				if (commonItemDataRow.Length > 0) // if theres any item in that space
				{ // u can do 0 cuz its a primary key so theres only gonna be max 1 row
					commonItemButtonArray[i].Tag = commonItemDataRow[0]["itemID"].ToString(); // get id
					if (commonItemDataRow[0]["itemType"].ToString() == "foodItem")
					{
						commonItemButtonArray[i].Text = getFoodItemName(commonItemDataRow[0]["itemID"].ToString());
					}
					else // set meal
					{
						commonItemButtonArray[i].Text = getSetMealName(commonItemDataRow[0]["itemID"].ToString());
					}
				}
				commonItemButtonArray[i].Width = 250;
				commonItemButtonArray[i].Height = 80;
				commonItemButtonArray[i].Left = xpos;
				commonItemButtonArray[i].Top = ypos;
				commonItemButtonArray[i].BackColor = Color.Transparent;
				commonItemButtonArray[i].MouseClick += new MouseEventHandler(commonItemButton_Click);
				commonItemsPanel.Controls.Add(commonItemButtonArray[i]);
				xpos += 250;
				if ((i + 1) % 4 == 0) // new row
				{
					xpos = 0;
					ypos += 80;
				}
			}
		}

		private void commonItemButton_Click(object sender, MouseEventArgs e)
		{
			// unselect prev button
			if (commonItemID > -1)
			{
				commonItemButtonArray[commonItemID].BackColor = Color.Transparent;
			}
			Button commonItemButton = (Button)sender;
			commonItemButton.BackColor = Color.Gold;
			commonItemID = (commonItemButton.Location.Y / 80) * 4 + (commonItemButton.Location.X / 250);
			// u can link item to common item space // if a buttons been selected
			if (itemID != "" && itemType != "")
			{
				addCommonItem();
			}
		}

		private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			con.Open();
			itemsDataTableByCategory = new DataTable(); // clear prev
			int categoryID = getCategoryIDFromSelectedIndex();
			SqlDataAdapter getItemsByCategory = new SqlDataAdapter();
			string[] dataViewColumnNames = ["foodItemID", "foodName"];
			if (categoryComboBox.Text == "Set Meals")
			{
				getItemsByCategory = new SqlDataAdapter("SELECT * FROM SetMealTbl", con);
				dataViewColumnNames = ["setMealID", "setMealName"];
			}
			else // any reg food items
			{
				getItemsByCategory = new SqlDataAdapter("SELECT * FROM FoodItemTbl WHERE categoryID = @CID ORDER BY foodItemID", con);
				getItemsByCategory.SelectCommand.Parameters.AddWithValue("@CID", categoryID);
			}
			getItemsByCategory.Fill(itemsDataTableByCategory);
			DataView foodItemsDataViewByCategory = new DataView(itemsDataTableByCategory);
			// fill in set meals datagridview
			itemDataGridView.DataSource = foodItemsDataViewByCategory.ToTable(true, dataViewColumnNames);
			itemDataGridView.Columns[0].Width = 100; // first column is id no matter what
			itemDataGridView.ClearSelection();
			con.Close();
		}

		private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				if (categoryComboBox.Text == "Set Meals")
				{
					itemID = itemDataGridView.Rows[selectedRowIndex].Cells["setMealID"].Value.ToString();
					itemType = "setMeal";
				}
				else // reg food items
				{
					itemID = itemDataGridView.Rows[selectedRowIndex].Cells["foodItemID"].Value.ToString();
					itemType = "foodItem";
				}
				// u can link item to common item space // if a buttons been selected
				if (commonItemID > -1)
				{
					addCommonItem();
				}
			}
		}

		private void addCommonItem()
		{
			con.Open();
			int commonItemIndex = doesItemExistInCommonItems(itemID);
			if (commonItemIndex > -1) // if item alr existed in common item tbl
			{
				SqlCommand removeExistingItemFromDatabase = new SqlCommand("DELETE FROM CommonItemTbl WHERE itemID = @IID", con);
				removeExistingItemFromDatabase.Parameters.AddWithValue("@IID", itemID);
				removeExistingItemFromDatabase.ExecuteNonQuery();
				// clear that button
				commonItemButtonArray[commonItemIndex].Tag = null;
				commonItemButtonArray[commonItemIndex].Text = string.Empty;
			}
			// remove prev space if existed
			if (commonItemButtonArray[commonItemID].Tag != null)
			{
				removeCommonItemFromDatabase();
			}
			// add to database
			SqlCommand addCommonItemToDatabase = new SqlCommand("INSERT INTO CommonItemTbl(commonItemID, itemID, itemType) VALUES(@CIID, @IID, @IT)", con);
			addCommonItemToDatabase.Parameters.AddWithValue("@CIID", commonItemID);
			addCommonItemToDatabase.Parameters.AddWithValue("@IID", itemID);
			addCommonItemToDatabase.Parameters.AddWithValue("@IT", itemType);
			addCommonItemToDatabase.ExecuteNonQuery();
			// add to buttons
			commonItemButtonArray[commonItemID].Tag = itemID;
			// get item name
			if (itemType == "foodItem")
			{
				commonItemButtonArray[commonItemID].Text = getFoodItemName(itemID);
			}
			else // set meal
			{
				commonItemButtonArray[commonItemID].Text = getSetMealName(itemID);
			}
			// clear values and unselect
			commonItemButtonArray[commonItemID].BackColor = Color.Transparent;
			commonItemID = -1;
			itemID = string.Empty;
			itemType = string.Empty;
			itemDataGridView.ClearSelection();
			// update datatable
			updateCommonItemsDataTable();
			con.Close();
		}

		private void deleteItemButton_Click(object sender, EventArgs e) // delete common item
		{
			con.Open();
			if (commonItemID > -1) // if item selected
			{
				removeCommonItemFromDatabase();
				// clear common item values and unselect
				commonItemButtonArray[commonItemID].Text = string.Empty;
				commonItemButtonArray[commonItemID].BackColor = Color.Transparent;
				commonItemID = -1;
				// update datatable
				updateCommonItemsDataTable();
			}
			else
			{
				MessageBox.Show("Item not selected from common items", "Ordering System");
			}
			con.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
