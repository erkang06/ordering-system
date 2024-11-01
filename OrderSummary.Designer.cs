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
			singleOrderDataGridView = new DataGridView();
			printOrderSummaryButton = new Button();
			cancelButton = new Button();
			datePicker = new DateTimePicker();
			printOrderSummary = new System.Drawing.Printing.PrintDocument();
			printPreviewDialog = new PrintPreviewDialog();
			customerNameLabel = new Label();
			label3 = new Label();
			billingPostcodeLabel = new Label();
			billingCityLabel = new Label();
			billingVillageLabel = new Label();
			billingStreetNameLabel = new Label();
			billingHouseNumberLabel = new Label();
			label1 = new Label();
			label2 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
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
			orderDataGridView.TabIndex = 44;
			orderDataGridView.TabStop = false;
			orderDataGridView.CellClick += ordersDataGridView_CellClick;
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
			printKitchenTicketButton.TabIndex = 53;
			printKitchenTicketButton.Text = "Print Kitchen Ticket";
			printKitchenTicketButton.UseVisualStyleBackColor = false;
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
			printCustomerTicketButton.TabIndex = 54;
			printCustomerTicketButton.Text = "Print Customer Ticket";
			printCustomerTicketButton.UseVisualStyleBackColor = false;
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
			// printOrderSummaryButton
			// 
			printOrderSummaryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			printOrderSummaryButton.BackColor = SystemColors.Control;
			printOrderSummaryButton.FlatStyle = FlatStyle.Flat;
			printOrderSummaryButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			printOrderSummaryButton.Location = new Point(12, 948);
			printOrderSummaryButton.Name = "printOrderSummaryButton";
			printOrderSummaryButton.Size = new Size(258, 123);
			printOrderSummaryButton.TabIndex = 56;
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
			cancelButton.TabIndex = 57;
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
			datePicker.TabIndex = 58;
			datePicker.Value = new DateTime(2024, 10, 18, 10, 18, 38, 0);
			datePicker.ValueChanged += datePicker_ValueChanged;
			// 
			// printOrderSummary
			// 
			printOrderSummary.PrintPage += printOrderSummary_PrintPage;
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
			// customerNameLabel
			// 
			customerNameLabel.BackColor = Color.Transparent;
			customerNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			customerNameLabel.ForeColor = Color.Black;
			customerNameLabel.Location = new Point(908, 24);
			customerNameLabel.Margin = new Padding(3, 5, 3, 5);
			customerNameLabel.Name = "customerNameLabel";
			customerNameLabel.Size = new Size(220, 50);
			customerNameLabel.TabIndex = 61;
			customerNameLabel.Text = "Customer:";
			// 
			// label3
			// 
			label3.BackColor = Color.White;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label3.ForeColor = Color.Black;
			label3.Location = new Point(1134, 26);
			label3.Margin = new Padding(3, 5, 3, 5);
			label3.Name = "label3";
			label3.Size = new Size(678, 50);
			label3.TabIndex = 65;
			label3.Text = "Customer:";
			// 
			// billingPostcodeLabel
			// 
			billingPostcodeLabel.BackColor = Color.Transparent;
			billingPostcodeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			billingPostcodeLabel.ForeColor = Color.Black;
			billingPostcodeLabel.Location = new Point(1472, 178);
			billingPostcodeLabel.Margin = new Padding(3, 5, 3, 5);
			billingPostcodeLabel.Name = "billingPostcodeLabel";
			billingPostcodeLabel.Size = new Size(150, 40);
			billingPostcodeLabel.TabIndex = 70;
			billingPostcodeLabel.Text = "Postcode:";
			// 
			// billingCityLabel
			// 
			billingCityLabel.BackColor = Color.Transparent;
			billingCityLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			billingCityLabel.ForeColor = Color.Black;
			billingCityLabel.Location = new Point(1472, 138);
			billingCityLabel.Margin = new Padding(3, 5, 3, 5);
			billingCityLabel.Name = "billingCityLabel";
			billingCityLabel.Size = new Size(150, 40);
			billingCityLabel.TabIndex = 69;
			billingCityLabel.Text = "City:";
			// 
			// billingVillageLabel
			// 
			billingVillageLabel.BackColor = Color.Transparent;
			billingVillageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			billingVillageLabel.ForeColor = Color.Black;
			billingVillageLabel.Location = new Point(1472, 98);
			billingVillageLabel.Margin = new Padding(3, 5, 3, 5);
			billingVillageLabel.Name = "billingVillageLabel";
			billingVillageLabel.Size = new Size(150, 40);
			billingVillageLabel.TabIndex = 68;
			billingVillageLabel.Text = "Village:";
			// 
			// billingStreetNameLabel
			// 
			billingStreetNameLabel.BackColor = Color.Transparent;
			billingStreetNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			billingStreetNameLabel.ForeColor = Color.Black;
			billingStreetNameLabel.Location = new Point(908, 178);
			billingStreetNameLabel.Margin = new Padding(3, 5, 3, 5);
			billingStreetNameLabel.Name = "billingStreetNameLabel";
			billingStreetNameLabel.Size = new Size(220, 40);
			billingStreetNameLabel.TabIndex = 67;
			billingStreetNameLabel.Text = "Street Name:";
			// 
			// billingHouseNumberLabel
			// 
			billingHouseNumberLabel.BackColor = Color.Transparent;
			billingHouseNumberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			billingHouseNumberLabel.ForeColor = Color.Black;
			billingHouseNumberLabel.Location = new Point(908, 138);
			billingHouseNumberLabel.Margin = new Padding(3, 5, 3, 5);
			billingHouseNumberLabel.Name = "billingHouseNumberLabel";
			billingHouseNumberLabel.Size = new Size(220, 40);
			billingHouseNumberLabel.TabIndex = 66;
			billingHouseNumberLabel.Text = "House Number:";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label1.BackColor = Color.White;
			label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.Black;
			label1.Location = new Point(1628, 98);
			label1.Name = "label1";
			label1.RightToLeft = RightToLeft.Yes;
			label1.Size = new Size(280, 40);
			label1.TabIndex = 73;
			label1.Text = "hyperflop village";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label2.BackColor = Color.White;
			label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.Black;
			label2.Location = new Point(1134, 178);
			label2.Name = "label2";
			label2.RightToLeft = RightToLeft.Yes;
			label2.Size = new Size(332, 40);
			label2.TabIndex = 72;
			label2.Text = "00.00";
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label4.BackColor = Color.White;
			label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.Black;
			label4.Location = new Point(1134, 138);
			label4.Name = "label4";
			label4.RightToLeft = RightToLeft.Yes;
			label4.Size = new Size(332, 40);
			label4.TabIndex = 71;
			label4.Text = "0000.00";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label5.BackColor = Color.White;
			label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.Black;
			label5.Location = new Point(1628, 178);
			label5.Name = "label5";
			label5.RightToLeft = RightToLeft.Yes;
			label5.Size = new Size(280, 40);
			label5.TabIndex = 75;
			label5.Text = "0000.00";
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label6.BackColor = Color.White;
			label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.Black;
			label6.Location = new Point(1628, 138);
			label6.Name = "label6";
			label6.RightToLeft = RightToLeft.Yes;
			label6.Size = new Size(280, 40);
			label6.TabIndex = 74;
			label6.Text = "superbirmingham";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label7.BackColor = Color.White;
			label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.Black;
			label7.Location = new Point(1134, 98);
			label7.Name = "label7";
			label7.RightToLeft = RightToLeft.Yes;
			label7.Size = new Size(332, 40);
			label7.TabIndex = 77;
			label7.Text = "0000.00";
			// 
			// label8
			// 
			label8.BackColor = Color.Transparent;
			label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			label8.ForeColor = Color.Black;
			label8.Location = new Point(908, 98);
			label8.Margin = new Padding(3, 5, 3, 5);
			label8.Name = "label8";
			label8.Size = new Size(220, 40);
			label8.TabIndex = 76;
			label8.Text = "Phone Number:";
			// 
			// OrderSummary
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(label7);
			Controls.Add(label8);
			Controls.Add(label5);
			Controls.Add(label6);
			Controls.Add(label1);
			Controls.Add(label2);
			Controls.Add(label4);
			Controls.Add(billingPostcodeLabel);
			Controls.Add(billingCityLabel);
			Controls.Add(billingVillageLabel);
			Controls.Add(billingStreetNameLabel);
			Controls.Add(billingHouseNumberLabel);
			Controls.Add(label3);
			Controls.Add(customerNameLabel);
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
		private DataGridView singleOrderDataGridView;
		private Button printOrderSummaryButton;
		private Button cancelButton;
		private DateTimePicker datePicker;
		private System.Drawing.Printing.PrintDocument printOrderSummary;
		private PrintPreviewDialog printPreviewDialog;
		private Label customerNameLabel;
		private Label label3;
		private Label billingPostcodeLabel;
		private Label billingCityLabel;
		private Label billingVillageLabel;
		private Label billingStreetNameLabel;
		private Label billingHouseNumberLabel;
		private Label label1;
		private Label label2;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
	}
}