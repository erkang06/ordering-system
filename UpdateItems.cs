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
		DataView categoriesDataView;
		public UpdateItems()
		{
			InitializeComponent();
		}

		private void UpdateItems_Load(object sender, EventArgs e)
		{
			con.Open();
			// get category table to fill in category combobox
			SqlCommand getCategories = new SqlCommand("SELECT * FROM CategoryTbl ORDER BY categoryIndex", con);
			SqlDataReader categoriesDataReader = getCategories.ExecuteReader();
			// put all names from data reader into list
			List<string> categoryNames = new List<string>();
			while (categoriesDataReader.Read())
			{
				categoryNames.Add(categoriesDataReader[1].ToString());
			}
			// fill in category combobox
			foreach (string categoryName in categoryNames)
			{
				categoryComboBox.Items.Add(categoryName.Trim());
			}
			con.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
