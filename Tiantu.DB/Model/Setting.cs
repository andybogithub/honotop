using System;

namespace Tiantu.DB.Model
{
	/// <summary>
	/// Setting:实体类
	/// </summary>
	[Serializable]
	public partial class Setting
	{	
		public Setting()
        { }
        #region Model
        private int _id;
        private string _setkey;
		private string _setvalue;

        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SETKEY
        {
            set{_setkey=value;}
            get{return _setkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SETVALUE
        {
            set{_setvalue=value;}
            get{return _setvalue;}
		}
		#endregion Model

	
	}
}
