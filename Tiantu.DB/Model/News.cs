using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// News:实体类
	/// </summary>
	[Serializable]
	public partial class News
	{	
		public News()
        { }
		#region Model
		private int _newsid;
		private int _clzid;
		private int _cateid;
		private string _imgurl;
		private string _smimgurl;
		private string _title;
		private string _subtitle;
		private string _contents;
		private string _title_en;
		private string _subtitle_en;
		private string _contents_en;
		private string _pdfurl;
		private string _pdfurl_en;
		private Boolean _istop;
		private int _sortid;
		private DateTime _pubdate;


		/// <summary>
		/// 
		/// </summary>
		public int NEWSID
        {
            set{_newsid=value;}
            get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CLZID
        {
            set{_clzid=value;}
            get{return _clzid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CATEID
        {
            set{_cateid=value;}
            get{return _cateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IMGURL
        {
            set{_imgurl=value;}
            get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMIMGURL
        {
            set{_smimgurl=value;}
            get{return _smimgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TITLE
        {
            set{_title=value;}
            get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SUBTITLE
        {
            set{_subtitle=value;}
            get{return _subtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CONTENTS
        {
            set{_contents=value;}
            get{return _contents;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TITLE_EN
        {
            set{_title_en=value;}
            get{return _title_en;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SUBTITLE_EN
        {
            set{_subtitle_en=value;}
            get{return _subtitle_en;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CONTENTS_EN
        {
            set{_contents_en=value;}
            get{return _contents_en;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PDFURL
        {
            set{_pdfurl=value;}
            get{return _pdfurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PDFURL_EN
        {
            set{_pdfurl_en=value;}
            get{return _pdfurl_en;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Boolean ISTOP
        {
            set{_istop=value;}
            get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SORTID
        {
            set{_sortid=value;}
            get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PUBDATE
        {
            set{_pubdate=value;}
            get{return _pubdate;}
		}
		#endregion Model

	
	}
}
