namespace KantarApp
{
	partial class Form2
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.comboPort = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textQty = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnSave = new System.Windows.Forms.Button();
			this.checkRead = new System.Windows.Forms.CheckBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboPort
			// 
			this.comboPort.FormattingEnabled = true;
			this.comboPort.Location = new System.Drawing.Point(208, 15);
			this.comboPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.comboPort.Name = "comboPort";
			this.comboPort.Size = new System.Drawing.Size(225, 29);
			this.comboPort.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(91, 17);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Seri Port";
			// 
			// textQty
			// 
			this.textQty.Location = new System.Drawing.Point(208, 57);
			this.textQty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textQty.Name = "textQty";
			this.textQty.Size = new System.Drawing.Size(225, 28);
			this.textQty.TabIndex = 3;
			this.textQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textQty_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(91, 60);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 21);
			this.label3.TabIndex = 4;
			this.label3.Text = "Okunan Değer";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(413, 231);
			this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(230, 47);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Kapat";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 291);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
			this.statusStrip1.Size = new System.Drawing.Size(653, 26);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(18, 20);
			this.toolStripStatusLabel1.Text = "...";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(178, 231);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(230, 47);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Ayarları Kaydet";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// checkRead
			// 
			this.checkRead.AutoSize = true;
			this.checkRead.Location = new System.Drawing.Point(208, 106);
			this.checkRead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkRead.Name = "checkRead";
			this.checkRead.Size = new System.Drawing.Size(96, 25);
			this.checkRead.TabIndex = 7;
			this.checkRead.Text = "Port Oku";
			this.checkRead.UseVisualStyleBackColor = true;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(653, 317);
			this.Controls.Add(this.checkRead);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.textQty);
			this.Controls.Add(this.comboPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form2";
			this.Text = "Kantar App";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox comboPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textQty;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.CheckBox checkRead;
		private System.IO.Ports.SerialPort serialPort1;
	}
}

