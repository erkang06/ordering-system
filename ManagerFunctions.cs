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

		}

		private void updateCustomersButton_Click(object sender, EventArgs e)
		{

		}

		private void orderSummaryButton_Click(object sender, EventArgs e)
		{
			OrderSummary obj = new OrderSummary();
			obj.Show();
			obj.TopMost = true;
		}

		private void changeLoginPasswordButton_Click(object sender, EventArgs e)
		{
			string loginPassword = Interaction.InputBox("Enter the new login password:", "Manager Functions");
			File.WriteAllText(@"./LoginPassword.txt", loginPassword);
			MessageBox.Show("Login password has been changed successfully", "Ordering System");
		}

		private void changeManagerPasswordButton_Click(object sender, EventArgs e)
		{
			string managerPassword = Interaction.InputBox("Enter the new manager password:", "Manager Functions");
			File.WriteAllText(@"./ManagerPassword.txt", managerPassword);
			MessageBox.Show("Manager password has been changed successfully", "Ordering System");
		}
	}
}
