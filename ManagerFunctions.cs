using ordering_system.Properties;
using System.Security.Cryptography;
using System.Text;

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
			UpdateSetMeals obj = new UpdateSetMeals();
			obj.Show();
			obj.TopMost = true;
		}

		private void updateCommonItemsButton_Click(object sender, EventArgs e)
		{
			UpdateCommonItems obj = new UpdateCommonItems();
			obj.Show();
			//obj.TopMost = true;
		}

		private void updateCustomersButton_Click(object sender, EventArgs e)
		{
			UpdateCustomers obj = new UpdateCustomers();
			obj.Show();
			obj.TopMost = true;
		}

		private void orderSummaryButton_Click(object sender, EventArgs e)
		{
			OrderSummary obj = new OrderSummary();
			obj.Show();
			//obj.TopMost = true;
		}

		private void changeLoginPasswordButton_Click(object sender, EventArgs e)
		{
			changePassword("Login");
		}

		private void changeManagerPasswordButton_Click(object sender, EventArgs e)
		{
			changePassword("Manager");
		}

		private void changePassword(string passwordType) // theyre literally the same so like might as well
		{
			ChangePassword obj = new ChangePassword(passwordType);
			if (obj.ShowDialog(this) == DialogResult.OK) // if accept button clicked
			{
				// different if for login or for manager funcions
				string entropyFile, cipherFile;
				if (passwordType == "Login")
				{
					entropyFile = Resources.loginEntropy;
					cipherFile = Resources.loginCipher;
				}
				else // manager
				{
					entropyFile = Resources.managerEntropy;
					cipherFile = Resources.managerCipher;
				}
				// https://stackoverflow.com/a/12657970
				// Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes()
				byte[] plaintext = UnicodeEncoding.ASCII.GetBytes(obj.getPassword());

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
					MessageBox.Show($"{passwordType} password has been changed successfully", "Ordering System");
				}
				catch
				{
					MessageBox.Show($"{passwordType} password hasn't been changed", "Ordering System");
				}
				obj.Close();
			}
			obj.Dispose();
		}
	}
}
