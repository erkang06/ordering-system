namespace ordering_system
{
	partial class Login
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
			loginLabel = new Label();
			passwordLabel = new Label();
			SuspendLayout();
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(518, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 45;
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
			acceptButton.TabIndex = 44;
			acceptButton.Text = "Accept";
			acceptButton.UseVisualStyleBackColor = false;
			acceptButton.Click += acceptButton_Click;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			passwordTextBox.Font = new Font("Segoe UI", 14F);
			passwordTextBox.Location = new Point(308, 200);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(300, 57);
			passwordTextBox.TabIndex = 43;
			passwordTextBox.KeyPress += passwordTextBox_KeyPress;
			// 
			// loginLabel
			// 
			loginLabel.BackColor = Color.Transparent;
			loginLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
			loginLabel.ForeColor = Color.Black;
			loginLabel.Location = new Point(12, 14);
			loginLabel.Margin = new Padding(3, 5, 3, 5);
			loginLabel.Name = "loginLabel";
			loginLabel.Size = new Size(500, 80);
			loginLabel.TabIndex = 42;
			loginLabel.Text = "Ordering System";
			// 
			// passwordLabel
			// 
			passwordLabel.BackColor = Color.Transparent;
			passwordLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			passwordLabel.ForeColor = Color.Black;
			passwordLabel.Location = new Point(12, 200);
			passwordLabel.Margin = new Padding(3, 5, 3, 5);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(250, 50);
			passwordLabel.TabIndex = 41;
			passwordLabel.Text = "Password:";
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(620, 512);
			Controls.Add(cancelButton);
			Controls.Add(acceptButton);
			Controls.Add(passwordTextBox);
			Controls.Add(loginLabel);
			Controls.Add(passwordLabel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Login";
			Text = "Login";
			Load += Login_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button cancelButton;
		private Button acceptButton;
		private TextBox passwordTextBox;
		private Label loginLabel;
		private Label passwordLabel;
	}
}