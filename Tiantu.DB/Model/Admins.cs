using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Admins:实体类
	/// </summary>
	[Serializable]
	public partial class Admins
	{	
		public Admins()
        { }
		#region Model
		private int _adminid;
		private string _adminname;
		private string _adminpass;
		private string _realname;
		private DateTime _lastlogintime;
		private string _lastloginip;


		/// <summary>
		/// 
		/// </summary>
		public int ADMINID
        {
            set{_adminid=value;}
            get{return _adminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADMINNAME
        {
            set{_adminname=value;}
            get{return _adminname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADMINPASS
        {
            set{_adminpass=value;}
            get{return _adminpass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REALNAME
        {
            set{_realname=value;}
            get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LASTLOGINTIME
        {
            set{_lastlogintime=value;}
            get{return _lastlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LASTLOGINIP
        {
            set{_lastloginip=value;}
            get{return _lastloginip;}
		}
		#endregion Model

	
	}
}
