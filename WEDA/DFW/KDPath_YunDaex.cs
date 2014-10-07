using System;
using System.Collections.Generic;
using System.Text;
using DK.KDServer.Common;

namespace DK.KDServer.WEBDA.DFW
{
    /// <summary>
    /// 韵达
    /// </summary>
    public class KDPath_YunDaex : KDPathBase
    {
        public override bool Init()
        {
            this.VeriCodeLength = 6;

            this.HttpHelp = new HttpHelper();
            string url = "http://ykjcx.yundasys.com/go.php";

            Encoding en = Encoding.Default;
            string postDataStr="wen="+this.KDNo;// 1900941731943
            string html = this.HttpHelp.PostSpaceMessage(url, postDataStr, en);

            //string str = this.HttpHelp.GetHtml(url);
            if (html.Length > 300)
            {
                this.BMVerificationCode = this.HttpHelp.GetStream("http://ykjcx.yundasys.com/imagecode.php?d=" + new Random().NextDouble());
            }
            else//写日志
            {
                return false;
            }
            return true;
        }
        

        public override string GetKDPath()
        {
            string url = "http://ykjcx.yundasys.com/go_wsd.php";
            string postDataStr = string.Format("wen={0}&debug=1&hh={2}&lang=&yzm={1}&=", this.KDNo, this.VerificationCode,DateTime.Now.Hour);
            Encoding en = Encoding.GetEncoding("gb2312");
            string Location = string.Empty;
            string html = this.HttpHelp.PostSpaceMessage_outLocation(url, postDataStr, en, out Location);
            if (string.IsNullOrEmpty(html))
            {
                en = Encoding.UTF8;
                html = this.HttpHelp.GetHtml(Location, en);
            }
            //=gb2312
            return html;
            //if (!string.IsNullOrEmpty(html) && html.IndexOf("<table id=\"showTable\"") > 0)
            //{
            //    int start = html.IndexOf("<table id=\"showTable\"");
            //    int End = html.IndexOf("</table>", start);
            //    string mTable = html.Substring(start, End - start + 8);
            //    mTable = mTable.Replace("\t", "").Replace("&nbsp;", " ").Replace("\r\n", "");

            //    return mTable;
            //}
            return "";
        }


    }
}
