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
			orderDataGridView.Location = new Point(12, 102);
			orderDataGridView.MultiSelect = false;
			orderDataGridView.Name = "orderDataGridView";
			orderDataGridView.ReadOnly = true;
			orderDataGridView.RowHeadersWidth = 82;
			orderDataGridView.ScrollBars = ScrollBars.Vertical;
			orderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			orderDataGridView.Size = new Size(1302, 835);
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
			deliveryChargePriceLabel.Location = new Point(176, 985);
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
			subtotalPriceLabel.Location = new Point(176, 945);
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
			deliveryChargeTextLabel.Location = new Point(12, 980);
			deliveryChargeTextLabel.Name = "deliveryChargeTextLabel";
			deliveryChargeTextLabel.Size = new Size(158, 40);
			deliveryChargeTextLabel.TabIndex = 48;
			deliveryChargeTextLabel.Text = "Delivery:";
			// 
			// subtotalTextLabel
			// 
			subtotalTextLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			subtotalTextLabel.BackColor = Color.Transparent;
			subtotalTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			subtotalTextLabel.ForeColor = Color.DarkOliveGreen;
			subtotalTextLabel.Location = new Point(12, 940);
			subtotalTextLabel.Name = "subtotalTextLabel";
			subtotalTextLabel.Size = new Size(158, 40);
			subtotalTextLabel.TabIndex = 47;
			subtotalTextLabel.Text = "Subtotal:";
			// 
			// totalPriceLabel
			// 
			totalPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			totalPriceLabel.BackColor = Color.White;
			totalPriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			totalPriceLabel.ForeColor = Color.Black;
			totalPriceLabel.Location = new Point(176, 1025);
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
			totalTextLabel.Location = new Point(12, 1020);
			totalTextLabel.Name = "totalTextLabel";
			totalTextLabel.Size = new Size(158, 40);
			totalTextLabel.TabIndex = 51;
			totalTextLabel.Text = "Total:";
			// 
			// printKitchenTicketButton
			// 
			printKitchenTicketButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			printKitchenTicketButton.BackColor = SystemColors.Control;
			printKitchenTicketButton.FlatStyle = FlatStyle.Flat;
			printKitchenTicketButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			printKitchenTicketButton.Location = new Point(608, 945);
			printKitchenTicketButton.Name = "printKitchenTicketButton";
			printKitchenTicketButton.Size = new Size(350, 123);
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
			printCustomerTicketButton.Location = new Point(964, 945);
			printCustomerTicketButton.Name = "printCustomerTicketButton";
			printCustomerTicketButton.Size = new Size(350, 123);
			printCustomerTicketButton.TabIndex = 54;
			printCustomerTicketButton.Text = "Print Customer Ticket";
			printCustomerTicketButton.UseVisualStyleBackColor = false;
			// 
			// singleOrderDataGridView
			// 
			singleOrderDataGridView.Anchor = AnchorStyles.Right;
			singleOrderDataGridView.BackgroundColor = Color.White;
			singleOrderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			singleOrderDataGridView.Location = new Point(1320, 0);
			singleOrderDataGridView.MultiSelect = false;
			singleOrderDataGridView.Name = "singleOrderDataGridView";
			singleOrderDataGridView.ReadOnly = true;
			singleOrderDataGridView.RowHeadersWidth = 82;
			singleOrderDataGridView.ScrollBars = ScrollBars.Vertical;
			singleOrderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			singleOrderDataGridView.Size = new Size(600, 1080);
			singleOrderDataGridView.TabIndex = 55;
			singleOrderDataGridView.TabStop = false;
			// 
			// printOrderSummaryButton
			// 
			printOrderSummaryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			printOrderSummaryButton.BackColor = SystemColors.Control;
			printOrderSummaryButton.FlatStyle = FlatStyle.Flat;
			printOrderSummaryButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			printOrderSummaryButton.Location = new Point(332, 945);
			printOrderSummaryButton.Name = "printOrderSummaryButton";
			printOrderSummaryButton.Size = new Size(270, 123);
			printOrderSummaryButton.TabIndex = 56;
			printOrderSummaryButton.Text = "Print Summary";
			printOrderSummaryButton.UseVisualStyleBackColor = false;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1224, 12);
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
			datePicker.Location = new Point(938, 12);
			datePicker.MinimumSize = new Size(0, 80);
			datePicker.Name = "datePicker";
			datePicker.ShowUpDown = true;
			datePicker.Size = new Size(280, 80);
			datePicker.TabIndex = 58;
			datePicker.Value = new DateTime(2024, 10, 18, 10, 18, 38, 0);
			datePicker.ValueChanged += datePicker_ValueChanged;
			// 
			// OrderSummary
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
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
	}
}