using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_PhotosList : System.Web.UI.Page
{

    Tiantu.DB.DAL.Photos dalPhotos = new Tiantu.DB.DAL.Photos();

    public int cateid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.cateid = SL.GetQueryIntValue("cateid");

        string strMenu = "";
        //string[] strCatename = { "全部", "项目定制仓", "电商仓", "温控仓", "进货采购", "销售", "库存", "产品1", "产品2", "产品3" };
        //int[] intCateid = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        string[] strCatename = { "全部", "项目定制仓", "电商仓", "温控仓", "产品1", "产品2", "产品3" };
        int[] intCateid = { 0, 1, 2, 3, 7, 8, 9 };
        for (int i = 0; i < strCatename.Length; i++)
        {
            strMenu += string.Format("<a href = 'PhotosList.aspx?cateid={0}' class='btn {2}'>{1}</a>", intCateid[i], strCatename[i],
                this.cateid == intCateid[i] ? "active" : "");
        }
        this.lblMenu.Text = strMenu;


        #region 显示列表
        string strWhere = "1=1";
        string strParams = "";
        if (this.cateid > 0)
        {
            strWhere += " AND CATEID=" + this.cateid;
            strParams += "&cateid=" + cateid;
        }

        #region 分页
        int pageIndex = SL.GetQueryIntValue("pageid");
        int recordCount = dalPhotos.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;
        string strPager = SL.GetPagerNavigator(pageIndex, recordCount, strParams, 3, "/webadmin/PhotosList.aspx", out startIndex, out endIndex);
        this.lblPagination.Text = strPager;
        #endregion

        var list = dalPhotos.GetListByPage(strWhere, "CATEID,SORTID DESC", startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterStores.DataSource = list;
            this.RepeaterStores.DataBind();
        }
        #endregion


    }

    protected void RepeaterStores_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ("delete".Equals(e.CommandName))
        {
            int relid = Convert.ToInt32(e.CommandArgument);
            Tiantu.DB.Model.Photos model = dalPhotos.GetModel(relid);
            if (model != null)
            {
                //删除图片文件
                SL.TryDeleteImage(model.IMGURL);
            }
            dalPhotos.Delete(relid);
            Response.Redirect("PhotosList.aspx?cateid=" + model.CATEID);
        }
    }


    protected string GetImg(object img)
    {
        string imgCont = "";
        if (img != null && img.ToString().Length > 0)
        {
            imgCont = string.Format("<img src='{0}' style='width:60px;height:60px;'/>", img.ToString());
        }
        else
        {
            imgCont = "无";
        }

        return imgCont;
    }

    protected string GetCateName(object cateid)
    {
        string cateName = "";

        if (cateid != null)
        {
            int caid = Convert.ToInt32(cateid);

            if (caid == 1)
            {
                cateName = "项目定制仓";
            }
            else if (caid == 2)
            {
                cateName = "电商仓";
            }
            else if (caid == 3)
            {
                cateName = "温控仓";
            }
            else if (caid == 4)
            {
                cateName = "产品";
            }
            else if (caid == 5)
            {
                cateName = "进货采购";
            }
            else if (caid == 6)
            {
                cateName = "销售";
            }
            else if (caid == 7)
            {
                cateName = "库存";
            }
        }
        return cateName;

    }


}