using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ordering_system
{
	public partial class UpdateItems : Form
	{
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		DataView categoriesDataView, foodItemsDataView; // full databases compared to whats shown in datagridview
		string foodItemID; // id of currently selected item from datagridview
		public UpdateItems()
		{
			InitializeComponent();
		}

		private void UpdateItems_Load(object sender, EventArgs e)
		{
			con.Open();
			// get category table to fill in category combobox
			SqlDataAdapter getCategories = new SqlDataAdapter("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			DataSet categoriesDataSet = new DataSet();
			getCategories.Fill(categoriesDataSet);
			categoriesDataView = new DataView(categoriesDataSet.Tables[0], "", "categoryID", DataViewRowState.CurrentRows);
			// put all names from data reader into list
			List<string> categoryNames = new List<string>();
			foreach (DataRowView category in foodItemsDataView)
			{
				categoryNames.Add(category["categoryName"].ToString());
			}
			// fill in category combobox
			foreach (string categoryName in categoryNames)
			{
				categoryComboBox.Items.Add(categoryName.Trim());
			}
			categoryComboBox.SelectedIndex = 0; // so it doesnt start blank
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
			int selectedCategoryID = categoriesDataView.Find(categoryID);
			if (selectedCategoryID != -1) // if category exists lmao
			{
				categoryComboBox.Text = categoriesDataView[selectedCategoryID]["categoryName"].ToString().Trim();
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
			updateDataGridView();
			con.Close();
		}

		private void updateItemButton_Click(object sender, EventArgs e)
		{
			con.Open();
			updateDataGridView();
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
