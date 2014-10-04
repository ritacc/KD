using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DK.KDServer.Common
{
    public class HtmlTable
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> listTR { get; set; }

        public string _Html { get; set; }

        public HtmlTable(string html)
        {
            //_Html = html.Replace("\t", "").Replace("&nbsp;", " ").Replace("\r\n", "");
            _Html = html;
            TableToTr();
        }

        public void TableToTr()
        {
            listTR = new List<string>();
            int EndIndex = 0;
            if (string.IsNullOrEmpty(_Html))
                return;

            do
            {
                int start = _Html.IndexOf("<tr", EndIndex);
                if (start < 0)
                    return;

                int end = _Html.IndexOf("</tr>", EndIndex);
                listTR.Add(_Html.Substring(start, end - start+5));
                EndIndex = end + 4;
            } while (true);
        }
    }
}
