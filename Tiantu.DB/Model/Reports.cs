using System;

namespace Tiantu.DB.Model
{
    /// <summary>
    /// Reports:实体类
    /// </summary>
    [Serializable]
    public partial class Reports
    {
        public Reports()
        { }
        #region Model
        private int _reportid;
        private int _cateid;
        private string _title;
        private string _pdfurl;
        private string _pdfurl_en;
        private string _imgurl;
        private string _imgurl_en;
        private DateTime _pubdate;
        private int _sortid;


        /// <summary>
        /// 
        /// </summary>
        public int REPORTID
        {
            set { _reportid = value; }
            get { return _reportid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CATEID
        {
            set { _cateid = value; }
            get { return _cateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TITLE
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PDFURL
        {
            set { _pdfurl = value; }
            get { return _pdfurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PDFURL_EN
        {
            set { _pdfurl_en = value; }
            get { return _pdfurl_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IMGURL
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IMGURL_EN
        {
            set { _imgurl_en = value; }
            get { return _imgurl_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PUBDATE
        {
            set { _pubdate = value; }
            get { return _pubdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SORTID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        #endregion Model


    }


   

}
