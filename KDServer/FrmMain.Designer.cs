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
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSF = new System.Windows.Forms.Button();
            this.btnYundaex = new System.Windows.Forms.Button();
            this.btnSto = new System.Windows.Forms.Button();
            this.btnYT = new System.Windows.Forms.Button();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnRest = new System.Windows.Forms.Button();
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
            // rtbMsg
            // 
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbMsg.Location = new System.Drawing.Point(0, 108);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(380, 290);
            this.rtbMsg.TabIndex = 3;
            this.rtbMsg.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRest);
            this.panel1.Controls.Add(this.btnSF);
            this.panel1.Controls.Add(this.btnYundaex);
            this.panel1.Controls.Add(this.btnSto);
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
            // btnSF
            // 
            this.btnSF.Location = new System.Drawing.Point(228, 43);
            this.btnSF.Name = "btnSF";
            this.btnSF.Size = new System.Drawing.Size(46, 23);
            this.btnSF.TabIndex = 6;
            this.btnSF.Text = "顺丰";
            this.btnSF.UseVisualStyleBackColor = true;
            this.btnSF.Click += new System.EventHandler(this.btnSF_Click);
            // 
            // btnYundaex
            // 
            this.btnYundaex.Location = new System.Drawing.Point(175, 43);
            this.btnYundaex.Name = "btnYundaex";
            this.btnYundaex.Size = new System.Drawing.Size(45, 23);
            this.btnYundaex.TabIndex = 5;
            this.btnYundaex.Text = "韵达";
            this.btnYundaex.UseVisualStyleBackColor = true;
            this.btnYundaex.Click += new System.EventHandler(this.btnYundaex_Click);
            // 
            // btnSto
            // 
            this.btnSto.Location = new System.Drawing.Point(124, 43);
            this.btnSto.Name = "btnSto";
            this.btnSto.Size = new System.Drawing.Size(47, 23);
            this.btnSto.TabIndex = 4;
            this.btnSto.Text = "申通";
            this.btnSto.UseVisualStyleBackColor = true;
            this.btnSto.Click += new System.EventHandler(this.btnSto_Click);
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
            this.dgvdata.Location = new System.Drawing.Point(380, 108);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowTemplate.Height = 23;
            this.dgvdata.Size = new System.Drawing.Size(441, 290);
            this.dgvdata.TabIndex = 5;
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(12, 79);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(54, 23);
            this.btnRest.TabIndex = 7;
            this.btnRest.Text = "Reset";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 398);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.rtbMsg);
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
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Button btnYT;
        private System.Windows.Forms.Button btnSF;
        private System.Windows.Forms.Button btnYundaex;
        private System.Windows.Forms.Button btnSto;
        private System.Windows.Forms.Button btnRest;
    }
}