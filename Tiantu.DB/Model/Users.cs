using System;
namespace Tiantu.DB.Model
{

    [Serializable]
    public partial class Users
    {
        public Users()
        { }


        #region Model
        private int _userid;
        private string _usertel;
        private string _userpass;
        private string _username;
        private string _address;
      
        private string _qq;
        private string _email;
        private string _imgurl;
        private int _points;
        private DateTime _pubdate = DateTime.Now;
        /// <summary>
        /// 会员编号（流水号）
        /// </summary>
        public int USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 登录电话
        /// </summary>
        public string USERTEL
        {
            set { _usertel = value; }
            get { return _usertel; }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string USERPASS
        {
            set { _userpass = value; }
            get { return _userpass; }
        }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string USERNAME
        {
            set { _username = value; }
            get { return _username; }
        }

       
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS
        {
            set { _address = value; }
            get { return _address; }
        }
   
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
     

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime PUBDATE
        {
            set { _pubdate = value; }
            get { return _pubdate; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string IMGURL
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }

      /// <summary>
        /// 
        /// </summary>
        public int POINTS
        {
            set { _points = value; }
            get { return _points; }
        }


        #endregion Model









    }
}

