using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;


namespace DK.KDServer.WEBDA
{
    public class HttpHelper
    {
        #region 私有变量
        private CookieContainer cc;
        private string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
        private string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        private string userAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1) Gecko/20090624 Firefox/3.5";
        private Encoding encoding = Encoding.GetEncoding("GB2312");
        private int connectTimeOutRetryTryMaxTimes = 3;
        private int currentTry = 0;
        #endregion

       

        #region 属性
        /// <summary>
        /// Cookie容器
        /// </summary>
        public CookieContainer CookieContainer
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }

        /// <summary>
        /// 获取网页源码时使用的编码
        /// </summary>
        /// <value></value>
        public Encoding Encoding
        {
            get
            {
                return encoding;
            }
            set
            {
                encoding = value;
            }
        }

        /// <summary>
        /// 连接超时的重试次数
        /// </summary>
        public int ConnectTimeOutRetryTryMaxTimes
        {
            get
            {
                return connectTimeOutRetryTryMaxTimes;
            }
            set
            {
                connectTimeOutRetryTryMaxTimes = value;
            }
        }

        private IWebProxy webProxy;
        /// <summary>
        /// 网络代理
        /// </summary>
        public IWebProxy WebProxy
        {
            set
            {
                webProxy = value;
            }
        }

        private Uri responseUri;
        public Uri ResponseUri
        {
            get
            {
                return responseUri;
            }
            set
            {
                responseUri = value;
            }
        }

        private string referer = string.Empty;
        public string Referer
        {
            get
            {
                return referer;
            }
            set
            {
                referer = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        public HttpHelper()
        {
            cc = new CookieContainer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="cc">The cc.</param>
        public HttpHelper(CookieContainer cc)
        {
            this.cc = cc;
            if (cc == null) cc = new CookieContainer();
        }
       

        /// <summary>
        /// 使用代理访问指定页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ProxyIP"></param>
        /// <returns></returns>
        public string GetHtmlProxy(string url, string ProxyIP)
        {
            try
            {
                HttpWebRequest httpWebRequest;
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = referer;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Timeout = 4000;
                httpWebRequest.Method = "GET";
                WebProxy webProxy = null;
                if (ProxyIP.Trim() != "")
                {
                    string str = ProxyIP;
                    string[] iparr = str.Split(':');
                    webProxy = new WebProxy(iparr[0], int.Parse(iparr[1]));
                }

                if (webProxy != null)
                {
                    httpWebRequest.Proxy = webProxy;
                }

                HttpWebResponse httpWebResponse;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                return html;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string GetHtml(string url)
        {
            return GetHtml(url, Encoding.GetEncoding("gb2312"));
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieCollection">Cookie集合</param>
        /// <returns></returns>
        public string GetHtml(string url, Encoding encode)
        {
            currentTry++;

            try
            {
                HttpWebRequest httpWebRequest;
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cc;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = referer;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                if (webProxy != null)
                {
                    httpWebRequest.Proxy = webProxy;
                }

                HttpWebResponse httpWebResponse;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                responseUri = httpWebResponse.ResponseUri;
                Stream responseStream = httpWebResponse.GetResponseStream();
                cc.Add(
                httpWebResponse.Cookies);
                StreamReader streamReader = new StreamReader(responseStream, encode);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                CookieCollection mloginCC = httpWebResponse.Cookies;
                CookieSInfo = mloginCC;
                currentTry = 0;
                return html;// +"\r\n" + responseHeader;
            }
            catch
            {
                currentTry = 0;
                return string.Empty;
            }
        }

        public CookieCollection CookieSInfo { get; set; }

        public Bitmap GetStream(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.UserAgent = userAgent;
            request.Accept = accept;
            request.ContentType = this.contentType;
            request.Referer = referer;
            request.CookieContainer = cc;

            Stream responseStream = request.GetResponse().GetResponseStream();
            Bitmap bitmap = new Bitmap(responseStream, true);
            string responseHeader = ((HttpWebResponse)request.GetResponse()).GetResponseHeader("Set-Cookie");
            //cok = GetCookie(responseHeader);
            responseStream.Close();
            return bitmap;
        }
        

        
        public string PostSpaceMessage(string Url, string postDataStr, Encoding m_code)
        {
            string str = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = cc;

                request.Accept = "text/html, */*";
               
                request.UserAgent = "Mozilla/3.0 (compatible; Indy Library)";

                request.AllowAutoRedirect = false;                
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), m_code);
                writer.Write(postDataStr);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.GetResponseHeader("Set-Cookie");
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, m_code);
                str = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }
        

       

        #region Cookie处理

        /// <summary>
        /// 将COOKIE字符串转成COOKIE集合
        /// </summary>
        /// <param name="strCookie">COOKIE字符串</param>
        /// <returns></returns>
        public static CookieCollection StringToCookieCollection(string strCookie)
        {
            CookieCollection cookies = new CookieCollection();
            string[] strArray = strCookie.TrimEnd(new char[] { ';' }).Split(new char[] { ';' });
            foreach (string str in strArray)
            {
                string[] strArray2 = str.Split(new char[] { '=' });
                if (strArray2[0].Trim() != "")
                {
                    Cookie c = new Cookie();
                    c.Name = strArray2[0].Trim();
                    c.Value = strArray2[1].Trim();
                    if (strArray2.Length > 2)
                    {
                        c.Value += "=" + strArray2[2].Trim();
                    }
                    c.Value = c.Value.Split(',')[0];
                    cookies.Add(c);
                }
            }
            return cookies;
        }
        /// <summary>
        /// 将COOKIE集合转成COOKIE字符串
        /// </summary>
        /// <param name="cookies">COOKIE集合</param>
        /// <returns></returns>
        public static string CookieCollectionToString(CookieCollection cookies)
        {
            string str = string.Empty;
            if ((cookies != null) && (cookies.Count > 0))
            {
                foreach (Cookie cookie in cookies)
                {
                    string name = cookie.Name;
                    string str3 = cookie.Value;
                    str = str + string.Format("{0}={1};", name, str3);
                }
            }
            return str;
        }
        #endregion

    }
}
