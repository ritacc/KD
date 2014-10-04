namespace DK.KDServer.KDFrm
{
    partial class FrmMain
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
            this.btnEMS = new System.Windows.Forms.Button();
            this.txtKDNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnYT = new System.Windows.Forms.Button();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEMS
            // 
            this.btnEMS.Location = new System.Drawing.Point(24, 43);
            this.btnEMS.Name = "btnEMS";
            this.btnEMS.Size = new System.Drawing.Size(42, 23);
            this.btnEMS.TabIndex = 0;
            this.btnEMS.Text = "EMS";
            this.btnEMS.UseVisualStyleBackColor = true;
            this.btnEMS.Click += new System.EventHandler(this.btnEMS_Click);
            // 
            // txtKDNo
            // 
            this.txtKDNo.Location = new System.Drawing.Point(63, 9);
            this.txtKDNo.Name = "txtKDNo";
            this.txtKDNo.Size = new System.Drawing.Size(155, 21);
            this.txtKDNo.TabIndex = 1;
            this.txtKDNo.Text = "1067912775809";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "快递号";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.Location = new System.Drawing.Point(0, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(264, 290);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "7214394348\n1067912775809";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnYT);
            this.panel1.Controls.Add(this.btnEMS);
            this.panel1.Controls.Add(this.txtKDNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 108);
            this.panel1.TabIndex = 4;
            // 
            // btnYT
            // 
            this.btnYT.Location = new System.Drawing.Point(72, 43);
            this.btnYT.Name = "btnYT";
            this.btnYT.Size = new System.Drawing.Size(46, 23);
            this.btnYT.TabIndex = 3;
            this.btnYT.Text = "圆通";
            this.btnYT.UseVisualStyleBackColor = true;
            this.btnYT.Click += new System.EventHandler(this.btnYT_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdata.Location = new System.Drawing.Point(264, 108);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowTemplate.Height = 23;
            this.dgvdata.Size = new System.Drawing.Size(557, 290);
            this.dgvdata.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 398);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试主页";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEMS;
        private System.Windows.Forms.TextBox txtKDNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Button btnYT;
    }
}