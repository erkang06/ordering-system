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

namespace ordering_system
{
	public partial class ManagerFunctionsLogin : Form
	{
		string password;
		public ManagerFunctionsLogin()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			if (passwordTextBox.Text == password)
			{
				ManagerFunctions obj = new ManagerFunctions();
				obj.Show();
				obj.TopMost = true;
				this.Close();
			}
			else
			{
				MessageBox.Show("Password Incorrect", "Manager Functions");
				passwordTextBox.Focus();
			}
		}

		private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				acceptButton_Click((object)sender, e);
			}
		}

		private void ManagerFunctionsLogin_Load(object sender, EventArgs e) // get the manager password
		{
			try
			{
				StreamReader passwordFile = new StreamReader(@"./ManagerPassword.txt");
				password = passwordFile.ReadLine().Trim();
				passwordFile.Close();
			}
			catch // if file doesnt exist, set to default
			{
				password = "password";
				File.WriteAllText(@"./ManagerPassword.txt", password);
				MessageBox.Show("Password not found so has been reset to 'password'", "Ordering system");
			}
		}
	}
}
