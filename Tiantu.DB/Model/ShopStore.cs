using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiantu.DB.Model
{
    /// <summary>
    /// 兑换商品分类
    /// </summary>
    public class ShopCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ClazzId { get; set; }
    }

    public class ShopCart
    {
        public int TempOrderId { get; set; }
        public int UserId { get; set; }
        public int EmplId { get; set; }
        public int ProductId { get; set; }
        public int AddressId { get; set; }
        public bool IsInsurance { get; set; }
        public int OrderQty { get; set; }
        public int OrderPoint { get; set; }
        public DateTime OrderDateTime { get; set; }

    }
   

    /// <summary>
    /// 兑换商品
    /// </summary>
    public class ShopProduct
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品子标题
        /// </summary>
        public string SubName { get; set; }

        /// <summary>
        /// 产品系列编号（1：积分商品，2：夺宝商品）
        /// </summary>
        public int ClazzId { get; set; }

        /// <summary>
        /// 产品分类编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 兑换积分
        /// </summary>
        public int Point { get; set; }
        /// <summary>
        /// 保险价格
        /// </summary>
        public decimal InsurancePrice { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 库存状态
        /// </summary>
        public string QtyStatus { get; set; }
        /// <summary>
        /// 物流方式
        /// </summary>
        public string Shipment { get; set; }
        /// <summary>
        /// 产品详细
        /// </summary>
        public string ProductDetails { get; set; }
        /// <summary>
        /// 推荐产品
        /// </summary>
        public bool TJTag { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ImageIcon { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime { get; set; }

        /// <summary>
        /// 产品状态（线上与下架）
        /// </summary>
        public bool IsOnLine { get; set; }


        /// <summary>
        /// 秒杀商品标记
        /// </summary>
        public bool SeckillTag { get; set; }
        /// <summary>
        /// 热门商品标记
        /// </summary>
        public bool HotTag { get; set; }
        /// <summary>
        /// 首页显示标记
        /// </summary>
        public bool ShowHomeTag { get; set; }

 


        /// <summary>
        /// 秒杀结束时间
        /// </summary>
        public DateTime SeckillEndTime { get; set; }

        /// <summary>
        /// 秒杀积分
        /// </summary>
        public int SeckillPoint { get; set; }

        /// <summary>
        /// 夺宝需要人数
        /// </summary>
        public int DBNeedTotal { get; set; }

 
        /// <summary>
        /// 每个夺宝项目最多参与人次
        /// </summary>
        public int DBAllowJoin { get; set; }

        /// <summary>
        /// 开奖状态（0：未达到上限，1：已达上限，开奖倒计时，2：已开奖）
        /// </summary>
        public int DubaoStatus { get; set; }

        /// <summary>
        /// 开奖号码
        /// </summary>
        public int DubaoWinNo { get; set; }

        /// <summary>
        /// 开奖时间
        /// </summary>
        public DateTime DubaoWinDate { get; set; }
    }



    /// <summary>
    /// 用户地址
    /// </summary>
    public class ShopUserAddress
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int EmplId { get; set; }
        public string City { get; set; }
        public string Addrs { get; set; }
        public string ZipCode { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        /// <summary>
        /// 默认地址
        /// </summary>
        public bool IsDefaultAddress { get; set; }
    }



    /// <summary>
    /// 兑换订单
    /// </summary>
    public class ShopOrder
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int EmplId { get; set; }
        public string Provice { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Addrs { get; set; }
        public string ZipCode { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderTime { get; set; }
    }


    /// <summary>
    /// 新闻
    /// </summary>
    public class ShopNews
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
        public int ClazzId { get; set; }
        public DateTime PubTime { get; set; }
    }


    public class ShopAbouts
    {
        public int AboutId { get; set; }
        public string  Title { get; set; }
        public string Details { get; set; }
    }


    public class ShopGames
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public int SortId { get; set; }
    }



	[Serializable]
    public partial class UserPoints
    {
        public UserPoints()
        { }
        #region Model
        private int _pointid;
        private int _modelno;
        private int _userid;
        private int _emplid;
        private int _points;
        private int _opertype;
        private int _operid;
        private DateTime _pubdate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int POINTID
        {
            set { _pointid = value; }
            get { return _pointid; }
        }
        /// <summary>
        /// 操作模块
        /// </summary>
        public int MODELNO
        {
            set { _modelno = value; }
            get { return _modelno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int EMPLID
        {
            set { _emplid = value; }
            get { return _emplid; }
        }
        /// <summary>
        /// 积分值
        /// </summary>
        public int POINTS
        {
            set { _points = value; }
            get { return _points; }
        }
        /// <summary>
        /// 1 加 2 减
        /// </summary>
        public int OPERTYPE
        {
            set { _opertype = value; }
            get { return _opertype; }
        }
        /// <summary>
        /// 关联ID
        /// </summary>
        public int OPERID
        {
            set { _operid = value; }
            get { return _operid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PUBDATE
        {
            set { _pubdate = value; }
            get { return _pubdate; }
        }
        #endregion Model




    }
}
