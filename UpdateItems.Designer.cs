namespace ordering_system
{
	partial class UpdateItems
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
			deleteCategoryButton = new Button();
			updateCategoryButton = new Button();
			addCategoryButton = new Button();
			itemIDTextBox = new TextBox();
			itemIDLabel = new Label();
			updateItemsLabel = new Label();
			cancelButton = new Button();
			itemDataGridView = new DataGridView();
			itemNameTextBox = new TextBox();
			itemNameLabel = new Label();
			smallPriceTextBox = new TextBox();
			smallPriceLabel = new Label();
			largePriceTextBox = new TextBox();
			largePriceLabel = new Label();
			defaultToLargePriceCheckBox = new CheckBox();
			hasSmallPriceCheckBox = new CheckBox();
			isOutOfStockCheckBox = new CheckBox();
			categoryLabel = new Label();
			categoryComboBox = new ComboBox();
			((System.ComponentModel.ISupportInitialize)itemDataGridView).BeginInit();
			SuspendLayout();
			// 
			// deleteCategoryButton
			// 
			deleteCategoryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			deleteCategoryButton.BackColor = SystemColors.Control;
			deleteCategoryButton.FlatStyle = FlatStyle.Flat;
			deleteCategoryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteCategoryButton.Location = new Point(12, 988);
			deleteCategoryButton.Name = "deleteCategoryButton";
			deleteCategoryButton.Size = new Size(400, 80);
			deleteCategoryButton.TabIndex = 59;
			deleteCategoryButton.Text = "Delete Category";
			deleteCategoryButton.UseVisualStyleBackColor = false;
			// 
			// updateCategoryButton
			// 
			updateCategoryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			updateCategoryButton.BackColor = SystemColors.Control;
			updateCategoryButton.FlatStyle = FlatStyle.Flat;
			updateCategoryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateCategoryButton.Location = new Point(12, 902);
			updateCategoryButton.Name = "updateCategoryButton";
			updateCategoryButton.Size = new Size(400, 80);
			updateCategoryButton.TabIndex = 58;
			updateCategoryButton.Text = "Update Category";
			updateCategoryButton.UseVisualStyleBackColor = false;
			// 
			// addCategoryButton
			// 
			addCategoryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			addCategoryButton.BackColor = SystemColors.Control;
			addCategoryButton.FlatStyle = FlatStyle.Flat;
			addCategoryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			addCategoryButton.Location = new Point(12, 816);
			addCategoryButton.Name = "addCategoryButton";
			addCategoryButton.Size = new Size(400, 80);
			addCategoryButton.TabIndex = 57;
			addCategoryButton.Text = "Add Category";
			addCategoryButton.UseVisualStyleBackColor = false;
			// 
			// itemIDTextBox
			// 
			itemIDTextBox.Font = new Font("Segoe UI", 14F);
			itemIDTextBox.Location = new Point(413, 104);
			itemIDTextBox.Name = "itemIDTextBox";
			itemIDTextBox.Size = new Size(550, 57);
			itemIDTextBox.TabIndex = 55;
			// 
			// itemIDLabel
			// 
			itemIDLabel.BackColor = Color.Transparent;
			itemIDLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			itemIDLabel.ForeColor = Color.Black;
			itemIDLabel.Location = new Point(12, 104);
			itemIDLabel.Margin = new Padding(3, 5, 3, 5);
			itemIDLabel.Name = "itemIDLabel";
			itemIDLabel.Size = new Size(395, 50);
			itemIDLabel.TabIndex = 56;
			itemIDLabel.Text = "Item ID:";
			// 
			// updateItemsLabel
			// 
			updateItemsLabel.BackColor = Color.Transparent;
			updateItemsLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			updateItemsLabel.ForeColor = Color.Black;
			updateItemsLabel.Location = new Point(12, 14);
			updateItemsLabel.Margin = new Padding(3, 5, 3, 5);
			updateItemsLabel.Name = "updateItemsLabel";
			updateItemsLabel.Size = new Size(400, 80);
			updateItemsLabel.TabIndex = 54;
			updateItemsLabel.Text = "Update Items";
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1818, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 53;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// itemDataGridView
			// 
			itemDataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			itemDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			itemDataGridView.BackgroundColor = Color.White;
			itemDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			itemDataGridView.Location = new Point(969, 98);
			itemDataGridView.Name = "itemDataGridView";
			itemDataGridView.RowHeadersWidth = 82;
			itemDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			itemDataGridView.Size = new Size(939, 970);
			itemDataGridView.TabIndex = 52;
			// 
			// itemNameTextBox
			// 
			itemNameTextBox.Font = new Font("Segoe UI", 14F);
			itemNameTextBox.Location = new Point(413, 164);
			itemNameTextBox.Name = "itemNameTextBox";
			itemNameTextBox.Size = new Size(550, 57);
			itemNameTextBox.TabIndex = 60;
			// 
			// itemNameLabel
			// 
			itemNameLabel.BackColor = Color.Transparent;
			itemNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			itemNameLabel.ForeColor = Color.Black;
			itemNameLabel.Location = new Point(12, 164);
			itemNameLabel.Margin = new Padding(3, 5, 3, 5);
			itemNameLabel.Name = "itemNameLabel";
			itemNameLabel.Size = new Size(395, 50);
			itemNameLabel.TabIndex = 61;
			itemNameLabel.Text = "Item Name:";
			// 
			// smallPriceTextBox
			// 
			smallPriceTextBox.Font = new Font("Segoe UI", 14F);
			smallPriceTextBox.Location = new Point(413, 284);
			smallPriceTextBox.Name = "smallPriceTextBox";
			smallPriceTextBox.Size = new Size(550, 57);
			smallPriceTextBox.TabIndex = 62;
			// 
			// smallPriceLabel
			// 
			smallPriceLabel.BackColor = Color.Transparent;
			smallPriceLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			smallPriceLabel.ForeColor = Color.Black;
			smallPriceLabel.Location = new Point(12, 284);
			smallPriceLabel.Margin = new Padding(3, 5, 3, 5);
			smallPriceLabel.Name = "smallPriceLabel";
			smallPriceLabel.Size = new Size(395, 50);
			smallPriceLabel.TabIndex = 63;
			smallPriceLabel.Text = "Small Price:";
			// 
			// largePriceTextBox
			// 
			largePriceTextBox.Font = new Font("Segoe UI", 14F);
			largePriceTextBox.Location = new Point(413, 344);
			largePriceTextBox.Name = "largePriceTextBox";
			largePriceTextBox.Size = new Size(550, 57);
			largePriceTextBox.TabIndex = 64;
			// 
			// largePriceLabel
			// 
			largePriceLabel.BackColor = Color.Transparent;
			largePriceLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			largePriceLabel.ForeColor = Color.Black;
			largePriceLabel.Location = new Point(12, 344);
			largePriceLabel.Margin = new Padding(3, 5, 3, 5);
			largePriceLabel.Name = "largePriceLabel";
			largePriceLabel.RightToLeft = RightToLeft.No;
			largePriceLabel.Size = new Size(395, 50);
			largePriceLabel.TabIndex = 65;
			largePriceLabel.Text = "Large Price:";
			// 
			// defaultToLargePriceCheckBox
			// 
			defaultToLargePriceCheckBox.AutoSize = true;
			defaultToLargePriceCheckBox.BackColor = Color.Gainsboro;
			defaultToLargePriceCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			defaultToLargePriceCheckBox.Location = new Point(12, 404);
			defaultToLargePriceCheckBox.Name = "defaultToLargePriceCheckBox";
			defaultToLargePriceCheckBox.Size = new Size(459, 55);
			defaultToLargePriceCheckBox.TabIndex = 66;
			defaultToLargePriceCheckBox.Text = "Default to Large Price?";
			defaultToLargePriceCheckBox.UseVisualStyleBackColor = false;
			// 
			// hasSmallPriceCheckBox
			// 
			hasSmallPriceCheckBox.AutoSize = true;
			hasSmallPriceCheckBox.BackColor = Color.Gainsboro;
			hasSmallPriceCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			hasSmallPriceCheckBox.Location = new Point(12, 224);
			hasSmallPriceCheckBox.Name = "hasSmallPriceCheckBox";
			hasSmallPriceCheckBox.Size = new Size(343, 55);
			hasSmallPriceCheckBox.TabIndex = 67;
			hasSmallPriceCheckBox.Text = "Has Small Price?";
			hasSmallPriceCheckBox.UseVisualStyleBackColor = false;
			// 
			// isOutOfStockCheckBox
			// 
			isOutOfStockCheckBox.AutoSize = true;
			isOutOfStockCheckBox.BackColor = Color.Gainsboro;
			isOutOfStockCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			isOutOfStockCheckBox.Location = new Point(12, 464);
			isOutOfStockCheckBox.Name = "isOutOfStockCheckBox";
			isOutOfStockCheckBox.Size = new Size(292, 55);
			isOutOfStockCheckBox.TabIndex = 68;
			isOutOfStockCheckBox.Text = "Out of Stock?";
			isOutOfStockCheckBox.UseVisualStyleBackColor = false;
			// 
			// categoryLabel
			// 
			categoryLabel.BackColor = Color.Transparent;
			categoryLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			categoryLabel.ForeColor = Color.Black;
			categoryLabel.Location = new Point(12, 524);
			categoryLabel.Margin = new Padding(3, 5, 3, 5);
			categoryLabel.Name = "categoryLabel";
			categoryLabel.RightToLeft = RightToLeft.No;
			categoryLabel.Size = new Size(395, 50);
			categoryLabel.TabIndex = 70;
			categoryLabel.Text = "Category:";
			// 
			// categoryComboBox
			// 
			categoryComboBox.Font = new Font("Segoe UI", 14F);
			categoryComboBox.FormattingEnabled = true;
			categoryComboBox.Location = new Point(413, 524);
			categoryComboBox.Name = "categoryComboBox";
			categoryComboBox.Size = new Size(550, 58);
			categoryComboBox.TabIndex = 71;
			// 
			// UpdateItems
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(categoryComboBox);
			Controls.Add(categoryLabel);
			Controls.Add(isOutOfStockCheckBox);
			Controls.Add(hasSmallPriceCheckBox);
			Controls.Add(defaultToLargePriceCheckBox);
			Controls.Add(largePriceTextBox);
			Controls.Add(largePriceLabel);
			Controls.Add(smallPriceTextBox);
			Controls.Add(smallPriceLabel);
			Controls.Add(itemNameTextBox);
			Controls.Add(itemNameLabel);
			Controls.Add(deleteCategoryButton);
			Controls.Add(updateCategoryButton);
			Controls.Add(addCategoryButton);
			Controls.Add(itemIDTextBox);
			Controls.Add(itemIDLabel);
			Controls.Add(updateItemsLabel);
			Controls.Add(cancelButton);
			Controls.Add(itemDataGridView);
			FormBorderStyle = FormBorderStyle.None;
			Name = "UpdateItems";
			Text = "UpdateItems";
			Load += UpdateItems_Load;
			((System.ComponentModel.ISupportInitialize)itemDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button deleteCategoryButton;
		private Button updateCategoryButton;
		private Button addCategoryButton;
		private TextBox itemIDTextBox;
		private Label itemIDLabel;
		private Label updateItemsLabel;
		private Button cancelButton;
		private DataGridView itemDataGridView;
		private TextBox itemNameTextBox;
		private Label itemNameLabel;
		private TextBox smallPriceTextBox;
		private Label smallPriceLabel;
		private TextBox largePriceTextBox;
		private Label largePriceLabel;
		private CheckBox defaultToLargePriceCheckBox;
		private CheckBox hasSmallPriceCheckBox;
		private CheckBox isOutOfStockCheckBox;
		private Label categoryLabel;
		private ComboBox categoryComboBox;
	}
}