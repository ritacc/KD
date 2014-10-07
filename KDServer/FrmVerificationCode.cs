using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DK.KDServer.KDFrm
{
    public partial class FrmVerificationCode : Form
    {
        public FrmVerificationCode()
        {
            InitializeComponent();
        }
        private string _VeriCode = string.Empty;
        /// <summary>
        /// 验证码
        /// </summary>
        public string VeriCode
        {
            get { return _VeriCode; }
            set { _VeriCode = value; }
        }

        
        /// <summary>
        /// 验证码图片
        /// </summary>
        public Bitmap BMVerificationCode { get; set; }

        public int VeriCodeLength { get; set; }


        private void txtVericode_TextChanged(object sender, EventArgs e)
        {
            if (txtVericode.Text.Trim().Length == VeriCodeLength)
            {
                _VeriCode = txtVericode.Text.Trim();
                this.Close();
            }
        }

        private void FrmVerificationCode_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.BMVerificationCode;

            Bitmap bmp = this.BMVerificationCode;
            byte[] buffer = new byte[bmp.Width * bmp.Height * 4];
            int stride = bmp.Width * 4;
            for (int row = 0; row < bmp.Height; row++)
            {
                for(int column = 0; column < bmp.Width; column++)
                {
                    Color pixel = bmp.GetPixel(column, row);
                    int index = row * stride + column * 4;
                    buffer[index] = pixel.R;
                    buffer[index + 1] = pixel.G;
                    buffer[index + 2] = pixel.B;
                    buffer[index + 3] = pixel.A;
                    if(row * stride + column == 0)
                    {

                    }
                }
            }
            _VeriCode = YZM.EMS.Get(buffer, stride);
            txtVericode.Text = _VeriCode;
            int iResult=0;
            if (int.TryParse(_VeriCode, out iResult))
            {
                this.Close();
            }
            txtVericode.Focus();
        }

        private void txtVericode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _VeriCode = txtVericode.Text.Trim();
                this.Close();
            }
        }
    }
}
