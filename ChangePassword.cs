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
	public partial class ChangePassword : Form
	{
		public ChangePassword(string passwordType)
		{
			InitializeComponent();
			if (passwordType == "Login")
			{
				passwordTypeLabel.Text = "Login Password";
				helpLabel.Text = "Please enter the new login password:";
			}
			else // manager
			{
				passwordTypeLabel.Text = "Manager Password";
				helpLabel.Text = "Please enter the new manager password:";
			}
		}

		public string getPassword()
		{
			return passwordTextBox.Text;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			if (passwordTextBox.Text.Length > 0) // if smts in the passwordtextbox yk
			{
				DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("No password entered", "Ordering system");
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
	}
}
