namespace ordering_system
{
	partial class UpdateCommonItems
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
			itemDataGridView = new DataGridView();
			categoryComboBox = new ComboBox();
			categoryLabel = new Label();
			updateCommonItemsLabel = new Label();
			cancelButton = new Button();
			commonItemsPanel = new Panel();
			deleteItemButton = new Button();
			acceptButton = new Button();
			maxSetMealsLabel = new Label();
			((System.ComponentModel.ISupportInitialize)itemDataGridView).BeginInit();
			SuspendLayout();
			// 
			// itemDataGridView
			// 
			itemDataGridView.AllowUserToAddRows = false;
			itemDataGridView.AllowUserToDeleteRows = false;
			itemDataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			itemDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			itemDataGridView.BackgroundColor = Color.White;
			itemDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			itemDataGridView.Location = new Point(12, 162);
			itemDataGridView.MultiSelect = false;
			itemDataGridView.Name = "itemDataGridView";
			itemDataGridView.ReadOnly = true;
			itemDataGridView.RowHeadersVisible = false;
			itemDataGridView.RowHeadersWidth = 82;
			itemDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			itemDataGridView.Size = new Size(890, 906);
			itemDataGridView.TabIndex = 109;
			itemDataGridView.TabStop = false;
			itemDataGridView.CellClick += itemDataGridView_CellClick;
			// 
			// categoryComboBox
			// 
			categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			categoryComboBox.Font = new Font("Segoe UI", 14F);
			categoryComboBox.FormattingEnabled = true;
			categoryComboBox.Location = new Point(218, 98);
			categoryComboBox.Name = "categoryComboBox";
			categoryComboBox.Size = new Size(684, 58);
			categoryComboBox.TabIndex = 105;
			categoryComboBox.SelectedIndexChanged += categoryComboBox_SelectedIndexChanged;
			// 
			// categoryLabel
			// 
			categoryLabel.BackColor = Color.Transparent;
			categoryLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			categoryLabel.ForeColor = Color.Black;
			categoryLabel.Location = new Point(12, 98);
			categoryLabel.Margin = new Padding(3, 5, 3, 5);
			categoryLabel.Name = "categoryLabel";
			categoryLabel.RightToLeft = RightToLeft.No;
			categoryLabel.Size = new Size(200, 50);
			categoryLabel.TabIndex = 108;
			categoryLabel.Text = "Category:";
			// 
			// updateCommonItemsLabel
			// 
			updateCommonItemsLabel.BackColor = Color.Transparent;
			updateCommonItemsLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			updateCommonItemsLabel.ForeColor = Color.Black;
			updateCommonItemsLabel.Location = new Point(12, 14);
			updateCommonItemsLabel.Margin = new Padding(3, 5, 3, 5);
			updateCommonItemsLabel.Name = "updateCommonItemsLabel";
			updateCommonItemsLabel.Size = new Size(650, 80);
			updateCommonItemsLabel.TabIndex = 107;
			updateCommonItemsLabel.Text = "Update Common Items";
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1818, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 106;
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// commonItemsPanel
			// 
			commonItemsPanel.BackColor = Color.White;
			commonItemsPanel.Location = new Point(908, 162);
			commonItemsPanel.Name = "commonItemsPanel";
			commonItemsPanel.Size = new Size(1000, 400);
			commonItemsPanel.TabIndex = 111;
			// 
			// deleteItemButton
			// 
			deleteItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			deleteItemButton.BackColor = SystemColors.Control;
			deleteItemButton.FlatStyle = FlatStyle.Flat;
			deleteItemButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteItemButton.Location = new Point(1508, 568);
			deleteItemButton.Name = "deleteItemButton";
			deleteItemButton.Size = new Size(400, 80);
			deleteItemButton.TabIndex = 113;
			deleteItemButton.Text = "Delete Item";
			deleteItemButton.UseVisualStyleBackColor = false;
			// 
			// acceptButton
			// 
			acceptButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			acceptButton.BackColor = Color.Gold;
			acceptButton.FlatStyle = FlatStyle.Flat;
			acceptButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			acceptButton.Location = new Point(1658, 938);
			acceptButton.Name = "acceptButton";
			acceptButton.Size = new Size(250, 130);
			acceptButton.TabIndex = 114;
			acceptButton.Text = "Save Layout";
			acceptButton.UseVisualStyleBackColor = false;
			// 
			// maxSetMealsLabel
			// 
			maxSetMealsLabel.BackColor = Color.Transparent;
			maxSetMealsLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			maxSetMealsLabel.ForeColor = Color.Black;
			maxSetMealsLabel.Location = new Point(912, 30);
			maxSetMealsLabel.Margin = new Padding(3, 5, 3, 5);
			maxSetMealsLabel.Name = "maxSetMealsLabel";
			maxSetMealsLabel.Size = new Size(900, 118);
			maxSetMealsLabel.TabIndex = 110;
			maxSetMealsLabel.Text = "The maximum number of common items allowed is 20\r\n\r\n\r\n\r\n";
			// 
			// UpdateCommonItems
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(acceptButton);
			Controls.Add(deleteItemButton);
			Controls.Add(commonItemsPanel);
			Controls.Add(maxSetMealsLabel);
			Controls.Add(itemDataGridView);
			Controls.Add(categoryComboBox);
			Controls.Add(categoryLabel);
			Controls.Add(updateCommonItemsLabel);
			Controls.Add(cancelButton);
			FormBorderStyle = FormBorderStyle.None;
			Name = "UpdateCommonItems";
			Text = "UpdateCommonItems";
			Load += UpdateCommonItems_Load;
			((System.ComponentModel.ISupportInitialize)itemDataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private DataGridView itemDataGridView;
		private ComboBox categoryComboBox;
		private Label categoryLabel;
		private Label updateCommonItemsLabel;
		private Button cancelButton;
		private Panel commonItemsPanel;
		private Button deleteItemButton;
		private Button acceptButton;
		private Label maxSetMealsLabel;
	}
}