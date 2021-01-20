using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Clazz:实体类
	/// </summary>
	[Serializable]
	public partial class Clazz
	{	
		public Clazz()
        { }
		#region Model
		private int _clzid;
		private string _clzname;
		private Boolean _istag;
		private string _notes;


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
		public string CLZNAME
        {
            set{_clzname=value;}
            get{return _clzname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Boolean ISTAG
        {
            set{_istag=value;}
            get{return _istag;}
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
