using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Cases:实体类
	/// </summary>
	[Serializable]
	public partial class Cases
	{	
		public Cases()
        { }
		#region Model
		private int _caseid;
		private string _notes;
		private string _notes_en;
		private string _imgurl;
		private int _sortid;


		/// <summary>
		/// 
		/// </summary>
		public int CASEID
        {
            set{_caseid=value;}
            get{return _caseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NOTES
        {
            set{_notes=value;}
            get{return _notes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NOTES_EN
        {
            set{_notes_en=value;}
            get{return _notes_en;}
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
		public int SORTID
        {
            set{_sortid=value;}
            get{return _sortid;}
		}
		#endregion Model

	
	}
}
