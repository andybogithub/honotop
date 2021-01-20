using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiantu.DB.Model
{
  

    [Serializable]
    public partial class LoginLog
    {
        public LoginLog()
        { }
        #region Model
        private int _logid;
        private string _loginname;
        private string _loginip;
        private DateTime _logintime;


        /// <summary>
        /// 
        /// </summary>
        public int LogId
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LoginIp
        {
            set { _loginip = value; }
            get { return _loginip; }
        }


        /// <summary>
        /// 
        /// </summary>
        public DateTime LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        #endregion Model


    }


}
