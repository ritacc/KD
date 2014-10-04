using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Web;

namespace DK.KDServer.WEBDA.DFW
{
    public class KDPath_EMS : KDPathBase
    {

        public override string GetKDPath()
        {

            /**
             http://www.ems.com.cn/ems/order/singleQuery_t     post
             
             http://www.11183.com.cn/mailtracking/you_jian_cha_xun.html
             http://www.ems.com.cn/ems/rand?d=0.5656721936247522
             
             * **/
            string url = "http://www.ems.com.cn/ems/order/singleQuery_t";// +new Random().NextDouble();
            string postDataStr = string.Format("mailNum={0}&checkCode={1}",this.KDNo,this.VerificationCode);


          

            Encoding en = Encoding.GetEncoding("gb2312");
            en = Encoding.UTF8;
            en = Encoding.Default;
            return this.HttpHelp.PostQQSpaceMessage(url, postDataStr, en);

            //return this.KDNo;
        }


        public override bool Init()
        {
            this.VeriCodeLength = 6;

            this.HttpHelp = new HttpHelper();
            //string url = "" + rd.NextDouble();//0.5789324410930858";
            string url = "http://www.11183.com.cn/mailtracking/you_jian_cha_xun.html";

            string str = this.HttpHelp.GetHtml(url);
            if (str.Length > 1000)
            {
                this.BMVerificationCode = this.HttpHelp.GetStream("http://www.ems.com.cn/ems/rand?d=" + new Random().NextDouble());
            }
            else//写日志
            {
                return false;
            }
            return true;
        }
        
             
    }
}
