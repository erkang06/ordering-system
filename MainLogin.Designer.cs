namespace ordering_system
{
	partial class MainLogin
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
			passwordLabel = new Label();
			loginLabel = new Label();
			passwordTextBox = new TextBox();
			acceptButton = new Button();
			cancelButton = new Button();
			SuspendLayout();
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
			passwordLabel.TabIndex = 13;
			passwordLabel.Text = "Password:";
			// 
			// loginLabel
			// 
			loginLabel.BackColor = Color.Transparent;
			loginLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
			loginLabel.ForeColor = Color.Black;
			loginLabel.Location = new Point(12, 14);
			loginLabel.Margin = new Padding(3, 5, 3, 5);
			loginLabel.Name = "loginLabel";
			loginLabel.Size = new Size(450, 80);
			loginLabel.TabIndex = 14;
			loginLabel.Text = "Ordering System";
			// 
			// passwordTextBox
			// 
			passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			passwordTextBox.Font = new Font("Segoe UI", 14F);
			passwordTextBox.Location = new Point(250, 200);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(300, 57);
			passwordTextBox.TabIndex = 15;
			passwordTextBox.KeyPress += passwordTextBox_KeyPress;
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
			acceptButton.TabIndex = 39;
			acceptButton.Text = "Accept";
			acceptButton.UseVisualStyleBackColor = false;
			acceptButton.Click += acceptButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(460, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 40;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// MainLogin
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(562, 512);
			Controls.Add(cancelButton);
			Controls.Add(acceptButton);
			Controls.Add(passwordTextBox);
			Controls.Add(loginLabel);
			Controls.Add(passwordLabel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "MainLogin";
			Text = "Please enter the password:";
			Load += MainLogin_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label passwordLabel;
		private Label loginLabel;
		private TextBox passwordTextBox;
		private Button acceptButton;
		private Button cancelButton;
	}
}