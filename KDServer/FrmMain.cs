using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DK.KDServer.WEBDA.DFW;
using System.Reflection;

namespace DK.KDServer.KDFrm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            rtbMsg.Text = @"EMS:    1067912775809
圆通快递    1067912775809
申通快递    868371280766
韵达快运    1900941731943
韵达快运    3100087067357
顺丰快运    588564240167
";

            this.txtKDNo.Text = "1900941731943";

        }
        /**
         * 物流公司为申通快递,运单号868371280766
         * 物流公司为韵达快运,运单号1900941731943
         * 物流公司为韵达快运,运单号3100087067357
         * 顺丰:  588564240167
         * **/


        private void LoadPath(string className)
        {
            KDPathBase _yto = (KDPathBase)Assembly.Load("WEBDA").CreateInstance("DK.KDServer.WEBDA.DFW." + className);
            _yto.KDNo = txtKDNo.Text;

            if (_yto.Init())
            {
                FrmVerificationCode frmVericode = new FrmVerificationCode();
                frmVericode.BMVerificationCode = _yto.BMVerificationCode;
                frmVericode.VeriCodeLength = _yto.VeriCodeLength;
                frmVericode.Owner = this;
                frmVericode.ShowDialog();
                if (frmVericode.VeriCode != null )
                {
                    _yto.VerificationCode = frmVericode.VeriCode;//验证码
                    string kdPath = _yto.GetKDPath();//获取到快递路径

                    this.rtbMsg.Text = kdPath;

                    this.dgvdata.DataSource = _yto.listKDPath;
                }
            }
        }

        private void LoadPath_(string className)
        {
            KDPathBase _yto = (KDPathBase)Assembly.Load("WEBDA").CreateInstance("DK.KDServer.WEBDA.DFW." + className);
            _yto.KDNo = txtKDNo.Text;

            if (_yto.Init())
            {
                //FrmVerificationCode frmVericode = new FrmVerificationCode();
                //frmVericode.BMVerificationCode = _yto.BMVerificationCode;
                //frmVericode.VeriCodeLength = _yto.VeriCodeLength;
                //frmVericode.Owner = this;
                //frmVericode.ShowDialog();
                //if (frmVericode.VeriCode != null && frmVericode.VeriCode.Length == _yto.VeriCodeLength)
                //{
                    //_yto.VerificationCode = frmVericode.VeriCode;//验证码
                    string kdPath = _yto.GetKDPath();//获取到快递路径

                    this.rtbMsg.Text = kdPath;

                    this.dgvdata.DataSource = _yto.listKDPath;
                //}
            }
        }
        
        private void btnEMS_Click(object sender, EventArgs e)
        {
            LoadPath("KDPath_EMS");//EMS
        }

        private void btnYT_Click(object sender, EventArgs e)
        {
            LoadPath("KDPath_YTO");//圆通
        }

        private void btnSto_Click(object sender, EventArgs e)
        {
            LoadPath_("KDPath_STO");//申通
        }

        private void btnYundaex_Click(object sender, EventArgs e)
        {
            LoadPath("KDPath_YunDaex");//韵达
        }

        private void btnSF_Click(object sender, EventArgs e)
        {
            LoadPath("KDPath_SF_Express");//顺丰
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            rtbMsg.Text = @"EMS:    1067912775809
圆通快递    1067912775809
申通快递    868371280766
韵达快运    1900941731943
韵达快运    3100087067357
顺丰快运    588564240167
";
        }
    }
}
