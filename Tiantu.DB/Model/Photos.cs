using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Photos:实体类
	/// </summary>
	[Serializable]
	public partial class Photos
	{	
		public Photos()
        { }
		#region Model
		private int _photoid;
		private int _cateid;
		private string _imgurl;
		private string _thumbnail;
		private int _sortid;


		/// <summary>
		/// 
		/// </summary>
		public int PHOTOID
        {
            set{_photoid=value;}
            get{return _photoid;}
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
		public string THUMBNAIL
        {
            set{_thumbnail=value;}
            get{return _thumbnail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SORTID
        {
            set{_sortid=value;}
            get{return _sortid;}
		}
		#endregion Model

	
	}
}
