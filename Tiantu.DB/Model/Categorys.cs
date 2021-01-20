using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Categorys:实体类
	/// </summary>
	[Serializable]
	public partial class Categorys
	{	
		public Categorys()
        { }
		#region Model
		private int _cateid;
		private int _clzid;
		private string _catename;
		private int _parentid;
		private int _sortid;
		private string _notes;


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
		public int CLZID
        {
            set{_clzid=value;}
            get{return _clzid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CATENAME
        {
            set{_catename=value;}
            get{return _catename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PARENTID
        {
            set{_parentid=value;}
            get{return _parentid;}
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
		public string NOTES
        {
            set{_notes=value;}
            get{return _notes;}
		}
		#endregion Model

	
	}
}
