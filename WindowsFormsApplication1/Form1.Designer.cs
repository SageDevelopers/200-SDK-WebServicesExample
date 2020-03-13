namespace WindowsFormsApplication1
{
	partial class Form1
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
            this.openSessionButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fetchCustomerButton = new System.Windows.Forms.Button();
            this.closeSessionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.openSessionButton.Location = new System.Drawing.Point(3, 28);
            this.openSessionButton.Name = "button1";
            this.openSessionButton.Size = new System.Drawing.Size(102, 25);
            this.openSessionButton.TabIndex = 0;
            this.openSessionButton.Text = "OpenSession";
            this.openSessionButton.UseVisualStyleBackColor = true;
            this.openSessionButton.Click += new System.EventHandler(this.openSessionButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.fetchCustomerButton.Location = new System.Drawing.Point(120, 28);
            this.fetchCustomerButton.Name = "button2";
            this.fetchCustomerButton.Size = new System.Drawing.Size(102, 25);
            this.fetchCustomerButton.TabIndex = 2;
            this.fetchCustomerButton.Text = "FetchCustomer";
            this.fetchCustomerButton.UseVisualStyleBackColor = true;
            this.fetchCustomerButton.Click += new System.EventHandler(this.fetchCustomerButton_Click);
            // 
            // button3
            // 
            this.closeSessionButton.Location = new System.Drawing.Point(3, 59);
            this.closeSessionButton.Name = "button3";
            this.closeSessionButton.Size = new System.Drawing.Size(102, 25);
            this.closeSessionButton.TabIndex = 3;
            this.closeSessionButton.Text = "CloseSession";
            this.closeSessionButton.UseVisualStyleBackColor = true;
            this.closeSessionButton.Click += new System.EventHandler(this.closeSessionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 87);
            this.Controls.Add(this.closeSessionButton);
            this.Controls.Add(this.fetchCustomerButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.openSessionButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button openSessionButton;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button fetchCustomerButton;
		private System.Windows.Forms.Button closeSessionButton;
	}
}