
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Tiantu.DB.Common
{
    public class WebControlsHelper
    {


        /// <summary>
        /// 网站域名： unkonw.com
        /// </summary>
        public static string WebDomain = "unkonw.com";

        /// <summary>
        /// 是否测试  本地：localhost  
        /// </summary>
        public static string DEBUG_WEBSITE
        {
            get
            {
                string _website = System.Configuration.ConfigurationManager.AppSettings["DebugWebsite"];
                return string.IsNullOrWhiteSpace(_website) ? "" : _website;
            }
        }


        public static string HttpPC
        {
            get
            {
                //<appSettings>
                //  <add key = "DebugWebsite" value="localhost"/>
                //</appSettings>
                return DEBUG_WEBSITE.Equals("localhost") ? "http://localhost:8269" : "http://www.honotop.com";
            }
        }







        #region 文件版本

        public static string version = "";
        public static string jsVersion = "";
        public static string cssVersion = "";

        static WebControlsHelper()
        {
            version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            jsVersion = SL.EncryptMD5(version).ToLower();
            cssVersion = SL.EncryptMD5(version).ToLower();
        }

        public static string GetJsLink(params string[] paths)
        {
            StringBuilder links = new StringBuilder();
            foreach (var item in paths)
            {
                links.AppendLine(@"<script type='text/javascript' charset='utf-8' src='{0}{1}?v={2}'></script>".ToFormat(HttpPC, item, jsVersion));
            }
            return links.ToString();
        }

        public static string GetCssLink(params string[] paths)
        {
            StringBuilder links = new StringBuilder();
            foreach (var item in paths)
            {
                links.AppendLine(@"<link rel='stylesheet' type='text/css' href='{0}{1}?v={2}' />".ToFormat(HttpPC, item, cssVersion));
            }
            return links.ToString();
        }

        #endregion 文件版本



        #region 文件、图片上传
        /// <summary>
        /// 上传图片  
        /// eg: imgurl= WebControlsHelper.FileUploadImage(this.FileUpload1, "news", imgurl);
        /// </summary>
        /// <param name="fileupload"></param>
        /// <param name="dir">/upfile/{0}/yyyyMMddHHmmssffff.***</param>
        /// <param name="imgurl">旧图片路径</param>
        public static string FileUploadImage(System.Web.UI.WebControls.FileUpload fileupload, string dir, string imgurl)
        {
            if (fileupload.HasFile)
            {
                //删除旧图
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(imgurl)))
                {
                    System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(imgurl));
                }

                //上传新图
                imgurl = string.Format("/upfile/{0}/{1}{2}", dir, System.DateTime.Now.ToString("yyyyMMddHHmmssffff"), System.IO.Path.GetExtension(fileupload.PostedFile.FileName));
                fileupload.SaveAs(System.Web.HttpContext.Current.Server.MapPath(imgurl));
            }
            return imgurl;
        }


        /// <summary>
        /// 上传PDF 
        /// eg: imgurl= WebControlsHelper.FileUpload(this.FileUpload1, "news", imgurl);
        /// </summary>
        /// <param name="fileupload"></param>
        /// <param name="dir">/upfile/{0}/yyyyMMddHHmmssffff.***</param>
        /// <param name="imgurl">旧文件路径</param>
        public static string FileUpload(System.Web.UI.WebControls.FileUpload fileupload, string dir, string url, string filename = "")
        {
            if (fileupload.HasFile)
            {
                //删除旧图
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(url)))
                {
                    System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(url));
                }

                //上传新图
                url = string.Format("/upfile/{0}/{1}{2}", dir, (string.IsNullOrWhiteSpace(filename) ? System.DateTime.Now.ToString("yyyyMMddHHmmssffff") : filename),
                    System.IO.Path.GetExtension(fileupload.PostedFile.FileName));
                fileupload.SaveAs(System.Web.HttpContext.Current.Server.MapPath(url));
            }
            return url;
        }
        #endregion 文件、图片上传



        #region 页面JSON
        public static string SimpleJsonResult(string ErrorMessage = "", string SuccessMessage = "")
        {
            Hashtable result = new Hashtable();
            if (string.IsNullOrWhiteSpace(ErrorMessage))
            {
                result.Add("errcode", 1);
                result.Add("errmsg", SuccessMessage);
            }
            else
            {
                result.Add("errcode", -1);
                result.Add("errmsg", ErrorMessage);
            }

            return JsonUtil.Encode(result);

        }
        public static void SimpleJsonResultxxx(object obj)
        {

            Type t = obj.GetType();
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object value1 = pi.GetValue(obj, null);
                string name = pi.Name;
                if (value1.GetType() == typeof(int))
                {

                }
            }
        }
        #endregion 页面JSON
    }
}