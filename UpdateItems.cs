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
	public partial class UpdateItems : Form
	{
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\benny\Documents\CS\NEA\ordering system\Ordering System.mdf;Integrated Security=True;Connect Timeout=30");
		DataView categoriesDataView;
		public UpdateItems()
		{
			InitializeComponent();
		}

		private void UpdateItems_Load(object sender, EventArgs e)
		{
			con.Open();
			// populate category autocomplete thingy yk
			SqlDataAdapter getCategories = new SqlDataAdapter("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			DataSet categoriesDataSet = new DataSet();
			getCategories.Fill(categoriesDataSet);
			categoriesDataView = new DataView(categoriesDataSet.Tables[0]);
			DataTable categoriesDataTable = categoriesDataView.ToTable();
			categoryComboBox.DataSource = categoriesDataTable.Columns.Cast<DataColumn>().ToList();
			categoryComboBox.ValueMember = "categoryName";
			categoryComboBox.DisplayMember = "categoryName";
			con.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
