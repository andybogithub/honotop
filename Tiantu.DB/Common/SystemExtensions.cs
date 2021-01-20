namespace System
{
    public static class SystemExtensions
    {
        #region 扩展

        #region 字符串扩展

        public static int ToInt32(this string str)
        {
            int ret = -1;
            int.TryParse(str, out ret);
            return ret;
        }

        public static double ToDouble(this string str)
        {
            double ret = -1;
            double.TryParse(str, out ret);
            return ret;
        }

        public static decimal ToDecimal(this string str)
        {
            decimal ret = -1;
            decimal.TryParse(str, out ret);
            return ret;
        }

        public static short ToShort(this string str)
        {
            short ret = -1;
            short.TryParse(str, out ret);
            return ret;
        }

        public static bool ToBool(this string str)
        {
            bool ret = false;
            bool.TryParse(str, out ret);
            return ret;
        }

        public static DateTime ToDateTime(this string str)
        {
            return Convert.ToDateTime(str);
        }

        public static string IsEmpty(this string value, string defaultvalue)
        {
            value = string.IsNullOrWhiteSpace(value) ? defaultvalue : value;
            return value;
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        public static string Format(this string value, object arg0)
        {
            return string.Format(value, arg0);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        public static string Format(this string value, object arg0, object arg1)
        {
            return string.Format(value, arg0, arg1);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        public static string Format(this string value, object arg0, object arg1, object arg2)
        {
            return string.Format(value, arg0, arg1, arg2);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        public static string ToFormat(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        #endregion 字符串扩展

        #region 日期扩展

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringA(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringB(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// yyyy年MM月dd日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringC(this DateTime dt)
        {
            return dt.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// yyyy.MM.dd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringD(this DateTime dt)
        {
            return dt.ToString("yyyy.MM.dd");
        }

        /// <summary>
        /// MM.dd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringE(this DateTime dt)
        {
            return dt.ToString("MM.dd");
        }

        /// <summary>
        /// yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringF(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm");
        }

        #endregion 日期扩展

        #region 数字扩展

        /// <summary>
        /// ,###,##0.######
        /// </summary>
        public static string ToStringA(this decimal dt)
        {
            return dt.ToString(",###,##0.######");
        }

        /// <summary>
        /// ,###,##0.##
        /// </summary>
        public static string ToStringB(this decimal dt)
        {
            return dt.ToString(",###,##0.##");
        }

        /// <summary>
        /// 省略小数位
        /// </summary>
        public static string ToStringC(this decimal dt)
        {
            return Math.Ceiling(dt).ToString();
        }

        #endregion 数字扩展

        #endregion 扩展
    }
}