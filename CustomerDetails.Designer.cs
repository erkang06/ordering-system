namespace ordering_system
{
	partial class CustomerDetails
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
			customerNameLabel = new Label();
			phoneNumberLabel = new Label();
			customerNameTextBox = new TextBox();
			phoneNumberTextBox = new TextBox();
			billingAddressLabel = new Label();
			billingHouseNumberTextBox = new TextBox();
			billingHouseNumberLabel = new Label();
			blacklistedCheckBox = new CheckBox();
			billingStreetNameTextBox = new TextBox();
			billingStreetNameLabel = new Label();
			billingVillageTextBox = new TextBox();
			billingVillageLabel = new Label();
			billingCityTextBox = new TextBox();
			billingCityLabel = new Label();
			billingPostcodeTextBox = new TextBox();
			billingPostcodeLabel = new Label();
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
			deliveryAddressLabel = new Label();
			billingAsDeliveryCheckBox = new CheckBox();
			addressDataGridView = new DataGridView();
			deliveryDeliveryChargeTextBox = new TextBox();
			deliveryDeliveryChargeLabel = new Label();
			acceptAddressButton = new Button();
			cancelAddressButton = new Button();
			deleteDeliveryAddressButton = new Button();
			collectionButton = new Button();
			deliveryButton = new Button();
			deleteCustomerButton = new Button();
			findCustomerButton = new Button();
			((System.ComponentModel.ISupportInitialize)addressDataGridView).BeginInit();
			SuspendLayout();
			// 
			// customerNameLabel
			// 
			customerNameLabel.BackColor = Color.Transparent;
			customerNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			customerNameLabel.ForeColor = Color.Black;
			customerNameLabel.Location = new Point(12, 12);
			customerNameLabel.Margin = new Padding(3, 5, 3, 5);
			customerNameLabel.Name = "customerNameLabel";
			customerNameLabel.Size = new Size(350, 50);
			customerNameLabel.TabIndex = 4;
			customerNameLabel.Text = "*Customer Name:";
			// 
			// phoneNumberLabel
			// 
			phoneNumberLabel.BackColor = Color.Transparent;
			phoneNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			phoneNumberLabel.ForeColor = Color.Black;
			phoneNumberLabel.Location = new Point(12, 72);
			phoneNumberLabel.Margin = new Padding(3, 5, 3, 5);
			phoneNumberLabel.Name = "phoneNumberLabel";
			phoneNumberLabel.Size = new Size(350, 50);
			phoneNumberLabel.TabIndex = 6;
			phoneNumberLabel.Text = "*Phone Number:";
			// 
			// customerNameTextBox
			// 
			customerNameTextBox.Font = new Font("Segoe UI", 14F);
			customerNameTextBox.Location = new Point(370, 12);
			customerNameTextBox.Name = "customerNameTextBox";
			customerNameTextBox.Size = new Size(550, 57);
			customerNameTextBox.TabIndex = 1;
			customerNameTextBox.Leave += customerNameTextBox_Leave;
			// 
			// phoneNumberTextBox
			// 
			phoneNumberTextBox.Font = new Font("Segoe UI", 14F);
			phoneNumberTextBox.Location = new Point(370, 72);
			phoneNumberTextBox.Name = "phoneNumberTextBox";
			phoneNumberTextBox.Size = new Size(550, 57);
			phoneNumberTextBox.TabIndex = 2;
			phoneNumberTextBox.Leave += phoneNumberTextBox_Leave;
			// 
			// billingAddressLabel
			// 
			billingAddressLabel.BackColor = Color.Transparent;
			billingAddressLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingAddressLabel.ForeColor = Color.Black;
			billingAddressLabel.Location = new Point(12, 195);
			billingAddressLabel.Margin = new Padding(3, 5, 3, 5);
			billingAddressLabel.Name = "billingAddressLabel";
			billingAddressLabel.Size = new Size(500, 80);
			billingAddressLabel.TabIndex = 11;
			billingAddressLabel.Text = "Billing Address";
			// 
			// billingHouseNumberTextBox
			// 
			billingHouseNumberTextBox.Font = new Font("Segoe UI", 14F);
			billingHouseNumberTextBox.Location = new Point(370, 295);
			billingHouseNumberTextBox.Name = "billingHouseNumberTextBox";
			billingHouseNumberTextBox.Size = new Size(550, 57);
			billingHouseNumberTextBox.TabIndex = 5;
			billingHouseNumberTextBox.Leave += billingHouseNumberTextBox_Leave;
			// 
			// billingHouseNumberLabel
			// 
			billingHouseNumberLabel.BackColor = Color.Transparent;
			billingHouseNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingHouseNumberLabel.ForeColor = Color.Black;
			billingHouseNumberLabel.Location = new Point(12, 295);
			billingHouseNumberLabel.Margin = new Padding(3, 5, 3, 5);
			billingHouseNumberLabel.Name = "billingHouseNumberLabel";
			billingHouseNumberLabel.Size = new Size(350, 50);
			billingHouseNumberLabel.TabIndex = 12;
			billingHouseNumberLabel.Text = "House Number:";
			// 
			// blacklistedCheckBox
			// 
			blacklistedCheckBox.AutoSize = true;
			blacklistedCheckBox.BackColor = Color.Gainsboro;
			blacklistedCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			blacklistedCheckBox.Location = new Point(12, 132);
			blacklistedCheckBox.Name = "blacklistedCheckBox";
			blacklistedCheckBox.Size = new Size(303, 55);
			blacklistedCheckBox.TabIndex = 3;
			blacklistedCheckBox.Text = "Is Blacklisted?";
			blacklistedCheckBox.UseVisualStyleBackColor = false;
			// 
			// billingStreetNameTextBox
			// 
			billingStreetNameTextBox.Font = new Font("Segoe UI", 14F);
			billingStreetNameTextBox.Location = new Point(370, 355);
			billingStreetNameTextBox.Name = "billingStreetNameTextBox";
			billingStreetNameTextBox.Size = new Size(550, 57);
			billingStreetNameTextBox.TabIndex = 6;
			billingStreetNameTextBox.Leave += billingStreetNameTextBox_Leave;
			// 
			// billingStreetNameLabel
			// 
			billingStreetNameLabel.BackColor = Color.Transparent;
			billingStreetNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingStreetNameLabel.ForeColor = Color.Black;
			billingStreetNameLabel.Location = new Point(12, 355);
			billingStreetNameLabel.Margin = new Padding(3, 5, 3, 5);
			billingStreetNameLabel.Name = "billingStreetNameLabel";
			billingStreetNameLabel.Size = new Size(350, 50);
			billingStreetNameLabel.TabIndex = 15;
			billingStreetNameLabel.Text = "Street Name:";
			// 
			// billingVillageTextBox
			// 
			billingVillageTextBox.Font = new Font("Segoe UI", 14F);
			billingVillageTextBox.Location = new Point(370, 415);
			billingVillageTextBox.Name = "billingVillageTextBox";
			billingVillageTextBox.Size = new Size(550, 57);
			billingVillageTextBox.TabIndex = 7;
			billingVillageTextBox.Leave += billingVillageTextBox_Leave;
			// 
			// billingVillageLabel
			// 
			billingVillageLabel.BackColor = Color.Transparent;
			billingVillageLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingVillageLabel.ForeColor = Color.Black;
			billingVillageLabel.Location = new Point(12, 415);
			billingVillageLabel.Margin = new Padding(3, 5, 3, 5);
			billingVillageLabel.Name = "billingVillageLabel";
			billingVillageLabel.Size = new Size(350, 50);
			billingVillageLabel.TabIndex = 17;
			billingVillageLabel.Text = "Village:";
			// 
			// billingCityTextBox
			// 
			billingCityTextBox.Font = new Font("Segoe UI", 14F);
			billingCityTextBox.Location = new Point(370, 475);
			billingCityTextBox.Name = "billingCityTextBox";
			billingCityTextBox.Size = new Size(550, 57);
			billingCityTextBox.TabIndex = 8;
			billingCityTextBox.Leave += billingCityTextBox_Leave;
			// 
			// billingCityLabel
			// 
			billingCityLabel.BackColor = Color.Transparent;
			billingCityLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingCityLabel.ForeColor = Color.Black;
			billingCityLabel.Location = new Point(12, 475);
			billingCityLabel.Margin = new Padding(3, 5, 3, 5);
			billingCityLabel.Name = "billingCityLabel";
			billingCityLabel.Size = new Size(350, 50);
			billingCityLabel.TabIndex = 19;
			billingCityLabel.Text = "City:";
			// 
			// billingPostcodeTextBox
			// 
			billingPostcodeTextBox.Font = new Font("Segoe UI", 14F);
			billingPostcodeTextBox.Location = new Point(370, 535);
			billingPostcodeTextBox.Name = "billingPostcodeTextBox";
			billingPostcodeTextBox.Size = new Size(550, 57);
			billingPostcodeTextBox.TabIndex = 9;
			billingPostcodeTextBox.Leave += billingPostcodeTextBox_Leave;
			// 
			// billingPostcodeLabel
			// 
			billingPostcodeLabel.BackColor = Color.Transparent;
			billingPostcodeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			billingPostcodeLabel.ForeColor = Color.Black;
			billingPostcodeLabel.Location = new Point(12, 535);
			billingPostcodeLabel.Margin = new Padding(3, 5, 3, 5);
			billingPostcodeLabel.Name = "billingPostcodeLabel";
			billingPostcodeLabel.Size = new Size(350, 50);
			billingPostcodeLabel.TabIndex = 21;
			billingPostcodeLabel.Text = "Postcode:";
			// 
			// deliveryPostcodeTextBox
			// 
			deliveryPostcodeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryPostcodeTextBox.Font = new Font("Segoe UI", 14F);
			deliveryPostcodeTextBox.Location = new Point(1358, 950);
			deliveryPostcodeTextBox.Name = "deliveryPostcodeTextBox";
			deliveryPostcodeTextBox.Size = new Size(550, 57);
			deliveryPostcodeTextBox.TabIndex = 19;
			deliveryPostcodeTextBox.Leave += deliveryPostcodeTextBox_Leave;
			// 
			// deliveryPostcodeLabel
			// 
			deliveryPostcodeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryPostcodeLabel.BackColor = Color.Transparent;
			deliveryPostcodeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryPostcodeLabel.ForeColor = Color.Black;
			deliveryPostcodeLabel.Location = new Point(1000, 950);
			deliveryPostcodeLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryPostcodeLabel.Name = "deliveryPostcodeLabel";
			deliveryPostcodeLabel.Size = new Size(350, 50);
			deliveryPostcodeLabel.TabIndex = 32;
			deliveryPostcodeLabel.Text = "*Postcode:";
			// 
			// deliveryCityTextBox
			// 
			deliveryCityTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryCityTextBox.Font = new Font("Segoe UI", 14F);
			deliveryCityTextBox.Location = new Point(1358, 890);
			deliveryCityTextBox.Name = "deliveryCityTextBox";
			deliveryCityTextBox.Size = new Size(550, 57);
			deliveryCityTextBox.TabIndex = 18;
			deliveryCityTextBox.Leave += deliveryCityTextBox_Leave;
			// 
			// deliveryCityLabel
			// 
			deliveryCityLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryCityLabel.BackColor = Color.Transparent;
			deliveryCityLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryCityLabel.ForeColor = Color.Black;
			deliveryCityLabel.Location = new Point(1000, 890);
			deliveryCityLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryCityLabel.Name = "deliveryCityLabel";
			deliveryCityLabel.Size = new Size(350, 50);
			deliveryCityLabel.TabIndex = 30;
			deliveryCityLabel.Text = "*City:";
			// 
			// deliveryVillageTextBox
			// 
			deliveryVillageTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryVillageTextBox.Font = new Font("Segoe UI", 14F);
			deliveryVillageTextBox.Location = new Point(1358, 830);
			deliveryVillageTextBox.Name = "deliveryVillageTextBox";
			deliveryVillageTextBox.Size = new Size(550, 57);
			deliveryVillageTextBox.TabIndex = 17;
			deliveryVillageTextBox.Leave += deliveryVillageTextBox_Leave;
			// 
			// deliveryVillageLabel
			// 
			deliveryVillageLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryVillageLabel.BackColor = Color.Transparent;
			deliveryVillageLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryVillageLabel.ForeColor = Color.Black;
			deliveryVillageLabel.Location = new Point(1000, 830);
			deliveryVillageLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryVillageLabel.Name = "deliveryVillageLabel";
			deliveryVillageLabel.Size = new Size(350, 50);
			deliveryVillageLabel.TabIndex = 28;
			deliveryVillageLabel.Text = "Village:";
			// 
			// deliveryStreetNameTextBox
			// 
			deliveryStreetNameTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryStreetNameTextBox.Font = new Font("Segoe UI", 14F);
			deliveryStreetNameTextBox.Location = new Point(1358, 770);
			deliveryStreetNameTextBox.Name = "deliveryStreetNameTextBox";
			deliveryStreetNameTextBox.Size = new Size(550, 57);
			deliveryStreetNameTextBox.TabIndex = 16;
			deliveryStreetNameTextBox.Leave += deliveryStreetNameTextBox_Leave;
			// 
			// deliveryStreetNameLabel
			// 
			deliveryStreetNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryStreetNameLabel.BackColor = Color.Transparent;
			deliveryStreetNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryStreetNameLabel.ForeColor = Color.Black;
			deliveryStreetNameLabel.Location = new Point(1000, 770);
			deliveryStreetNameLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryStreetNameLabel.Name = "deliveryStreetNameLabel";
			deliveryStreetNameLabel.Size = new Size(350, 50);
			deliveryStreetNameLabel.TabIndex = 26;
			deliveryStreetNameLabel.Text = "*Street Name:";
			// 
			// deliveryHouseNumberTextBox
			// 
			deliveryHouseNumberTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryHouseNumberTextBox.Font = new Font("Segoe UI", 14F);
			deliveryHouseNumberTextBox.Location = new Point(1358, 710);
			deliveryHouseNumberTextBox.Name = "deliveryHouseNumberTextBox";
			deliveryHouseNumberTextBox.Size = new Size(550, 57);
			deliveryHouseNumberTextBox.TabIndex = 15;
			deliveryHouseNumberTextBox.Leave += deliveryHouseNumberTextBox_Leave;
			// 
			// deliveryHouseNumberLabel
			// 
			deliveryHouseNumberLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryHouseNumberLabel.BackColor = Color.Transparent;
			deliveryHouseNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryHouseNumberLabel.ForeColor = Color.Black;
			deliveryHouseNumberLabel.Location = new Point(1000, 710);
			deliveryHouseNumberLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryHouseNumberLabel.Name = "deliveryHouseNumberLabel";
			deliveryHouseNumberLabel.Size = new Size(350, 50);
			deliveryHouseNumberLabel.TabIndex = 24;
			deliveryHouseNumberLabel.Text = "*House Number:";
			// 
			// deliveryAddressLabel
			// 
			deliveryAddressLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryAddressLabel.BackColor = Color.Transparent;
			deliveryAddressLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryAddressLabel.ForeColor = Color.Black;
			deliveryAddressLabel.Location = new Point(1000, 610);
			deliveryAddressLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryAddressLabel.Name = "deliveryAddressLabel";
			deliveryAddressLabel.Size = new Size(500, 80);
			deliveryAddressLabel.TabIndex = 23;
			deliveryAddressLabel.Text = "Delivery Address";
			// 
			// billingAsDeliveryCheckBox
			// 
			billingAsDeliveryCheckBox.AutoSize = true;
			billingAsDeliveryCheckBox.BackColor = Color.Gainsboro;
			billingAsDeliveryCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			billingAsDeliveryCheckBox.Location = new Point(12, 595);
			billingAsDeliveryCheckBox.Name = "billingAsDeliveryCheckBox";
			billingAsDeliveryCheckBox.Size = new Size(778, 55);
			billingAsDeliveryCheckBox.TabIndex = 10;
			billingAsDeliveryCheckBox.Text = "Use Billing Address as Delivery Address?";
			billingAsDeliveryCheckBox.UseVisualStyleBackColor = false;
			billingAsDeliveryCheckBox.CheckedChanged += billingAsDeliveryCheckBox_CheckedChanged;
			// 
			// addressDataGridView
			// 
			addressDataGridView.AllowUserToAddRows = false;
			addressDataGridView.AllowUserToDeleteRows = false;
			addressDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			addressDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			addressDataGridView.BackgroundColor = Color.White;
			addressDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			addressDataGridView.ColumnHeadersVisible = false;
			addressDataGridView.Location = new Point(1000, 12);
			addressDataGridView.MultiSelect = false;
			addressDataGridView.Name = "addressDataGridView";
			addressDataGridView.ReadOnly = true;
			addressDataGridView.RowHeadersVisible = false;
			addressDataGridView.RowHeadersWidth = 10;
			addressDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			addressDataGridView.Size = new Size(908, 590);
			addressDataGridView.TabIndex = 35;
			addressDataGridView.TabStop = false;
			addressDataGridView.CellClick += addressDataGridView_CellClick;
			// 
			// deliveryDeliveryChargeTextBox
			// 
			deliveryDeliveryChargeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryDeliveryChargeTextBox.Font = new Font("Segoe UI", 14F);
			deliveryDeliveryChargeTextBox.Location = new Point(1358, 1010);
			deliveryDeliveryChargeTextBox.Name = "deliveryDeliveryChargeTextBox";
			deliveryDeliveryChargeTextBox.Size = new Size(550, 57);
			deliveryDeliveryChargeTextBox.TabIndex = 20;
			deliveryDeliveryChargeTextBox.Leave += deliveryDeliveryChargeTextBox_Leave;
			// 
			// deliveryDeliveryChargeLabel
			// 
			deliveryDeliveryChargeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deliveryDeliveryChargeLabel.BackColor = Color.Transparent;
			deliveryDeliveryChargeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryDeliveryChargeLabel.ForeColor = Color.Black;
			deliveryDeliveryChargeLabel.Location = new Point(1000, 1010);
			deliveryDeliveryChargeLabel.Margin = new Padding(3, 5, 3, 5);
			deliveryDeliveryChargeLabel.Name = "deliveryDeliveryChargeLabel";
			deliveryDeliveryChargeLabel.Size = new Size(350, 50);
			deliveryDeliveryChargeLabel.TabIndex = 36;
			deliveryDeliveryChargeLabel.Text = "*Delivery Charge:";
			// 
			// acceptAddressButton
			// 
			acceptAddressButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			acceptAddressButton.BackColor = Color.Teal;
			acceptAddressButton.FlatStyle = FlatStyle.Flat;
			acceptAddressButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			acceptAddressButton.Location = new Point(12, 967);
			acceptAddressButton.Name = "acceptAddressButton";
			acceptAddressButton.Size = new Size(200, 100);
			acceptAddressButton.TabIndex = 22;
			acceptAddressButton.Text = "Accept";
			acceptAddressButton.UseVisualStyleBackColor = false;
			acceptAddressButton.Click += acceptAddressButton_Click;
			// 
			// cancelAddressButton
			// 
			cancelAddressButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			cancelAddressButton.BackColor = SystemColors.Control;
			cancelAddressButton.FlatStyle = FlatStyle.Flat;
			cancelAddressButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			cancelAddressButton.Location = new Point(218, 968);
			cancelAddressButton.Name = "cancelAddressButton";
			cancelAddressButton.Size = new Size(200, 100);
			cancelAddressButton.TabIndex = 23;
			cancelAddressButton.Text = "Cancel";
			cancelAddressButton.UseVisualStyleBackColor = false;
			cancelAddressButton.Click += cancelAddressButton_Click;
			// 
			// deleteDeliveryAddressButton
			// 
			deleteDeliveryAddressButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteDeliveryAddressButton.BackColor = SystemColors.Control;
			deleteDeliveryAddressButton.FlatStyle = FlatStyle.Flat;
			deleteDeliveryAddressButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteDeliveryAddressButton.Location = new Point(1508, 610);
			deleteDeliveryAddressButton.Name = "deleteDeliveryAddressButton";
			deleteDeliveryAddressButton.Size = new Size(400, 80);
			deleteDeliveryAddressButton.TabIndex = 21;
			deleteDeliveryAddressButton.Text = "Delete Address";
			deleteDeliveryAddressButton.UseVisualStyleBackColor = false;
			deleteDeliveryAddressButton.Click += deleteDeliveryAddressButton_Click;
			// 
			// collectionButton
			// 
			collectionButton.BackColor = Color.Transparent;
			collectionButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			collectionButton.Location = new Point(218, 660);
			collectionButton.Name = "collectionButton";
			collectionButton.Size = new Size(200, 80);
			collectionButton.TabIndex = 12;
			collectionButton.Text = "Collection";
			collectionButton.UseVisualStyleBackColor = false;
			collectionButton.Click += collectionButton_Click;
			// 
			// deliveryButton
			// 
			deliveryButton.BackColor = Color.Transparent;
			deliveryButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			deliveryButton.Location = new Point(12, 660);
			deliveryButton.Name = "deliveryButton";
			deliveryButton.Size = new Size(200, 80);
			deliveryButton.TabIndex = 11;
			deliveryButton.Text = "Delivery";
			deliveryButton.UseVisualStyleBackColor = false;
			deliveryButton.Click += deliveryButton_Click;
			// 
			// deleteCustomerButton
			// 
			deleteCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteCustomerButton.BackColor = SystemColors.Control;
			deleteCustomerButton.FlatStyle = FlatStyle.Flat;
			deleteCustomerButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteCustomerButton.ForeColor = Color.Red;
			deleteCustomerButton.Location = new Point(520, 660);
			deleteCustomerButton.Name = "deleteCustomerButton";
			deleteCustomerButton.Size = new Size(400, 80);
			deleteCustomerButton.TabIndex = 14;
			deleteCustomerButton.Text = "Delete Customer";
			deleteCustomerButton.UseVisualStyleBackColor = false;
			deleteCustomerButton.Click += deleteCustomerButton_Click;
			// 
			// findCustomerButton
			// 
			findCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			findCustomerButton.BackColor = SystemColors.Control;
			findCustomerButton.FlatStyle = FlatStyle.Flat;
			findCustomerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			findCustomerButton.Location = new Point(370, 135);
			findCustomerButton.Name = "findCustomerButton";
			findCustomerButton.Size = new Size(258, 60);
			findCustomerButton.TabIndex = 4;
			findCustomerButton.Text = "Find Customer";
			findCustomerButton.UseVisualStyleBackColor = false;
			findCustomerButton.Click += findCustomerButton_Click;
			// 
			// CustomerDetails
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(findCustomerButton);
			Controls.Add(deleteCustomerButton);
			Controls.Add(collectionButton);
			Controls.Add(deliveryButton);
			Controls.Add(deleteDeliveryAddressButton);
			Controls.Add(cancelAddressButton);
			Controls.Add(acceptAddressButton);
			Controls.Add(deliveryDeliveryChargeTextBox);
			Controls.Add(deliveryDeliveryChargeLabel);
			Controls.Add(addressDataGridView);
			Controls.Add(billingAsDeliveryCheckBox);
			Controls.Add(deliveryPostcodeTextBox);
			Controls.Add(deliveryPostcodeLabel);
			Controls.Add(deliveryCityTextBox);
			Controls.Add(deliveryCityLabel);
			Controls.Add(deliveryVillageTextBox);
			Controls.Add(deliveryVillageLabel);
			Controls.Add(deliveryStreetNameTextBox);
			Controls.Add(deliveryStreetNameLabel);
			Controls.Add(deliveryHouseNumberTextBox);
			Controls.Add(deliveryHouseNumberLabel);
			Controls.Add(deliveryAddressLabel);
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
			Controls.Add(billingAddressLabel);
			Controls.Add(phoneNumberTextBox);
			Controls.Add(customerNameTextBox);
			Controls.Add(phoneNumberLabel);
			Controls.Add(customerNameLabel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "CustomerDetails";
			Text = "Customer Details";
			((System.ComponentModel.ISupportInitialize)addressDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label customerNameLabel;
		private Label deliveryCityLabel;
		private Label phoneNumberLabel;
		private TextBox customerNameTextBox;
		private TextBox phoneNumberTextBox;
		private Label billingAddressLabel;
		private TextBox billingHouseNumberTextBox;
		private Label billingHouseNumberLabel;
		private CheckBox blacklistedCheckBox;
		private TextBox billingStreetNameTextBox;
		private Label billingStreetNameLabel;
		private TextBox billingVillageTextBox;
		private Label billingVillageLabel;
		private TextBox billingCityTextBox;
		private Label billingCityLabel;
		private TextBox billingPostcodeTextBox;
		private Label billingPostcodeLabel;
		private TextBox deliveryPostcodeTextBox;
		private Label deliveryPostcodeLabel;
		private TextBox deliveryCityTextBox;
		private TextBox deliveryVillageTextBox;
		private Label deliveryVillageLabel;
		private TextBox deliveryStreetNameTextBox;
		private Label deliveryStreetNameLabel;
		private TextBox deliveryHouseNumberTextBox;
		private Label deliveryHouseNumberLabel;
		private Label deliveryAddressLabel;
		private CheckBox billingAsDeliveryCheckBox;
		private DataGridView addressDataGridView;
		private TextBox deliveryDeliveryChargeTextBox;
		private Label deliveryDeliveryChargeLabel;
		private Button acceptAddressButton;
		private Button cancelAddressButton;
		private Button deleteDeliveryAddressButton;
		private Button collectionButton;
		private Button deliveryButton;
		private Button deleteCustomerButton;
		private Button findCustomerButton;
	}
}