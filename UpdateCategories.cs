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
	public partial class UpdateCategories : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataView categoriesDataView; // full databases compared to whats shown in datagridview
		int categoryID = -1; // id of selected category from datagridview
		public UpdateCategories()
		{
			InitializeComponent();
		}

		private bool doesCategoryExist() // checks if category exists in database w/ same name
		{
			SqlCommand checkIfCategoryExists = new SqlCommand("SELECT COUNT(*) FROM CategoryTbl WHERE categoryName = @CN", con);
			checkIfCategoryExists.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
			int categoryExists = (int)checkIfCategoryExists.ExecuteScalar();
			if (categoryExists == 0)
			{
				return false;
			}
			return true;
		}

		private bool areAllFieldsFilled() // checks if all fields have been filled in
		{
			if (categoryNameTextBox.Text != "" && categoryIndexTextBox.Text != "")
			{
				return true;
			}
			return false;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UpdateCategories_Load(object sender, EventArgs e)
		{
			con.Open();
			updateDataGridView();
			con.Close();
		}

		private void updateDataGridView()
		{
			SqlDataAdapter getCategories = new SqlDataAdapter("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			DataSet categoriesDataSet = new DataSet();
			getCategories.Fill(categoriesDataSet);
			categoriesDataView = new DataView(categoriesDataSet.Tables[0]);
			// fill in category datagridview
			DataTable categoriesDataTable = categoriesDataView.ToTable(true, "categoryName", "categoryIndex");
			categoryDataGridView.DataSource = categoriesDataTable;
			// fill in default for category index
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
			categoryIndexTextBox.Text = (maxCategoryIndex + 1).ToString();
			categoryNameTextBox.Text = "";
			categoryDataGridView.ClearSelection();
		}

		private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through categoriesdatagridview to find the full deets
			int selectedRowIndex = categoryDataGridView.SelectedCells[0].RowIndex;
			if (categoryDataGridView.RowCount > 1 && selectedRowIndex < categoryDataGridView.RowCount - 1) // just in case theres no selectable rows or u click the blank row
			{
				DataRowView selectedRow = categoriesDataView[selectedRowIndex];
				categoryID = Convert.ToInt32(selectedRow.Row["categoryID"]);
				// update textboxes
				categoryNameTextBox.Text = selectedRow.Row["categoryName"].ToString();
				categoryIndexTextBox.Text = selectedRow.Row["categoryIndex"].ToString();
			}
			else // unselect flop row
			{
				categoryDataGridView.ClearSelection();
			}
		}

		private void addCategoryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (doesCategoryExist() == false && areAllFieldsFilled() == true) // if category doesnt alr exist and all textboxes filled in
			{
				SqlCommand addCategoryToDatabase = new SqlCommand("INSERT INTO CategoryTbl(categoryName, categoryIndex) VALUES(@CN, @CI)", con);
				addCategoryToDatabase.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
				addCategoryToDatabase.Parameters.AddWithValue("@CI", Convert.ToInt32(categoryIndexTextBox.Text));
				addCategoryToDatabase.ExecuteNonQuery();
				MessageBox.Show("Category added to database", "Ordering System");
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

		private void updateCategoryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllFieldsFilled() == true && categoryID != -1) // if all fields filled in
			{
				SqlCommand updateCategory = new SqlCommand("UPDATE CategoryTbl SET categoryName = @CN, categoryIndex = @CI WHERE categoryID = @CID", con);
				updateCategory.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
				updateCategory.Parameters.AddWithValue("@CI", Convert.ToInt32(categoryIndexTextBox.Text));
				updateCategory.Parameters.AddWithValue("@CID", categoryID);
				updateCategory.ExecuteNonQuery();
				MessageBox.Show("Category updated", "Ordering System");
				updateDataGridView();
			}
			else if (areAllFieldsFilled() == true) // category not selected
			{
				MessageBox.Show("Category not selected", "Ordering System");
			}
			else // incomplete form
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			con.Close();
		}

		private void categoryNameTextBox_Leave(object sender, EventArgs e)
		{
			if (categoryNameTextBox.Text.Length > 30) // if category too long for database
			{
				MessageBox.Show("Category name too long", "Ordering System");
				categoryNameTextBox.Focus();
			}
		}

		private void deleteCategoryButton_Click(object sender, EventArgs e) // ADD DEFENSE AGAINST NONE CAT IDS
		{
			con.Open();
			if (doesCategoryExist() == false) // category not found
			{
				MessageBox.Show("Category not found in database", "Ordering System");
			}
			else if (categoryID == -1) // no category selected
			{
				MessageBox.Show("Category not selected", "Ordering System");
			}
			else // category found
			{
				// check if category used in food item tbl
				SqlCommand checkIfCategoryUsed = new SqlCommand("SELECT COUNT(*) FROM FoodItemTbl WHERE categoryID = @CID", con);
				checkIfCategoryUsed.Parameters.AddWithValue("@CID", categoryID);
				int instancesOfCategoryUsed = (int)checkIfCategoryUsed.ExecuteScalar();
				if (instancesOfCategoryUsed > 0)
				{
					MessageBox.Show("There is at least one item that uses this category. Remove them before deleting a category", "Ordering System");
				}
				else
				{
					SqlCommand deleteCategory = new SqlCommand("DELETE FROM CustomerTbl WHERE categoryID = @CID", con);
					deleteCategory.Parameters.AddWithValue("@CID", categoryID);
					deleteCategory.ExecuteNonQuery();
					categoryID = -1;
					MessageBox.Show("Category deleted", "Ordering System");
					updateDataGridView();
				}
			}
			con.Close();
		}

		private void categoryIndexTextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				Convert.ToInt32(categoryIndexTextBox.Text); // check if value is acc int
				if (Convert.ToDecimal(categoryIndexTextBox.Text) < 0) // not within range
				{
					MessageBox.Show("Category index not within range", "Ordering System");
					categoryIndexTextBox.Focus();
				}
			}
			catch // not int
			{
				MessageBox.Show("Category index not an integer", "Ordering System");
				categoryIndexTextBox.Focus();
			}
		}
	}
}
