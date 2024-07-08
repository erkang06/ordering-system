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
	public partial class CustomerDetails : Form
	{
		public CustomerDetails()
		{
			InitializeComponent();
		}

		private void acceptAddressButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cancelAddressButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void deliveryButton_Click(object sender, EventArgs e)
		{
			deliveryButton.BackColor = Color.Yellow;
			collectionButton.BackColor = Color.Transparent;
		}

		private void collectionButton_Click(object sender, EventArgs e)
		{
			collectionButton.BackColor = Color.Yellow;
			deliveryButton.BackColor = Color.Transparent;
		}
	}
}
