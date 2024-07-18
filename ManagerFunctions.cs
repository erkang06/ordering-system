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
		ConfigurationBuilder configurationBuilder;
		IConfiguration configuration;

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

		private void changeLoginButton_Click(object sender, EventArgs e)
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

		private void ManagerFunctions_Load(object sender, EventArgs e)
		{
			configurationBuilder = new ConfigurationBuilder();
			configuration = configurationBuilder.AddUserSecrets<ManagerFunctions>().Build();
		}

		private void orderSummaryButton_Click(object sender, EventArgs e)
		{

		}
	}
}
