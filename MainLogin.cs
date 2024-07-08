using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordering_system
{
	public partial class MainLogin : Form
	{
		public MainLogin()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			if (passwordTextBox.Text == "password")
			{
				MainMenu obj = new MainMenu();
				obj.Show();
				obj.TopMost = true;
				this.Close();
			}
			else
			{
				MessageBox.Show("Password Incorrect", "Ordering system");
			}
		}
	}
}
