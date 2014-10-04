using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DK.KDServer.WEBDA.DFW;

namespace DK.KDServer.KDFrm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// EMS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEMS_Click(object sender, EventArgs e)
        {
            KDPathBase _ems = new KDPath_EMS();
            _ems.KDNo = txtKDNo.Text;

            if (_ems.Init())
            {
                FrmVerificationCode frmVericode = new FrmVerificationCode();
                frmVericode.BMVerificationCode = _ems.BMVerificationCode;
                frmVericode.VeriCodeLength = _ems.VeriCodeLength;
                frmVericode.Owner = this;
                frmVericode.ShowDialog();
                if (frmVericode.VeriCode != null && frmVericode.VeriCode.Length == _ems.VeriCodeLength)
                {
                    _ems.VerificationCode = frmVericode.VeriCode;//验证码
                   string kdPath= _ems.GetKDPath();//获取到快递路径

                   this.richTextBox1.Text = kdPath;

                   this.dgvdata.DataSource = _ems.listKDPath;
                }
            }

        }

        /// <summary>
        /// 圆通
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYT_Click(object sender, EventArgs e)
        {
            KDPathBase _yto = new KDPath_YTO();
            _yto.KDNo = txtKDNo.Text;

            if (_yto.Init())
            {
                FrmVerificationCode frmVericode = new FrmVerificationCode();
                frmVericode.BMVerificationCode = _yto.BMVerificationCode;
                frmVericode.VeriCodeLength = _yto.VeriCodeLength;
                frmVericode.Owner = this;
                frmVericode.ShowDialog();
                if (frmVericode.VeriCode != null && frmVericode.VeriCode.Length == _yto.VeriCodeLength)
                {
                    _yto.VerificationCode = frmVericode.VeriCode;//验证码
                    string kdPath = _yto.GetKDPath();//获取到快递路径

                    this.richTextBox1.Text = kdPath;

                    this.dgvdata.DataSource = _yto.listKDPath;
                }
            }

        }
    }
}
