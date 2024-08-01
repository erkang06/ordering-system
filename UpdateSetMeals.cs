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
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		DataView foodItemsDataView, setMealsDataView; // full database compared to whats shown in datagridview
		DataSet categoriesDataSet; // same as above xoxo
		string foodItemID; // id of currently selected item from datagridview

		public UpdateSetMeals()
		{
			InitializeComponent();
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
			foreach (string categoryName in categoryNames)
			{
				categoryComboBox.Items.Add(categoryName.Trim());
			}
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
	}
}
