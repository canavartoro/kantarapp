namespace KantarApp
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.textUrl = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboPort = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textQty = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnSave = new System.Windows.Forms.Button();
			this.checkRead = new System.Windows.Forms.CheckBox();
			this.checkTest = new System.Windows.Forms.CheckBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textUrl
			// 
			this.textUrl.Location = new System.Drawing.Point(166, 30);
			this.textUrl.Name = "textUrl";
			this.textUrl.Size = new System.Drawing.Size(516, 32);
			this.textUrl.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Sunucu Adresi";
			// 
			// comboPort
			// 
			this.comboPort.FormattingEnabled = true;
			this.comboPort.Location = new System.Drawing.Point(166, 80);
			this.comboPort.Name = "comboPort";
			this.comboPort.Size = new System.Drawing.Size(269, 32);
			this.comboPort.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Seri Port";
			// 
			// textQty
			// 
			this.textQty.Location = new System.Drawing.Point(166, 131);
			this.textQty.Name = "textQty";
			this.textQty.Size = new System.Drawing.Size(269, 32);
			this.textQty.TabIndex = 3;
			this.textQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textQty_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Okunan Değer";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(496, 277);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(276, 56);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 348);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(784, 32);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(24, 25);
			this.toolStripStatusLabel1.Text = "...";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(214, 277);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(276, 56);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Ayarları Kaydet";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// checkRead
			// 
			this.checkRead.AutoSize = true;
			this.checkRead.Location = new System.Drawing.Point(166, 180);
			this.checkRead.Name = "checkRead";
			this.checkRead.Size = new System.Drawing.Size(113, 28);
			this.checkRead.TabIndex = 7;
			this.checkRead.Text = "Port Oku";
			this.checkRead.UseVisualStyleBackColor = true;
			// 
			// checkTest
			// 
			this.checkTest.AutoSize = true;
			this.checkTest.Location = new System.Drawing.Point(166, 214);
			this.checkTest.Name = "checkTest";
			this.checkTest.Size = new System.Drawing.Size(131, 28);
			this.checkTest.TabIndex = 7;
			this.checkTest.Text = "Similasyon";
			this.checkTest.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(784, 380);
			this.Controls.Add(this.checkTest);
			this.Controls.Add(this.checkRead);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.textQty);
			this.Controls.Add(this.comboPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textUrl);
			this.Controls.Add(this.label3);
			this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Kantar App";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textUrl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textQty;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.CheckBox checkRead;
		private System.Windows.Forms.CheckBox checkTest;
		private System.IO.Ports.SerialPort serialPort1;
	}
}

