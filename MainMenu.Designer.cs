namespace ordering_system
{
	partial class MainMenu
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			customerDetailsPanel = new Panel();
			customerDetailsLabel = new Label();
			orderNumberLabel = new Label();
			orderTypePanel = new Panel();
			collectionButton = new Button();
			counterButton = new Button();
			deliveryButton = new Button();
			managerFunctionsPanel = new Panel();
			timeLabel = new Label();
			viewOrdersButton = new Button();
			acceptOrderButton = new Button();
			managerFunctionsButton = new Button();
			itemEditFunctionsPanel = new Panel();
			smallPriceButton = new Button();
			largePriceButton = new Button();
			cancelOrderButton = new Button();
			increaseQuantityButton = new Button();
			decreaseQuantityButton = new Button();
			priceEditButton = new Button();
			memoButton = new Button();
			runningOrderPanel = new Panel();
			estimatedTimeLabel = new Label();
			estimatedTimePicker = new DateTimePicker();
			totalPriceLabel = new Label();
			deliveryChargePriceLabel = new Label();
			subtotalPriceLabel = new Label();
			deliveryChargeTextLabel = new Label();
			subtotalTextLabel = new Label();
			runningOrderScrollBar = new VScrollBar();
			commonItemsPanel = new Panel();
			itemsPanel = new Panel();
			categoriesPanel = new Panel();
			paymentPanel = new Panel();
			viewOrdersPanel = new Panel();
			timer = new System.Windows.Forms.Timer(components);
			customerDetailsPanel.SuspendLayout();
			orderTypePanel.SuspendLayout();
			managerFunctionsPanel.SuspendLayout();
			itemEditFunctionsPanel.SuspendLayout();
			runningOrderPanel.SuspendLayout();
			SuspendLayout();
			// 
			// customerDetailsPanel
			// 
			customerDetailsPanel.BackColor = Color.Teal;
			customerDetailsPanel.Controls.Add(customerDetailsLabel);
			customerDetailsPanel.Controls.Add(orderNumberLabel);
			customerDetailsPanel.Location = new Point(0, 0);
			customerDetailsPanel.Margin = new Padding(0);
			customerDetailsPanel.Name = "customerDetailsPanel";
			customerDetailsPanel.Size = new Size(1110, 80);
			customerDetailsPanel.TabIndex = 0;
			customerDetailsPanel.Click += customerDetails_Click;
			// 
			// customerDetailsLabel
			// 
			customerDetailsLabel.BackColor = Color.Transparent;
			customerDetailsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
			customerDetailsLabel.ForeColor = Color.White;
			customerDetailsLabel.Location = new Point(90, 21);
			customerDetailsLabel.Name = "customerDetailsLabel";
			customerDetailsLabel.Size = new Size(1004, 45);
			customerDetailsLabel.TabIndex = 1;
			customerDetailsLabel.Text = "phone number and address here";
			customerDetailsLabel.Click += customerDetails_Click;
			// 
			// orderNumberLabel
			// 
			orderNumberLabel.BackColor = Color.Transparent;
			orderNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			orderNumberLabel.ForeColor = Color.White;
			orderNumberLabel.Location = new Point(10, 15);
			orderNumberLabel.Name = "orderNumberLabel";
			orderNumberLabel.Size = new Size(84, 45);
			orderNumberLabel.TabIndex = 0;
			orderNumberLabel.Text = "100";
			// 
			// orderTypePanel
			// 
			orderTypePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			orderTypePanel.BackColor = Color.White;
			orderTypePanel.Controls.Add(collectionButton);
			orderTypePanel.Controls.Add(counterButton);
			orderTypePanel.Controls.Add(deliveryButton);
			orderTypePanel.Location = new Point(1110, 0);
			orderTypePanel.Margin = new Padding(0);
			orderTypePanel.Name = "orderTypePanel";
			orderTypePanel.Size = new Size(630, 80);
			orderTypePanel.TabIndex = 1;
			// 
			// collectionButton
			// 
			collectionButton.BackColor = Color.Transparent;
			collectionButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			collectionButton.Location = new Point(420, 0);
			collectionButton.Name = "collectionButton";
			collectionButton.Size = new Size(210, 80);
			collectionButton.TabIndex = 2;
			collectionButton.Text = "Collection";
			collectionButton.UseVisualStyleBackColor = false;
			collectionButton.Click += collectionButton_Click;
			// 
			// counterButton
			// 
			counterButton.BackColor = Color.Transparent;
			counterButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			counterButton.Location = new Point(210, 0);
			counterButton.Name = "counterButton";
			counterButton.Size = new Size(210, 80);
			counterButton.TabIndex = 1;
			counterButton.Text = "Counter";
			counterButton.UseVisualStyleBackColor = false;
			counterButton.Click += counterButton_Click;
			// 
			// deliveryButton
			// 
			deliveryButton.BackColor = Color.Transparent;
			deliveryButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			deliveryButton.Location = new Point(0, 0);
			deliveryButton.Name = "deliveryButton";
			deliveryButton.Size = new Size(210, 80);
			deliveryButton.TabIndex = 0;
			deliveryButton.Text = "Delivery";
			deliveryButton.UseVisualStyleBackColor = false;
			deliveryButton.Click += deliveryButton_Click;
			// 
			// managerFunctionsPanel
			// 
			managerFunctionsPanel.Anchor = AnchorStyles.Right;
			managerFunctionsPanel.BackColor = Color.Gold;
			managerFunctionsPanel.Controls.Add(timeLabel);
			managerFunctionsPanel.Controls.Add(viewOrdersButton);
			managerFunctionsPanel.Controls.Add(acceptOrderButton);
			managerFunctionsPanel.Controls.Add(managerFunctionsButton);
			managerFunctionsPanel.Location = new Point(1740, 0);
			managerFunctionsPanel.Margin = new Padding(0);
			managerFunctionsPanel.Name = "managerFunctionsPanel";
			managerFunctionsPanel.Size = new Size(180, 1080);
			managerFunctionsPanel.TabIndex = 2;
			// 
			// timeLabel
			// 
			timeLabel.Font = new Font("Segoe UI", 12F);
			timeLabel.Location = new Point(0, 890);
			timeLabel.Name = "timeLabel";
			timeLabel.Size = new Size(180, 90);
			timeLabel.TabIndex = 6;
			timeLabel.Text = "00/00/00 00:00:00";
			timeLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// viewOrdersButton
			// 
			viewOrdersButton.BackColor = Color.Transparent;
			viewOrdersButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			viewOrdersButton.Location = new Point(0, 100);
			viewOrdersButton.Name = "viewOrdersButton";
			viewOrdersButton.Size = new Size(180, 100);
			viewOrdersButton.TabIndex = 5;
			viewOrdersButton.Text = "View Orders";
			viewOrdersButton.UseVisualStyleBackColor = false;
			viewOrdersButton.Click += viewOrdersButton_Click;
			// 
			// acceptOrderButton
			// 
			acceptOrderButton.BackColor = Color.Transparent;
			acceptOrderButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			acceptOrderButton.Location = new Point(0, 0);
			acceptOrderButton.Name = "acceptOrderButton";
			acceptOrderButton.Size = new Size(180, 100);
			acceptOrderButton.TabIndex = 4;
			acceptOrderButton.Text = "Accept Order";
			acceptOrderButton.UseVisualStyleBackColor = false;
			acceptOrderButton.Click += acceptOrderButton_Click;
			// 
			// managerFunctionsButton
			// 
			managerFunctionsButton.BackColor = Color.Transparent;
			managerFunctionsButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			managerFunctionsButton.Location = new Point(0, 980);
			managerFunctionsButton.Name = "managerFunctionsButton";
			managerFunctionsButton.Size = new Size(180, 100);
			managerFunctionsButton.TabIndex = 3;
			managerFunctionsButton.Text = "Manager Functions";
			managerFunctionsButton.UseVisualStyleBackColor = false;
			managerFunctionsButton.Click += managerFunctionsButton_Click;
			// 
			// itemEditFunctionsPanel
			// 
			itemEditFunctionsPanel.BackColor = Color.White;
			itemEditFunctionsPanel.Controls.Add(smallPriceButton);
			itemEditFunctionsPanel.Controls.Add(largePriceButton);
			itemEditFunctionsPanel.Controls.Add(cancelOrderButton);
			itemEditFunctionsPanel.Controls.Add(increaseQuantityButton);
			itemEditFunctionsPanel.Controls.Add(decreaseQuantityButton);
			itemEditFunctionsPanel.Controls.Add(priceEditButton);
			itemEditFunctionsPanel.Controls.Add(memoButton);
			itemEditFunctionsPanel.Location = new Point(0, 80);
			itemEditFunctionsPanel.Margin = new Padding(0);
			itemEditFunctionsPanel.Name = "itemEditFunctionsPanel";
			itemEditFunctionsPanel.Size = new Size(700, 80);
			itemEditFunctionsPanel.TabIndex = 2;
			// 
			// smallPriceButton
			// 
			smallPriceButton.Image = Properties.Resources.smallPrice;
			smallPriceButton.Location = new Point(400, 0);
			smallPriceButton.Name = "smallPriceButton";
			smallPriceButton.Size = new Size(100, 80);
			smallPriceButton.TabIndex = 6;
			smallPriceButton.UseVisualStyleBackColor = true;
			// 
			// largePriceButton
			// 
			largePriceButton.Image = Properties.Resources.largePrice;
			largePriceButton.Location = new Point(500, 0);
			largePriceButton.Name = "largePriceButton";
			largePriceButton.Size = new Size(100, 80);
			largePriceButton.TabIndex = 5;
			largePriceButton.UseVisualStyleBackColor = true;
			// 
			// cancelOrderButton
			// 
			cancelOrderButton.Image = Properties.Resources.redCancelOrder;
			cancelOrderButton.Location = new Point(600, 0);
			cancelOrderButton.Name = "cancelOrderButton";
			cancelOrderButton.Size = new Size(100, 80);
			cancelOrderButton.TabIndex = 4;
			cancelOrderButton.UseVisualStyleBackColor = true;
			// 
			// increaseQuantityButton
			// 
			increaseQuantityButton.Image = Properties.Resources.increaseQuantity;
			increaseQuantityButton.Location = new Point(300, 0);
			increaseQuantityButton.Name = "increaseQuantityButton";
			increaseQuantityButton.Size = new Size(100, 80);
			increaseQuantityButton.TabIndex = 3;
			increaseQuantityButton.UseVisualStyleBackColor = true;
			// 
			// decreaseQuantityButton
			// 
			decreaseQuantityButton.Image = Properties.Resources.decreaseQuantity;
			decreaseQuantityButton.Location = new Point(200, 0);
			decreaseQuantityButton.Name = "decreaseQuantityButton";
			decreaseQuantityButton.Size = new Size(100, 80);
			decreaseQuantityButton.TabIndex = 2;
			decreaseQuantityButton.UseVisualStyleBackColor = true;
			// 
			// priceEditButton
			// 
			priceEditButton.Image = Properties.Resources.priceEdit;
			priceEditButton.Location = new Point(100, 0);
			priceEditButton.Name = "priceEditButton";
			priceEditButton.Size = new Size(100, 80);
			priceEditButton.TabIndex = 1;
			priceEditButton.UseVisualStyleBackColor = true;
			// 
			// memoButton
			// 
			memoButton.Image = Properties.Resources.memo;
			memoButton.Location = new Point(0, 0);
			memoButton.Name = "memoButton";
			memoButton.Size = new Size(100, 80);
			memoButton.TabIndex = 0;
			memoButton.UseVisualStyleBackColor = true;
			// 
			// runningOrderPanel
			// 
			runningOrderPanel.BackColor = Color.Maroon;
			runningOrderPanel.Controls.Add(estimatedTimeLabel);
			runningOrderPanel.Controls.Add(estimatedTimePicker);
			runningOrderPanel.Controls.Add(totalPriceLabel);
			runningOrderPanel.Controls.Add(deliveryChargePriceLabel);
			runningOrderPanel.Controls.Add(subtotalPriceLabel);
			runningOrderPanel.Controls.Add(deliveryChargeTextLabel);
			runningOrderPanel.Controls.Add(subtotalTextLabel);
			runningOrderPanel.Controls.Add(runningOrderScrollBar);
			runningOrderPanel.Location = new Point(0, 160);
			runningOrderPanel.Margin = new Padding(0);
			runningOrderPanel.Name = "runningOrderPanel";
			runningOrderPanel.Size = new Size(700, 660);
			runningOrderPanel.TabIndex = 2;
			// 
			// estimatedTimeLabel
			// 
			estimatedTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			estimatedTimeLabel.BackColor = Color.Transparent;
			estimatedTimeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			estimatedTimeLabel.ForeColor = Color.White;
			estimatedTimeLabel.Location = new Point(285, 575);
			estimatedTimeLabel.Name = "estimatedTimeLabel";
			estimatedTimeLabel.Size = new Size(140, 40);
			estimatedTimeLabel.TabIndex = 8;
			estimatedTimeLabel.Text = "Est. Time:";
			// 
			// estimatedTimePicker
			// 
			estimatedTimePicker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			estimatedTimePicker.CalendarFont = new Font("Segoe UI", 14F);
			estimatedTimePicker.CustomFormat = "HH:mm";
			estimatedTimePicker.Font = new Font("Segoe UI", 9F);
			estimatedTimePicker.Format = DateTimePickerFormat.Custom;
			estimatedTimePicker.Location = new Point(285, 621);
			estimatedTimePicker.Name = "estimatedTimePicker";
			estimatedTimePicker.ShowUpDown = true;
			estimatedTimePicker.Size = new Size(140, 39);
			estimatedTimePicker.TabIndex = 7;
			// 
			// totalPriceLabel
			// 
			totalPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			totalPriceLabel.BackColor = Color.White;
			totalPriceLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			totalPriceLabel.ForeColor = Color.DodgerBlue;
			totalPriceLabel.Location = new Point(431, 580);
			totalPriceLabel.Name = "totalPriceLabel";
			totalPriceLabel.RightToLeft = RightToLeft.No;
			totalPriceLabel.Size = new Size(269, 80);
			totalPriceLabel.TabIndex = 4;
			totalPriceLabel.Text = "£0000.00";
			totalPriceLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// deliveryChargePriceLabel
			// 
			deliveryChargePriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			deliveryChargePriceLabel.BackColor = Color.White;
			deliveryChargePriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryChargePriceLabel.ForeColor = Color.Black;
			deliveryChargePriceLabel.Location = new Point(139, 620);
			deliveryChargePriceLabel.Name = "deliveryChargePriceLabel";
			deliveryChargePriceLabel.RightToLeft = RightToLeft.Yes;
			deliveryChargePriceLabel.Size = new Size(140, 40);
			deliveryChargePriceLabel.TabIndex = 3;
			deliveryChargePriceLabel.Text = "£0.00";
			// 
			// subtotalPriceLabel
			// 
			subtotalPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			subtotalPriceLabel.BackColor = Color.White;
			subtotalPriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			subtotalPriceLabel.ForeColor = Color.Black;
			subtotalPriceLabel.Location = new Point(139, 580);
			subtotalPriceLabel.Name = "subtotalPriceLabel";
			subtotalPriceLabel.RightToLeft = RightToLeft.Yes;
			subtotalPriceLabel.Size = new Size(140, 40);
			subtotalPriceLabel.TabIndex = 2;
			subtotalPriceLabel.Text = "£0000.00";
			// 
			// deliveryChargeTextLabel
			// 
			deliveryChargeTextLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			deliveryChargeTextLabel.BackColor = Color.Transparent;
			deliveryChargeTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			deliveryChargeTextLabel.ForeColor = Color.White;
			deliveryChargeTextLabel.Location = new Point(3, 615);
			deliveryChargeTextLabel.Name = "deliveryChargeTextLabel";
			deliveryChargeTextLabel.Size = new Size(130, 40);
			deliveryChargeTextLabel.TabIndex = 1;
			deliveryChargeTextLabel.Text = "Delivery:";
			// 
			// subtotalTextLabel
			// 
			subtotalTextLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			subtotalTextLabel.BackColor = Color.Transparent;
			subtotalTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			subtotalTextLabel.ForeColor = Color.White;
			subtotalTextLabel.Location = new Point(3, 575);
			subtotalTextLabel.Name = "subtotalTextLabel";
			subtotalTextLabel.Size = new Size(130, 40);
			subtotalTextLabel.TabIndex = 0;
			subtotalTextLabel.Text = "Subtotal:";
			// 
			// runningOrderScrollBar
			// 
			runningOrderScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			runningOrderScrollBar.Location = new Point(670, 0);
			runningOrderScrollBar.Name = "runningOrderScrollBar";
			runningOrderScrollBar.Size = new Size(30, 580);
			runningOrderScrollBar.TabIndex = 0;
			// 
			// commonItemsPanel
			// 
			commonItemsPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			commonItemsPanel.BackColor = Color.BlueViolet;
			commonItemsPanel.Location = new Point(0, 820);
			commonItemsPanel.Margin = new Padding(0);
			commonItemsPanel.Name = "commonItemsPanel";
			commonItemsPanel.Size = new Size(700, 260);
			commonItemsPanel.TabIndex = 3;
			// 
			// itemsPanel
			// 
			itemsPanel.BackColor = Color.DodgerBlue;
			itemsPanel.Location = new Point(700, 80);
			itemsPanel.Margin = new Padding(0);
			itemsPanel.Name = "itemsPanel";
			itemsPanel.Size = new Size(1040, 700);
			itemsPanel.TabIndex = 4;
			// 
			// categoriesPanel
			// 
			categoriesPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			categoriesPanel.BackColor = Color.LightCyan;
			categoriesPanel.Location = new Point(700, 780);
			categoriesPanel.Margin = new Padding(0);
			categoriesPanel.Name = "categoriesPanel";
			categoriesPanel.Size = new Size(1040, 300);
			categoriesPanel.TabIndex = 6;
			// 
			// paymentPanel
			// 
			paymentPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			paymentPanel.BackColor = Color.DarkOrange;
			paymentPanel.Location = new Point(0, 820);
			paymentPanel.Margin = new Padding(0);
			paymentPanel.Name = "paymentPanel";
			paymentPanel.Size = new Size(700, 260);
			paymentPanel.TabIndex = 4;
			paymentPanel.Visible = false;
			// 
			// viewOrdersPanel
			// 
			viewOrdersPanel.BackColor = Color.HotPink;
			viewOrdersPanel.Location = new Point(700, 80);
			viewOrdersPanel.Margin = new Padding(0);
			viewOrdersPanel.Name = "viewOrdersPanel";
			viewOrdersPanel.Size = new Size(1040, 1000);
			viewOrdersPanel.TabIndex = 1;
			viewOrdersPanel.Visible = false;
			// 
			// timer
			// 
			timer.Enabled = true;
			timer.Interval = 200;
			timer.Tick += timer_Tick;
			// 
			// MainMenu
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1920, 1080);
			Controls.Add(categoriesPanel);
			Controls.Add(itemsPanel);
			Controls.Add(runningOrderPanel);
			Controls.Add(itemEditFunctionsPanel);
			Controls.Add(managerFunctionsPanel);
			Controls.Add(orderTypePanel);
			Controls.Add(customerDetailsPanel);
			Controls.Add(viewOrdersPanel);
			Controls.Add(commonItemsPanel);
			Controls.Add(paymentPanel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "MainMenu";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Main Menu";
			customerDetailsPanel.ResumeLayout(false);
			orderTypePanel.ResumeLayout(false);
			managerFunctionsPanel.ResumeLayout(false);
			itemEditFunctionsPanel.ResumeLayout(false);
			runningOrderPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel customerDetailsPanel;
		private Panel orderTypePanel;
		private Panel managerFunctionsPanel;
		private Panel itemEditFunctionsPanel;
		private Panel runningOrderPanel;
		private Panel commonItemsPanel;
		private Panel itemsPanel;
		private Panel categoriesPanel;
		private Label orderNumberLabel;
		private Label customerDetailsLabel;
		private VScrollBar runningOrderScrollBar;
		private Label subtotalTextLabel;
		private Label deliveryChargeTextLabel;
		private Label deliveryChargePriceLabel;
		private Label subtotalPriceLabel;
		private Button deliveryButton;
		private Button collectionButton;
		private Button counterButton;
		private Button memoButton;
		private Button smallPriceButton;
		private Button largePriceButton;
		private Button cancelOrderButton;
		private Button increaseQuantityButton;
		private Button decreaseQuantityButton;
		private Button priceEditButton;
		private Button timeEditButton;
		private Panel paymentPanel;
		private Label totalPriceLabel;
		private Button managerFunctionsButton;
		private Button viewOrdersButton;
		private Button acceptOrderButton;
		private Panel viewOrdersPanel;
		private Label timeLabel;
		private System.Windows.Forms.Timer timer;
		private DateTimePicker estimatedTimePicker;
		private Label estimatedTimeLabel;
	}
}
