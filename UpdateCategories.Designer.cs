namespace ordering_system
{
	partial class UpdateCategories
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
			categoryDataGridView = new DataGridView();
			cancelButton = new Button();
			updateCategoriesLabel = new Label();
			categoryNameTextBox = new TextBox();
			categoryNameLabel = new Label();
			addCategoryButton = new Button();
			updateCategoryButton = new Button();
			deleteCategoryButton = new Button();
			categoryIndexTextBox = new TextBox();
			categoryIndexLabel = new Label();
			((System.ComponentModel.ISupportInitialize)categoryDataGridView).BeginInit();
			SuspendLayout();
			// 
			// categoryDataGridView
			// 
			categoryDataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			categoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			categoryDataGridView.BackgroundColor = Color.White;
			categoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			categoryDataGridView.Location = new Point(969, 98);
			categoryDataGridView.Name = "categoryDataGridView";
			categoryDataGridView.RowHeadersWidth = 82;
			categoryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			categoryDataGridView.Size = new Size(939, 970);
			categoryDataGridView.TabIndex = 0;
			categoryDataGridView.CellClick += categoryDataGridView_CellClick;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1818, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 42;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// updateCategoriesLabel
			// 
			updateCategoriesLabel.BackColor = Color.Transparent;
			updateCategoriesLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			updateCategoriesLabel.ForeColor = Color.Black;
			updateCategoriesLabel.Location = new Point(12, 14);
			updateCategoriesLabel.Margin = new Padding(3, 5, 3, 5);
			updateCategoriesLabel.Name = "updateCategoriesLabel";
			updateCategoriesLabel.Size = new Size(500, 80);
			updateCategoriesLabel.TabIndex = 43;
			updateCategoriesLabel.Text = "Update Categories";
			// 
			// categoryNameTextBox
			// 
			categoryNameTextBox.Font = new Font("Segoe UI", 14F);
			categoryNameTextBox.Location = new Point(12, 162);
			categoryNameTextBox.Name = "categoryNameTextBox";
			categoryNameTextBox.Size = new Size(550, 57);
			categoryNameTextBox.TabIndex = 44;
			categoryNameTextBox.Leave += categoryNameTextBox_Leave;
			// 
			// categoryNameLabel
			// 
			categoryNameLabel.BackColor = Color.Transparent;
			categoryNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			categoryNameLabel.ForeColor = Color.Black;
			categoryNameLabel.Location = new Point(12, 104);
			categoryNameLabel.Margin = new Padding(3, 5, 3, 5);
			categoryNameLabel.Name = "categoryNameLabel";
			categoryNameLabel.Size = new Size(350, 50);
			categoryNameLabel.TabIndex = 46;
			categoryNameLabel.Text = "Category Name:";
			// 
			// addCategoryButton
			// 
			addCategoryButton.BackColor = SystemColors.Control;
			addCategoryButton.FlatStyle = FlatStyle.Flat;
			addCategoryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			addCategoryButton.Location = new Point(352, 515);
			addCategoryButton.Name = "addCategoryButton";
			addCategoryButton.Size = new Size(400, 80);
			addCategoryButton.TabIndex = 47;
			addCategoryButton.Text = "Add Category";
			addCategoryButton.UseVisualStyleBackColor = false;
			addCategoryButton.Click += addCategoryButton_Click;
			// 
			// updateCategoryButton
			// 
			updateCategoryButton.BackColor = SystemColors.Control;
			updateCategoryButton.FlatStyle = FlatStyle.Flat;
			updateCategoryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateCategoryButton.Location = new Point(352, 601);
			updateCategoryButton.Name = "updateCategoryButton";
			updateCategoryButton.Size = new Size(400, 80);
			updateCategoryButton.TabIndex = 48;
			updateCategoryButton.Text = "Update Category";
			updateCategoryButton.UseVisualStyleBackColor = false;
			updateCategoryButton.Click += updateCategoryButton_Click;
			// 
			// deleteCategoryButton
			// 
			deleteCategoryButton.BackColor = SystemColors.Control;
			deleteCategoryButton.FlatStyle = FlatStyle.Flat;
			deleteCategoryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			deleteCategoryButton.Location = new Point(352, 687);
			deleteCategoryButton.Name = "deleteCategoryButton";
			deleteCategoryButton.Size = new Size(400, 80);
			deleteCategoryButton.TabIndex = 49;
			deleteCategoryButton.Text = "Delete Category";
			deleteCategoryButton.UseVisualStyleBackColor = false;
			deleteCategoryButton.Click += deleteCategoryButton_Click;
			// 
			// categoryIndexTextBox
			// 
			categoryIndexTextBox.Font = new Font("Segoe UI", 14F);
			categoryIndexTextBox.Location = new Point(12, 285);
			categoryIndexTextBox.Name = "categoryIndexTextBox";
			categoryIndexTextBox.Size = new Size(550, 57);
			categoryIndexTextBox.TabIndex = 50;
			categoryIndexTextBox.Leave += categoryIndexTextBox_Leave;
			// 
			// categoryIndexLabel
			// 
			categoryIndexLabel.BackColor = Color.Transparent;
			categoryIndexLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			categoryIndexLabel.ForeColor = Color.Black;
			categoryIndexLabel.Location = new Point(12, 227);
			categoryIndexLabel.Margin = new Padding(3, 5, 3, 5);
			categoryIndexLabel.Name = "categoryIndexLabel";
			categoryIndexLabel.Size = new Size(350, 50);
			categoryIndexLabel.TabIndex = 51;
			categoryIndexLabel.Text = "Category Index:";
			// 
			// UpdateCategories
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(categoryIndexTextBox);
			Controls.Add(categoryIndexLabel);
			Controls.Add(deleteCategoryButton);
			Controls.Add(updateCategoryButton);
			Controls.Add(addCategoryButton);
			Controls.Add(categoryNameTextBox);
			Controls.Add(categoryNameLabel);
			Controls.Add(updateCategoriesLabel);
			Controls.Add(cancelButton);
			Controls.Add(categoryDataGridView);
			FormBorderStyle = FormBorderStyle.None;
			Name = "UpdateCategories";
			Text = "UpdateCategories";
			Load += UpdateCategories_Load;
			((System.ComponentModel.ISupportInitialize)categoryDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView categoryDataGridView;
		private Button cancelButton;
		private Label updateCategoriesLabel;
		private TextBox categoryNameTextBox;
		private Label categoryNameLabel;
		private Button addCategoryButton;
		private Button updateCategoryButton;
		private Button deleteCategoryButton;
		private TextBox categoryIndexTextBox;
		private Label categoryIndexLabel;
	}
}