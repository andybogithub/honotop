using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;

namespace Tiantu.DB.Common
{
    /// <summary>
    ///DataMatchHelper 的摘要说明
    /// </summary>
    public class HtmlUtils
    {
        public HtmlUtils()
        {
            //获取层div
            //<div[^>]*>[^<>]*(((?'Open'<div[^>]*>)[^<>]*)+((?'-Open'</div>)[^<>]*)+)*(?(Open)(?!))</div>
            //<div>((?<Open><div>)|(?<-Open></div>)|[^<>])*(?(Open)(?!))</div>
        }

        #region 获取文本值
        /// <summary>
        /// 获取文本值
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string GetItemText(string strHtml)
        {
            /*
             * **************************************************
             *    <div>
             *          这里是获取的内容
             *    </div>
             *  **************************************************
             */
            if (strHtml.IndexOf("<") > -1 || strHtml.IndexOf(">") > -1)
            {
                string pattern = @"<(\w+)[^>]*>([\w\W]*)<\/\1>";
                if (Regex.IsMatch(strHtml, pattern, RegexOptions.IgnoreCase))
                {
                    return Regex.Match(strHtml, pattern, RegexOptions.IgnoreCase).Groups[2].Value.Trim();
                }
            }
            return strHtml;
        }

        #endregion



        #region 获取一个属性的值
        /// <summary>
        /// 获取一个属性的值
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string GetItemAttrValue(string propName, string strHtml)
        {
            /*
             * **************************************************
             *  <item propName='这里是获取的内容'/>
             *  **************************************************
             */
            string pattern = string.Format(@"{0}\s*=\s*([""']*)([\w\W]*?)\1[\s|>|\/]", propName);
            if (Regex.IsMatch(strHtml, pattern, RegexOptions.IgnoreCase))
            {
                Match m = Regex.Match(strHtml, pattern, RegexOptions.IgnoreCase);
                return m.Groups[2].Value;
            }
            return "";
        }
        #endregion


        #region 将所有属性与值组成 hashtable
        /// <summary>
        /// 将所有属性与值组成 hashtable
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static Hashtable GetItemAttrs(string strHtml)
        {
            /*
             * 格式：
             *  <item id='1001' name='item1' price='21'/>
             *  **********************************
             * 返回类型： Hashtable
             *  id->10001, name->item1, price=21
             * 
             * */
            Hashtable ht = new Hashtable();
            string pattern = @"(\w+)\s*=\s*([""']*)(.*?)\2[\s|>|\/]";
            //pattern = @"(\w+)\s*=\s*(?![""'])(\S*)";
            if (Regex.IsMatch(strHtml, pattern, RegexOptions.IgnoreCase))
            {
                MatchCollection mc = Regex.Matches(strHtml, pattern, RegexOptions.IgnoreCase);
                foreach (Match m in mc)
                {
                    ht.Add(m.Groups[1].Value, m.Groups[3].Value);
                }
            }
            return ht;
        }
        #endregion



