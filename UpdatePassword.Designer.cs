namespace ordering_system
{
	partial class UpdatePassword
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
			acceptButton = new Button();
			passwordTextBox = new TextBox();
			passwordTypeLabel = new Label();
			helpLabel = new Label();
			SuspendLayout();
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(548, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 3;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// acceptButton
			// 
			acceptButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			acceptButton.BackColor = Color.Gold;
			acceptButton.FlatStyle = FlatStyle.Flat;
			acceptButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			acceptButton.Location = new Point(12, 400);
			acceptButton.Name = "acceptButton";
			acceptButton.Size = new Size(200, 100);
			acceptButton.TabIndex = 2;
			acceptButton.Text = "Accept";
			acceptButton.UseVisualStyleBackColor = false;
			acceptButton.Click += acceptButton_Click;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Font = new Font("Segoe UI", 14F);
			passwordTextBox.Location = new Point(12, 258);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(626, 57);
			passwordTextBox.TabIndex = 1;
			passwordTextBox.KeyPress += passwordTextBox_KeyPress;
			// 
			// passwordTypeLabel
			// 
			passwordTypeLabel.BackColor = Color.Transparent;
			passwordTypeLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
			passwordTypeLabel.ForeColor = Color.Black;
			passwordTypeLabel.Location = new Point(12, 14);
			passwordTypeLabel.Margin = new Padding(3, 5, 3, 5);
			passwordTypeLabel.Name = "passwordTypeLabel";
			passwordTypeLabel.Size = new Size(500, 80);
			passwordTypeLabel.TabIndex = 42;
			passwordTypeLabel.Text = "Password";
			// 
			// helpLabel
			// 
			helpLabel.BackColor = Color.Transparent;
			helpLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			helpLabel.ForeColor = Color.Black;
			helpLabel.Location = new Point(12, 140);
			helpLabel.Margin = new Padding(3, 5, 3, 5);
			helpLabel.Name = "helpLabel";
			helpLabel.Size = new Size(500, 110);
			helpLabel.TabIndex = 41;
			helpLabel.Text = "Please enter the new password:";
			// 
			// UpdatePassword
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(650, 512);
			Controls.Add(cancelButton);
			Controls.Add(acceptButton);
			Controls.Add(passwordTextBox);
			Controls.Add(passwordTypeLabel);
			Controls.Add(helpLabel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "UpdatePassword";
			Text = "UpdatePassword";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button cancelButton;
		private Button acceptButton;
		private TextBox passwordTextBox;
		private Label passwordTypeLabel;
		private Label helpLabel;
	}
}