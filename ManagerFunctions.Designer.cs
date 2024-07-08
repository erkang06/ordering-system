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
			acceptButton = new Button();
			SuspendLayout();
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cancelButton.Image = Properties.Resources.redCancelOrder;
			cancelButton.Location = new Point(1818, 12);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 80);
			cancelButton.TabIndex = 41;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// managerFunctionsLabel
			// 
			managerFunctionsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			managerFunctionsLabel.BackColor = Color.Transparent;
			managerFunctionsLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			managerFunctionsLabel.ForeColor = Color.Black;
			managerFunctionsLabel.Location = new Point(12, 12);
			managerFunctionsLabel.Margin = new Padding(3, 5, 3, 5);
			managerFunctionsLabel.Name = "managerFunctionsLabel";
			managerFunctionsLabel.Size = new Size(550, 80);
			managerFunctionsLabel.TabIndex = 42;
			managerFunctionsLabel.Text = "Manager Functions";
			// 
			// acceptButton
			// 
			acceptButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			acceptButton.BackColor = Color.Gold;
			acceptButton.FlatStyle = FlatStyle.Flat;
			acceptButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			acceptButton.Location = new Point(1608, 968);
			acceptButton.Name = "acceptButton";
			acceptButton.Size = new Size(300, 100);
			acceptButton.TabIndex = 43;
			acceptButton.Text = "Exit Program";
			acceptButton.UseVisualStyleBackColor = false;
			acceptButton.Click += acceptButton_Click;
			// 
			// ManagerFunctions
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			ClientSize = new Size(1920, 1080);
			Controls.Add(acceptButton);
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
		private Button acceptButton;
	}
}