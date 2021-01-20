using System;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
using URLRewriter.Config;

/// <summary>
/// URLRewriter 路由重写单文件
/// </summary>
namespace URLRewriter
{
    /// <summary>
    /// 模块重写的基类。这个类是抽象的，因此必须派生自。
    /// </summary>
    public abstract class BaseModuleRewriter : IHttpModule
    {
        public virtual void Init(HttpApplication app)
        {
            app.AuthorizeRequest += new EventHandler(this.BaseModuleRewriter_AuthorizeRequest);
        }

        public virtual void Dispose()
        {
        }

        protected virtual void BaseModuleRewriter_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            // string webHost = app.Context.Request.ServerVariables["HTTP_HOST"].ToLower();

            Rewrite(app.Request.Path, app);

            //  Rewrite(app.Request.Url.AbsoluteUri, app);
        }

        protected abstract void Rewrite(string requestedPath, HttpApplication app);
    }

    /// <summary>
    ///  使用给定的路径、路径信息和查询字符串信息重写 URL。
    /// </summary>
    public class ModuleRewriter : BaseModuleRewriter
    {
        protected override void Rewrite(string requestedPath, System.Web.HttpApplication app)
        {
            // get the configuration rules
            RewriterRuleCollection rules = RewriterConfiguration.GetConfig().Rules;

            //  string webHost = app.Context.Request.ServerVariables["HTTP_HOST"];

            // iterate through each rule...
            for (int i = 0; i < rules.Count; i++)
            {
                // get the pattern to look for, and Resolve the Url (convert ~ into the appropriate directory)
                string lookFor = "^" + RewriterUtils.ResolveUrl(app.Context.Request.ApplicationPath, rules[i].LookFor) + "$";

                /*
                if (webHost.IndexOf("news.") == 0)
                {
                    lookFor = "^" + rules[i].LookFor + "$";
                }
                */

                // Create a regex (note that IgnoreCase is set...)
                Regex re = new Regex(lookFor, RegexOptions.IgnoreCase);

                // See if a match is found
                if (re.IsMatch(requestedPath))
                {
                    // match found - do any replacement needed
                    string sendToUrl = RewriterUtils.ResolveUrl(app.Context.Request.ApplicationPath, re.Replace(requestedPath, rules[i].SendTo));

                    // log rewriting information to the Trace object
                    // app.Context.Trace.Write("ModuleRewriter", "Rewriting URL to " + sendToUrl);

                    // Rewrite the URL
                    RewriterUtils.RewriteUrl(app.Context, sendToUrl);
                    break;      // exit the for loop
                }
            }
        }
    }

    /// <summary>
    /// 提供一个HttpHandler执行重定向。
    /// </summary>
    public class RewriterFactoryHandler : IHttpHandlerFactory
    {
        public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            // log info to the Trace object...
            context.Trace.Write("RewriterFactoryHandler", "Entering RewriterFactoryHandler");

            string sendToUrl = url;
            string filePath = pathTranslated;

            // get the configuration rules
            RewriterRuleCollection rules = RewriterConfiguration.GetConfig().Rules;

            // iterate through the rules
            for (int i = 0; i < rules.Count; i++)
            {
                // Get the pattern to look for (and resolve its URL)
                string lookFor = "^" + RewriterUtils.ResolveUrl(context.Request.ApplicationPath, rules[i].LookFor) + "$";

                // Create a regular expression object that ignores case...
                Regex re = new Regex(lookFor, RegexOptions.IgnoreCase);

                // Check to see if we've found a match
                if (re.IsMatch(url))
                {
                    // do any replacement needed
                    sendToUrl = RewriterUtils.ResolveUrl(context.Request.ApplicationPath, re.Replace(url, rules[i].SendTo));

                    // log info to the Trace object...
                    context.Trace.Write("RewriterFactoryHandler", "Found match, rewriting to " + sendToUrl);

                    // Rewrite the path, getting the querystring-less url and the physical file path
                    string sendToUrlLessQString;
                    RewriterUtils.RewriteUrl(context, sendToUrl, out sendToUrlLessQString, out filePath);

                    // return a compiled version of the page
                    context.Trace.Write("RewriterFactoryHandler", "Exiting RewriterFactoryHandler");    // log info to the Trace object...
                    return PageParser.GetCompiledPageInstance(sendToUrlLessQString, filePath, context);
                }
            }

            // if we reached this point, we didn't find a rewrite match
            context.Trace.Write("RewriterFactoryHandler", "Exiting RewriterFactoryHandler");    // log info to the Trace object...
            return PageParser.GetCompiledPageInstance(url, filePath, context);
        }

        public virtual void ReleaseHandler(IHttpHandler handler)
        {
        }
    }

    /// <summary>
    /// 为改写httpmodule和HttpHandler实用的辅助方法。
    /// </summary>
    internal class RewriterUtils
    {
        #region 重写URL

        internal static void RewriteUrl(HttpContext context, string sendToUrl)
        {
            string x, y;
            RewriteUrl(context, sendToUrl, out x, out y);
        }

        internal static void RewriteUrl(HttpContext context, string sendToUrl, out string sendToUrlLessQString, out string filePath)
        {
            // see if we need to add any extra querystring information
            if (context.Request.QueryString.Count > 0)
            {
                if (sendToUrl.IndexOf('?') != -1)
                    sendToUrl += "&" + context.Request.QueryString.ToString();
                else
                    sendToUrl += "?" + context.Request.QueryString.ToString();
            }

            // first strip the querystring, if any
            string queryString = String.Empty;
            sendToUrlLessQString = sendToUrl;
            if (sendToUrl.IndexOf('?') > 0)
            {
                sendToUrlLessQString = sendToUrl.Substring(0, sendToUrl.IndexOf('?'));
                queryString = sendToUrl.Substring(sendToUrl.IndexOf('?') + 1);
            }

            // grab the file's physical path
            filePath = string.Empty;
            filePath = context.Server.MapPath(sendToUrlLessQString);

            // rewrite the path...
            context.RewritePath(sendToUrlLessQString, String.Empty, queryString);

            // NOTE!  The above RewritePath() overload is only supported in the .NET Framework 1.1
            // If you are using .NET Framework 1.0, use the below form instead:
            // context.RewritePath(sendToUrl);
        }

        #endregion 重写URL

        internal static string ResolveUrl(string appPath, string url)
        {
            if (url.Length == 0 || url[0] != '~')
                return url;     // there is no ~ in the first character position, just return the url
            else
            {
                if (url.Length == 1)
                    return appPath;  // there is just the ~ in the URL, return the appPath
                if (url[1] == '/' || url[1] == '\\')
                {
                    // url looks like ~/ or ~\
                    if (appPath.Length > 1)
                        return appPath + "/" + url.Substring(2);
                    else
                        return "/" + url.Substring(2);
                }
                else
                {
                    // url looks like ~something
                    if (appPath.Length > 1)
                        return appPath + "/" + url.Substring(1);
                    else
                        return appPath + url.Substring(1);
                }
            }
        }
    }
}