        #region 根据ID,ClzName,指定前后标签来获取内容
        /// <summary>
        /// 根据ID来获取内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strHtmlBody"></param>
        /// <returns></returns>
        public static string GetContentById(string id, string htmlDS)
        {
            /*
            * ===================================================
            *  <div id='list'>
             *  这里是获取的内容
             * </div>
            *===================================================
            */
            //string pattern = string.Format(@"<(\w+)[^>]*id\s*=([""']*){0}\2[^>]*>((?!</?\1[^>]*>).|\n)*(((?'TAG'<\1[^>]*>)((?!</?\1[^>]*>).|\n)*)+((?'-TAG'</\1>)((?!</?\1[^>]*>).|\n)*)+)*(?(TAG)(?!))</\1>", id);
            string pattern = @"<([a-z]+)(?:(?!\bid\b)[^<>])*id=([""']?){0}\2[^>]*>(?><\1[^>]*>(?<o>)|</\1>(?<-o>)|(?:(?!</?\1).)*)*(?(o)(?!))</\1>";
            Match m = Regex.Match(htmlDS, string.Format(pattern, Regex.Escape(id)), RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return GetItemText(m.Value);
        }

        /// <summary>
        /// 根据ClassName来获取内容
        /// </summary>
        /// <param name="clzName"></param>
        /// <param name="htmlDS"></param>
        /// <returns></returns>
        public static string GetContentByClassName(string clzName, string htmlDS)
        {
            /*
            * ===================================================
            *  <div id='list'>
             *  这里是获取的内容
             * </div>
            *===================================================
            */
            //string pattern = string.Format(@"<(\w+)[^>]*id\s*=([""']*){0}\2[^>]*>((?!</?\1[^>]*>).|\n)*(((?'TAG'<\1[^>]*>)((?!</?\1[^>]*>).|\n)*)+((?'-TAG'</\1>)((?!</?\1[^>]*>).|\n)*)+)*(?(TAG)(?!))</\1>", id);
            string pattern = @"<([a-z]+)(?:(?!\bid\b)[^<>])*class=([""']?){0}\2[^>]*>(?><\1[^>]*>(?<o>)|</\1>(?<-o>)|(?:(?!</?\1).)*)*(?(o)(?!))</\1>";
            Match m = Regex.Match(htmlDS, string.Format(pattern, Regex.Escape(clzName)), RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return GetItemText(m.Value);
        }

        /// <summary>
        /// 指定开始与结束标签
        /// </summary>
        /// <param name="startTag"></param>
        /// <param name="endTag"></param>
        /// <param name="htmlDS"></param>
        /// <returns></returns>
        public static string GetContentByPointTag(string startTag, string endTag, string htmlDS)
        {

            string pattern = string.Format(@"{0}([\s\S]*?){1}", Regex.Escape(startTag), Regex.Escape(endTag));
            Match m = Regex.Match(htmlDS, pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            return GetItemText(m.Value);
        }

        /// <summary>
        /// 获取指定标签的值
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="htmlDS"></param>
        /// <returns></returns>
        public static string GetContentByTag(string tag, string htmlDS)
        {
            List<string> lstData = GetListByTagName(tag, htmlDS);
            return lstData.Count > 0 ? GetItemText(lstData[0]) : "";
        }

        #endregion



        #region 根据指定的属性与值来获取值
        /// <summary>
        /// 根据指定的属性与值来获取值，组成List[string]格式，如获取所有class='red'的项的文本值
        /// </summary>
        /// <param name="propName">指定属性</param>
        /// <param name="propVal">属性值</param>
        /// <param name="strHtmlBody"></param>
        /// <returns></returns>
        public static List<string> GetListByPropName(string propName, string propVal, string strHtmlBody)
        {
            /*
             * **********************************
             *  <div propName='propVal'>这里是获取的内容</div>
             *  <div propName='propVal'>这里是获取的内容</div>
             *  <div propName='propVal'>这里是获取的内容</div>
             * **********************************
             */
            List<string> lst = new List<string>();
            string pattern = string.Format(@"<(\w+)[^>]*{0}\s*=([""']*){1}\2[^>]*>((?!</?\1[^>]*>).|\n)*(((?'TAG'<\1[^>]*>)((?!</?\1[^>]*>).|\n)*)+((?'-TAG'</\1>)((?!</?\1[^>]*>).|\n)*)+)*(?(TAG)(?!))</\1>", propName, propVal);
            MatchCollection mc = Regex.Matches(strHtmlBody, pattern, RegexOptions.IgnoreCase);
            foreach (Match m in mc)
            {
                string strVal = GetItemText(m.Value);
                lst.Add(strVal);
            }
            return lst;
        }
        #endregion





        /// <summary>
        /// 获取一个标签（如：li)的所有值，组成List[string]
        /// </summary>
        /// <param name="el"></param>
        /// <param name="strHtmlBody"></param>
        /// <returns></returns>
        public static List<string> GetListByTagName(string tagName, string strHtmlBody)
        {
            /*
             * **********************************
             *  <ul>
             *  <li>111</li>
             *  <li>222</li>
             *  <li>333</li>
             *  </ul>
             *  **********************************
             * 返回类型： List<string>
             * 获取所有 li 的值
             * 
             */
            List<string> lst = new List<string>();
            string pattern = string.Format(@"<({0})[^>]*>((?!</?\1[^>]*>).|\n)*(((?'TAG'<\1[^>]*>)((?!</?\1[^>]*>).|\n)*)+((?'-TAG'</\1>)((?!</?\1[^>]*>).|\n)*)+)*(?(TAG)(?!))</\1>", tagName);
            MatchCollection mc = Regex.Matches(strHtmlBody, pattern, RegexOptions.IgnoreCase);
            foreach (Match m in mc)
            {
                string strVal = GetItemText(m.Value);
                lst.Add(strVal);
            }
            return lst;
        }




        /// <summary>
        /// 将html内容转化为DataTable格式
        /// </summary>
        /// <param name="strTable"></param>
        /// <returns></returns>
        public static DataTable ConvertHtmlTableToDataTable(string htmlDS)
        {
            DataTable dt = new DataTable();
            string pattern = @"<tr[^>]*>([\s\S]*?)<\/tr>";
            MatchCollection mc = Regex.Matches(htmlDS, pattern, RegexOptions.IgnoreCase);
            if (mc != null)
            {
                int rowIndex = 0;
                DataColumn dc;
                DataRow dr;
                foreach (Match m in mc)
                {
                    string val = m.Groups[1].Value;

                    if (rowIndex == 0)
                    {
                        MatchCollection columnMC = null;
                        //创建列
                        if (Regex.IsMatch(val, @"<th[^>]*>([\s\S]*?)<\/th>"))
                        {
                            columnMC = Regex.Matches(val, @"<th[^>]*>([\s\S]*?)<\/th>");
                        }
                        else if (Regex.IsMatch(val, @"<td[^>]*>([\s\S]*?)<\/td>"))
                        {
                            columnMC = Regex.Matches(val, @"<td[^>]*>([\s\S]*?)<\/td>");
                        }
                        if (columnMC != null)
                        {
                            for (int i = 0; i < columnMC.Count; i++)
                            {
                                dc = new DataColumn(GetHtmlText(columnMC[i].Groups[1].Value));
                                dt.Columns.Add(dc);
                            }
                        }
                    }
                    else
                    {
                        //添加行数据
                        if (Regex.IsMatch(val, @"<td[^>]*>([\s\S]*?)<\/td>"))
                        {
                            dr = dt.NewRow();
                            MatchCollection rowColl = Regex.Matches(val, @"<td[^>]*>([\s\S]*?)<\/td>");
                            for (int i = 0; i < rowColl.Count; i++)
                            {
                                dr[i] = rowColl[i].Groups[1].Value;
                            }
                            dt.Rows.Add(dr);
                        }
                    }

                    rowIndex++;
                }
            }
            return dt;
        }



        #region 公共方法
        /// <summary>
        /// 将html字符串转化为纯文本格式，过滤script,frameset,iframe,href,img,p,ul等标签
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string GetHtmlText(string dsHtml)
        {
            if (null == dsHtml || string.IsNullOrEmpty(dsHtml)) return "";
            string[] pattern = { @"<[^>]*>", @"<script[\s\S]+</script *>", @" href *= *[\s\S]*script *:", @" no[\s\S]*=", @"<iframe[\s\S]+</iframe *>", @"<frameset[\s\S]+</frameset *>", @"<img[^\>]+", "_disibledevent=" };
            for (int i = 0; i < pattern.Length; i++)
            {
                dsHtml = Regex.Replace(dsHtml, pattern[i], "");
            }
            return dsHtml;
        }
        #endregion




        #region 实用方法

        /// <summary>
        /// 根据ID来获取包含的table内容并将其转化为DataTable
        /// </summary>
        /// <param name="htmlId"></param>
        /// <param name="htmlDS"></param>
        /// <returns></returns>
        public static DataTable GetDataTableById(string htmlId, string htmlDS)
        {
            string ds = GetContentById(htmlId, htmlDS);
            return ConvertHtmlTableToDataTable(ds);
        }

        /// <summary>
        /// 从ul的id来提取List对象,组成格式： 1（链接地址），2（标题）
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="ulDS"></param>
        /// <returns></returns>
        public static List<string[]> GetTitleAndLinkByULId(string elementId, string htmlDS)
        {
            string ulDS = GetContentById(elementId, htmlDS);
            return GetTitleAndLinkFromULContent(ulDS);
        }

        /// <summary>
        /// 从ul的内容中提取List对象,组成格式： 1（链接地址），2（标题） 
        /// </summary>
        /// <param name="ulDS"></param>
        /// <returns></returns>
        public static List<string[]> GetTitleAndLinkFromULContent(string ulDS)
        {
            string[] strs;
            List<string[]> strList = new List<string[]>();
            List<string> lst = GetListByTagName("li", ulDS);
            for (int i = 0; i < lst.Count; i++)
            {
                strs = GetTitleAndLinkAndData(lst[i]);
                strList.Add(strs);
            }
            return strList;
        }



        /// <summary>
        /// 从字符串中提取：1（链接地址），2（标题） 
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static string[] GetTitleAndLink(string strVal)
        {
            string[] strArr = new string[2];
            string pattern = @"<\s*(a)[^>]*href\s*=\s*[""']*([\w\W]+?)[""'][^>]*>(.*?)</a>";
            Match m = Regex.Match(strVal, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                strArr[0] = m.Groups[2].Value;
                strArr[1] = m.Groups[3].Value;
            }
            return strArr;
        }

        /// <summary>
        ///  从字符串中提取：1（链接地址），2（标题），3（结束的值）, 4（开始的值）
        ///  <![CDATA[ 
        ///     <li><a href='www.web1.com'>web1</a><span>2012-08-01</span></li> 
        ///     <li><a href='www.web2.com'>web2</a><span>2012-08-01</span></li>
        ///     <li><a href='www.web3.com'>web3</a><span>2012-08-01</span></li>
        /// ]>
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static string[] GetTitleAndLinkAndData(string strVal)
        {
            string[] strArr = new string[4];
            string pattern = @"(<\s*(\w+)\s*>(.*?)<\/\s*\2\s*>)*<\s*a[^>]*href\s*=\s*[""']*([\w\W]+?)[""'][^>]*>(.*?)</a>[\s|\n]*(<\s*(\w+)\s*>(.*?)<\/\s*\7\s*>)*[\s|\n]*";
            Match m = Regex.Match(strVal, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                strArr[0] = m.Groups[4].Value;  //链接
                strArr[1] = m.Groups[5].Value;  //标题
                strArr[2] = m.Groups[8].Value;  //后值
                strArr[3] = m.Groups[3].Value;  //前值
            }
            return strArr;
        }
        #endregion


        #region 获取A列表
        public static List<string> GetTitleAndLinkDataList(string strVal)
        {
            List<string> list = new List<string>();
            string pattern = @"<a [^>]*href\s*=\s*[""']*([\w\W]+?)[""'][^>]*>(.*?)</a>";
            MatchCollection ms = Regex.Matches(strVal, pattern, RegexOptions.IgnoreCase);
            if (ms.Count > 0)
            {
                foreach (Match m in ms)
                {
                    list.Add(m.Groups[0].Value);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取A列表的 link,title
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static List<string[]> GetTitleAndLinkList(string strVal)
        {
            List<string[]> list = new List<string[]>();
            string pattern = @"<a [^>]*href\s*=\s*[""']*([\w\W]+?)[""'][^>]*>(.*?)</a>";
            MatchCollection ms = Regex.Matches(strVal, pattern, RegexOptions.IgnoreCase);
            if (ms.Count > 0)
            {
                foreach (Match m in ms)
                {
                    list.Add(new string[] { m.Groups[1].Value, m.Groups[2].Value });
                }
            }
            return list;
        }


        public static List<string[]> GetTitleAndLinkDataListByEmpty(string strVal)
        {
            List<string[]> list = new List<string[]>();
            string pattern = @"<a [^>]*href\s*=\s*([\w\W]+?) [^>]*>(.*?)</a>";
            MatchCollection ms = Regex.Matches(strVal, pattern, RegexOptions.IgnoreCase);
            if (ms.Count > 0)
            {
                foreach (Match m in ms)
                {
                    list.Add(new string[] { m.Groups[1].Value, m.Groups[2].Value });
                }
            }
            return list;
        }
        #endregion



        #region 从UL从获取li列表包含的数据
        public static List<string> GetLiListFromULData(string ulData)
        {
            return GetListByTagName("li", ulData);
        }

        /// <summary>
        /// 根据ul的id来获取li列表
        /// </summary>
        /// <param name="ulData"></param>
        /// <returns></returns>
        public static List<string> GetLiListByULId(string ulId, string htmlData)
        {
            string ulData = GetContentById(ulId, htmlData);
            return GetListByTagName("li", ulData);
        }


        /// <summary>
        /// 根据div的id来获取li列表
        /// </summary>
        /// <param name="divId"></param>
        /// <param name="htmlData"></param>
        /// <returns></returns>
        public static List<string> GetLiListByDivId(string divId, string htmlData)
        {
            /*
             * 如：<div id='mydiv'> 
             *      <ul>
             *          <li>1</li><li>11</li><li>111</li>
             *      </ul>
             *      <ul>
             *          <li>2</li><li>22</li><li>222</li>
             *      </ul>
             *    </div>
             *    
             * *****************************************   
             * 
             * 返回： 1,11,111,2,22,222组成的 List<string>
             * 
             */
            string divData = GetContentById(divId, htmlData);
            return GetListByTagName("li", divData);
        }
        #endregion




        #region 从图片标签中获取图片地址与文字信息
        /// <summary>
        /// 从[img src='http://www.website.com' title='this is title'/]中获取src,title的信息
        /// </summary>
        /// <param name="imgTagData"></param>
        /// <returns></returns>
        public static string[] GetImageDataInfo(string imgData)
        {
            string[] rs = new string[2];
            string pattern = @"<\s*img[^/>]*src\s*=\s*(?<c1>[""']*)(?<url>.*?)\<c1>[^/>]*(title\s*=\s*(?<c2>[""']*)(?<title>.*?)\<c2>[^/>]*)*/?>";
            if (Regex.IsMatch(imgData, pattern, RegexOptions.IgnoreCase))
            {
                Match m = Regex.Match(imgData, pattern, RegexOptions.IgnoreCase);
                rs[0] = m.Groups["url"].Value;
                rs[1] = m.Groups["title"].Value;
            }
            return rs;
        }
        #endregion





        #region 采集日志
        /// <summary>
        /// 采集日志
        /// </summary>
        /// <param name="strMsg"></param>
        public static void WriteLog(string strMsg)
        {
            string dirPath = @"D:\Work\项目\正则\Logger\" + DateTime.Now.ToString("yyyy-MM-dd");
            string filePath = dirPath + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }

            System.IO.Stream s = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(s, System.Text.Encoding.Default);
            sw.WriteLine("Date：{0}, {1} ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), strMsg);
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strList"></param>
        public static void WriteLog(List<string> strList)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (string s in strList)
            {
                sb.AppendLine(s);
            }
            WriteLog(sb.ToString());
        }
        #endregion


        /// <summary>
        /// 下载网址图片到服务器
        /// </summary>
        /// <param name="httpImageUrl">图片网址</param>
        /// <param name="serverImagePath">服务器本机地址</param>
        public static void SaveHttpImageToServer(string httpImageUrl, string serverImagePath)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.DownloadFile(httpImageUrl, serverImagePath);
            wc.Dispose();
        }


        /// <summary>
        /// 下载网址图片到服务器
        /// </summary>
        /// <param name="httpImageUrls"></param>
        /// <param name="serverImagePath"></param>
        public static void SaveHttpImageToServer(List<string> httpImageUrls, string serverImagePath)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            for (int i = 0; i < httpImageUrls.Count; i++)
            {
                wc.DownloadFile(httpImageUrls[i], serverImagePath);
            }
            wc.Dispose();
        }







        /// <summary>
        /// 备注
        /// </summary>
        private void Notices()
        {
            string id = "";
            string pattern = @"\(((?<Open>\()|(?<-Open>\))|[^()])*(?(Open)(?!))\)";

            Regex reg = new Regex(@"\(                  #普通字符“(”

                            (                       #分组构造，用来限定量词“*”修饰范围

                                (?<Open>\()         #命名捕获组，遇到开括弧’Open’计数加1

                            |                       #分支结构

                                (?<-Open>\))        #狭义平衡组，遇到闭括弧’Open’计数减1

                            |                       #分支结构

                                [^()]+              #非括弧的其它任意字符

                            )*                      #以上子串出现0次或任意多次

                            (?(Open)(?!))           #判断是否还有’Open’，有则说明不配对，什么都不匹配

                        \)                          #普通闭括弧

                     ", RegexOptions.IgnorePatternWhitespace);


            reg = new Regex(@"(?isx)                      #匹配模式，忽略大小写，“.”匹配任意字符

                      <div[^>]*>                      #开始标记“<div...>”

                          (?>                         #分组构造，用来限定量词“*”修饰范围

                              <div[^>]*>  (?<Open>)   #命名捕获组，遇到开始标记，入栈，Open计数加1

                          |                           #分支结构

                              </div>  (?<-Open>)      #狭义平衡组，遇到结束标记，出栈，Open计数减1

                          |                           #分支结构

                              (?:(?!</?div\b).)*      #右侧不为开始或结束标记的任意字符

                          )*                          #以上子串出现0次或任意多次

                          (?(Open)(?!))               #判断是否还有'OPEN'，有则说明不配对，什么都不匹配

                      </div>                          #结束标记“</div>”

                      ");

            // 根据id提取div嵌套标签
            reg = new Regex(@"(?isx)

                      <div(?:(?!(?:id=|</?div\b)).)*id=(['""]?)" + id + @"\1[^>]*>        #开始标记“<div...>”

                          (?>                         #分组构造，用来限定量词“*”修饰范围

                              <div[^>]*>  (?<Open>)   #命名捕获组，遇到开始标记，入栈，Open计数加1

                          |                           #分支结构

                              </div>  (?<-Open>)      #狭义平衡组，遇到结束标记，出栈，Open计数减1

                          |                           #分支结构

                              (?:(?!</?div\b).)*      #右侧不为开始或结束标记的任意字符

                          )*                          #以上子串出现0次或任意多次

                          (?(Open)(?!))               #判断是否还有'OPEN'，有则说明不配对，什么都不匹配

                      </div>                          #结束标记“</div>”

                     ");



        }

    }
}