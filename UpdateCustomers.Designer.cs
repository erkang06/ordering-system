namespace ordering_system
{
	partial class UpdateCustomers
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			cancelButton = new Button();
			updateCustomersLabel = new Label();
			billingPostcodeTextBox = new TextBox();
			billingPostcodeLabel = new Label();
			billingCityTextBox = new TextBox();
			billingCityLabel = new Label();
			billingVillageTextBox = new TextBox();
			billingVillageLabel = new Label();
			billingStreetNameTextBox = new TextBox();
			billingStreetNameLabel = new Label();
			blacklistedCheckBox = new CheckBox();
			billingHouseNumberTextBox = new TextBox();
			billingHouseNumberLabel = new Label();
			phoneNumberTextBox = new TextBox();
			customerNameTextBox = new TextBox();
			phoneNumberLabel = new Label();
			customerNameLabel = new Label();
			addressDataGridView = new DataGridView();
			deliveryDeliveryChargeTextBox = new TextBox();
			deliveryDeliveryChargeLabel = new Label();
			deliveryPostcodeTextBox = new TextBox();
			deliveryPostcodeLabel = new Label();
			deliveryCityTextBox = new TextBox();
			deliveryCityLabel = new Label();
			deliveryVillageTextBox = new TextBox();
			deliveryVillageLabel = new Label();
			deliveryStreetNameTextBox = new TextBox();
			deliveryStreetNameLabel = new Label();
			deliveryHouseNumberTextBox = new TextBox();
			deliveryHouseNumberLabel = new Label();
			deleteAddressButton = new Button();
			updateAddressButton = new Button();
			deleteCustomerButton = new Button();
			updateCustomerButton = new Button();
			addressPanel = new Panel();
			goBackButton = new Button();
			customerDataGridView = new DataGridView();
			((System.ComponentModel.ISupportInitialize)addressDataGridView).BeginInit();
			addressPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)customerDataGridView).BeginInit();
			SuspendLayout();
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1818, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 13;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// updateCustomersLabel
			// 
			updateCustomersLabel.BackColor = Color.Transparent;
			updateCustomersLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			updateCustomersLabel.ForeColor = Color.Black;
			updateCustomersLabel.Location = new Point(12, 14);
			updateCustomersLabel.Margin = new Padding(3, 5, 3, 5);
			updateCustomersLabel.Name = "updateCustomersLabel";
			updateCustomersLabel.Size = new Size(520, 80);
			updateCustomersLabel.TabIndex = 43;
			updateCustomersLabel.Text = "Update Customers";
			// 
			// billingPostcodeTextBox
			// 
			billingPostcodeTextBox.Font = new Font("Segoe UI", 14F);
			billingPostcodeTextBox.Location = new Point(370, 527);
			billingPostcodeTextBox.Name = "billingPostcodeTextBox";
			billingPostcodeTextBox.Size = new Size(550, 57);
			billingPostcodeTextBox.TabIndex = 54;
			// 
			// billingPostcodeLabel
			// 
			billingPostcodeLabel.BackColor = Color.Transparent;
			billingPostcodeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingPostcodeLabel.ForeColor = Color.Black;
			billingPostcodeLabel.Location = new Point(12, 527);
			billingPostcodeLabel.Margin = new Padding(3, 5, 3, 5);
			billingPostcodeLabel.Name = "billingPostcodeLabel";
			billingPostcodeLabel.Size = new Size(350, 50);
			billingPostcodeLabel.TabIndex = 60;
			billingPostcodeLabel.Text = "Postcode:";
			// 
			// billingCityTextBox
			// 
			billingCityTextBox.Font = new Font("Segoe UI", 14F);
			billingCityTextBox.Location = new Point(370, 467);
			billingCityTextBox.Name = "billingCityTextBox";
			billingCityTextBox.Size = new Size(550, 57);
			billingCityTextBox.TabIndex = 53;
			// 
			// billingCityLabel
			// 
			billingCityLabel.BackColor = Color.Transparent;
			billingCityLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingCityLabel.ForeColor = Color.Black;
			billingCityLabel.Location = new Point(12, 467);
			billingCityLabel.Margin = new Padding(3, 5, 3, 5);
			billingCityLabel.Name = "billingCityLabel";
			billingCityLabel.Size = new Size(350, 50);
			billingCityLabel.TabIndex = 59;
			billingCityLabel.Text = "City:";
			// 
			// billingVillageTextBox
			// 
			billingVillageTextBox.Font = new Font("Segoe UI", 14F);
			billingVillageTextBox.Location = new Point(370, 407);
			billingVillageTextBox.Name = "billingVillageTextBox";
			billingVillageTextBox.Size = new Size(550, 57);
			billingVillageTextBox.TabIndex = 52;
			// 
			// billingVillageLabel
			// 
			billingVillageLabel.BackColor = Color.Transparent;
			billingVillageLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingVillageLabel.ForeColor = Color.Black;
			billingVillageLabel.Location = new Point(12, 407);
			billingVillageLabel.Margin = new Padding(3, 5, 3, 5);
			billingVillageLabel.Name = "billingVillageLabel";
			billingVillageLabel.Size = new Size(350, 50);
			billingVillageLabel.TabIndex = 58;
			billingVillageLabel.Text = "Village:";
			// 
			// billingStreetNameTextBox
			// 
			billingStreetNameTextBox.Font = new Font("Segoe UI", 14F);
			billingStreetNameTextBox.Location = new Point(370, 347);
			billingStreetNameTextBox.Name = "billingStreetNameTextBox";
			billingStreetNameTextBox.Size = new Size(550, 57);
			billingStreetNameTextBox.TabIndex = 50;
			// 
			// billingStreetNameLabel
			// 
			billingStreetNameLabel.BackColor = Color.Transparent;
			billingStreetNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingStreetNameLabel.ForeColor = Color.Black;
			billingStreetNameLabel.Location = new Point(12, 347);
			billingStreetNameLabel.Margin = new Padding(3, 5, 3, 5);
			billingStreetNameLabel.Name = "billingStreetNameLabel";
			billingStreetNameLabel.Size = new Size(350, 50);
			billingStreetNameLabel.TabIndex = 57;
			billingStreetNameLabel.Text = "Street Name:";
			// 
			// blacklistedCheckBox
			// 
			blacklistedCheckBox.AutoSize = true;
			blacklistedCheckBox.BackColor = Color.Gainsboro;
			blacklistedCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			blacklistedCheckBox.Location = new Point(12, 224);
			blacklistedCheckBox.Name = "blacklistedCheckBox";
			blacklistedCheckBox.Size = new Size(303, 55);
			blacklistedCheckBox.TabIndex = 46;
			blacklistedCheckBox.Text = "Is Blacklisted?";
			blacklistedCheckBox.UseVisualStyleBackColor = false;
			// 
			// billingHouseNumberTextBox
			// 
			billingHouseNumberTextBox.Font = new Font("Segoe UI", 14F);
			billingHouseNumberTextBox.Location = new Point(370, 287);
			billingHouseNumberTextBox.Name = "billingHouseNumberTextBox";
			billingHouseNumberTextBox.Size = new Size(550, 57);
			billingHouseNumberTextBox.TabIndex = 49;
			// 
			// billingHouseNumberLabel
			// 
			billingHouseNumberLabel.BackColor = Color.Transparent;
			billingHouseNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingHouseNumberLabel.ForeColor = Color.Black;
			billingHouseNumberLabel.Location = new Point(12, 287);
			billingHouseNumberLabel.Margin = new Padding(3, 5, 3, 5);
			billingHouseNumberLabel.Name = "billingHouseNumberLabel";
			billingHouseNumberLabel.Size = new Size(350, 50);
			billingHouseNumberLabel.TabIndex = 56;
			billingHouseNumberLabel.Text = "House Number:";
			// 
			// phoneNumberTextBox
			// 
			phoneNumberTextBox.Font = new Font("Segoe UI", 14F);
			phoneNumberTextBox.Location = new Point(370, 164);
			phoneNumberTextBox.Name = "phoneNumberTextBox";
			phoneNumberTextBox.Size = new Size(550, 57);
			phoneNumberTextBox.TabIndex = 45;
			// 
			// customerNameTextBox
			// 
			customerNameTextBox.Font = new Font("Segoe UI", 14F);
			customerNameTextBox.Location = new Point(370, 104);
			customerNameTextBox.Name = "customerNameTextBox";
			customerNameTextBox.Size = new Size(550, 57);
			customerNameTextBox.TabIndex = 44;
			// 
			// phoneNumberLabel
			// 
			phoneNumberLabel.BackColor = Color.Transparent;
			phoneNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			phoneNumberLabel.ForeColor = Color.Black;
			phoneNumberLabel.Location = new Point(12, 164);
			phoneNumberLabel.Margin = new Padding(3, 5, 3, 5);
			phoneNumberLabel.Name = "phoneNumberLabel";
			phoneNumberLabel.Size = new Size(350, 50);
			phoneNumberLabel.TabIndex = 51;
			phoneNumberLabel.Text = "*Phone Number:";
			// 
			// customerNameLabel
			// 
			customerNameLabel.BackColor = Color.Transparent;
			customerNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			customerNameLabel.ForeColor = Color.Black;
			customerNameLabel.Location = new Point(12, 104);
			customerNameLabel.Margin = new Padding(3, 5, 3, 5);
			customerNameLabel.Name = "customerNameLabel";
			customerNameLabel.Size = new Size(350, 50);
			customerNameLabel.TabIndex = 48;
			customerNameLabel.Text = "*Customer Name:";
			// 
			// addressDataGridView
			// 
			addressDataGridView.AllowUserToAddRows = false;
			addressDataGridView.AllowUserToDeleteRows = false;
			addressDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			addressDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			addressDataGridView.BackgroundColor = Color.White;
			addressDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			addressDataGridView.Location = new Point(3, 0);
			addressDataGridView.MultiSelect = false;
			addressDataGridView.Name = "addressDataGridView";
			addressDataGridView.ReadOnly = true;
			addressDataGridView.RowHeadersVisible = false;
			addressDataGridView.RowHeadersWidth = 10;
			addressDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			addressDataGridView.Size = new Size(976, 514);
			addressDataGridView.TabIndex = 61;
			addressDataGridView.TabStop = false;
			addressDataGridView.CellClick += addressDataGridView_CellClick;
			// 
			// deliveryDeliveryChargeTextBox
			// 
			deliveryDeliveryChargeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryDeliveryChargeTextBox.Font = new Font("Segoe UI", 14F);
			deliveryDeliveryChargeTextBox.Location = new Point(379, 822);
			deliveryDeliveryChargeTextBox.Name = "deliveryDeliveryChargeTextBox";
			deliveryDeliveryChargeTextBox.Size = new Size(600, 57);
			deliveryDeliveryChargeTextBox.TabIndex = 67;
			// 
			// deliveryDeliveryChargeLabel
			// 
			deliveryDeliveryChargeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryDeliveryChargeLabel.BackColor = Color.Transparent;
			deliveryDeliveryChargeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryDeliveryChargeLabel.ForeColor = Color.Black;
			deliveryDeliveryChargeLabel.Location = new Point(3, 822);
			deliveryDeliveryChargeLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryDeliveryChargeLabel.Name = "deliveryDeliveryChargeLabel";
			deliveryDeliveryChargeLabel.Size = new Size(350, 50);
			deliveryDeliveryChargeLabel.TabIndex = 73;
			deliveryDeliveryChargeLabel.Text = "*Delivery Charge:";
			// 
			// deliveryPostcodeTextBox
			// 
			deliveryPostcodeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryPostcodeTextBox.Font = new Font("Segoe UI", 14F);
			deliveryPostcodeTextBox.Location = new Point(379, 762);
			deliveryPostcodeTextBox.Name = "deliveryPostcodeTextBox";
			deliveryPostcodeTextBox.Size = new Size(600, 57);
			deliveryPostcodeTextBox.TabIndex = 66;
			// 
			// deliveryPostcodeLabel
			// 
			deliveryPostcodeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryPostcodeLabel.BackColor = Color.Transparent;
			deliveryPostcodeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryPostcodeLabel.ForeColor = Color.Black;
			deliveryPostcodeLabel.Location = new Point(3, 762);
			deliveryPostcodeLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryPostcodeLabel.Name = "deliveryPostcodeLabel";
			deliveryPostcodeLabel.Size = new Size(350, 50);
			deliveryPostcodeLabel.TabIndex = 72;
			deliveryPostcodeLabel.Text = "*Postcode:";
			// 
			// deliveryCityTextBox
			// 
			deliveryCityTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryCityTextBox.Font = new Font("Segoe UI", 14F);
			deliveryCityTextBox.Location = new Point(379, 702);
			deliveryCityTextBox.Name = "deliveryCityTextBox";
			deliveryCityTextBox.Size = new Size(600, 57);
			deliveryCityTextBox.TabIndex = 65;
			// 
			// deliveryCityLabel
			// 
			deliveryCityLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryCityLabel.BackColor = Color.Transparent;
			deliveryCityLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryCityLabel.ForeColor = Color.Black;
			deliveryCityLabel.Location = new Point(3, 702);
			deliveryCityLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryCityLabel.Name = "deliveryCityLabel";
			deliveryCityLabel.Size = new Size(350, 50);
			deliveryCityLabel.TabIndex = 71;
			deliveryCityLabel.Text = "*City:";
			// 
			// deliveryVillageTextBox
			// 
			deliveryVillageTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryVillageTextBox.Font = new Font("Segoe UI", 14F);
			deliveryVillageTextBox.Location = new Point(379, 642);
			deliveryVillageTextBox.Name = "deliveryVillageTextBox";
			deliveryVillageTextBox.Size = new Size(600, 57);
			deliveryVillageTextBox.TabIndex = 64;
			// 
			// deliveryVillageLabel
			// 
			deliveryVillageLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryVillageLabel.BackColor = Color.Transparent;
			deliveryVillageLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryVillageLabel.ForeColor = Color.Black;
			deliveryVillageLabel.Location = new Point(3, 642);
			deliveryVillageLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryVillageLabel.Name = "deliveryVillageLabel";
			deliveryVillageLabel.Size = new Size(350, 50);
			deliveryVillageLabel.TabIndex = 70;
			deliveryVillageLabel.Text = "Village:";
			// 
			// deliveryStreetNameTextBox
			// 
			deliveryStreetNameTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryStreetNameTextBox.Font = new Font("Segoe UI", 14F);
			deliveryStreetNameTextBox.Location = new Point(379, 582);
			deliveryStreetNameTextBox.Name = "deliveryStreetNameTextBox";
			deliveryStreetNameTextBox.Size = new Size(600, 57);
			deliveryStreetNameTextBox.TabIndex = 63;
			// 
			// deliveryStreetNameLabel
			// 
			deliveryStreetNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryStreetNameLabel.BackColor = Color.Transparent;
			deliveryStreetNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryStreetNameLabel.ForeColor = Color.Black;
			deliveryStreetNameLabel.Location = new Point(3, 582);
			deliveryStreetNameLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryStreetNameLabel.Name = "deliveryStreetNameLabel";
			deliveryStreetNameLabel.Size = new Size(350, 50);
			deliveryStreetNameLabel.TabIndex = 69;
			deliveryStreetNameLabel.Text = "*Street Name:";
			// 
			// deliveryHouseNumberTextBox
			// 
			deliveryHouseNumberTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryHouseNumberTextBox.Font = new Font("Segoe UI", 14F);
			deliveryHouseNumberTextBox.Location = new Point(379, 522);
			deliveryHouseNumberTextBox.Name = "deliveryHouseNumberTextBox";
			deliveryHouseNumberTextBox.Size = new Size(600, 57);
			deliveryHouseNumberTextBox.TabIndex = 62;
			// 
			// deliveryHouseNumberLabel
			// 
			deliveryHouseNumberLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryHouseNumberLabel.BackColor = Color.Transparent;
			deliveryHouseNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryHouseNumberLabel.ForeColor = Color.Black;
			deliveryHouseNumberLabel.Location = new Point(3, 522);
			deliveryHouseNumberLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryHouseNumberLabel.Name = "deliveryHouseNumberLabel";
			deliveryHouseNumberLabel.Size = new Size(350, 50);
			deliveryHouseNumberLabel.TabIndex = 68;
			deliveryHouseNumberLabel.Text = "*House Number:";
			// 
			// deleteAddressButton
			// 
			deleteAddressButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteAddressButton.BackColor = SystemColors.Control;
			deleteAddressButton.FlatStyle = FlatStyle.Flat;
			deleteAddressButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteAddressButton.Location = new Point(369, 885);
			deleteAddressButton.Name = "deleteAddressButton";
			deleteAddressButton.Size = new Size(360, 80);
			deleteAddressButton.TabIndex = 74;
			deleteAddressButton.Text = "Delete Address";
			deleteAddressButton.UseVisualStyleBackColor = false;
			deleteAddressButton.Click += deleteAddressButton_Click;
			// 
			// updateAddressButton
			// 
			updateAddressButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			updateAddressButton.BackColor = SystemColors.Control;
			updateAddressButton.FlatStyle = FlatStyle.Flat;
			updateAddressButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateAddressButton.Location = new Point(3, 885);
			updateAddressButton.Name = "updateAddressButton";
			updateAddressButton.Size = new Size(360, 80);
			updateAddressButton.TabIndex = 75;
			updateAddressButton.Text = "Update Address";
			updateAddressButton.UseVisualStyleBackColor = false;
			updateAddressButton.Click += updateAddressButton_Click;
			// 
			// deleteCustomerButton
			// 
			deleteCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteCustomerButton.BackColor = SystemColors.Control;
			deleteCustomerButton.FlatStyle = FlatStyle.Flat;
			deleteCustomerButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteCustomerButton.Location = new Point(12, 988);
			deleteCustomerButton.Name = "deleteCustomerButton";
			deleteCustomerButton.Size = new Size(450, 80);
			deleteCustomerButton.TabIndex = 76;
			deleteCustomerButton.Text = "Delete Customer";
			deleteCustomerButton.UseVisualStyleBackColor = false;
			deleteCustomerButton.Click += deleteCustomerButton_Click;
			// 
			// updateCustomerButton
			// 
			updateCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			updateCustomerButton.BackColor = SystemColors.Control;
			updateCustomerButton.FlatStyle = FlatStyle.Flat;
			updateCustomerButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateCustomerButton.Location = new Point(12, 902);
			updateCustomerButton.Name = "updateCustomerButton";
			updateCustomerButton.Size = new Size(450, 80);
			updateCustomerButton.TabIndex = 77;
			updateCustomerButton.Text = "Update Customer";
			updateCustomerButton.UseVisualStyleBackColor = false;
			updateCustomerButton.Click += updateCustomerButton_Click;
			// 
			// addressPanel
			// 
			addressPanel.Anchor = AnchorStyles.Right;
			addressPanel.Controls.Add(goBackButton);
			addressPanel.Controls.Add(addressDataGridView);
			addressPanel.Controls.Add(updateAddressButton);
			addressPanel.Controls.Add(deliveryDeliveryChargeTextBox);
			addressPanel.Controls.Add(deliveryDeliveryChargeLabel);
			addressPanel.Controls.Add(deleteAddressButton);
			addressPanel.Controls.Add(deliveryPostcodeTextBox);
			addressPanel.Controls.Add(deliveryHouseNumberLabel);
			addressPanel.Controls.Add(deliveryPostcodeLabel);
			addressPanel.Controls.Add(deliveryHouseNumberTextBox);
			addressPanel.Controls.Add(deliveryCityTextBox);
			addressPanel.Controls.Add(deliveryStreetNameLabel);
			addressPanel.Controls.Add(deliveryCityLabel);
			addressPanel.Controls.Add(deliveryStreetNameTextBox);
			addressPanel.Controls.Add(deliveryVillageTextBox);
			addressPanel.Controls.Add(deliveryVillageLabel);
			addressPanel.Location = new Point(926, 104);
			addressPanel.Name = "addressPanel";
			addressPanel.Size = new Size(982, 970);
			addressPanel.TabIndex = 78;
			addressPanel.Visible = false;
			// 
			// goBackButton
			// 
			goBackButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			goBackButton.BackColor = SystemColors.Control;
			goBackButton.FlatStyle = FlatStyle.Flat;
			goBackButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			goBackButton.Location = new Point(735, 885);
			goBackButton.Name = "goBackButton";
			goBackButton.Size = new Size(244, 80);
			goBackButton.TabIndex = 76;
			goBackButton.Text = "Go Back";
			goBackButton.UseVisualStyleBackColor = false;
			goBackButton.Click += goBackButton_Click;
			// 
			// customerDataGridView
			// 
			customerDataGridView.AllowUserToAddRows = false;
			customerDataGridView.AllowUserToDeleteRows = false;
			customerDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			customerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			customerDataGridView.BackgroundColor = Color.White;
			customerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			customerDataGridView.Location = new Point(926, 104);
			customerDataGridView.MultiSelect = false;
			customerDataGridView.Name = "customerDataGridView";
			customerDataGridView.ReadOnly = true;
			customerDataGridView.RowHeadersVisible = false;
			customerDataGridView.RowHeadersWidth = 10;
			customerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			customerDataGridView.Size = new Size(982, 970);
			customerDataGridView.TabIndex = 79;
			customerDataGridView.TabStop = false;
			customerDataGridView.CellClick += customerDataGridView_CellClick;
			// 
			// UpdateCustomers
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(updateCustomerButton);
			Controls.Add(deleteCustomerButton);
			Controls.Add(billingPostcodeTextBox);
			Controls.Add(billingPostcodeLabel);
			Controls.Add(billingCityTextBox);
			Controls.Add(billingCityLabel);
			Controls.Add(billingVillageTextBox);
			Controls.Add(billingVillageLabel);
			Controls.Add(billingStreetNameTextBox);
			Controls.Add(billingStreetNameLabel);
			Controls.Add(blacklistedCheckBox);
			Controls.Add(billingHouseNumberTextBox);
			Controls.Add(billingHouseNumberLabel);
			Controls.Add(phoneNumberTextBox);
			Controls.Add(customerNameTextBox);
			Controls.Add(phoneNumberLabel);
			Controls.Add(customerNameLabel);
			Controls.Add(updateCustomersLabel);
			Controls.Add(cancelButton);
			Controls.Add(customerDataGridView);
			Controls.Add(addressPanel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "UpdateCustomers";
			Text = "UpdateCustomers";
			Load += UpdateCustomers_Load;
			((System.ComponentModel.ISupportInitialize)addressDataGridView).EndInit();
			addressPanel.ResumeLayout(false);
			addressPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)customerDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button cancelButton;
		private Label updateCustomersLabel;
		private TextBox billingPostcodeTextBox;
		private Label billingPostcodeLabel;
		private TextBox billingCityTextBox;
		private Label billingCityLabel;
		private TextBox billingVillageTextBox;
		private Label billingVillageLabel;
		private TextBox billingStreetNameTextBox;
		private Label billingStreetNameLabel;
		private CheckBox blacklistedCheckBox;
		private TextBox billingHouseNumberTextBox;
		private Label billingHouseNumberLabel;
		private TextBox phoneNumberTextBox;
		private TextBox customerNameTextBox;
		private Label phoneNumberLabel;
		private Label customerNameLabel;
		private DataGridView addressDataGridView;
		private TextBox deliveryDeliveryChargeTextBox;
		private Label deliveryDeliveryChargeLabel;
		private TextBox deliveryPostcodeTextBox;
		private Label deliveryPostcodeLabel;
		private TextBox deliveryCityTextBox;
		private Label deliveryCityLabel;
		private TextBox deliveryVillageTextBox;
		private Label deliveryVillageLabel;
		private TextBox deliveryStreetNameTextBox;
		private Label deliveryStreetNameLabel;
		private TextBox deliveryHouseNumberTextBox;
		private Label deliveryHouseNumberLabel;
		private Button deleteAddressButton;
		private Button updateAddressButton;
		private Button deleteCustomerButton;
		private Button updateCustomerButton;
		private Panel addressPanel;
		private DataGridView customerDataGridView;
		private Button goBackButton;
	}
}