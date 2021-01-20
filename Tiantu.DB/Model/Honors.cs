using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Honors:实体类
	/// </summary>
	[Serializable]
	public partial class Honors
	{	
		public Honors()
        { }
		#region Model
		private int _honorid;
		private string _imgurl;
		private string _smimgurl;
		private int _sortid;


		/// <summary>
		/// 
		/// </summary>
		public int HONORID
        {
            set{_honorid=value;}
            get{return _honorid;}
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
		public int SORTID
        {
            set{_sortid=value;}
            get{return _sortid;}
		}
		#endregion Model

	
	}
}
