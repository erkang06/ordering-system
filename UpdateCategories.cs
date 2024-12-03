using ordering_system.Properties;
using System.Data;
using System.Data.SqlClient;

namespace ordering_system
{
	public partial class UpdateCategories : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataTable categoriesDataTable; // full datatable compared to whats shown in datagridview
		int categoryID = -1; // id of selected category from datagridview
		public UpdateCategories()
		{
			InitializeComponent();
		}

		// common use functions

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

		private void clearCategoryScreen() // clears textboxes and categoryid
		{
			categoryID = -1;
			categoryNameTextBox.Text = string.Empty;
			categoryIndexTextBox.Text = string.Empty;
		}

		// sorting the form out

		private void UpdateCategories_Load(object sender, EventArgs e)
		{
			con.Open();
			updateDataGridView();
			con.Close();
		}

		private void updateDataGridView()
		{
			categoriesDataTable = new DataTable(); // clear prev
																						 // get categories from categorytbl
			SqlDataAdapter getCategories = new SqlDataAdapter("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			getCategories.Fill(categoriesDataTable);
			DataView categoriesDataView = new DataView(categoriesDataTable);
			// fill in category datagridview - clear bf adding in again
			categoryDataGridView.DataSource = null;
			categoryDataGridView.DataSource = categoriesDataView.ToTable(true, "categoryName", "categoryIndex");
			categoryDataGridView.Columns["categoryIndex"].Width = 300;
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
			// check if max # of categories reached
			if (categoriesDataTable.Rows.Count >= 24)
			{
				addCategoryButton.Enabled = false;
			}
			else
			{
				addCategoryButton.Enabled = true;
			}
			categoryIndexTextBox.Text = (maxCategoryIndex + 1).ToString();
			categoryNameTextBox.Text = string.Empty;
			categoryDataGridView.ClearSelection();
		}

		// form related + data validation

		private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// find clicked row of table in order to search through categoriesdatatable to find the full deets
			int selectedRowIndex = e.RowIndex;
			if (selectedRowIndex > -1) // just in case u click the header
			{
				// find associated row in categoriesdataview
				string categoryName = categoryDataGridView.Rows[selectedRowIndex].Cells["categoryName"].Value.ToString();
				DataRow selectedRow = categoriesDataTable.Select($"categoryName = '{categoryName}'")[0];
				categoryID = Convert.ToInt32(selectedRow["categoryID"]);
				// update textboxes
				categoryNameTextBox.Text = selectedRow["categoryName"].ToString();
				categoryIndexTextBox.Text = selectedRow["categoryIndex"].ToString();
			}
		}

		private void categoryNameTextBox_Leave(object sender, EventArgs e)
		{
			if (categoryNameTextBox.Text.Length > 30) // if category too long for database
			{
				MessageBox.Show("Category name too long", "Ordering System");
				categoryNameTextBox.Focus();
			}
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

		// sql functions

		private void addCategoryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			if (areAllFieldsFilled() == false) // not all textboxes filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else if (doesCategoryExist()) // if category exists
			{
				MessageBox.Show("Category already exists with same name", "Ordering System");
			}
			else // if category doesnt alr exist and all textboxes filled in
			{
				SqlCommand addCategoryToDatabase = new SqlCommand("INSERT INTO CategoryTbl(categoryName, categoryIndex) VALUES(@CN, @CI)", con);
				addCategoryToDatabase.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
				addCategoryToDatabase.Parameters.AddWithValue("@CI", Convert.ToInt32(categoryIndexTextBox.Text));
				addCategoryToDatabase.ExecuteNonQuery();
				MessageBox.Show("Category added to database", "Ordering System");
				clearCategoryScreen();
				updateDataGridView();
			}
			con.Close();
		}

		private void updateCategoryButton_Click(object sender, EventArgs e)
		{
			con.Open();
			// get if category name has been changed - for checking if item exists w/ same name
			bool hasCategoryNameChanged = true;
			DataRow[] selectedRow = categoriesDataTable.Select($"categoryID = '{categoryID}'");
			if (selectedRow.Length > 0) // therell only be one since its a primary key
			{
				string currentCategoryName = selectedRow[0]["categoryName"].ToString();
				if (currentCategoryName == categoryNameTextBox.Text)
				{
					hasCategoryNameChanged = false;
				}
			}
			// acc validating data
			if (areAllFieldsFilled() == false) // not all textboxes filled in
			{
				MessageBox.Show("Not all fields filled in", "Ordering System");
			}
			else if (categoryID == -1) // category not selected
			{
				MessageBox.Show("Category not selected", "Ordering System");
			}
			else if (hasCategoryNameChanged && doesCategoryExist()) // if new category name has already been used in tbl
			{
				MessageBox.Show("Category already exists with the same name", "Ordering System");
			}
			else // if category doesnt alr exist and all textboxes filled in
			{
				SqlCommand updateCategory = new SqlCommand("UPDATE CategoryTbl SET categoryName = @CN, categoryIndex = @CI WHERE categoryID = @CID", con);
				updateCategory.Parameters.AddWithValue("@CN", categoryNameTextBox.Text);
				updateCategory.Parameters.AddWithValue("@CI", Convert.ToInt32(categoryIndexTextBox.Text));
				updateCategory.Parameters.AddWithValue("@CID", categoryID);
				updateCategory.ExecuteNonQuery();
				MessageBox.Show("Category updated", "Ordering System");
				clearCategoryScreen();
				updateDataGridView();
			}
			con.Close();
		}

		private void deleteCategoryButton_Click(object sender, EventArgs e)
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
				// check if category used in fooditemtbl
				SqlCommand checkIfCategoryUsed = new SqlCommand("SELECT COUNT(*) FROM FoodItemTbl WHERE categoryID = @CID", con);
				checkIfCategoryUsed.Parameters.AddWithValue("@CID", categoryID);
				int instancesOfCategoryUsed = (int)checkIfCategoryUsed.ExecuteScalar();
				if (instancesOfCategoryUsed > 0) // exists
				{
					MessageBox.Show("There is at least one item that uses this category. Remove them before deleting this category", "Ordering System");
				}
				else // doesnt exist - can delete
				{
					SqlCommand deleteCategory = new SqlCommand("DELETE FROM CategoryTbl WHERE categoryID = @CID", con);
					deleteCategory.Parameters.AddWithValue("@CID", categoryID);
					deleteCategory.ExecuteNonQuery();
					MessageBox.Show("Category deleted", "Ordering System");
					clearCategoryScreen();
					updateDataGridView();
				}
			}
			con.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
