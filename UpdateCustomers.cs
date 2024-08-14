using ordering_system.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordering_system
{
	public partial class UpdateCustomers : Form
	{
		readonly SqlConnection con = new SqlConnection(Resources.con);
		DataView customersDataView, addressesDataView; // full databases compared to whats shown in datagridview
		int customerID = -1; // id of selected customer from datagridview
		int addressID = -1; // id of selected address from datagridview
		public UpdateCustomers()
		{
			InitializeComponent();
		}

		private bool hasDeliveryAddresses() // checks if customer has at least 1 delivery address
		{
			SqlCommand hasDeliveryAddresses = new SqlCommand("SELECT COUNT(*) FROM AddressTbl WHERE customerID = @CID", con);
			hasDeliveryAddresses.Parameters.AddWithValue("@CID", customerID);
			int numberOfAddresses = (int)hasDeliveryAddresses.ExecuteScalar();
			if (numberOfAddresses == 0)
			{
				return false;
			}
			return true;
		}

		private void UpdateCustomers_Load(object sender, EventArgs e)
		{
			con.Open();
			updateCustomerDataGridView();
			con.Close();
		}

		private void updateCustomerDataGridView()
		{
			SqlDataAdapter getCustomers = new SqlDataAdapter("SELECT * FROM CustomerTbl ORDER BY customerID", con);
			DataSet customersDataSet = new DataSet();
			getCustomers.Fill(customersDataSet);
			customersDataView = new DataView(customersDataSet.Tables[0]);
			// fill in category datagridview
			DataTable customersDataTable = customersDataView.ToTable(true, "customerName", "phoneNumber", "houseNumber", "postcode");
			customerDataGridView.DataSource = customersDataTable;
			// hide deliveryaddress panel by default
			addressPanel.Visible = false;
			addressPanel.SendToBack();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through customerdataview to find the full deets
			int selectedRowIndex = customerDataGridView.SelectedCells[0].RowIndex;
			if (customerDataGridView.RowCount > 1 && selectedRowIndex < customerDataGridView.RowCount - 1) // just in case theres no selectable rows or u click the blank row
			{
				DataRowView selectedRow = customersDataView[selectedRowIndex];
				customerID = Convert.ToInt32(selectedRow.Row["customerID"]);
				// update textboxes
				customerNameTextBox.Text = selectedRow.Row["customerName"].ToString();
				phoneNumberTextBox.Text = selectedRow.Row["phoneNumber"].ToString();
				blacklistedCheckBox.Checked = Convert.ToBoolean(selectedRow.Row["isBlackListed"]);
				billingHouseNumberTextBox.Text = selectedRow.Row["houseNumber"].ToString();
				billingStreetNameTextBox.Text = selectedRow.Row["streetName"].ToString();
				billingVillageTextBox.Text = selectedRow.Row["village"].ToString();
				billingCityTextBox.Text = selectedRow.Row["city"].ToString();
				billingPostcodeTextBox.Text = selectedRow.Row["postcode"].ToString();
				if (hasDeliveryAddresses()) // show delivery addresses if there are any
				{
					addressPanel.BringToFront();
					addressPanel.Visible = true;
					SqlDataAdapter getAddressesForCustomer = new SqlDataAdapter("SELECT * FROM AddressTbl WHERE customerID = @CID ORDER BY addressID", con);
					getAddressesForCustomer.SelectCommand.Parameters.AddWithValue("@CID", customerID);
					DataSet addressesDataSet = new DataSet();
					getAddressesForCustomer.Fill(addressesDataSet);
					addressesDataView = new DataView(addressesDataSet.Tables[0]);
					// fill in address datagridview
					DataTable addressesDataTable = addressesDataView.ToTable(true, "houseNumber", "streetName", "postcode");
					addressDataGridView.DataSource = addressesDataTable;
				}
			}
			else // unselect flop row
			{
				customerDataGridView.ClearSelection();
			}
			con.Close();
		}

		private void addressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			con.Open();
			// find clicked row of table in order to search through addressesdataview to find the full deets
			int selectedRowIndex = addressDataGridView.SelectedCells[0].RowIndex;
			if (addressDataGridView.RowCount > 1 && selectedRowIndex < addressDataGridView.RowCount - 1) // just in case theres no selectable rows or u click the blank row
			{
				DataRowView selectedRow = addressesDataView[selectedRowIndex];
				addressID = Convert.ToInt32(selectedRow.Row["addressID"]);
				deliveryHouseNumberTextBox.Text = selectedRow.Row["houseNumber"].ToString();
				deliveryStreetNameTextBox.Text = selectedRow.Row["streetName"].ToString();
				deliveryVillageTextBox.Text = selectedRow.Row["village"].ToString();
				deliveryCityTextBox.Text = selectedRow.Row["city"].ToString();
				deliveryPostcodeTextBox.Text = selectedRow.Row["postcode"].ToString();
				deliveryDeliveryChargeTextBox.Text = selectedRow.Row["deliveryCharge"].ToString();
			}
			else // unselect flop row
			{
				customerDataGridView.ClearSelection();
			}
			con.Close();
		}

		private void goBackButton_Click(object sender, EventArgs e)
		{
			addressPanel.Visible = false;
			addressPanel.SendToBack();
		}
	}
}
