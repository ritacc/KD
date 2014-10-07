using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DK.KDServer.WEBDA.DFW
{
    /// <summary>
    /// 申通
    /// </summary>
    public class KDPath_STO : KDPathBase
    {
        public override bool Init()
        {
            this.VeriCodeLength = 6;
            this.URL = "";

            this.HttpHelp = new HttpHelper();
            string url = "http://q.sto.cn/track.aspx?wen=868371280766&.x=66&.y=7";

            string str = this.HttpHelp.GetHtml(url);
            if (str.Length > 1000)
            {

            }
            //if (str.Length > 1000)
            //{
            //    this.BMVerificationCode = this.HttpHelp.GetStream("http://www.ems.com.cn/ems/rand?d=" + new Random().NextDouble());
            //}
            //else//写日志
            //{
            //    return false;
            //}
            return true;
        }


        public override string GetKDPath()
        {
            string url = "http://q.sto.cn/track.aspx?wen=868371280766&.x=66&.y=7";
            string postDataStr ="";
            Encoding en = Encoding.UTF8;
            string html = this.HttpHelp.PostSpaceMessage(url, postDataStr, en);
            return html;

        //    string postDataStr = string.Format("mailNum={0}&checkCode={1}", this.KDNo, this.VerificationCode);
        //    Encoding en = Encoding.Default;

        //    string html = this.HttpHelp.PostSpaceMessage(url, postDataStr, en);
        //    if (!string.IsNullOrEmpty(html) && html.IndexOf("<table id=\"showTable\"") > 0)
        //    {
        //        int start = html.IndexOf("<table id=\"showTable\"");
        //        int End = html.IndexOf("</table>", start);
        //        string mTable = html.Substring(start, End - start + 8);
        //        mTable = mTable.Replace("\t", "").Replace("&nbsp;", " ").Replace("\r\n", "");

        //        return mTable;
        //    }
        //    return "";
        }


    }
}