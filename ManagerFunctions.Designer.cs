namespace ordering_system
{
	partial class ManagerFunctions
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
			managerFunctionsLabel = new Label();
			exitProgramButton = new Button();
			updateItemsButton = new Button();
			updateSetMealsButton = new Button();
			updateCustomersButton = new Button();
			orderSummaryButton = new Button();
			changeLoginPasswordButton = new Button();
			changeManagerPasswordButton = new Button();
			updateCategoriesButton = new Button();
			SuspendLayout();
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(522, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 9;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// managerFunctionsLabel
			// 
			managerFunctionsLabel.BackColor = Color.Transparent;
			managerFunctionsLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			managerFunctionsLabel.ForeColor = Color.Black;
			managerFunctionsLabel.Location = new Point(12, 12);
			managerFunctionsLabel.Margin = new Padding(3, 5, 3, 5);
			managerFunctionsLabel.Name = "managerFunctionsLabel";
			managerFunctionsLabel.Size = new Size(520, 80);
			managerFunctionsLabel.TabIndex = 42;
			managerFunctionsLabel.Text = "Manager Functions";
			// 
			// exitProgramButton
			// 
			exitProgramButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			exitProgramButton.BackColor = Color.Gold;
			exitProgramButton.FlatStyle = FlatStyle.Flat;
			exitProgramButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			exitProgramButton.Location = new Point(312, 968);
			exitProgramButton.Name = "exitProgramButton";
			exitProgramButton.Size = new Size(300, 100);
			exitProgramButton.TabIndex = 8;
			exitProgramButton.Text = "Exit Program";
			exitProgramButton.UseVisualStyleBackColor = false;
			exitProgramButton.Click += exitProgramButton_Click;
			// 
			// updateItemsButton
			// 
			updateItemsButton.BackColor = SystemColors.Control;
			updateItemsButton.FlatStyle = FlatStyle.Flat;
			updateItemsButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateItemsButton.Location = new Point(12, 236);
			updateItemsButton.Name = "updateItemsButton";
			updateItemsButton.Size = new Size(600, 80);
			updateItemsButton.TabIndex = 2;
			updateItemsButton.Text = "Update Items";
			updateItemsButton.UseVisualStyleBackColor = false;
			updateItemsButton.Click += updateItemsButton_Click;
			// 
			// updateSetMealsButton
			// 
			updateSetMealsButton.BackColor = SystemColors.Control;
			updateSetMealsButton.FlatStyle = FlatStyle.Flat;
			updateSetMealsButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateSetMealsButton.Location = new Point(12, 322);
			updateSetMealsButton.Name = "updateSetMealsButton";
			updateSetMealsButton.Size = new Size(600, 80);
			updateSetMealsButton.TabIndex = 3;
			updateSetMealsButton.Text = "Update Set Meals";
			updateSetMealsButton.UseVisualStyleBackColor = false;
			// 
			// updateCustomersButton
			// 
			updateCustomersButton.BackColor = SystemColors.Control;
			updateCustomersButton.FlatStyle = FlatStyle.Flat;
			updateCustomersButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateCustomersButton.Location = new Point(12, 408);
			updateCustomersButton.Name = "updateCustomersButton";
			updateCustomersButton.Size = new Size(600, 80);
			updateCustomersButton.TabIndex = 4;
			updateCustomersButton.Text = "Update Customers";
			updateCustomersButton.UseVisualStyleBackColor = false;
			updateCustomersButton.Click += updateCustomersButton_Click;
			// 
			// orderSummaryButton
			// 
			orderSummaryButton.BackColor = SystemColors.Control;
			orderSummaryButton.FlatStyle = FlatStyle.Flat;
			orderSummaryButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			orderSummaryButton.Location = new Point(12, 494);
			orderSummaryButton.Name = "orderSummaryButton";
			orderSummaryButton.Size = new Size(600, 80);
			orderSummaryButton.TabIndex = 5;
			orderSummaryButton.Text = "Order Summary";
			orderSummaryButton.UseVisualStyleBackColor = false;
			orderSummaryButton.Click += orderSummaryButton_Click;
			// 
			// changeLoginPasswordButton
			// 
			changeLoginPasswordButton.BackColor = SystemColors.Control;
			changeLoginPasswordButton.FlatStyle = FlatStyle.Flat;
			changeLoginPasswordButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			changeLoginPasswordButton.Location = new Point(12, 580);
			changeLoginPasswordButton.Name = "changeLoginPasswordButton";
			changeLoginPasswordButton.Size = new Size(600, 80);
			changeLoginPasswordButton.TabIndex = 6;
			changeLoginPasswordButton.Text = "Change Login Password";
			changeLoginPasswordButton.UseVisualStyleBackColor = false;
			changeLoginPasswordButton.Click += changeLoginPasswordButton_Click;
			// 
			// changeManagerPasswordButton
			// 
			changeManagerPasswordButton.BackColor = SystemColors.Control;
			changeManagerPasswordButton.FlatStyle = FlatStyle.Flat;
			changeManagerPasswordButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			changeManagerPasswordButton.Location = new Point(12, 666);
			changeManagerPasswordButton.Name = "changeManagerPasswordButton";
			changeManagerPasswordButton.Size = new Size(600, 80);
			changeManagerPasswordButton.TabIndex = 7;
			changeManagerPasswordButton.Text = "Change Manager Password";
			changeManagerPasswordButton.UseVisualStyleBackColor = false;
			changeManagerPasswordButton.Click += changeManagerPasswordButton_Click;
			// 
			// updateCategoriesButton
			// 
			updateCategoriesButton.BackColor = SystemColors.Control;
			updateCategoriesButton.FlatStyle = FlatStyle.Flat;
			updateCategoriesButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			updateCategoriesButton.Location = new Point(12, 150);
			updateCategoriesButton.Name = "updateCategoriesButton";
			updateCategoriesButton.Size = new Size(600, 80);
			updateCategoriesButton.TabIndex = 1;
			updateCategoriesButton.Text = "Update Categories";
			updateCategoriesButton.UseVisualStyleBackColor = false;
			updateCategoriesButton.Click += updateCategoriesButton_Click;
			// 
			// ManagerFunctions
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(624, 1080);
			Controls.Add(updateCategoriesButton);
			Controls.Add(changeManagerPasswordButton);
			Controls.Add(changeLoginPasswordButton);
			Controls.Add(orderSummaryButton);
			Controls.Add(updateCustomersButton);
			Controls.Add(updateSetMealsButton);
			Controls.Add(updateItemsButton);
			Controls.Add(exitProgramButton);
			Controls.Add(managerFunctionsLabel);
			Controls.Add(cancelButton);
			FormBorderStyle = FormBorderStyle.None;
			Name = "ManagerFunctions";
			Text = "Manager Functions";
			ResumeLayout(false);
		}

		#endregion

		private Button cancelButton;
		private Label managerFunctionsLabel;
		private Button exitProgramButton;
		private Button updateItemsButton;
		private Button updateSetMealsButton;
		private Button updateCustomersButton;
		private Button orderSummaryButton;
		private Button changeLoginPasswordButton;
		private Button changeManagerPasswordButton;
		private Button updateCategoriesButton;
	}
}