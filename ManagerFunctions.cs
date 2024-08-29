using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ordering_system
{
	public partial class ManagerFunctions : Form
	{

		public ManagerFunctions()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void exitProgramButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void updateCategoriesButton_Click(object sender, EventArgs e)
		{
			UpdateCategories obj = new UpdateCategories();
			obj.Show();
			obj.TopMost = true;
		}

		private void updateItemsButton_Click(object sender, EventArgs e)
		{
			UpdateItems obj = new UpdateItems();
			obj.Show();
			obj.TopMost = true;
		}

		private void updateSetMealsButton_Click(object sender, EventArgs e)
		{
			UpdateSetMeals obj = new UpdateSetMeals();
			obj.Show();
			obj.TopMost = true;
		}

		private void updateCustomersButton_Click(object sender, EventArgs e)
		{
			UpdateCustomers obj = new UpdateCustomers();
			obj.Show();
			//obj.TopMost = true;
		}

		private void orderSummaryButton_Click(object sender, EventArgs e)
		{
			OrderSummary obj = new OrderSummary();
			obj.Show();
			//obj.TopMost = true;
		}

		private void changeLoginPasswordButton_Click(object sender, EventArgs e)
		{
			changePassword("Login");
		}

		private void changeManagerPasswordButton_Click(object sender, EventArgs e)
		{
			changePassword("Manager");
		}

		private void changePassword(string passwordType) // theyre literally the same so like might as well
		{
			ChangePassword obj = new ChangePassword(passwordType);
			if (obj.ShowDialog(this) == DialogResult.OK) // if accept button clicked
			{
				File.WriteAllText(@$"./{passwordType}Password.txt", obj.getPassword());
				MessageBox.Show($"{passwordType} password has been changed successfully", "Ordering System");
				obj.Close();
			}
			obj.Dispose();
		}
	}
}
