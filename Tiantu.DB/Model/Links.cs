using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Links:实体类
	/// </summary>
	[Serializable]
	public partial class Links
	{	
		public Links()
        { }
		#region Model
		private int _linkid;
		private string _title;
		private string _title_en;
		private string _linkurl;
		private string _imgurl;
		private string _videourl;


		/// <summary>
		/// 
		/// </summary>
		public int LINKID
        {
            set{_linkid=value;}
            get{return _linkid;}
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
		public string TITLE_EN
        {
            set{_title_en=value;}
            get{return _title_en;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LINKURL
        {
            set{_linkurl=value;}
            get{return _linkurl;}
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
		public string VIDEOURL
        {
            set{_videourl=value;}
            get{return _videourl;}
		}
		#endregion Model

	
	}
}
