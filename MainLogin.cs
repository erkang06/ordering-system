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
using System.IO;

namespace ordering_system
{
	public partial class MainLogin : Form
	{
		string password;
		public MainLogin()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			if (passwordTextBox.Text == password)
			{
				MainMenu obj = new MainMenu();
				obj.Show();
				//obj.TopMost = true;
				this.Close();
			}
			else
			{
				MessageBox.Show("Password Incorrect", "Ordering system");
				passwordTextBox.Focus();
			}
		}

		private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				acceptButton_Click(sender, e);
			}
		}

		private void MainLogin_Load(object sender, EventArgs e) // get the login password
		{
			try
			{
				StreamReader passwordFile = new StreamReader(@"./LoginPassword.txt");
				password = passwordFile.ReadLine();
				passwordFile.Close();
			}
			catch // if file doesnt exist, set to default
			{
				password = "password";
				File.WriteAllText(@"./LoginPassword.txt", password);
				MessageBox.Show("Password not found so has been reset to 'password'", "Ordering system");
			}
		}
	}
}
