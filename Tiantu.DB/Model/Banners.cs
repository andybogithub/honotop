using System;

namespace Tiantu.DB.Model
{

    [Serializable]
	public partial class Banners
	{
		public Banners()
		{}
        #region Model
        private int _bnid;
        private string _title;
        private string _linkurl;
        private string _mobile_linkurl;
        private string _imgurl;
        private int _sortid;
        private string _type;
        /// <summary>
        /// 
        /// </summary>
        public int BNID
        {
            set { _bnid = value; }
            get { return _bnid; }
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
        /// PC版链接地址
        /// </summary>
        public string LINKURL
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }

        /// <summary>
        /// 手机版链接地址
        /// </summary>
        public string MOBILE_LINKURL
        {
            set { _mobile_linkurl = value; }
            get { return _mobile_linkurl; }
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
        public int SORTID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TYPE
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model


        /// <summary>
        /// 网站编号 
        /// </summary>
        public int WEBID { get; set; }

    }
}

