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
using System.Security.Cryptography;
using System.IO;

namespace ordering_system
{
	public partial class MainLogin : Form
	{
		string password;
		// different if for login or for manager funcions
		string entropyFile, cipherFile;
		public MainLogin(string passwordType)
		{
			InitializeComponent();
			// different if for login or for manager funcions
			if (passwordType == "Login")
			{
				loginLabel.Text = "Ordering System";
				entropyFile = "loginEntropy.txt";
				cipherFile = "loginCipher.txt";
			}
			else // manager
			{
				loginLabel.Text = "Manager Password";
				entropyFile = "managerEntropy.txt";
				cipherFile = "managerCipher.txt";
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			if (passwordTextBox.Text == password)
			{
				DialogResult = DialogResult.OK;
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
				byte[] entropy = File.ReadAllBytes(entropyFile);
				byte[] ciphertext = File.ReadAllBytes(cipherFile);
				byte[] newplaintext = ProtectedData.Unprotect(ciphertext, entropy, DataProtectionScope.CurrentUser);
				password = UnicodeEncoding.ASCII.GetString(newplaintext);
			}
			catch // if file doesnt exist, set to default
			{
				// https://stackoverflow.com/a/12657970
				// Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes()
				byte[] plaintext = UnicodeEncoding.ASCII.GetBytes("password");

				// Generate additional entropy (will be used as the Initialization vector)
				byte[] entropy = new byte[20];
				// https://stackoverflow.com/a/72419989
				using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
				{
					rng.GetBytes(entropy);
				}

				byte[] ciphertext = ProtectedData.Protect(plaintext, entropy, DataProtectionScope.CurrentUser);
				try
				{
					File.WriteAllBytes(entropyFile, entropy);
					File.WriteAllBytes(cipherFile, ciphertext);
				}
				catch (Exception f)
				{
					Console.WriteLine(f.ToString());
				}
				password = "password";
				MessageBox.Show("Password not found so has been reset to 'password'", "Ordering system");
			}
		}
	}
}
