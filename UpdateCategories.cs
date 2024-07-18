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
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		DataView categoriesDataView;
		int categoryID, categoryExists;
		public UpdateCategories()
		{
			InitializeComponent();
		}

		private void checkIfCategoryExists() // checks if category exists in database w/ same name - output = # of categories w/ name
		{
			SqlCommand checkIfCategoryExists = new SqlCommand("SELECT COUNT(*) FROM CategoryTbl WHERE categoryName = @CN", con);
			checkIfCategoryExists.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
			categoryExists = (int)checkIfCategoryExists.ExecuteScalar();
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
			DataSet addressesDataSet = new DataSet();
			getCategories.Fill(addressesDataSet);
			categoriesDataView = new DataView(addressesDataSet.Tables[0]);
			// fill in category datagridview
			DataTable categoriesDataTable = categoriesDataView.ToTable(true, "categoryName", "categoryIndex");
			categoryDataGridView.DataSource = categoriesDataTable;
			// fill in default for category index
			SqlCommand findMaxCategoryIndex = new SqlCommand("SELECT MAX(categoryIndex) FROM CategoryTbl", con);
			findMaxCategoryIndex.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
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
			categoryNameTextBox.Text = string.Empty;
		}

		private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through categoriesdatagridview to find the full deets
			int selectedRowIndex = categoryDataGridView.SelectedCells[0].RowIndex;
			DataRowView selectedRow = categoriesDataView[selectedRowIndex];
			categoryID = Convert.ToInt32(selectedRow.Row["categoryID"]);
			// update category
			categoryNameTextBox.Text = selectedRow.Row["categoryName"].ToString().Trim();
			categoryIndexTextBox.Text = selectedRow.Row["categoryIndex"].ToString().Trim();
		}

		private void addCategoryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			checkIfCategoryExists();
			if (categoryExists == 0 && areAllFieldsFilled() == true) // if category doesnt alr exist and all textboxes filled in
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
			if (areAllFieldsFilled() == true) // if all fields filled in
			{
				SqlCommand updateCategory = new SqlCommand("UPDATE CategoryTbl SET categoryName = @CN, categoryIndex = @CI WHERE categoryID = @CID", con);
				updateCategory.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
				updateCategory.Parameters.AddWithValue("@CI", Convert.ToInt32(categoryIndexTextBox.Text));
				updateCategory.Parameters.AddWithValue("@CID", categoryID);
				updateCategory.ExecuteNonQuery();
				MessageBox.Show("Category name updated", "Ordering System");
				updateDataGridView();
			}
			else
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

		private void deleteCategoryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			checkIfCategoryExists();
			if (categoryExists == 0) // category not found
			{
				MessageBox.Show("Category not found in database", "Ordering System");
			}
			else // category found
			{
				SqlCommand deleteCategory = new SqlCommand("DELETE FROM CustomerTbl WHERE categoryID = @CID", con);
				deleteCategory.Parameters.AddWithValue("@CN", categoryID);
				deleteCategory.ExecuteNonQuery();
				MessageBox.Show("Customer deleted", "Ordering System");
				updateDataGridView();
			}
			con.Close();
		}

		private void categoryIndexTextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				Convert.ToInt32(categoryIndexTextBox); // check if value is acc int
			}
			catch // not int
			{
				MessageBox.Show("Category index not an integer", "Ordering System");
				categoryIndexTextBox.Focus();
			}
		}
	}
}
