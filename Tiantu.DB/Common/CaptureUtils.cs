using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Tiantu.DB.Common
{
 

    public class CaptureResult
    {
        public CookieCollection CookieCollection { get; set; }

        public WebHeaderCollection Header { get; set; }

        public string Html { get; set; }
        public string Cookie { get; set; }
    }


    public class CaptureItem
    {
        public string Cookie { get; set; }
        public WebHeaderCollection Header { get; set; }
        public CookieCollection CookieCollection { get; set; }
    }


    public class CaptureModel
    {
        public CaptureContentModel listInfo { get; set; }
    }
    public class CaptureContentModel
    {
        public List<CaptureItemModel> content { get; set; }
    }
    public class CaptureItemModel
    {
        public string companyCd { get; set; }
        public string companyName { get; set; }
        public string destFilePath { get; set; }
        public string disclosureTitle { get; set; }
        public DateTime publishDate { get; set; }
    }


    public class CaptureUtils
    {
        //部分网站做了反爬虫技术时，需要模拟浏览器进行返回才能获取到相应的数据，否则获取不了
        //private static CookieContainer cookieContainer = new CookieContainer();
        private static string contentType = "application/x-www-form-urlencoded";
        private static string accept = "text/html, application/xhtml+xml, */*";
        private static string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0";


        public static CaptureResult Login(string userid,string password)
        {
            CaptureResult result = new CaptureResult();

            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Stream requestStream = null;
            Stream responseStream = null;
            StreamReader reader = null;
            

            string loginUrl = "https://www.51bxg.com/api_web/WebCommon/PostUserLogin";
            string postData = @"z_data={""loginName"":""" + userid + @""",""loginPwd"":""" + password + @""",""autoLogin"":false""}";

            try
            {
                request = (HttpWebRequest)WebRequest.Create(loginUrl);
                request.Method = "POST";
                request.Timeout = 100000;
                request.ReadWriteTimeout = 30000;
                request.UserAgent = userAgent;
                request.Accept = accept;
                request.ContentType = contentType;
                request.AllowAutoRedirect = false;
                request.ServicePoint.ConnectionLimit = 1024;

                byte[] data = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = data.Length;
                requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                response = request.GetResponse() as HttpWebResponse;
                result.Header = response.Headers;

                if (response.Cookies != null)
                {
                    result.CookieCollection = response.Cookies;
                }

                if (response.Headers["set-cookie"] != null)
                {
                    result.Cookie = response.Headers["set-cookie"];
                }

                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.UTF8);
                result.Html = reader.ReadToEnd();
                 
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                if (reader != null) reader.Close();
                if (responseStream != null) responseStream.Close();
                if (response != null) response.Close();
                if (request != null) request = null;
            }

            return result;
            }


        public static string GetResponseBody(string webUrl,string postData = null)
        {
            return GetResponseBody(null, webUrl, postData);
        }

        /// <summary>
        /// 返回请求的URL地址Tuple&lt;bool,string,string&gt; = 是否成功，网页源码，异常信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="keyword"></param>
        /// <param name="encoding"></param>
        /// <param name="newUrl"></param>
        /// <returns></returns>
        public static string GetResponseBody(CaptureItem httpItem , string webUrl, string postData )
        {
            string pageHtml = "", exceptionInfo = "";

            //编码             
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Stream requestStream = null;
            Stream responseStream = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(webUrl);
                request.Method = (string.IsNullOrEmpty(postData) ? "GET" : "POST");
                request.Timeout = 100000;
                request.ReadWriteTimeout = 30000;
                request.UserAgent = userAgent;
                request.Accept = accept;
                request.ContentType = contentType;
                request.AllowAutoRedirect = false;

                if (httpItem != null)
                {
                    if (httpItem.Header != null && httpItem.Header.Count > 0)
                    {
                        foreach (string item in httpItem.Header.AllKeys)
                        {
                            request.Headers.Add(item, httpItem.Header[item]);
                        }
                    }

                    if (!string.IsNullOrEmpty(httpItem.Cookie))
                    {
                        //Cookie
                        request.Headers[HttpRequestHeader.Cookie] = httpItem.Cookie;
                    }

                    if (httpItem.CookieCollection != null)
                    {
                        request.CookieContainer = new CookieContainer();
                        request.CookieContainer.Add(httpItem.CookieCollection);
                    }
                }

                

                if (!string.IsNullOrEmpty(postData))
                {
                    byte[] data = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = data.Length;
                    requestStream = request.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }

                request.ServicePoint.ConnectionLimit = 1024;
                // string ACCESS_TOKEN = "4fa8f4ebeb8d54314edb78ccfa1730ab5e2f61aba5808407589f38807a340b5f";
                // request.Headers.Add("Authorization", "Bearer " + ACCESS_TOKEN);

                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                response = request.GetResponse() as HttpWebResponse;
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.UTF8);
                pageHtml = reader.ReadToEnd();

            }
            catch (System.Net.WebException err)
            {
                exceptionInfo = err.Message;
            }
            catch (Exception err)
            {
                exceptionInfo = err.Message;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (responseStream != null) responseStream.Close();
                if (response != null) response.Close();
                if (request != null) request = null;
            }

            return pageHtml;
        }


 
    }
}