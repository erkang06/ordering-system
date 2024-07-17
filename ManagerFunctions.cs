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
			this.Close();
		}

		private void exitProgramButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void changeLoginButton_Click(object sender, EventArgs e)
		{
			string loginPassword = Interaction.InputBox("Enter the new login password:", "Manager Functions", "asda");
			File.WriteAllText(@"./Passwords/LoginPassword.txt", loginPassword);
		}

		private void changeManagerPasswordButton_Click(object sender, EventArgs e)
		{
			string managerPassword = Interaction.InputBox("Enter the new manager password:", "Manager Functions", "asda");
			File.WriteAllText(@"./Passwords/ManagerPassword.txt", managerPassword);
		}

		private void ManagerFunctions_Load(object sender, EventArgs e)
		{
			configurationBuilder = new ConfigurationBuilder();
			configuration = configurationBuilder.AddUserSecrets<ManagerFunctions>().Build();
		}
	}
}
