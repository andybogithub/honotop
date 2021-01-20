<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
public class UploadHandler : IHttpHandler, IRequiresSessionState
{
    //DeSai.DB.DAL.StoresShow dalStoresShow = new DeSai.DB.DAL.StoresShow();


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        try
        {
            string method = context.Request["method"];
            // Get the data
            HttpPostedFile mHttpPostedFile = context.Request.Files["Filedata"];
            if (mHttpPostedFile != null)
            {
                if ("upload_store_photo".Equals(method))
                {
                    UploadPhoto(context, mHttpPostedFile);
                    context.Response.StatusCode = 200;
                }
            }
        }
        catch (Exception ex)
        {
            // If any kind of error occurs return a 500 Internal Server error
            context.Response.StatusCode = 500;
            context.Response.Write(ex.Message);
        }

    }



    /// <summary>
    /// 上传照片
    /// </summary>
    /// <param name="context"></param>
    private void UploadPhoto(HttpContext context, HttpPostedFile mHttpPostedFile)
    {
        int ssid = Convert.ToInt32(context.Request["ssid"]);

        //上传文本到服务器          
        string directory = string.Format("/upfile/storenew/{0}/", ssid);
        if (!Directory.Exists(context.Server.MapPath(directory)))
        {
            //创建目录
            Directory.CreateDirectory(context.Server.MapPath(directory));
        }

        //上传文件到服务器
        string PhotoURL = directory + string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssffff"), System.IO.Path.GetExtension(mHttpPostedFile.FileName));
        mHttpPostedFile.SaveAs(context.Server.MapPath(PhotoURL));

        //更新数据库
        //dalStoresShow.AddStorePhotos(ssid, PhotoURL);
        
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}