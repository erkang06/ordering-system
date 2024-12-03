using ordering_system.Properties;
using System.Security.Cryptography;
using System.Text;

namespace ordering_system
{
	public partial class Login : Form
	{
		string password;
		// different if for login or for manager funcions
		string entropyFile, cipherFile;
		public Login(string passwordType)
		{
			InitializeComponent();

			// different if for login or for manager funcions
			if (passwordType == "Login")
			{
				loginLabel.Text = "Ordering System";
				entropyFile = Resources.loginEntropy;
				cipherFile = Resources.loginCipher;
			}
			else // manager
			{
				loginLabel.Text = "Manager Password";
				entropyFile = Resources.managerEntropy;
				cipherFile = Resources.managerCipher;
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

		private void Login_Load(object sender, EventArgs e) // get the login password
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
				catch (Exception ex) // if doesnt work for any reason
				{
					Console.WriteLine(ex.ToString());
				}
				password = "password";
				MessageBox.Show("Password not found so has been reset to 'password'", "Ordering system");
			}
		}
	}
}
