using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// AboutUs:实体类
	/// </summary>
	[Serializable]
	public partial class AboutUs
	{	
		public AboutUs()
        { }
		#region Model
		private int _aboutid;
		private string _title;
		private string _contents;
		private string _title_en;
		private string _contents_en;
		private int _sortid;


		/// <summary>
		/// 
		/// </summary>
		public int ABOUTID
        {
            set{_aboutid=value;}
            get{return _aboutid;}
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
		public string CONTENTS_EN
        {
            set{_contents_en=value;}
            get{return _contents_en;}
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
