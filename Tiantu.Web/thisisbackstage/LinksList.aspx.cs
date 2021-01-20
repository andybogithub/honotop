using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_LinksList : System.Web.UI.Page
{

    Tiantu.DB.DAL.Links dalLinks = new Tiantu.DB.DAL.Links();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 显示列表
        string strWhere = "1=1";
                
        int recordCount = dalLinks.GetRecordCount(strWhere);
        var list = dalLinks.GetList(0,strWhere, "LINKID DESC");
        if (list != null)
        {
            this.RepeaterLink.DataSource = list;
            this.RepeaterLink.DataBind();
        }
        #endregion


    }

  
    protected string GetImg(object img)
    {
        string imgCont = "";
        if (img != null && img.ToString().Length > 0)
        {
            imgCont = string.Format("<img src='{0}' style='width:190px;height:100px;'/>", img.ToString());
        }
        else
        {
            imgCont = "无";
        }

        return imgCont;
    }

 

}