namespace URLRewriter.Config
{
    public class RewriterConfigSerializerSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            // Create an instance of XmlSerializer based on the RewriterConfiguration type...
            XmlSerializer ser = new XmlSerializer(typeof(RewriterConfiguration));

            // Return the Deserialized object from the Web.config XML
            return ser.Deserialize(new XmlNodeReader(section));
        }
    }

    /// <summary>
    /// 路由重写配置
    /// </summary>
    [Serializable()]
    [XmlRoot("RewriterConfig")]
    public class RewriterConfiguration
    {
        private RewriterRuleCollection rules;

        public static RewriterConfiguration GetConfig()
        {
            if (HttpContext.Current.Cache["RewriterConfig"] == null)
            {
                HttpContext.Current.Cache.Insert("RewriterConfig", ConfigurationSettings.GetConfig("RewriterConfig"));
            }

            return (RewriterConfiguration)HttpContext.Current.Cache["RewriterConfig"];
        }

        #region 公共参数

        public RewriterRuleCollection Rules
        {
            get
            {
                return rules;
            }
            set
            {
                rules = value;
            }
        }

        #endregion 公共参数
    }

    /// <summary>
    /// 路由规则
    /// </summary>

    [Serializable()]
    public class RewriterRule
    {
        private string lookFor, sendTo;

        #region 公共参数

        public string LookFor
        {
            get
            {
                return lookFor;
            }
            set
            {
                lookFor = value;
            }
        }

        public string SendTo
        {
            get
            {
                return sendTo;
            }
            set
            {
                sendTo = value;
            }
        }

        #endregion 公共参数
    }

    /// <summary>
    /// 路由规则
    /// </summary>
    [Serializable()]
    public class RewriterRuleCollection : CollectionBase
    {
        public virtual void Add(RewriterRule r)
        {
            this.InnerList.Add(r);
        }

        public RewriterRule this[int index]
        {
            get
            {
                return (RewriterRule)this.InnerList[index];
            }
            set
            {
                this.InnerList[index] = value;
            }
        }
    }
}