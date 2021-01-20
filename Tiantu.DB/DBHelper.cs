
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tinatu.DB
{
    public partial class DBHelper
    {

        private static Tiantu.DB.DAL.Categorys dalCategorys = new Tiantu.DB.DAL.Categorys();
        private static Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
        private static Tiantu.DB.DAL.AboutUs dalAboutUs = new Tiantu.DB.DAL.AboutUs();
        private static Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();
        public static Tiantu.DB.DAL.Users dalUsers = new Tiantu.DB.DAL.Users();

        public static int WEBID_SHOP = 3;

        public static IEnumerable<Tiantu.DB.Model.Categorys> GetReportCateList()
        {
            var list = dalCategorys.GetList(0, "CLZID=4", "SORTID DESC, CATEID DESC");
            return list;
        }


        public static Tiantu.DB.Model.AboutUs GetAboutUs(int id)
        {
            Tiantu.DB.Model.AboutUs model = dalAboutUs.GetModel(id);
            model = (model == null ? new Tiantu.DB.Model.AboutUs() : model);
            return model;
        }

        public static IEnumerable<Tiantu.DB.Model.News> GetTopNews()
        {
            var list = dalNews.GetList(0, "ISTOP=1 AND CATEID<>4 ", "SORTID DESC, CATEID DESC");
            return list;
        }

        public static string GetPointNameByModeno(int modeno)
        {
            string pointname = "";
            if (modeno == 1)
            {
                pointname = "用户登录";
            }
            else if (modeno == 2)
            {
                pointname = "发布现货";
            }
            else if (modeno == 3)
            {
                pointname = "发布求购";
            }
            else if (modeno == 4)
            {
                pointname = "发布加工";
            }
            else if (modeno == 5)
            {
                pointname = "询价";
            }
            else if (modeno == 6)
            {
                pointname = "报价";
            }
            else if (modeno == 7)
            {
                pointname = "发布产品";
            }
            else if (modeno == 8)
            {
                pointname = "发布新闻";
            }
            else if (modeno == 9)
            {
                pointname = "发布招聘";
            }
            else if (modeno == 10)
            {
                pointname = "求职";
            }
            else if (modeno == 101)
            {
                pointname = "签到";
            }
            else if (modeno == 102)
            {
                pointname = "兑换商品";
            }
            else if (modeno == 103)
            {
                pointname = "夺宝";
            }
            else if (modeno == 104)
            {
                pointname = "游戏";
            }
            return pointname;
        }



    }
}
