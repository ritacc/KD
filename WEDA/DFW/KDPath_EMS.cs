using System;
using System.Collections.Generic;
using System.Text;
using DK.KDServer.Common;
 

namespace DK.KDServer.WEBDA.DFW
{
    public class KDPath_EMS : KDPathBase
    {

        public override string GetKDPath()
        {
            string url = "http://www.ems.com.cn/ems/order/singleQuery_t";
            string postDataStr = string.Format("mailNum={0}&checkCode={1}", this.KDNo, this.VerificationCode);
            Encoding en = Encoding.Default;

            string html = this.HttpHelp.PostSpaceMessage(url, postDataStr, en);
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

        public KDPathOR ConvertToObject(string trStr)
        {
            KDPathOR obj = new KDPathOR();
            int EndIndex = 0;
            int idStart=trStr.IndexOf("id=\"");
            int idEnd=trStr.IndexOf("\"",idStart+4);

            string id = trStr.Substring(idStart + 4, idEnd - idStart - 4);
            for (int i = 0; i < 3; i++)
            {
                int Start = trStr.IndexOf("<td", EndIndex);
                int Start_end = trStr.IndexOf(">", Start+3);
                int End = trStr.IndexOf("</td>", Start_end);
                EndIndex = End;
                if (i <= 1 && Start < 0)
                    return null;
                string mData = trStr.Substring(Start_end + 1, End - Start_end - 1);
                if (i == 0)
                {
                    if (!string.IsNullOrEmpty(mData.Trim()))
                        obj.PathData = Convert.ToDateTime(mData);
                }
                else if (i == 1)
                {
                    obj.City = mData;
                    obj.Index = Convert.ToInt32(id);
                }
                else if (i == 2)
                {
                    obj.KDStatus = mData;
                }
            }
            return obj;
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
