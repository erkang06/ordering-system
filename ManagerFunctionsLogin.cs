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
	public partial class ManagerFunctionsLogin : Form
	{
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
			if (passwordTextBox.Text == "password")
			{
				ManagerFunctions obj = new ManagerFunctions();
				obj.Show();
				obj.TopMost = true;
				this.Close();
			}
			else
			{
				MessageBox.Show("Password Incorrect", "Manager Functions");
			}
		}
	}
}
