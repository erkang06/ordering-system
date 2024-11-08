namespace ordering_system
{
	partial class OrderSummary
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSummary));
			orderSummaryLabel = new Label();
			orderDataGridView = new DataGridView();
			deliveryChargePriceLabel = new Label();
			subtotalPriceLabel = new Label();
			deliveryChargeTextLabel = new Label();
			subtotalTextLabel = new Label();
			totalPriceLabel = new Label();
			totalTextLabel = new Label();
			printKitchenTicketButton = new Button();
			printCustomerTicketButton = new Button();
			printOrderSummaryButton = new Button();
			cancelButton = new Button();
			datePicker = new DateTimePicker();
			printDocument = new System.Drawing.Printing.PrintDocument();
			printPreviewDialog = new PrintPreviewDialog();
			phoneNumberLabel = new Label();
			phoneNumberFieldLabel = new Label();
			postcodeLabel = new Label();
			cityLabel = new Label();
			villageLabel = new Label();
			streetNameLabel = new Label();
			HouseNumberLabel = new Label();
			villageFieldLabel = new Label();
			streetNameFieldLabel = new Label();
			houseNumberFieldLabel = new Label();
			postcodeFieldLabel = new Label();
			cityFieldLabel = new Label();
			customerNameFieldLabel = new Label();
			customerNameLabel = new Label();
			singleOrderDataGridView = new DataGridView();
			orderTypeFieldLabel = new Label();
			orderTypeLabel = new Label();
			((System.ComponentModel.ISupportInitialize)orderDataGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)singleOrderDataGridView).BeginInit();
			SuspendLayout();
			// 
			// orderSummaryLabel
			// 
			orderSummaryLabel.BackColor = Color.Transparent;
			orderSummaryLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			orderSummaryLabel.ForeColor = Color.Black;
			orderSummaryLabel.Location = new Point(12, 14);
			orderSummaryLabel.Margin = new Padding(3, 5, 3, 5);
			orderSummaryLabel.Name = "orderSummaryLabel";
			orderSummaryLabel.Size = new Size(450, 80);
			orderSummaryLabel.TabIndex = 43;
			orderSummaryLabel.Text = "Order Summary";
			// 
			// orderDataGridView
			// 
			orderDataGridView.AllowUserToAddRows = false;
			orderDataGridView.AllowUserToDeleteRows = false;
			orderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			orderDataGridView.BackgroundColor = Color.Gainsboro;
			orderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			orderDataGridView.Location = new Point(12, 98);
			orderDataGridView.MultiSelect = false;
			orderDataGridView.Name = "orderDataGridView";
			orderDataGridView.ReadOnly = true;
			orderDataGridView.RowHeadersVisible = false;
			orderDataGridView.RowHeadersWidth = 82;
			orderDataGridView.ScrollBars = ScrollBars.Vertical;
			orderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			orderDataGridView.Size = new Size(890, 840);
			orderDataGridView.TabIndex = 2;
			orderDataGridView.CellClick += orderDataGridView_CellClick;
			// 
			// deliveryChargePriceLabel
			// 
			deliveryChargePriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			deliveryChargePriceLabel.BackColor = Color.White;
			deliveryChargePriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryChargePriceLabel.ForeColor = Color.Black;
			deliveryChargePriceLabel.Location = new Point(1758, 991);
			deliveryChargePriceLabel.Name = "deliveryChargePriceLabel";
			deliveryChargePriceLabel.RightToLeft = RightToLeft.Yes;
			deliveryChargePriceLabel.Size = new Size(150, 40);
			deliveryChargePriceLabel.TabIndex = 50;
			deliveryChargePriceLabel.Text = "00.00";
			// 
			// subtotalPriceLabel
			// 
			subtotalPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			subtotalPriceLabel.BackColor = Color.White;
			subtotalPriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			subtotalPriceLabel.ForeColor = Color.Black;
			subtotalPriceLabel.Location = new Point(1758, 951);
			subtotalPriceLabel.Name = "subtotalPriceLabel";
			subtotalPriceLabel.RightToLeft = RightToLeft.Yes;
			subtotalPriceLabel.Size = new Size(150, 40);
			subtotalPriceLabel.TabIndex = 49;
			subtotalPriceLabel.Text = "0000.00";
			// 
			// deliveryChargeTextLabel
			// 
			deliveryChargeTextLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			deliveryChargeTextLabel.BackColor = Color.Transparent;
			deliveryChargeTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryChargeTextLabel.ForeColor = Color.DarkOliveGreen;
			deliveryChargeTextLabel.Location = new Point(1609, 986);
			deliveryChargeTextLabel.Name = "deliveryChargeTextLabel";
			deliveryChargeTextLabel.Size = new Size(140, 40);
			deliveryChargeTextLabel.TabIndex = 48;
			deliveryChargeTextLabel.Text = "Delivery:";
			// 
			// subtotalTextLabel
			// 
			subtotalTextLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			subtotalTextLabel.BackColor = Color.Transparent;
			subtotalTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			subtotalTextLabel.ForeColor = Color.DarkOliveGreen;
			subtotalTextLabel.Location = new Point(1609, 946);
			subtotalTextLabel.Name = "subtotalTextLabel";
			subtotalTextLabel.Size = new Size(140, 40);
			subtotalTextLabel.TabIndex = 47;
			subtotalTextLabel.Text = "Subtotal:";
			// 
			// totalPriceLabel
			// 
			totalPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			totalPriceLabel.BackColor = Color.White;
			totalPriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			totalPriceLabel.ForeColor = Color.Black;
			totalPriceLabel.Location = new Point(1758, 1031);
			totalPriceLabel.Name = "totalPriceLabel";
			totalPriceLabel.RightToLeft = RightToLeft.Yes;
			totalPriceLabel.Size = new Size(150, 40);
			totalPriceLabel.TabIndex = 52;
			totalPriceLabel.Text = "0000.00";
			// 
			// totalTextLabel
			// 
			totalTextLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			totalTextLabel.BackColor = Color.Transparent;
			totalTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			totalTextLabel.ForeColor = Color.DarkOliveGreen;
			totalTextLabel.Location = new Point(1609, 1026);
			totalTextLabel.Name = "totalTextLabel";
			totalTextLabel.Size = new Size(140, 40);
			totalTextLabel.TabIndex = 51;
			totalTextLabel.Text = "Total:";
			// 
			// printKitchenTicketButton
			// 
			printKitchenTicketButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			printKitchenTicketButton.BackColor = SystemColors.Control;
			printKitchenTicketButton.FlatStyle = FlatStyle.Flat;
			printKitchenTicketButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			printKitchenTicketButton.Location = new Point(276, 948);
			printKitchenTicketButton.Name = "printKitchenTicketButton";
			printKitchenTicketButton.Size = new Size(310, 123);
			printKitchenTicketButton.TabIndex = 4;
			printKitchenTicketButton.Text = "Print Kitchen Ticket";
			printKitchenTicketButton.UseVisualStyleBackColor = false;
			printKitchenTicketButton.Click += printTicketButton_Click;
			// 
			// printCustomerTicketButton
			// 
			printCustomerTicketButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			printCustomerTicketButton.BackColor = SystemColors.Control;
			printCustomerTicketButton.FlatStyle = FlatStyle.Flat;
			printCustomerTicketButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			printCustomerTicketButton.Location = new Point(592, 948);
			printCustomerTicketButton.Name = "printCustomerTicketButton";
			printCustomerTicketButton.Size = new Size(310, 123);
			printCustomerTicketButton.TabIndex = 5;
			printCustomerTicketButton.Text = "Print Customer Ticket";
			printCustomerTicketButton.UseVisualStyleBackColor = false;
			printCustomerTicketButton.Click += printTicketButton_Click;
			// 
			// printOrderSummaryButton
			// 
			printOrderSummaryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			printOrderSummaryButton.BackColor = SystemColors.Control;
			printOrderSummaryButton.FlatStyle = FlatStyle.Flat;
			printOrderSummaryButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			printOrderSummaryButton.Location = new Point(12, 948);
			printOrderSummaryButton.Name = "printOrderSummaryButton";
			printOrderSummaryButton.Size = new Size(258, 123);
			printOrderSummaryButton.TabIndex = 3;
			printOrderSummaryButton.Text = "Print Summary";
			printOrderSummaryButton.UseVisualStyleBackColor = false;
			printOrderSummaryButton.Click += printOrderSummaryButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1818, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 6;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// datePicker
			// 
			datePicker.CalendarFont = new Font("Segoe UI", 14F);
			datePicker.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			datePicker.Format = DateTimePickerFormat.Short;
			datePicker.Location = new Point(622, 12);
			datePicker.MinimumSize = new Size(0, 80);
			datePicker.Name = "datePicker";
			datePicker.ShowUpDown = true;
			datePicker.Size = new Size(280, 80);
			datePicker.TabIndex = 1;
			datePicker.Value = new DateTime(2024, 10, 18, 10, 18, 38, 0);
			datePicker.ValueChanged += datePicker_ValueChanged;
			// 
			// printDocument
			// 
			printDocument.PrintPage += printDocument_PrintPage;
			// 
			// printPreviewDialog
			// 
			printPreviewDialog.AutoScrollMargin = new Size(0, 0);
			printPreviewDialog.AutoScrollMinSize = new Size(0, 0);
			printPreviewDialog.ClientSize = new Size(400, 300);
			printPreviewDialog.Enabled = true;
			printPreviewDialog.Icon = (Icon)resources.GetObject("printPreviewDialog.Icon");
			printPreviewDialog.Name = "printPreviewDialog1";
			printPreviewDialog.Visible = false;
			// 
			// phoneNumberLabel
			// 
			phoneNumberLabel.BackColor = Color.Transparent;
			phoneNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			phoneNumberLabel.ForeColor = Color.Black;
			phoneNumberLabel.Location = new Point(908, 24);
			phoneNumberLabel.Margin = new Padding(3, 5, 3, 5);
			phoneNumberLabel.Name = "phoneNumberLabel";
			phoneNumberLabel.Size = new Size(260, 50);
			phoneNumberLabel.TabIndex = 61;
			phoneNumberLabel.Text = "Phone Number:";
			// 
			// phoneNumberFieldLabel
			// 
			phoneNumberFieldLabel.BackColor = Color.White;
			phoneNumberFieldLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			phoneNumberFieldLabel.ForeColor = Color.Black;
			phoneNumberFieldLabel.Location = new Point(1174, 26);
			phoneNumberFieldLabel.Margin = new Padding(3, 5, 3, 5);
			phoneNumberFieldLabel.Name = "phoneNumberFieldLabel";
			phoneNumberFieldLabel.Size = new Size(638, 50);
			phoneNumberFieldLabel.TabIndex = 65;
			// 
			// postcodeLabel
			// 
			postcodeLabel.BackColor = Color.Transparent;
			postcodeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			postcodeLabel.ForeColor = Color.Black;
			postcodeLabel.Location = new Point(1472, 178);
			postcodeLabel.Margin = new Padding(3, 5, 3, 5);
			postcodeLabel.Name = "postcodeLabel";
			postcodeLabel.Size = new Size(150, 40);
			postcodeLabel.TabIndex = 70;
			postcodeLabel.Text = "Postcode:";
			// 
			// cityLabel
			// 
			cityLabel.BackColor = Color.Transparent;
			cityLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			cityLabel.ForeColor = Color.Black;
			cityLabel.Location = new Point(1472, 138);
			cityLabel.Margin = new Padding(3, 5, 3, 5);
			cityLabel.Name = "cityLabel";
			cityLabel.Size = new Size(150, 40);
			cityLabel.TabIndex = 69;
			cityLabel.Text = "City:";
			// 
			// villageLabel
			// 
			villageLabel.BackColor = Color.Transparent;
			villageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			villageLabel.ForeColor = Color.Black;
			villageLabel.Location = new Point(1472, 98);
			villageLabel.Margin = new Padding(3, 5, 3, 5);
			villageLabel.Name = "villageLabel";
			villageLabel.Size = new Size(150, 40);
			villageLabel.TabIndex = 68;
			villageLabel.Text = "Village:";
			// 
			// streetNameLabel
			// 
			streetNameLabel.BackColor = Color.Transparent;
			streetNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			streetNameLabel.ForeColor = Color.Black;
			streetNameLabel.Location = new Point(908, 178);
			streetNameLabel.Margin = new Padding(3, 5, 3, 5);
			streetNameLabel.Name = "streetNameLabel";
			streetNameLabel.Size = new Size(240, 40);
			streetNameLabel.TabIndex = 67;
			streetNameLabel.Text = "Street Name:";
			// 
			// HouseNumberLabel
			// 
			HouseNumberLabel.BackColor = Color.Transparent;
			HouseNumberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			HouseNumberLabel.ForeColor = Color.Black;
			HouseNumberLabel.Location = new Point(908, 138);
			HouseNumberLabel.Margin = new Padding(3, 5, 3, 5);
			HouseNumberLabel.Name = "HouseNumberLabel";
			HouseNumberLabel.Size = new Size(240, 40);
			HouseNumberLabel.TabIndex = 66;
			HouseNumberLabel.Text = "House Number:";
			// 
			// villageFieldLabel
			// 
			villageFieldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			villageFieldLabel.BackColor = Color.White;
			villageFieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			villageFieldLabel.ForeColor = Color.Black;
			villageFieldLabel.Location = new Point(1628, 98);
			villageFieldLabel.Name = "villageFieldLabel";
			villageFieldLabel.RightToLeft = RightToLeft.Yes;
			villageFieldLabel.Size = new Size(280, 40);
			villageFieldLabel.TabIndex = 73;
			// 
			// streetNameFieldLabel
			// 
			streetNameFieldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			streetNameFieldLabel.BackColor = Color.White;
			streetNameFieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			streetNameFieldLabel.ForeColor = Color.Black;
			streetNameFieldLabel.Location = new Point(1154, 178);
			streetNameFieldLabel.Name = "streetNameFieldLabel";
			streetNameFieldLabel.RightToLeft = RightToLeft.Yes;
			streetNameFieldLabel.Size = new Size(312, 40);
			streetNameFieldLabel.TabIndex = 72;
			// 
			// houseNumberFieldLabel
			// 
			houseNumberFieldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			houseNumberFieldLabel.BackColor = Color.White;
			houseNumberFieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			houseNumberFieldLabel.ForeColor = Color.Black;
			houseNumberFieldLabel.Location = new Point(1154, 138);
			houseNumberFieldLabel.Name = "houseNumberFieldLabel";
			houseNumberFieldLabel.RightToLeft = RightToLeft.Yes;
			houseNumberFieldLabel.Size = new Size(312, 40);
			houseNumberFieldLabel.TabIndex = 71;
			// 
			// postcodeFieldLabel
			// 
			postcodeFieldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			postcodeFieldLabel.BackColor = Color.White;
			postcodeFieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			postcodeFieldLabel.ForeColor = Color.Black;
			postcodeFieldLabel.Location = new Point(1628, 178);
			postcodeFieldLabel.Name = "postcodeFieldLabel";
			postcodeFieldLabel.RightToLeft = RightToLeft.Yes;
			postcodeFieldLabel.Size = new Size(280, 40);
			postcodeFieldLabel.TabIndex = 75;
			// 
			// cityFieldLabel
			// 
			cityFieldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			cityFieldLabel.BackColor = Color.White;
			cityFieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cityFieldLabel.ForeColor = Color.Black;
			cityFieldLabel.Location = new Point(1628, 138);
			cityFieldLabel.Name = "cityFieldLabel";
			cityFieldLabel.RightToLeft = RightToLeft.Yes;
			cityFieldLabel.Size = new Size(280, 40);
			cityFieldLabel.TabIndex = 74;
			// 
			// customerNameFieldLabel
			// 
			customerNameFieldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			customerNameFieldLabel.BackColor = Color.White;
			customerNameFieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			customerNameFieldLabel.ForeColor = Color.Black;
			customerNameFieldLabel.Location = new Point(1154, 98);
			customerNameFieldLabel.Name = "customerNameFieldLabel";
			customerNameFieldLabel.RightToLeft = RightToLeft.Yes;
			customerNameFieldLabel.Size = new Size(312, 40);
			customerNameFieldLabel.TabIndex = 77;
			// 
			// customerNameLabel
			// 
			customerNameLabel.BackColor = Color.Transparent;
			customerNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			customerNameLabel.ForeColor = Color.Black;
			customerNameLabel.Location = new Point(908, 98);
			customerNameLabel.Margin = new Padding(3, 5, 3, 5);
			customerNameLabel.Name = "customerNameLabel";
			customerNameLabel.Size = new Size(240, 40);
			customerNameLabel.TabIndex = 76;
			customerNameLabel.Text = "Customer Name:";
			// 
			// singleOrderDataGridView
			// 
			singleOrderDataGridView.AllowUserToAddRows = false;
			singleOrderDataGridView.AllowUserToDeleteRows = false;
			singleOrderDataGridView.Anchor = AnchorStyles.Right;
			singleOrderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			singleOrderDataGridView.BackgroundColor = Color.White;
			singleOrderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			singleOrderDataGridView.ColumnHeadersVisible = false;
			singleOrderDataGridView.Location = new Point(908, 226);
			singleOrderDataGridView.MultiSelect = false;
			singleOrderDataGridView.Name = "singleOrderDataGridView";
			singleOrderDataGridView.ReadOnly = true;
			singleOrderDataGridView.RowHeadersVisible = false;
			singleOrderDataGridView.RowHeadersWidth = 82;
			singleOrderDataGridView.ScrollBars = ScrollBars.Vertical;
			singleOrderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			singleOrderDataGridView.Size = new Size(1000, 712);
			singleOrderDataGridView.TabIndex = 55;
			singleOrderDataGridView.TabStop = false;
			// 
			// orderTypeFieldLabel
			// 
			orderTypeFieldLabel.BackColor = Color.White;
			orderTypeFieldLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			orderTypeFieldLabel.ForeColor = Color.Black;
			orderTypeFieldLabel.Location = new Point(1114, 951);
			orderTypeFieldLabel.Margin = new Padding(3, 5, 3, 5);
			orderTypeFieldLabel.Name = "orderTypeFieldLabel";
			orderTypeFieldLabel.Size = new Size(489, 50);
			orderTypeFieldLabel.TabIndex = 79;
			// 
			// orderTypeLabel
			// 
			orderTypeLabel.BackColor = Color.Transparent;
			orderTypeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			orderTypeLabel.ForeColor = Color.Black;
			orderTypeLabel.Location = new Point(908, 951);
			orderTypeLabel.Margin = new Padding(3, 5, 3, 5);
			orderTypeLabel.Name = "orderTypeLabel";
			orderTypeLabel.Size = new Size(200, 50);
			orderTypeLabel.TabIndex = 78;
			orderTypeLabel.Text = "Order Type:";
			// 
			// OrderSummary
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(orderTypeFieldLabel);
			Controls.Add(orderTypeLabel);
			Controls.Add(customerNameFieldLabel);
			Controls.Add(customerNameLabel);
			Controls.Add(postcodeFieldLabel);
			Controls.Add(cityFieldLabel);
			Controls.Add(villageFieldLabel);
			Controls.Add(streetNameFieldLabel);
			Controls.Add(houseNumberFieldLabel);
			Controls.Add(postcodeLabel);
			Controls.Add(cityLabel);
			Controls.Add(villageLabel);
			Controls.Add(streetNameLabel);
			Controls.Add(HouseNumberLabel);
			Controls.Add(phoneNumberFieldLabel);
			Controls.Add(phoneNumberLabel);
			Controls.Add(datePicker);
			Controls.Add(cancelButton);
			Controls.Add(printOrderSummaryButton);
			Controls.Add(singleOrderDataGridView);
			Controls.Add(printCustomerTicketButton);
			Controls.Add(printKitchenTicketButton);
			Controls.Add(totalPriceLabel);
			Controls.Add(totalTextLabel);
			Controls.Add(deliveryChargePriceLabel);
			Controls.Add(subtotalPriceLabel);
			Controls.Add(deliveryChargeTextLabel);
			Controls.Add(subtotalTextLabel);
			Controls.Add(orderDataGridView);
			Controls.Add(orderSummaryLabel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "OrderSummary";
			Text = "OrderSummary";
			Load += OrderSummary_Load;
			((System.ComponentModel.ISupportInitialize)orderDataGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)singleOrderDataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Label orderSummaryLabel;
		private DataGridView orderDataGridView;
		private Label deliveryChargePriceLabel;
		private Label subtotalPriceLabel;
		private Label deliveryChargeTextLabel;
		private Label subtotalTextLabel;
		private Label totalPriceLabel;
		private Label totalTextLabel;
		private Button printKitchenTicketButton;
		private Button printCustomerTicketButton;
		private Button printOrderSummaryButton;
		private Button cancelButton;
		private DateTimePicker datePicker;
		private System.Drawing.Printing.PrintDocument printDocument;
		private PrintPreviewDialog printPreviewDialog;
		private Label phoneNumberLabel;
		private Label phoneNumberFieldLabel;
		private Label postcodeLabel;
		private Label cityLabel;
		private Label villageLabel;
		private Label streetNameLabel;
		private Label HouseNumberLabel;
		private Label villageFieldLabel;
		private Label streetNameFieldLabel;
		private Label houseNumberFieldLabel;
		private Label postcodeFieldLabel;
		private Label cityFieldLabel;
		private Label customerNameFieldLabel;
		private Label customerNameLabel;
		private DataGridView singleOrderDataGridView;
		private Label orderTypeFieldLabel;
		private Label orderTypeLabel;
	}
}