using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class thisisbackstage_capture_CaptureData : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if ("capture".Equals(Request.Form["method"]))
        //{

        //    var page = SL.GetQueryFormIntValue("page");

        //    Response.End();
        //}

        if (!IsPostBack)
        {
          
        }
    }

    /// <summary>
    /// 开始采集
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnStartCapture_Click(object sender, EventArgs e)
    {
        var pageId = this.ddlpageId.SelectedValue.ToInt32();
        StartCapture(pageId);
        this.PlaceHolderResult.Visible = true;
        //this.txtBody.Text = "获取结果：" + body;
    }

    /// <summary>
    /// 开始采集
    /// </summary>
    /// <param name="page"></param>
    void StartCapture(int page)
    {
        try
        {
            var companyCd = "835106";
            var needFields = new string[] { "companyCd", "companyName", "disclosureTitle", "destFilePath", "publishDate" };
            var sortfield = "xxssdq";
            var sorttype = "asc";

            var webUrl = "http://www.neeq.com.cn/disclosureInfoController/infoResult_zh.do?callback=json";
            var data = "page={0}&companyCd={1}&sortfield={2}&sorttype={3}".ToFormat(page, companyCd, sortfield, sorttype);
            var body = CaptureUtils.GetResponseBody(webUrl, data);

            //取([ *** ]) 中间的值
            string pattern = @"\(\[(.*)\]\)";
            MatchCollection mc = Regex.Matches(body, pattern, RegexOptions.IgnoreCase);

            var result = "";// mc[0].Groups[1].Value.ToString();

            if (mc.Count > 0)
            {
                var json_data = mc[0].Groups[1].Value.ToString();
                CaptureModel capture = JsonUtil.Decode(json_data, typeof(CaptureModel)) as CaptureModel;
                result = capture.listInfo.content.Count.ToString();

                var lists = capture.listInfo.content;


                for (int i = lists.Count - 1; i >= 0; i--)
                {
                    var item = lists[i];


                    //2021-04月前的不要
                    if (Convert.ToDateTime(item.publishDate).Subtract(DateTime.Parse("2021-04-01")).TotalDays < 0)
                        continue;

                    //下载图片 
                    var pdfUrl = "/upfile/pdf/{0}".ToFormat(System.IO.Path.GetFileName(item.destFilePath));
                    if (!item.destFilePath.IsNullOrWhiteSpace())
                    {
                        var httpImageUrl = "http://www.neeq.com.cn" + item.destFilePath;
                        var pdfFilePath = Server.MapPath(pdfUrl);
                        if (!System.IO.File.Exists(pdfFilePath))
                        {
                            HtmlUtils.SaveHttpImageToServer(httpImageUrl, pdfFilePath);
                        }
                    }

                    var title = item.disclosureTitle;

                    if (item.disclosureTitle.StartsWith("[临时公告]"))
                    {
                        //公告
                        title = title.Replace("[临时公告]", "");
                        title = title.Replace("天图物流:", "");

                        //公告 
                        var exists = dalNotices.Exists(title);
                        if (!exists)
                        {
                            var model = new Tiantu.DB.Model.Notices();
                            model.TITLE = title;
                            model.SUBTITLE = "";
                            model.PDFURL = pdfUrl;
                            model.PUBDATE = Convert.ToDateTime(item.publishDate);
                            dalNotices.Add(model);
                        }
                    }
                    else if (item.disclosureTitle.StartsWith("[定期报告]"))
                    {
                        //报告
                        title = title.Replace("[定期报告]", "");
                        title = title.Replace("天图物流:", "");

                        //报告 
                        var exists = dalReports.Exists(title);
                        if (!exists)
                        {
                            var yearId = GetYear(title);
                            var categoryId = dalReports.GetCategoryId(yearId);
                            var model = new Tiantu.DB.Model.Reports();
                            model.TITLE = title;
                            model.CATEID = categoryId;
                            model.PDFURL = pdfUrl;
                            model.PUBDATE = Convert.ToDateTime(item.publishDate);
                            dalReports.Add(model);
                        }
                    }

                }


                this.gridView1.DataSource = capture.listInfo.content;
                this.gridView1.DataBind();
            }

  

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

      
    }



    int GetYear(string title)
    {
        int yearId = DateTime.Now.Year;
        string pattern = @"(\d+)年";
        MatchCollection mc = Regex.Matches(title, pattern, RegexOptions.IgnoreCase);
        try
        {
            yearId  = Convert.ToInt32(mc[0].Groups[1].Value);
        }
        catch (Exception ex)
        {

        }
        return yearId;
    }
}