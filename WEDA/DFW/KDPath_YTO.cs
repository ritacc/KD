using System;
using System.Collections.Generic;
using System.Text;
using DK.KDServer.Common;


namespace DK.KDServer.WEBDA.DFW
{
    public class KDPath_YTO : KDPathBase
    {

        public override string GetKDPath()
        {
            string url = "http://trace.yto.net.cn:8022/Trace.aspx";
            string postDataStr = string.Format("waybillNo={0}&validateCode={1}", this.KDNo, this.VerificationCode);
            Encoding en = Encoding.UTF8;

            string html = this.HttpHelp.PostSpaceMessage(url, postDataStr, en);
            return html;
            if (!string.IsNullOrEmpty(html) && html.IndexOf("<table id=\"showTable\"") > 0)
            {
                int start = html.IndexOf("<table id=\"showTable\"");
                int End = html.IndexOf("</table>", start);
                string mTable = html.Substring(start, End - start + 8);
                mTable = mTable.Replace("\t", "").Replace("&nbsp;", " ").Replace("\r\n", "");

                HtmlTable ht = new HtmlTable(mTable);//字符串
                this.listKDPath = new List<KDPathOR>();//路径对象
                if (ht.listTR.Count > 0)
                {
                    for (int i = 1; i < ht.listTR.Count; i++)
                    {
                        KDPathOR obj = ConvertToObject(ht.listTR[i]);
                        if (obj != null)
                            listKDPath.Add(obj);
                    }
                }

            }
            return "";
        }

        private KDPathOR ConvertToObject(string trStr)
        {
            KDPathOR obj = new KDPathOR();
            int EndIndex = 0;
            int idStart = trStr.IndexOf("id=\"");
            int idEnd = trStr.IndexOf("\"", idStart + 4);

            string id = trStr.Substring(idStart + 4, idEnd - idStart - 4);
            for (int i = 0; i < 3; i++)
            {
                int Start = trStr.IndexOf("<td", EndIndex);
                int Start_end = trStr.IndexOf(">", Start + 3);
                int End = trStr.IndexOf("</td>", Start_end);
                EndIndex = End;
                if (i <= 1 && Start < 0)
                    return null;
                if (i == 0)
                {
                    obj.PathData = Convert.ToDateTime(trStr.Substring(Start_end + 1, End - Start_end - 1));
                }
                else if (i == 1)
                {
                    obj.City = trStr.Substring(Start_end + 1, End - Start_end - 1);
                    obj.Index = Convert.ToInt32(id);
                }
                else if (i == 2)
                {
                    obj.KDStatus = trStr.Substring(Start_end + 1, End - Start_end - 1);
                }
            }
            return obj;
        }


        public override bool Init()
        {
            this.VeriCodeLength = 4;

            this.HttpHelp = new HttpHelper();
            string url = "http://trace.yto.net.cn:8022/ValidateError.aspx";

            string str = this.HttpHelp.GetHtml(url);
            if (str.Length > 300)
            {
                this.BMVerificationCode = this.HttpHelp.GetStream("http://trace.yto.net.cn:8022/ValidateCode.aspx?" + new Random().NextDouble());
            }
            else//写日志
            {
                return false;
            }
            return true;
        }


    }
}
