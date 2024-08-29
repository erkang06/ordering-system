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
		string itemID; // id of currently selected item/setmeal from datagridview
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
			// get common items
			SqlDataAdapter getCommonItems = new SqlDataAdapter("SELECT * FROM CommonItemTbl", con);
			getCommonItems.Fill(commonItemsDataTable);
			loadCommonItemButtons();
			con.Close();
		}

		private void loadCommonItemButtons() // fill in commonitemspanel w/ buttons
		{
			// fill in food buttons
			int xpos = 0, ypos = 0;
			for (int i = 0; i < commonItemButtonArray.Length; i++) // cant be more than array length
			{
				// create each food button
				commonItemButtonArray[i] = new Button();
				commonItemButtonArray[i].UseMnemonic = false; // allows for &
				commonItemButtonArray[i].Tag = commonItemsDataTable.Rows[i][0].ToString(); // get id
				commonItemButtonArray[i].Text = commonItemsDataTable.Rows[i][1].ToString(); // get name
				commonItemButtonArray[i].Width = 250;
				commonItemButtonArray[i].Height = 100;
				commonItemButtonArray[i].Left = xpos;
				commonItemButtonArray[i].Top = ypos;
				commonItemButtonArray[i].BackColor = Color.AntiqueWhite;
				//commonItemButtonArray[i].MouseClick += new MouseEventHandler(itemButton_Click);
				commonItemsPanel.Controls.Add(commonItemButtonArray[i]);
				xpos += 250;
				if ((i + 1) % 4 == 0) // new row
				{
					xpos = 0;
					ypos += 100;
				}
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

		}
	}
}
