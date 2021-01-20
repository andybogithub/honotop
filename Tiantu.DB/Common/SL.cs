using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Tiantu.DB.Common
{
    /// 图片大小变形方式
    /// </summary>
    public enum EUploadMode
    {
        /// <summary>
        /// 指定高宽缩放（可能变形）
        /// </summary>
        HW,
        /// <summary>
        /// 指定宽，高按比例
        /// </summary>
        W,
        /// <summary>
        //指定高，宽按比例
        /// </summary>
        H,
        /// <summary>
        /// 指定高宽裁减（不变形）
        /// </summary>
        CUT
    }


    /// <summary>
    /// SL 方法类
    /// </summary>
    public partial class SL
    {
        /// <summary>
        /// 网站域名： unkonw.com
        /// </summary>
        public static string Webdomain = "unkonw.com";


        #region 浏览器判断
        /// <summary>
        /// 是否为移动端
        /// </summary>
        /// <returns></returns>
        public static bool IsMobile()
        {
            string[] mobileAgents = { "iphone", "android", "phone", "mobile", "wap", "netfront", "java", "opera mobi", "opera mini", "ucweb", "windows ce", "symbian", "series", "webos", "sony", "blackberry", "dopod", "nokia", "samsung", "palmsource", "xda", "pieplus", "meizu", "midp", "cldc", "motorola", "foma", "docomo", "up.browser", "up.link", "blazer", "helio", "hosin", "huawei", "novarra", "coolpad", "webos", "techfaith", "palmsource", "alcatel", "amoi", "ktouch", "nexian", "ericsson", "philips", "sagem", "wellcom", "bunjalloo", "maui", "smartphone", "iemobile", "spice", "bird", "zte-", "longcos", "pantech", "gionee", "portalmmm", "jig browser", "hiptop", "benq", "haier", "^lct", "320x320", "240x320", "176x220", "w3c ", "acs-", "alav", "alca", "amoi", "audi", "avan", "benq", "bird", "blac", "blaz", "brew", "cell", "cldc", "cmd-", "dang", "doco", "eric", "hipt", "inno", "ipaq", "java", "jigs", "kddi", "keji", "leno", "lg-c", "lg-d", "lg-g", "lge-", "maui", "maxo", "midp", "mits", "mmef", "mobi", "mot-", "moto", "mwbp", "nec-", "newt", "noki", "oper", "palm", "pana", "pant", "phil", "play", "port", "prox", "qwap", "sage", "sams", "sany", "sch-", "sec-", "send", "seri", "sgh-", "shar", "sie-", "siem", "smal", "smar", "sony", "sph-", "symb", "t-mo", "teli", "tim-", "tosh", "tsm-", "upg1", "upsi", "vk-v", "voda", "wap-", "wapa", "wapi", "wapp", "wapr", "webc", "winw", "winw", "xda", "xda-", "Googlebot-Mobile" };
            bool isMoblie = false;
            if (System.Web.HttpContext.Current.Request.UserAgent.ToString().ToLower() != null)
            {
                for (int i = 0; i < mobileAgents.Length; i++)
                {
                    if (System.Web.HttpContext.Current.Request.UserAgent.ToString().ToLower().IndexOf(mobileAgents[i]) >= 0)
                    {
                        isMoblie = true;
                        break;
                    }
                }
            }
            if (isMoblie)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为PC机
        /// </summary>
        public static bool IsCompany()
        {
            string uAgent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];


            bool bIsPC = true;
            string osPat = "mozilla|m3gate|winwap|openwave|Windows NT|Windows 3.1|95|Blackcomb|98|ME|X Window|Longhorn|ubuntu|AIX|Linux|AmigaOS|BEOS|HP-UX|OpenBSD|FreeBSD|NetBSD|OS/2|OSF1|SUN";
            if (string.IsNullOrEmpty(uAgent)) uAgent = "";
            Regex reg = new Regex(osPat);

            if (reg.IsMatch(uAgent))
            {
                osPat = "MI-ONE|juc|series|kjava|berry|mobile|htc|android|symbian|mtk|brew|Mobile|htc|Android|Symbian|CE|MTK|Brew|iPhone|MeeGo|Bada|Berry|Plam|Kjava|Series|JUC";
                Regex reg1 = new Regex(osPat);

                if (reg1.IsMatch(uAgent))
                {
                    bIsPC = false;
                }
            }
            else
            {
                bIsPC = false;
            }
            return bIsPC;
        }


        ///<summary>
        /// 根据 Agent 判断是否是智能手机
        ///</summary>
        ///<returns></returns>
        public static bool IsPC()
        {
            bool flag = false;

            string agent = HttpContext.Current.Request.UserAgent;
            string[] keywords = { "Android", "iPhone", "iPod", "iPad", "Windows Phone", "MQQBrowser" };

            //排除 Windows 桌面系统
            if (!agent.Contains("Windows NT") || (agent.Contains("Windows NT") && agent.Contains("compatible; MSIE 9.0;")))
            {
                //排除 苹果桌面系统
                if (!agent.Contains("Windows NT") && !agent.Contains("Macintosh"))
                {
                    foreach (string item in keywords)
                    {
                        if (agent.Contains(item))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }

            return !flag;
        }




        /// <summary>
        /// 判断是否为微信浏览器
        /// </summary>
        /// <returns></returns>
        public static bool IsWXBrowser()
        {
            string szBrowser = "MicroMessenger".ToLower();
            string strAgent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToLower();
            bool bIsPC = Regex.IsMatch(strAgent, szBrowser);
            return bIsPC;
        }
        #endregion


        #region 拼音
        #region === 第一种方法获首字母 ===

        /// <summary>
        /// 获首字母
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetPYChar(string c)
        {
            string result = GetPinyin(c);
            return string.IsNullOrEmpty(result) ? "" : result.Substring(0, 1);
        }
        #endregion


        #region === 第二种方法：获取全拼 ===

        private static Hashtable GetHashtable()
        {
            Hashtable _pinyinHash = new Hashtable();
            _pinyinHash.Add(-20319, "a");
            _pinyinHash.Add(-20317, "ai"); _pinyinHash.Add(-20304, "an"); _pinyinHash.Add(-20295, "ang");
            _pinyinHash.Add(-20292, "ao"); _pinyinHash.Add(-20283, "ba"); _pinyinHash.Add(-20265, "bai");
            _pinyinHash.Add(-20257, "ban"); _pinyinHash.Add(-20242, "bang"); _pinyinHash.Add(-20230, "bao");
            _pinyinHash.Add(-20051, "bei"); _pinyinHash.Add(-20036, "ben"); _pinyinHash.Add(-20032, "beng");
            _pinyinHash.Add(-20026, "bi"); _pinyinHash.Add(-20002, "bian"); _pinyinHash.Add(-19990, "biao");
            _pinyinHash.Add(-19986, "bie"); _pinyinHash.Add(-19982, "bin"); _pinyinHash.Add(-19976, "bing");
            _pinyinHash.Add(-19805, "bo"); _pinyinHash.Add(-19784, "bu"); _pinyinHash.Add(-19775, "ca");
            _pinyinHash.Add(-19774, "cai"); _pinyinHash.Add(-19763, "can"); _pinyinHash.Add(-19756, "cang");
            _pinyinHash.Add(-19751, "cao"); _pinyinHash.Add(-19746, "ce"); _pinyinHash.Add(-19741, "ceng");
            _pinyinHash.Add(-19739, "cha"); _pinyinHash.Add(-19728, "chai"); _pinyinHash.Add(-19725, "chan");
            _pinyinHash.Add(-19715, "chang"); _pinyinHash.Add(-19540, "chao"); _pinyinHash.Add(-19531, "che");
            _pinyinHash.Add(-19525, "chen"); _pinyinHash.Add(-19515, "cheng"); _pinyinHash.Add(-19500, "chi");
            _pinyinHash.Add(-19484, "chong"); _pinyinHash.Add(-19479, "chou"); _pinyinHash.Add(-19467, "chu");
            _pinyinHash.Add(-19289, "chuai"); _pinyinHash.Add(-19288, "chuan"); _pinyinHash.Add(-19281, "chuang");
            _pinyinHash.Add(-19275, "chui"); _pinyinHash.Add(-19270, "chun"); _pinyinHash.Add(-19263, "chuo");
            _pinyinHash.Add(-19261, "ci"); _pinyinHash.Add(-19249, "cong"); _pinyinHash.Add(-19243, "cou");
            _pinyinHash.Add(-19242, "cu"); _pinyinHash.Add(-19238, "cuan"); _pinyinHash.Add(-19235, "cui");
            _pinyinHash.Add(-19227, "cun"); _pinyinHash.Add(-19224, "cuo"); _pinyinHash.Add(-19218, "da");
            _pinyinHash.Add(-19212, "dai"); _pinyinHash.Add(-19038, "dan"); _pinyinHash.Add(-19023, "dang");
            _pinyinHash.Add(-19018, "dao"); _pinyinHash.Add(-19006, "de"); _pinyinHash.Add(-19003, "deng");
            _pinyinHash.Add(-18996, "di"); _pinyinHash.Add(-18977, "dian"); _pinyinHash.Add(-18961, "diao");
            _pinyinHash.Add(-18952, "die"); _pinyinHash.Add(-18783, "ding"); _pinyinHash.Add(-18774, "diu");
            _pinyinHash.Add(-18773, "dong"); _pinyinHash.Add(-18763, "dou"); _pinyinHash.Add(-18756, "du");
            _pinyinHash.Add(-18741, "duan"); _pinyinHash.Add(-18735, "dui"); _pinyinHash.Add(-18731, "dun");
            _pinyinHash.Add(-18722, "duo"); _pinyinHash.Add(-18710, "e"); _pinyinHash.Add(-18697, "en");
            _pinyinHash.Add(-18696, "er"); _pinyinHash.Add(-18526, "fa"); _pinyinHash.Add(-18518, "fan");
            _pinyinHash.Add(-18501, "fang"); _pinyinHash.Add(-18490, "fei"); _pinyinHash.Add(-18478, "fen");
            _pinyinHash.Add(-18463, "feng"); _pinyinHash.Add(-18448, "fo"); _pinyinHash.Add(-18447, "fou");
            _pinyinHash.Add(-18446, "fu"); _pinyinHash.Add(-18239, "ga"); _pinyinHash.Add(-18237, "gai");
            _pinyinHash.Add(-18231, "gan"); _pinyinHash.Add(-18220, "gang"); _pinyinHash.Add(-18211, "gao");
            _pinyinHash.Add(-18201, "ge"); _pinyinHash.Add(-18184, "gei"); _pinyinHash.Add(-18183, "gen");
            _pinyinHash.Add(-18181, "geng"); _pinyinHash.Add(-18012, "gong"); _pinyinHash.Add(-17997, "gou");
            _pinyinHash.Add(-17988, "gu"); _pinyinHash.Add(-17970, "gua"); _pinyinHash.Add(-17964, "guai");
            _pinyinHash.Add(-17961, "guan"); _pinyinHash.Add(-17950, "guang"); _pinyinHash.Add(-17947, "gui");
            _pinyinHash.Add(-17931, "gun"); _pinyinHash.Add(-17928, "guo"); _pinyinHash.Add(-17922, "ha");
            _pinyinHash.Add(-17759, "hai"); _pinyinHash.Add(-17752, "han"); _pinyinHash.Add(-17733, "hang");
            _pinyinHash.Add(-17730, "hao"); _pinyinHash.Add(-17721, "he"); _pinyinHash.Add(-17703, "hei");
            _pinyinHash.Add(-17701, "hen"); _pinyinHash.Add(-17697, "heng"); _pinyinHash.Add(-17692, "hong");
            _pinyinHash.Add(-17683, "hou"); _pinyinHash.Add(-17676, "hu"); _pinyinHash.Add(-17496, "hua");
            _pinyinHash.Add(-17487, "huai"); _pinyinHash.Add(-17482, "huan"); _pinyinHash.Add(-17468, "huang");
            _pinyinHash.Add(-17454, "hui"); _pinyinHash.Add(-17433, "hun"); _pinyinHash.Add(-17427, "huo");
            _pinyinHash.Add(-17417, "ji"); _pinyinHash.Add(-17202, "jia"); _pinyinHash.Add(-17185, "jian");
            _pinyinHash.Add(-16983, "jiang"); _pinyinHash.Add(-16970, "jiao"); _pinyinHash.Add(-16942, "jie");
            _pinyinHash.Add(-16915, "jin"); _pinyinHash.Add(-16733, "jing"); _pinyinHash.Add(-16708, "jiong");
            _pinyinHash.Add(-16706, "jiu"); _pinyinHash.Add(-16689, "ju"); _pinyinHash.Add(-16664, "juan");
            _pinyinHash.Add(-16657, "jue"); _pinyinHash.Add(-16647, "jun"); _pinyinHash.Add(-16474, "ka");
            _pinyinHash.Add(-16470, "kai"); _pinyinHash.Add(-16465, "kan"); _pinyinHash.Add(-16459, "kang");
            _pinyinHash.Add(-16452, "kao"); _pinyinHash.Add(-16448, "ke"); _pinyinHash.Add(-16433, "ken");
            _pinyinHash.Add(-16429, "keng"); _pinyinHash.Add(-16427, "kong"); _pinyinHash.Add(-16423, "kou");
            _pinyinHash.Add(-16419, "ku"); _pinyinHash.Add(-16412, "kua"); _pinyinHash.Add(-16407, "kuai");
            _pinyinHash.Add(-16403, "kuan"); _pinyinHash.Add(-16401, "kuang"); _pinyinHash.Add(-16393, "kui");
            _pinyinHash.Add(-16220, "kun"); _pinyinHash.Add(-16216, "kuo"); _pinyinHash.Add(-16212, "la");
            _pinyinHash.Add(-16205, "lai"); _pinyinHash.Add(-16202, "lan"); _pinyinHash.Add(-16187, "lang");
            _pinyinHash.Add(-16180, "lao"); _pinyinHash.Add(-16171, "le"); _pinyinHash.Add(-16169, "lei");
            _pinyinHash.Add(-16158, "leng"); _pinyinHash.Add(-16155, "li"); _pinyinHash.Add(-15959, "lia");
            _pinyinHash.Add(-15958, "lian"); _pinyinHash.Add(-15944, "liang"); _pinyinHash.Add(-15933, "liao");
            _pinyinHash.Add(-15920, "lie"); _pinyinHash.Add(-15915, "lin"); _pinyinHash.Add(-15903, "ling");
            _pinyinHash.Add(-15889, "liu"); _pinyinHash.Add(-15878, "long"); _pinyinHash.Add(-15707, "lou");
            _pinyinHash.Add(-15701, "lu"); _pinyinHash.Add(-15681, "lv"); _pinyinHash.Add(-15667, "luan");
            _pinyinHash.Add(-15661, "lue"); _pinyinHash.Add(-15659, "lun"); _pinyinHash.Add(-15652, "luo");
            _pinyinHash.Add(-15640, "ma"); _pinyinHash.Add(-15631, "mai"); _pinyinHash.Add(-15625, "man");
            _pinyinHash.Add(-15454, "mang"); _pinyinHash.Add(-15448, "mao"); _pinyinHash.Add(-15436, "me");
            _pinyinHash.Add(-15435, "mei"); _pinyinHash.Add(-15419, "men"); _pinyinHash.Add(-15416, "meng");
            _pinyinHash.Add(-15408, "mi"); _pinyinHash.Add(-15394, "mian"); _pinyinHash.Add(-15385, "miao");
            _pinyinHash.Add(-15377, "mie"); _pinyinHash.Add(-15375, "min"); _pinyinHash.Add(-15369, "ming");
            _pinyinHash.Add(-15363, "miu"); _pinyinHash.Add(-15362, "mo"); _pinyinHash.Add(-15183, "mou");
            _pinyinHash.Add(-15180, "mu"); _pinyinHash.Add(-15165, "na"); _pinyinHash.Add(-15158, "nai");
            _pinyinHash.Add(-15153, "nan"); _pinyinHash.Add(-15150, "nang"); _pinyinHash.Add(-15149, "nao");
            _pinyinHash.Add(-15144, "ne"); _pinyinHash.Add(-15143, "nei"); _pinyinHash.Add(-15141, "nen");
            _pinyinHash.Add(-15140, "neng"); _pinyinHash.Add(-15139, "ni"); _pinyinHash.Add(-15128, "nian");
            _pinyinHash.Add(-15121, "niang"); _pinyinHash.Add(-15119, "niao"); _pinyinHash.Add(-15117, "nie");
            _pinyinHash.Add(-15110, "nin"); _pinyinHash.Add(-15109, "ning"); _pinyinHash.Add(-14941, "niu");
            _pinyinHash.Add(-14937, "nong"); _pinyinHash.Add(-14933, "nu"); _pinyinHash.Add(-14930, "nv");
            _pinyinHash.Add(-14929, "nuan"); _pinyinHash.Add(-14928, "nue"); _pinyinHash.Add(-14926, "nuo");
            _pinyinHash.Add(-14922, "o"); _pinyinHash.Add(-14921, "ou"); _pinyinHash.Add(-14914, "pa");
            _pinyinHash.Add(-14908, "pai"); _pinyinHash.Add(-14902, "pan"); _pinyinHash.Add(-14894, "pang");
            _pinyinHash.Add(-14889, "pao"); _pinyinHash.Add(-14882, "pei"); _pinyinHash.Add(-14873, "pen");
            _pinyinHash.Add(-14871, "peng"); _pinyinHash.Add(-14857, "pi"); _pinyinHash.Add(-14678, "pian");
            _pinyinHash.Add(-14674, "piao"); _pinyinHash.Add(-14670, "pie"); _pinyinHash.Add(-14668, "pin");
            _pinyinHash.Add(-14663, "ping"); _pinyinHash.Add(-14654, "po"); _pinyinHash.Add(-14645, "pu");
            _pinyinHash.Add(-14630, "qi"); _pinyinHash.Add(-14594, "qia"); _pinyinHash.Add(-14429, "qian");
            _pinyinHash.Add(-14407, "qiang"); _pinyinHash.Add(-14399, "qiao"); _pinyinHash.Add(-14384, "qie");
            _pinyinHash.Add(-14379, "qin"); _pinyinHash.Add(-14368, "qing"); _pinyinHash.Add(-14355, "qiong");
            _pinyinHash.Add(-14353, "qiu"); _pinyinHash.Add(-14345, "qu"); _pinyinHash.Add(-14170, "quan");
            _pinyinHash.Add(-14159, "que"); _pinyinHash.Add(-14151, "qun"); _pinyinHash.Add(-14149, "ran");
            _pinyinHash.Add(-14145, "rang"); _pinyinHash.Add(-14140, "rao"); _pinyinHash.Add(-14137, "re");
            _pinyinHash.Add(-14135, "ren"); _pinyinHash.Add(-14125, "reng"); _pinyinHash.Add(-14123, "ri");
            _pinyinHash.Add(-14122, "rong"); _pinyinHash.Add(-14112, "rou"); _pinyinHash.Add(-14109, "ru");
            _pinyinHash.Add(-14099, "ruan"); _pinyinHash.Add(-14097, "rui"); _pinyinHash.Add(-14094, "run");
            _pinyinHash.Add(-14092, "ruo"); _pinyinHash.Add(-14090, "sa"); _pinyinHash.Add(-14087, "sai");
            _pinyinHash.Add(-14083, "san"); _pinyinHash.Add(-13917, "sang"); _pinyinHash.Add(-13914, "sao");
            _pinyinHash.Add(-13910, "se"); _pinyinHash.Add(-13907, "sen"); _pinyinHash.Add(-13906, "seng");
            _pinyinHash.Add(-13905, "sha"); _pinyinHash.Add(-13896, "shai"); _pinyinHash.Add(-13894, "shan");
            _pinyinHash.Add(-13878, "shang"); _pinyinHash.Add(-13870, "shao"); _pinyinHash.Add(-13859, "she");
            _pinyinHash.Add(-13847, "shen"); _pinyinHash.Add(-13831, "sheng"); _pinyinHash.Add(-13658, "shi");
            _pinyinHash.Add(-13611, "shou"); _pinyinHash.Add(-13601, "shu"); _pinyinHash.Add(-13406, "shua");
            _pinyinHash.Add(-13404, "shuai"); _pinyinHash.Add(-13400, "shuan"); _pinyinHash.Add(-13398, "shuang");
            _pinyinHash.Add(-13395, "shui"); _pinyinHash.Add(-13391, "shun"); _pinyinHash.Add(-13387, "shuo");
            _pinyinHash.Add(-13383, "si"); _pinyinHash.Add(-13367, "song"); _pinyinHash.Add(-13359, "sou");
            _pinyinHash.Add(-13356, "su"); _pinyinHash.Add(-13343, "suan"); _pinyinHash.Add(-13340, "sui");
            _pinyinHash.Add(-13329, "sun"); _pinyinHash.Add(-13326, "suo"); _pinyinHash.Add(-13318, "ta");
            _pinyinHash.Add(-13147, "tai"); _pinyinHash.Add(-13138, "tan"); _pinyinHash.Add(-13120, "tang");
            _pinyinHash.Add(-13107, "tao"); _pinyinHash.Add(-13096, "te"); _pinyinHash.Add(-13095, "teng");
            _pinyinHash.Add(-13091, "ti"); _pinyinHash.Add(-13076, "tian"); _pinyinHash.Add(-13068, "tiao");
            _pinyinHash.Add(-13063, "tie"); _pinyinHash.Add(-13060, "ting"); _pinyinHash.Add(-12888, "tong");
            _pinyinHash.Add(-12875, "tou"); _pinyinHash.Add(-12871, "tu"); _pinyinHash.Add(-12860, "tuan");
            _pinyinHash.Add(-12858, "tui"); _pinyinHash.Add(-12852, "tun"); _pinyinHash.Add(-12849, "tuo");
            _pinyinHash.Add(-12838, "wa"); _pinyinHash.Add(-12831, "wai"); _pinyinHash.Add(-12829, "wan");
            _pinyinHash.Add(-12812, "wang"); _pinyinHash.Add(-12802, "wei"); _pinyinHash.Add(-12607, "wen");
            _pinyinHash.Add(-12597, "weng"); _pinyinHash.Add(-12594, "wo"); _pinyinHash.Add(-12585, "wu");
            _pinyinHash.Add(-12556, "xi"); _pinyinHash.Add(-12359, "xia"); _pinyinHash.Add(-12346, "xian");
            _pinyinHash.Add(-12320, "xiang"); _pinyinHash.Add(-12300, "xiao"); _pinyinHash.Add(-12120, "xie");
            _pinyinHash.Add(-12099, "xin"); _pinyinHash.Add(-12089, "xing"); _pinyinHash.Add(-12074, "xiong");
            _pinyinHash.Add(-12067, "xiu"); _pinyinHash.Add(-12058, "xu"); _pinyinHash.Add(-12039, "xuan");
            _pinyinHash.Add(-11867, "xue"); _pinyinHash.Add(-11861, "xun"); _pinyinHash.Add(-11847, "ya");
            _pinyinHash.Add(-11831, "yan"); _pinyinHash.Add(-11798, "yang"); _pinyinHash.Add(-11781, "yao");
            _pinyinHash.Add(-11604, "ye"); _pinyinHash.Add(-11589, "yi"); _pinyinHash.Add(-11536, "yin");
            _pinyinHash.Add(-11358, "ying"); _pinyinHash.Add(-11340, "yo"); _pinyinHash.Add(-11339, "yong");
            _pinyinHash.Add(-11324, "you"); _pinyinHash.Add(-11303, "yu"); _pinyinHash.Add(-11097, "yuan");
            _pinyinHash.Add(-11077, "yue"); _pinyinHash.Add(-11067, "yun"); _pinyinHash.Add(-11055, "za");
            _pinyinHash.Add(-11052, "zai"); _pinyinHash.Add(-11045, "zan"); _pinyinHash.Add(-11041, "zang");
            _pinyinHash.Add(-11038, "zao"); _pinyinHash.Add(-11024, "ze"); _pinyinHash.Add(-11020, "zei");
            _pinyinHash.Add(-11019, "zen"); _pinyinHash.Add(-11018, "zeng"); _pinyinHash.Add(-11014, "zha");
            _pinyinHash.Add(-10838, "zhai"); _pinyinHash.Add(-10832, "zhan"); _pinyinHash.Add(-10815, "zhang");
            _pinyinHash.Add(-10800, "zhao"); _pinyinHash.Add(-10790, "zhe"); _pinyinHash.Add(-10780, "zhen");
            _pinyinHash.Add(-10764, "zheng"); _pinyinHash.Add(-10587, "zhi"); _pinyinHash.Add(-10544, "zhong");
            _pinyinHash.Add(-10533, "zhou"); _pinyinHash.Add(-10519, "zhu"); _pinyinHash.Add(-10331, "zhua");
            _pinyinHash.Add(-10329, "zhuai"); _pinyinHash.Add(-10328, "zhuan"); _pinyinHash.Add(-10322, "zhuang");
            _pinyinHash.Add(-10315, "zhui"); _pinyinHash.Add(-10309, "zhun"); _pinyinHash.Add(-10307, "zhuo");
            _pinyinHash.Add(-10296, "zi"); _pinyinHash.Add(-10281, "zong"); _pinyinHash.Add(-10274, "zou");
            _pinyinHash.Add(-10270, "zu"); _pinyinHash.Add(-10262, "zuan"); _pinyinHash.Add(-10260, "zui");
            _pinyinHash.Add(-10256, "zun"); _pinyinHash.Add(-10254, "zuo"); _pinyinHash.Add(-10247, "zz");
            return _pinyinHash;
        }

        /// <summary>
        /// 获得汉字的拼音，如果输入的是英文字符将原样输出，中文标点符号将被忽略
        /// </summary>
        /// <param name="chineseChars">汉字字符串</param>
        /// <returns>拼音</returns>
        public static string GetPinyin(string chineseChars)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(chineseChars);
            int byteValue;
            StringBuilder sb = new StringBuilder(chineseChars.Length * 4);
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteValue = (int)byteArray[i];
                if (byteValue > 160)
                {
                    byteValue = byteValue * 256 + byteArray[++i] - 65536;
                    sb.Append(GetPinyin(byteValue));
                }
                else
                {
                    sb.Append((char)byteValue);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获得汉字拼音的简写，即每一个汉字的拼音的首字母组成的串，如果输入的是英文字符将原样输出，中文标点符号将被忽略
        /// </summary>
        /// <param name="chineseChars">汉字字符串</param>
        /// <returns>拼音简写</returns>
        public static string GetShortPinyin(string chineseChars)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(chineseChars);
            int byteValue;
            StringBuilder sb = new StringBuilder(chineseChars.Length * 4);
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteValue = (int)byteArray[i];
                if (byteValue > 160)
                {
                    byteValue = byteValue * 256 + byteArray[++i] - 65536;
                    string charPinyin = GetPinyin(byteValue);
                    if (!string.IsNullOrEmpty(charPinyin))
                    {
                        charPinyin = new string(charPinyin[0], 1);
                    }
                    sb.Append(charPinyin);
                }
                else
                {
                    sb.Append((char)byteValue);
                }
            }

            return sb.ToString();
        }

        private static string GetPinyin(int charValue)
        {
            Hashtable _pinyinHash = GetHashtable();
            if (charValue < -20319 || charValue > -10247)
                return "";

            while (!_pinyinHash.ContainsKey(charValue))
                charValue--;

            return (string)_pinyinHash[charValue];
        }
        #endregion
        #endregion


        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        public static string EncryptMD5(string strVal)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strVal);
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(buffer);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        #region Decrypt
        private static byte[] MakeMD5(byte[] original)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(original);
            return buffer;
        }

        private static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = MakeMD5(key);
            provider.Mode = CipherMode.ECB;
            return provider.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        private static string Decrypt(string original, string key)
        {
            return Decrypt(original, key, Encoding.Default);
        }

        private static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buffer = Convert.FromBase64String(encrypted);
            byte[] bytes = Encoding.Default.GetBytes(key);
            return Encoding.Default.GetString(Decrypt(buffer, bytes));
        }

        private static byte[] Decrypt(byte[] encrypted)
        {
            byte[] bytes = Encoding.Default.GetBytes("MD5");
            return Decrypt(encrypted, bytes);
        }

        public static string Decrypt(string original)
        {
            return Decrypt(original, "MD5", Encoding.Default);
        }
        #endregion




        #endregion


        #region 字符串
        /// <summary>
        /// 将文本中的换行符转化为html中的换行
        /// </summary>
        /// <param name="strWord"></param>
        /// <returns></returns>
        public static string GetDescription(object strWord)
        {
            if (strWord != null && !string.IsNullOrEmpty(strWord.ToString()))
            {
                string contents = strWord.ToString().Replace(((char)13).ToString(), "<br/>");
                return contents;
            }
            return "";
        }

        /// <summary>
        /// 安全内容
        /// </summary>
        /// <param name="objHtml"></param>
        /// <returns></returns>
        public static string GetSafeContents(object objHtml, bool BFilterTable)
        {
            string strHtml = string.Empty;
            if (objHtml != null && objHtml.ToString().Trim().Length > 0)
            {
                strHtml = objHtml.ToString().Trim();
                Regex regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
                Regex regex2 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
                Regex regex3 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
                Regex regex4 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);

                strHtml = regex1.Replace(strHtml, ""); //过滤<script></script>标记
                strHtml = regex2.Replace(strHtml, ""); //过滤其它控件的on...事件
                strHtml = regex3.Replace(strHtml, ""); //过滤iframe
                strHtml = regex4.Replace(strHtml, ""); //过滤frameset

                if (BFilterTable)
                {
                    Regex regex5 = new Regex(@"<[^>]*>", RegexOptions.IgnoreCase);
                    strHtml = regex5.Replace(strHtml, "");
                }
            }
            return strHtml;
        }


        /// <summary>
        /// 获取纯文本
        /// </summary>
        public static string GetText(object objHtml)
        {
            if (DBNull.Value == objHtml || string.IsNullOrEmpty(objHtml.ToString())) return "";

            string strHtml = objHtml.ToString();

            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<script>内容</script>为空格
            string regex_str = "(?is)<script[^>]*>.*?</script>";//替换<script>内容</script>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<style>内容</style>为空格
            regex_str = "(?is)<style[^>]*>.*?</style>";//替换<style>内容</style>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "(&nbsp;)+";//替换&nbsp;为空格
            regex_str = "(?i)&nbsp;";//替换&nbsp;为空格
            strHtml = Regex.Replace(strHtml, regex_str, " ");

            //regex_str = "(\r\n)*";//替换\r\n为空
            regex_str = @"[\r\n]*";//替换\r\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //regex_str = "<[^<]*>";//替换Html标签为空
            regex_str = "<[^<>]*>";//替换Html标签为空
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "\n*";//替换\n为空
            regex_str = @"\n*";//替换\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以这样
            regex_str = "\t*";//替换\t为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以
            regex_str = "'";//替换'为’
            strHtml = Regex.Replace(strHtml, regex_str, "’", RegexOptions.IgnoreCase);

            //可以
            regex_str = " +";//替换若干个空格为一个空格
            strHtml = Regex.Replace(strHtml, regex_str, "  ", RegexOptions.IgnoreCase);

            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);

            string strOutput = regex.Replace(strHtml, "");//替换掉"<"和">"之间的内容
            strOutput = strOutput.Replace("<", "");
            strOutput = strOutput.Replace(">", "");
            strOutput = strOutput.Replace("&nbsp;", "");


            return strOutput;
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="szText"></param>
        /// <param name="nLen"></param>
        /// <param name="isDot"></param>
        /// <returns></returns>
        public static string CutString(object szText, int nLen, bool isDot)
        {
            if (szText != null)
            {
                if (szText.ToString().Length > nLen)
                {
                    return szText.ToString().Trim().Substring(0, nLen) + (isDot ? "..." : "");
                }
                return szText.ToString().Trim();
            }
            return "";
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="szText"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static string CutString(object szText, int nLen)
        {
            if (szText != null)
            {
                if (szText.ToString().Trim().Length > nLen)
                {
                    return szText.ToString().Trim().Substring(0, nLen);
                }
                return szText.ToString().Trim();
            }
            return "";
        }

        /// <summary>
        /// 获取纯文本
        /// </summary>
        public static string GetTextContents(object objHtml)
        {
            if (DBNull.Value == objHtml || string.IsNullOrEmpty(objHtml.ToString())) return "";

            string strHtml = objHtml.ToString();

            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<script>内容</script>为空格
            string regex_str = "(?is)<script[^>]*>.*?</script>";//替换<script>内容</script>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<style>内容</style>为空格
            regex_str = "(?is)<style[^>]*>.*?</style>";//替换<style>内容</style>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "(&nbsp;)+";//替换&nbsp;为空格
            regex_str = "(?i)&nbsp;";//替换&nbsp;为空格
            strHtml = Regex.Replace(strHtml, regex_str, " ");

            //regex_str = "(\r\n)*";//替换\r\n为空
            regex_str = @"[\r\n]*";//替换\r\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //regex_str = "<[^<]*>";//替换Html标签为空
            regex_str = "<[^<>]*>";//替换Html标签为空
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "\n*";//替换\n为空
            regex_str = @"\n*";//替换\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以这样
            regex_str = "\t*";//替换\t为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以
            regex_str = "'";//替换'为’
            strHtml = Regex.Replace(strHtml, regex_str, "’", RegexOptions.IgnoreCase);

            //可以
            regex_str = " +";//替换若干个空格为一个空格
            strHtml = Regex.Replace(strHtml, regex_str, "  ", RegexOptions.IgnoreCase);

            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);

            string strOutput = regex.Replace(strHtml, "");//替换掉"<"和">"之间的内容
            strOutput = strOutput.Replace("<", "");
            strOutput = strOutput.Replace(">", "");
            strOutput = strOutput.Replace("&nbsp;", "");


            return strOutput;
        }

        #endregion


        #region 文件操作
        /// <summary>
        /// 写入文本内容
        /// </summary>
        /// <param name="fileurl"></param>
        /// <param name="szEvent"></param>
        public static void WriteContentsToFile(string fileurl, string szEvent)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath(fileurl);
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine(szEvent);
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 读取文本内容
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static string GetFileContents(string fileurl)
        {
            string szEvent = "";
            string filepath = System.Web.HttpContext.Current.Server.MapPath(fileurl);
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            szEvent = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return szEvent;
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="photoPath"></param>
        public static void FileDelete(string photoPath)
        {
            if (!string.IsNullOrEmpty(photoPath))
            {
                string fullPath = HttpContext.Current.Server.MapPath(photoPath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }

        public static bool FileExists(object fileUrl)
        {
            if (fileUrl != null && !string.IsNullOrEmpty(fileUrl.ToString()))
            {
                string fullPath = HttpContext.Current.Server.MapPath(fileUrl.ToString());
                if (File.Exists(fullPath))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion



        #region List操作
        /// <summary>
        /// 将 List[int] 对象转化为 String
        /// </summary>
        public static string GetArrayInt(List<int> list)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == (list.Count - 1))
                {
                    builder.Append(list[i].ToString());
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(",");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// 将 List[string] 对象转化为 String
        /// </summary>
        public static string GetWhereArrayStr(List<string> list)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    builder.Append(",");
                }
                builder.AppendFormat(" '{0}' ", list[i]);
            }
            return builder.ToString();
        }


        /// <summary>
        /// 将 List[string] 对象转化为 String
        /// </summary>
        public static string GetArrayStr(List<string> list)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == (list.Count - 1))
                {
                    builder.Append(list[i].ToString());
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(",");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// 将List[string]对象转化为 String
        /// </summary>
        /// <param name="list"></param>
        /// <param name="speater"></param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == (list.Count - 1))
                {
                    builder.Append(list[i]);
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(speater);
                }
            }
            return builder.ToString();
        }


        /// <summary>
        /// 将String 转化为 List[string]，默认转小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str)
        {
            return GetStrArray(str, ',', true);
        }

        public static List<int> GetIntArray(string str)
        {
            char speater = ',';
            List<int> list = new List<int>();
            foreach (string str2 in str.Split(new char[] { speater }))
            {
                if (!string.IsNullOrEmpty(str2) && (str2 != speater.ToString()))
                {
                    string item = str2;
                    list.Add(Convert.ToInt32(item));
                }
            }
            return list;
        }

        /// <summary>
        /// 将String 转化为 List[string]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="speater"></param>
        /// <param name="toLower"></param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            foreach (string str2 in str.Split(new char[] { speater }))
            {
                if (!string.IsNullOrEmpty(str2) && (str2 != speater.ToString()))
                {
                    string item = str2;
                    if (toLower)
                    {
                        item = str2.ToLower();
                    }
                    else
                    {
                        item = str2.ToUpper();
                    }
                    list.Add(item.Trim());
                }
            }
            return list;
        }


        public static int GetIntStr(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    return Convert.ToInt32(str);
                }
                catch
                {
                }
            }
            return 0;
        }
        #endregion



        #region 控件绑定操作

        public static void BindMultipleControl(Control ctrl, DataSet ds, string[] szFieldsTxt, string szFieldVal, string szHeadTxt, string szHeadVal)
        {
            if (ctrl is DropDownList)
            {
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0)
                {
                    ctrlDDL.Items.Clear();
                }

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string szText = row[szFieldsTxt[0]].ToString();
                        for (int i = 1; i < szFieldsTxt.Length; i++)
                        {
                            string szItemName = row[szFieldsTxt[i]].ToString();
                            if (!string.IsNullOrEmpty(szItemName))
                            {
                                szText += " - " + szItemName;
                            }
                        }
                        ctrlDDL.Items.Add(new ListItem(szText, row[szFieldVal].ToString().Trim()));
                    }
                    if (!string.IsNullOrEmpty(szHeadTxt))
                    {
                        ctrlDDL.Items.Insert(0, new ListItem(szHeadTxt, szHeadVal));
                    }
                }
            }
        }

        /// <summary>
        /// 绑定DropDownList
        /// </summary>
        /// <param name="ctrl">控件（DropDownList，CheckBoxList,RadioList</param>
        /// <param name="ds">数据源</param>
        /// <param name="szFileds">0：keyValue, 1：keyText, 2: HeadTitle（可为NULL), 3: HeadValue（可为NULL)</param>
        public static void BindControl(Control ctrl, DataSet ds, string[] szFileds)
        {
            if (szFileds.Length == 1)
            {
                BindControl(ctrl, ds, szFileds[0], szFileds[0], null, null);
            }
            else if (szFileds.Length == 2)
            {
                BindControl(ctrl, ds, szFileds[0], szFileds[1], null, null);
            }
            else if (szFileds.Length == 3)
            {
                BindControl(ctrl, ds, szFileds[0], szFileds[1], szFileds[2], "");
            }
            else if (szFileds.Length == 4)
            {
                BindControl(ctrl, ds, szFileds[0], szFileds[1], szFileds[2], szFileds[3]);
            }
        }

        /// <summary>
        /// 将数据源绑定控件
        /// </summary>
        /// <param name="ctrl">可为 DropDownList，CheckBoxList，RadioButtonList</param>
        /// <param name="ds"></param>
        /// <param name="szFieldVal"></param>
        /// <param name="szFieldTxt"></param>
        /// <param name="szHeadTxt"></param>
        /// <param name="szHeadVal"></param>
        public static void BindControl(Control ctrl, DataSet ds, string szFieldVal, string szFieldTxt, string szHeadTxt, string szHeadVal)
        {
            if (ctrl is DropDownList)
            {
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0)
                {
                    ctrlDDL.Items.Clear();
                }

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ctrlDDL.Items.Add(new ListItem(row[szFieldTxt].ToString().Trim(), row[szFieldVal].ToString().Trim()));
                    }
                }

                if (!string.IsNullOrEmpty(szHeadTxt))
                {
                    ctrlDDL.Items.Insert(0, new ListItem(szHeadTxt, szHeadVal));
                }
            }
            else if (ctrl is CheckBoxList)
            {
                CheckBoxList ctrlCheckBox = ctrl as CheckBoxList;
                if (ctrlCheckBox.Items.Count > 0)
                {
                    ctrlCheckBox.Items.Clear();
                }

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ctrlCheckBox.DataSource = ds.Tables[0];
                    ctrlCheckBox.DataValueField = szFieldVal;
                    ctrlCheckBox.DataTextField = szFieldTxt;
                    ctrlCheckBox.DataBind();
                }
            }
            else if (ctrl is RadioButtonList)
            {
                RadioButtonList ctrlRadio = ctrl as RadioButtonList;
                if (ctrlRadio.Items.Count > 0)
                {
                    ctrlRadio.Items.Clear();
                }

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ctrlRadio.DataSource = ds.Tables[0];
                    ctrlRadio.DataValueField = szFieldVal;
                    ctrlRadio.DataTextField = szFieldTxt;
                    ctrlRadio.DataBind();
                }
            }
        }




        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="ctrl">可为 DropDownList，CheckBoxList，RadioButtonList</param>
        /// <param name="nVal">初始值</param>
        public static void SetControlValue(Control ctrl, int nVal)
        {
            if (ctrl is DropDownList)
            {
                //DropDownList控件 
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0)
                {
                    ctrlDDL.SelectedIndex = -1;
                }
                foreach (ListItem item in ctrlDDL.Items)
                {
                    if (Convert.ToInt32(item.Value) == nVal)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else if (ctrl is CheckBoxList)
            {
                //CheckBoxList控件
                CheckBoxList ctrlCheckBox = ctrl as CheckBoxList;
                if (ctrlCheckBox.Items.Count > 0)
                {
                    ctrlCheckBox.SelectedIndex = -1;
                }
                foreach (ListItem item in ctrlCheckBox.Items)
                {
                    if (Convert.ToInt32(item.Value) == nVal)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else if (ctrl is RadioButtonList)
            {
                //RadioButtonList控件 
                RadioButtonList ctrlRadio = ctrl as RadioButtonList;
                if (ctrlRadio.Items.Count > 0)
                {
                    ctrlRadio.SelectedIndex = -1;
                }
                foreach (ListItem item in ctrlRadio.Items)
                {
                    if (Convert.ToInt32(item.Value) == nVal)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }


        public static void SetControlText(DropDownList ctrlDDL, string strVal)
        {
            if (!string.IsNullOrEmpty(strVal))
            {
                foreach (ListItem item in ctrlDDL.Items)
                {
                    if (strVal.Trim().Equals(item.Text.Trim()))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="ctrl">可为 DropDownList，CheckBoxList，RadioButtonList</param>
        /// <param name="sVal">控件值</param>
        public static void SetControlValue(Control ctrl, string sVal)
        {
            List<string> list = GetStrArray(sVal, ',', false);

            if (ctrl is DropDownList)
            {
                //DropDownList控件 
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0)
                {
                    ctrlDDL.SelectedIndex = -1;
                }
                foreach (ListItem item in ctrlDDL.Items)
                {
                    if (list.Contains(item.Value.Trim()))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else if (ctrl is CheckBoxList)
            {
                //CheckBoxList控件
                CheckBoxList ctrlCheckBox = ctrl as CheckBoxList;
                if (ctrlCheckBox.Items.Count > 0)
                {
                    ctrlCheckBox.SelectedIndex = -1;
                }
                foreach (ListItem item in ctrlCheckBox.Items)
                {
                    if (list.Contains(item.Value.Trim()))
                    {
                        item.Selected = true;
                    }
                }
            }
            else if (ctrl is RadioButtonList)
            {
                //RadioButtonList控件 
                RadioButtonList ctrlRadio = ctrl as RadioButtonList;
                if (ctrlRadio.Items.Count > 0)
                {
                    ctrlRadio.SelectedIndex = -1;
                }
                foreach (ListItem item in ctrlRadio.Items)
                {
                    if (list.Contains(item.Value.Trim()))
                    {
                        item.Selected = true;
                    }
                }
            }
        }


        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="ctrl">可为  CheckBoxList </param>
        /// <param name="nVal">初始值</param>
        public static void SetControlValue(DropDownList ctrl, List<string> oList)
        {
            if (ctrl.Items.Count > 0)
            {
                foreach (ListItem item in ctrl.Items)
                {
                    if (oList.Contains(item.Value.Trim()))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="ctrl">可为  CheckBoxList </param>
        /// <param name="nVal">初始值</param>
        public static void SetControlValue(CheckBoxList ctrl, List<string> oList)
        {
            if (ctrl.Items.Count > 0)
            {
                foreach (ListItem item in ctrl.Items)
                {
                    if (oList.Contains(item.Value.Trim()))
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// 获取控件的值
        /// </summary>
        /// <param name="ctrl">可为 DropDownList，CheckBoxList，RadioButtonList</param>
        /// <returns></returns>
        public static string GetControlSelectedValue(Control ctrl)
        {
            string sVal = "";
            if (ctrl is DropDownList)
            {
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0 && ctrlDDL.SelectedIndex > -1)
                {
                    sVal = ctrlDDL.SelectedItem.Value.Trim();
                }
            }
            else if (ctrl is CheckBoxList)
            {
                CheckBoxList ctrlCheckBox = ctrl as CheckBoxList;
                if (ctrlCheckBox.Items.Count > 0 && ctrlCheckBox.SelectedIndex > -1)
                {
                    foreach (ListItem item in ctrlCheckBox.Items)
                    {
                        if (item.Selected)
                        {
                            sVal += (sVal.Length > 0 ? "," : "");
                            sVal += item.Value.Trim();
                        }
                    }
                }
            }
            else if (ctrl is RadioButtonList)
            {
                RadioButtonList ctrlRadio = ctrl as RadioButtonList;
                if (ctrlRadio.Items.Count > 0 && ctrlRadio.SelectedIndex > -1)
                {
                    foreach (ListItem item in ctrlRadio.Items)
                    {
                        if (item.Selected)
                        {
                            sVal = item.Value.Trim();
                            break;
                        }
                    }
                }
            }
            return sVal;
        }

        /// <summary>
        /// 获取控件的值
        /// </summary>
        /// <param name="ctrl">可为 DropDownList，CheckBoxList，RadioButtonList</param>
        /// <returns></returns>
        public static int GetControlSelectedIntValue(Control ctrl)
        {
            int nVal = 0;
            if (ctrl is DropDownList)
            {
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0 && ctrlDDL.SelectedIndex > -1)
                {
                    nVal = int.Parse(ctrlDDL.SelectedItem.Value);
                }
            }
            else if (ctrl is CheckBoxList)
            {
                CheckBoxList ctrlCheckBox = ctrl as CheckBoxList;
                if (ctrlCheckBox.Items.Count > 0 && ctrlCheckBox.SelectedIndex > -1)
                {
                    foreach (ListItem item in ctrlCheckBox.Items)
                    {
                        if (item.Selected)
                        {
                            nVal = Convert.ToInt32(item.Value);
                            break;
                        }
                    }
                }
            }
            else if (ctrl is RadioButtonList)
            {
                RadioButtonList ctrlRadio = ctrl as RadioButtonList;
                if (ctrlRadio.Items.Count > 0 && ctrlRadio.SelectedIndex > -1)
                {
                    foreach (ListItem item in ctrlRadio.Items)
                    {
                        if (item.Selected)
                        {
                            nVal = Convert.ToInt32(item.Value);
                            break;
                        }
                    }
                }
            }
            return nVal;
        }

        /// <summary>
        /// 获取控件的文本值
        /// </summary>
        /// <param name="ctrl">可为 DropDownList，CheckBoxList，RadioButtonList</param>
        /// <returns></returns>
        public static string GetControlSelectedText(Control ctrl)
        {
            string sVal = "";
            if (ctrl is DropDownList)
            {
                DropDownList ctrlDDL = ctrl as DropDownList;
                if (ctrlDDL.Items.Count > 0 && ctrlDDL.SelectedIndex > -1)
                {
                    sVal = ctrlDDL.SelectedItem.Text.Trim();
                }
            }
            else if (ctrl is CheckBoxList)
            {
                CheckBoxList ctrlCheckBox = ctrl as CheckBoxList;
                if (ctrlCheckBox.Items.Count > 0 && ctrlCheckBox.SelectedIndex > -1)
                {
                    foreach (ListItem item in ctrlCheckBox.Items)
                    {
                        if (item.Selected)
                        {
                            sVal += (sVal.Length > 0 ? "," : "");
                            sVal += item.Text.Trim();
                        }
                    }
                }
            }
            else if (ctrl is RadioButtonList)
            {
                RadioButtonList ctrlRadio = ctrl as RadioButtonList;
                if (ctrlRadio.Items.Count > 0 && ctrlRadio.SelectedIndex > -1)
                {
                    foreach (ListItem item in ctrlRadio.Items)
                    {
                        if (item.Selected)
                        {
                            sVal = item.Text.Trim();
                            break;
                        }
                    }
                }
            }
            return sVal;
        }

        #endregion







        #region 日期操作
        /// <summary>
        /// 获取相差时间
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static string GetSubtractDate(DateTime DateTime1, DateTime DateTime2)
        {
            string str = null;
            try
            {
                TimeSpan span = (TimeSpan)(DateTime2 - DateTime1);
                if (span.Days >= 1)
                {
                    return (DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日");
                }
                if (span.Hours > 1)
                {
                    return (span.Hours.ToString() + "小时前");
                }
                str = span.Minutes.ToString() + "分钟前";
            }
            catch
            {
            }
            return str;
        }

        /// <summary>
        /// 获取最后一天
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int GetLastDay(int year, int month)
        {
            DateTime time = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            return time.Day;
        }

        /// <summary>
        /// 获取星期几
        /// </summary>
        /// <param name="dayOfWeek">数字号（从0开始），0表示星期天</param>
        /// <returns></returns>
        public static string GetWeekDayName(int dayOfWeek)
        {
            string[] cnWeekDayNames = { "日", "一", "二", "三", "四", "五", "六" };
            return "星期" + cnWeekDayNames[dayOfWeek];
        }

        #endregion



        #region Url


        public static bool IsBase64(string eStr)
        {
            if ((eStr.Length % 4) != 0)
            {
                return false;
            }
            if (!Regex.IsMatch(eStr, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="eStr"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string eStr)
        {
            if (!IsBase64(eStr))
            {
                return eStr;
            }
            byte[] bytes = Convert.FromBase64String(eStr);
            return HttpUtility.UrlDecode(System.Text.Encoding.UTF8.GetString(bytes));
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="sourthUrl"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string sourthUrl)
        {
            if (!string.IsNullOrEmpty(sourthUrl))
            {
                string s = HttpUtility.UrlEncode(sourthUrl.Trim());
                return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
            }
            return "";
        }

        #endregion




        #region Excel导出
        /// <summary>
        /// 将DataSet转化为Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        public static string DSToExcel(DataSet ds, string excelPath)
        {
            return DSToExcel(ds, excelPath, null);
        }

        /// <summary>
        /// 将DataSet转化为Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        public static string DSToExcel(DataSet ds, string excelPath, Hashtable ht)
        {
            if (ds == null)
            {
                return "DataSet不能为空";
            }
            DataTable dt = ds.Tables[0];
            dt.TableName = "Sheet1";
            int count = dt.Rows.Count;
            int num2 = dt.Columns.Count;
            if (count == 0)
            {
                return "没有数据";
            }

            string szColumnName = "";
            StringBuilder builder = new StringBuilder();
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", excelPath);
            builder.Append("CREATE TABLE ");
            builder.Append(dt.TableName + " ( ");
            for (int i = 0; i < num2; i++)
            {
                szColumnName = dt.Columns[i].ColumnName;

                if (ht != null && ht.Count > 0)
                {
                    szColumnName = GetValueFromHashtable(ht, szColumnName);
                }

                if (i < (num2 - 1))
                {
                    builder.Append(string.Format("{0} nvarchar,", szColumnName));
                }
                else
                {
                    builder.Append(string.Format("{0} nvarchar)", szColumnName));
                }
            }
            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
            {
                System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand();
                command.Connection = connection;
                command.CommandText = builder.ToString();
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    return ("在Excel中创建表失败，错误信息：" + exception.Message);
                }
                builder.Remove(0, builder.Length);
                builder.Append("INSERT INTO ");
                builder.Append(dt.TableName + " ( ");
                for (int j = 0; j < num2; j++)
                {
                    szColumnName = dt.Columns[j].ColumnName;

                    if (ht != null && ht.Count > 0)
                    {
                        szColumnName = GetValueFromHashtable(ht, szColumnName);
                    }

                    if (j < (num2 - 1))
                    {
                        builder.Append(szColumnName + ",");
                    }
                    else
                    {
                        builder.Append(szColumnName + ") values (");
                    }
                }
                for (int k = 0; k < num2; k++)
                {
                    if (k < (num2 - 1))
                    {
                        builder.Append("@" + dt.Columns[k].ColumnName + ",");
                    }
                    else
                    {
                        builder.Append("@" + dt.Columns[k].ColumnName + ")");
                    }
                }
                command.CommandText = builder.ToString();
                System.Data.OleDb.OleDbParameterCollection parameters = command.Parameters;
                for (int m = 0; m < num2; m++)
                {
                    parameters.Add(new System.Data.OleDb.OleDbParameter("@" + dt.Columns[m].ColumnName, System.Data.OleDb.OleDbType.VarChar));
                }
                foreach (DataRow row in dt.Rows)
                {
                    for (int n = 0; n < parameters.Count; n++)
                    {
                        parameters[n].Value = row[n];
                    }
                    command.ExecuteNonQuery();
                }
                return "数据已成功导入Excel";
            }
        }

        /// <summary>
        /// 将DataSet导出到Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="title"></param>
        public static void DataSetToExcel(DataSet ds, string title)
        {
            DataSetToExcel(ds, title, null, null, null);
        }

        /// <summary>
        /// 将DataSet导出到Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="title"></param>
        /// <param name="ht"></param>
        public static void DataSetToExcel(DataSet ds, string title, Hashtable ht)
        {
            DataSetToExcel(ds, title, null, null, ht);
        }

        /// <summary>
        /// 将DataSet导出到Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="title"></param>
        /// <param name="subtitle"></param>
        public static void DataSetToExcel(DataSet ds, string title, string subtitle)
        {
            DataSetToExcel(ds, title, subtitle, null, null);
        }

        /// <summary>
        /// 将DataSet导出到Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="title"></param>
        /// <param name="subtitle"></param>
        /// <param name="ht"></param>
        public static void DataSetToExcel(DataSet ds, string title, string subtitle, Hashtable ht)
        {
            DataSetToExcel(ds, title, subtitle, null, ht);
        }

        /// <summary>
        /// 将DataSet导出到Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="title"></param>
        /// <param name="subtitle"></param>
        /// <param name="bottomtitle"></param>
        /// <param name="ht"></param>
        public static void DataSetToExcel(DataSet ds, string title, string subtitle, string bottomtitle, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            if (ds != null)
            {
                System.Data.DataTable dt = ds.Tables[0];
                int columnsCount = dt.Columns.Count;

                if (subtitle != null && subtitle.Length > 0)
                {
                    sb.AppendFormat("<table><tr><td colspan={0} style='text-align:left;'>{1}</td></tr></table>" + Environment.NewLine, columnsCount, subtitle);
                }

                if (dt.Rows.Count > 0)
                {
                    sb.AppendLine("<table border='0' cellpadding='0' cellspacing='0'>");
                    sb.AppendLine("<thead>");
                    sb.AppendLine("<tr style='text-align:center;background:#293954;color:#ffffff;font-weight:normal;height:32px;'>");
                    for (int i = 0; i < columnsCount; i++)
                    {
                        string columname = dt.Columns[i].ColumnName;
                        if (ht != null && ht.Count > 0)
                        {
                            columname = GetValueFromHashtable(ht, columname);
                        }
                        sb.AppendFormat("<td>{0}</td>", columname);
                    }
                    sb.AppendLine("</tr>");
                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        sb.AppendLine("<tr style='text-align:center'>");
                        for (int i = 0; i < columnsCount; i++)
                        {
                            sb.AppendFormat("<td>{0}</td>", GetText(row[i]));
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.AppendLine("</tbody>");


                    if (bottomtitle != null && bottomtitle.Length > 0)
                    {
                        sb.AppendLine("<tfoot>");
                        sb.AppendFormat("<tr style='color:#FF0000; font-size:20px'><td colspan='{0}'>{1}</td></tr>" + Environment.NewLine, columnsCount, bottomtitle);
                        sb.AppendLine("</tfoot>");
                    }
                    sb.AppendLine("</table>");
                }
            }
            string body = sb.ToString();
            HtmlToExcel(title, body);
        }



        /// <summary>
        /// 将Excel转化为DataSet
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static DataSet ExcelToDS(string Path)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
            System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString);
            connection.Open();
            string selectCommandText = "";
            System.Data.OleDb.OleDbDataAdapter adapter = null;
            DataSet dataSet = null;
            selectCommandText = "select * from [Sheet1$]";
            adapter = new System.Data.OleDb.OleDbDataAdapter(selectCommandText, connectionString);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "table1");
            connection.Close();
            return dataSet;
        }

        /// <summary>
        /// 导出正文（不带CSS)
        /// </summary>
        /// <param name="body"></param>
        public static void HtmlToExcel(string body)
        {
            HtmlToExcel(null, body, null);
        }

        /// <summary>
        /// 导出标题与正文（不带CSS)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        public static void HtmlToExcel(string title, string body)
        {
            HtmlToExcel(title, body, null);
        }

        public static void HtmlToExcel(string title, string body, string css)
        {
            HtmlToExcel(title, body, null, null);
        }
        /// <summary>
        /// 导出标题与正文（带CSS)
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="subtitle">子标题</param>
        /// <param name="body">导出内容</param>
        public static void HtmlToExcel(string title, string body, string css, string note)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            sw.WriteLine(@"<html xmlns:x='urn:schemas-microsoft-com:office:excel'>
            <head>
            <!--[if gte mso 9]>
                <xml>
                    <x:ExcelWorkbook>
                        <x:ExcelWorksheets>
                            <x:ExcelWorksheet>
                                 <x:Name>sheet1</x:Name>                                         
                                    <x:WorksheetOptions>      
                                        <x:Print><x:ValidPrinterInfo /></x:Print>    
                                    </x:WorksheetOptions>   
                            </x:ExcelWorksheet>  
                        </x:ExcelWorksheets>
                    </x:ExcelWorkbook>  
                </xml>
        <![endif]-->
        <meta http-equiv='content-type' content='application/vnd.ms-excel; charset=UTF-8'/>");

            if (!string.IsNullOrEmpty(css))
            {
                sw.WriteLine("<style tyle='text/css'>");
                sw.WriteLine(css);
                sw.WriteLine("</style>");
            }

            sw.WriteLine(@"</head>
            <html>
                <body>");

            if (!string.IsNullOrEmpty(title))
            {
                sw.WriteLine(string.Format("<h1 style='text-align:center; margin:0; font-family:微软雅黑;'>{0}</h1>", title));
            }

            sw.WriteLine(body);

            if (!string.IsNullOrEmpty(note))
            {
                sw.WriteLine(string.Format("{0}", note));
            }
            sw.WriteLine(@"</body>
                            </html>");

            string fileName = (string.IsNullOrEmpty(title) ? DateTime.Now.ToString("yyyyMMddHHmmss") : title);
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls");
            System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            System.Web.HttpContext.Current.Response.Charset = "UTF-8";
            System.Web.HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8;
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            string strHtmlContent = sw.ToString().Replace("<br/>", "<br style='mso-data-placement:same-cell;'/>");
            System.Web.HttpContext.Current.Response.Output.Write(strHtmlContent);
            System.Web.HttpContext.Current.Response.ContentType = "text/html";
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }

        #endregion


        #region 将GridView导出到Excel中
        public static void GridViewToExcel(GridView gridView, string title)
        {
            GridViewToExcel(gridView, title, null, null, null);
        }
        public static void GridViewToExcel(GridView gridView, string title, int[] hideColumnIndex)
        {
            GridViewToExcel(gridView, title, null, null, hideColumnIndex);
        }
        public static void GridViewToExcel(GridView gridView, string title, string subtitle)
        {
            GridViewToExcel(gridView, title, subtitle, null, null);
        }
        public static void GridViewToExcel(GridView gridView, string title, string subtitle, int[] hideColumnIndex)
        {
            GridViewToExcel(gridView, title, subtitle, null, hideColumnIndex);
        }
        public static void GridViewToExcel(GridView gridView, string title, string subtitle, string bottomtitle)
        {
            GridViewToExcel(gridView, title, subtitle, bottomtitle, null);
        }
        public static void GridViewToExcel(GridView gridView, string title, string subtitle, string bottomtitle, int[] hideColumnIndex)
        {
            int rowsCount = gridView.Rows.Count;
            if (rowsCount > 0)
            {
                int columnsCount = gridView.Columns.Count;

                bool existed = false;
                StringBuilder sb = new StringBuilder();
                if (subtitle != null && subtitle.Length > 0)
                {
                    sb.AppendFormat("<table><tr><td colspan={0} style='text-align:left'>{1}</td></tr></table>" + Environment.NewLine, columnsCount, subtitle);
                }
                sb.AppendLine("<table border='0' cellpadding='0' cellspacing='0'>");
                sb.AppendLine("<thead>");
                sb.AppendLine("<tr style='text-align:center;background:#b8cce4;'>");
                for (int i = 0; i < columnsCount; i++)
                {
                    existed = false;
                    if (hideColumnIndex != null)
                    {
                        for (int m = 0; m < hideColumnIndex.Length; m++)
                        {
                            if (i == hideColumnIndex[m])
                            {
                                existed = true;
                                break;
                            }
                        }
                    }
                    if (!existed)
                    {
                        sb.AppendFormat("<th>{0}</th>", gridView.Columns[i].HeaderText);
                    }
                }
                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");
                foreach (GridViewRow row in gridView.Rows)
                {
                    sb.AppendLine("<tr style='text-align:center'>");
                    for (int i = 0; i < columnsCount; i++)
                    {
                        existed = false;
                        if (hideColumnIndex != null)
                        {
                            for (int m = 0; m < hideColumnIndex.Length; m++)
                            {
                                if (i == hideColumnIndex[m])
                                {
                                    existed = true;
                                    break;
                                }
                            }
                        }
                        if (!existed)
                        {
                            System.Text.StringBuilder szVal = new System.Text.StringBuilder();
                            szVal.Append(row.Cells[i].Text);

                            if (row.Cells[i].HasControls())
                            {
                                foreach (System.Web.UI.Control c in row.Cells[i].Controls)
                                {
                                    if (c is Label)
                                    {
                                        szVal.Append((c as Label).Text);
                                    }
                                    else if (c is System.Web.UI.LiteralControl)
                                    {
                                        szVal.Append((c as System.Web.UI.LiteralControl).Text);
                                    }
                                    else if (c is System.Web.UI.DataBoundLiteralControl)
                                    {
                                        szVal.Append((c as System.Web.UI.DataBoundLiteralControl).Text);
                                    }
                                    else if (c is System.Web.UI.WebControls.HyperLink)
                                    {
                                        szVal.Append((c as System.Web.UI.WebControls.HyperLink).Text);
                                    }
                                }
                            }
                            string itemText = szVal.ToString();
                            sb.AppendFormat("<td>{0}</td>", GetText(itemText));
                        }
                    }
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</tbody>");
                System.Web.UI.WebControls.GridViewRow foot = gridView.FooterRow;

                if (foot != null)
                {
                    sb.AppendLine("<tfoot>");
                    sb.Append("<tr>");
                    for (int i = 0; i < foot.Cells.Count; i++)
                    {
                        sb.AppendFormat("<td>{0}</td>", foot.Cells[i].Text);
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("</tfoot>");
                }

                sb.AppendLine("</table>");

                if (bottomtitle.Length > 0)
                {
                    sb.AppendLine("<table>");
                    sb.AppendLine("<tfoot>");
                    sb.AppendFormat("<tr style='color:#FF0000; font-size:20px'><td colspan='{0}'>{1}</td></tr>" + Environment.NewLine, columnsCount, bottomtitle);
                    sb.AppendLine("</tfoot>");
                    sb.AppendLine("</table>");
                }


                string body = sb.ToString();
                HtmlToExcel(title, body);
            }
        }
        #endregion



        #region 获取Hashset的值
        /// <summary>
        /// 获取Hashset的值
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetValueFromHashtable(Hashtable ht, string strKey)
        {
            if (ht.ContainsKey(strKey))
            {
                return ht[strKey].ToString().Trim().ToUpper();
            }
            return "";
        }
        #endregion



        #region 获取Web.config文本配置信息
        public static string GetConfigString(string key)
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings[key];
        }
        #endregion


        #region IP信息获取
        /// <summary>
        /// 获取访问者IP
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        #endregion


        #region 获取文章分享链接
        /// <summary>
        /// 打印分享链接
        /// </summary>
        /// <returns></returns>
        public static string GetBookShareIcons()
        {
            StringBuilder szTxt = new StringBuilder();
            szTxt.Append(@"<div id='jiathisbutton'>
<div id='ckepop'>
    <span class='jiathis_txt'>分享到：</span> <a class='jiathis_button_tools_1'></a><a class='jiathis_button_tools_2'>
    </a><a class='jiathis_button_tools_3'></a><a class='jiathis_button_tools_4'></a>
    <a href='http://www.jiathis.com/share' class='jiathis jiathis_txt jiathis_separator jtico jtico_jiathis' target='_blank'>更多</a> <a class='jiathis_counter_style'></a>
</div>
</div>");
            szTxt.Append(@"<script type='text/javascript' src='http://v2.jiathis.com/code/jia.js' charset='utf-8'></script>");
            szTxt.Append("<div class='clearfix'></div>");
            return szTxt.ToString();
        }
        #endregion


        #region 表单验证
        static Regex RegPhone = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
        static Regex RegNumber = new Regex("^[0-9]+$");
        static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        static Regex RegEmail = new Regex(@"^[\w-]+@[\w-]+\.(com|net|cn|org|edu|mil|tv|biz|info)$");
        static Regex RegCHZN = new Regex("[一-龥]");

        public static double GetStrDouble(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                string szIds = "";
                for (int i = 0; i < Id.Length; i++)
                {
                    if (!(SL.IsNumber(Id[i].ToString()) || Char.IsPunctuation(Id[i])))
                    {
                        break;
                    }

                    szIds += Id[i].ToString();
                }
                return Convert.ToDouble(szIds);
            }
            return 0.00;
        }

        public static int GetStrInt(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                string szIds = "";
                for (int i = 0; i < Id.Length; i++)
                {
                    if (!(SL.IsNumber(Id[i].ToString())))
                    {
                        break;
                    }
                    szIds += Id[i].ToString();
                }
                return Convert.ToInt32(szIds);
            }
            return 0;
        }

        /// <summary>
        /// 获取数据库值（字符类型）
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static string GetDBString(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal || string.IsNullOrEmpty(objVal.ToString()))
            {
                return "";
            }
            return objVal.ToString().Trim();
        }

        /// <summary>
        /// 获取数据库值（整形类型）
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static int GetDBInt(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal || string.IsNullOrEmpty(objVal.ToString()))
            {
                return 0;
            }

            int nVal = 0;
            int.TryParse(objVal.ToString(), out nVal);
            return nVal;
        }


        /// <summary>
        /// 获取数据库值（布尔类型）
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static double GetDBDouble(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal || string.IsNullOrEmpty(objVal.ToString()))
            {
                return 0;
            }

            double dVal = 0.00;
            double.TryParse(objVal.ToString(), out dVal);
            return dVal;
        }

        /// <summary>
        /// 获取数据库值（布尔类型）
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static string GetDBTimeString(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal || string.IsNullOrEmpty(objVal.ToString()))
            {
                return "";
            }

            try
            {
                return Convert.ToDateTime(objVal).ToString("yyyy-MM-dd");
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// 卡号验证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 0x12)
            {
                return CheckIDCard18(Id);
            }
            return ((Id.Length == 15) && CheckIDCard15(Id));
        }


        /// <summary>
        /// 卡号验证(15位）
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private static bool CheckIDCard15(string Id)
        {
            long result = 0L;
            if (!long.TryParse(Id, out result) || (result < Math.Pow(10.0, 14.0)))
            {
                return false;
            }
            string str = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (str.IndexOf(Id.Remove(2)) == -1)
            {
                return false;
            }
            string s = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (!DateTime.TryParse(s, out time))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 卡号验证（18位）
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private static bool CheckIDCard18(string Id)
        {
            long result = 0L;
            if ((!long.TryParse(Id.Remove(0x11), out result) || (result < Math.Pow(10.0, 16.0))) || !long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out result))
            {
                return false;
            }
            string str = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (str.IndexOf(Id.Remove(2)) == -1)
            {
                return false;
            }
            string s = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (!DateTime.TryParse(s, out time))
            {
                return false;
            }
            string[] strArray = "1,0,x,9,8,7,6,5,3,2".Split(new char[] { ',' });
            string[] strArray2 = "7,9,10,5,8,2,1,6,3,7,9,10,5,8,2".Split(new char[] { ',' });
            char[] chArray = Id.Remove(0x11).ToCharArray();
            int a = 0;
            for (int i = 0; i < 0x11; i++)
            {
                a += int.Parse(strArray2[i]) * int.Parse(chArray[i].ToString());
            }
            int num4 = -1;
            Math.DivRem(a, 11, out num4);
            if (strArray[num4] != Id.Substring(0x11, 1).ToLower())
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 邮箱地址格式验证
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            return RegEmail.Match(inputData.ToLower()).Success;
        }
        public static bool IsHasCHZN(string inputData)
        {
            return RegCHZN.Match(inputData).Success;
        }
        public static bool isContainSameChar(string strInput)
        {
            string charInput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                charInput = strInput.Substring(0, 1);
            }
            return isContainSameChar(strInput, charInput, strInput.Length);
        }
        public static bool isContainSameChar(string strInput, string charInput, int lenInput)
        {
            if (string.IsNullOrEmpty(charInput))
            {
                return false;
            }
            Regex regex = new Regex(string.Format("^([{0}])+$", charInput));
            return regex.Match(strInput).Success;
        }




        /// <summary>
        /// 整数格式验证
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            return RegNumber.Match(inputData).Success;
        }


        /// <summary>
        /// 小数格式验证
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            return RegDecimal.Match(inputData).Success;
        }


        /// <summary>
        /// 日期格式验证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    DateTime.Parse(str);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 手机号码格式验证
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsPhone(string inputData)
        {
            if (string.IsNullOrEmpty(inputData) || inputData.Trim().Length != 11) return false;
            return RegPhone.Match(inputData).Success;
        }

        #endregion



        #region 图片格式验证
        public static bool ContainsImage(object objImageUrl)
        {
            if (DBNull.Value == objImageUrl || null == objImageUrl || string.IsNullOrEmpty(objImageUrl.ToString()) || objImageUrl.ToString().Trim().Length < 3 || objImageUrl.ToString().IndexOf(".") == -1)
            {
                return false;
            }
            else
            {
                bool bImage = false;
                string[] strArr = objImageUrl.ToString().Split(new char[] { '|' });
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strArr[i].Trim().Length > 3 && IsImageExt(strArr[i]))
                    {
                        bImage = true;
                        break;
                    }
                }
                return bImage;
            }
        }

        /// <summary>
        /// 图片格式验证 | ".jpg", ".jpeg", ".gif", ".png", ".bmp"
        /// </summary>
        /// <param name="objImageUrl"></param>
        /// <returns></returns>
        public static bool IsImageExt(object objImageUrl)
        {
            if (DBNull.Value == objImageUrl || null == objImageUrl || string.IsNullOrEmpty(objImageUrl.ToString()) || objImageUrl.ToString().Trim().Length < 3 || objImageUrl.ToString().IndexOf(".") == -1)
            {
                return false;
            }
            string objExt = objImageUrl.ToString().Trim().ToLower();
            string[] strExt = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
            List<string> lstExt = new List<string>();
            for (int i = 0; i < strExt.Length; i++)
            {
                lstExt.Add(strExt[i]);
            }

            return lstExt.Contains(Path.GetExtension(objExt));
        }

        /// <summary>
        /// 存在则删除图片
        /// </summary>
        /// <param name="objImageUrl"></param>
        public static void TryDeleteImage(object objImageUrl)
        {
            if (SL.IsImageExt(objImageUrl))
            {
                File.Delete(HttpContext.Current.Server.MapPath(objImageUrl.ToString()));
            }
        }
        #endregion


        #region 输出图片




        public static string OutImage(object imgUrl)
        {
            return OutImage(imgUrl, 0, 0);
        }

        public static string OutImage(object imgUrl, int nWidth, int nHeight)
        {
            if (!IsImageExt(imgUrl)) return "";

            string result = "";
            result += string.Format("<a href='{0}' target='_blank'><img src='{0}' onerror='javascript:loaderrorpic(this)'  style='vertical-align:middle;", imgUrl.ToString().Trim());
            if (nWidth > 0)
                result += string.Format(" width:{0}px; ", nWidth);
            if (nHeight > 0)
                result += string.Format(" height:{0}px; ", nHeight);
            result += "' /></a>";
            return result;
        }
        #endregion



        #region 窗口显示方式 alert,confirm
        public static void Show(Page page, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = GetText(text);
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + text + "');</script>");
            }
        }

        public static void Show(Page page, string text, string url)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = GetText(text);
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + text + "');window.location=\"" + url + "\"</script>");
            }
        }

        public static void ShowConfirm(WebControl Control, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = GetText(text);
                Control.Attributes.Add("onclick", "return confirm('" + text + "');");
            }
        }
        #endregion


        #region 验证对象值是否为空
        /// <summary>
        /// 验证对象值是否为空
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static bool ObjectValueIsInvalid(object objValue)
        {
            if (null == objValue || DBNull.Value == objValue || objValue.ToString().Length == 0)
            {
                return false;
            }
            return true;
        }

        public static bool GetBooleanValue(object objValue)
        {
            if (null == objValue || DBNull.Value == objValue || objValue.ToString().Length == 0)
            {
                return false;
            }
            else if (objValue.ToString().Equals("1"))
            {
                return true;
            }
            else if (objValue.ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(objValue);
            }
        }
        #endregion


        #region 随机取值
        private static Random _Rnd = new Random();
        /// <summary>   
        /// 产生随机字符串   
        /// </summary>   
        /// <param name="num">随机出几个字符</param>   
        /// <returns>随机出的字符串</returns>   
        public static string GetRandomTexts(int num)
        {
            string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chastr = str.ToCharArray();
            string code = "";
            int i;
            for (i = 0; i < num; i++)
            {
                code += str.Substring(_Rnd.Next(0, str.Length), 1);
            }
            return code;
        }

        /// <summary>
        /// 产生随机纯数字字符串
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetRandomNumbers(int num)
        {
            string str = "0123456789";
            char[] chastr = str.ToCharArray();
            string code = "";
            int i;
            for (i = 0; i < num; i++)
            {
                code += str.Substring(_Rnd.Next(0, str.Length), 1);
            }
            return code;
        }


        /// <summary>
        /// 产生随机纯文本字符串
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetRandomWords(int num)
        {
            string str = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chastr = str.ToCharArray();
            string code = "";
            int i;
            for (i = 0; i < num; i++)
            {
                code += str.Substring(_Rnd.Next(0, str.Length), 1);
            }
            return code;
        }
        #endregion


        #region 字符类型转化
        /// <summary>
        /// 转化为double类型
        /// </summary>
        /// <param name="szVal"></param>
        /// <returns></returns>
        public static double StringToDBDouble(string szVal)
        {
            if (!string.IsNullOrEmpty(szVal))
            {
                try
                {
                    return Convert.ToDouble(szVal);
                }
                catch
                {
                }
            }
            return 0;
        }

        public static decimal StringToDBDecimal(string szVal)
        {
            if (!string.IsNullOrEmpty(szVal))
            {
                try
                {
                    return Convert.ToDecimal(szVal);
                }
                catch
                {
                }
            }
            return 0;
        }


        /// <summary>
        /// 转化为double类型
        /// </summary>
        /// <param name="szVal"></param>
        /// <returns></returns>
        public static int StringToDBInt(string szVal)
        {
            if (!string.IsNullOrEmpty(szVal))
            {
                try
                {
                    return Convert.ToInt32(szVal);
                }
                catch
                {
                }
            }
            return 0;
        }

        /// <summary>
        /// 对象转字符串
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static string DBToString(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal)
            {
                return "";
            }
            return objVal.ToString().Trim();
        }

        /// <summary>
        /// 整形转字符（为0时转为空）
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static string DBIntToString(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal || Convert.ToInt32(objVal) == 0)
            {
                return "";
            }
            return Convert.ToInt32(objVal).ToString();
        }

        /// <summary>
        /// 浮点转字符（为0时转为空）
        /// </summary>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static string DBDoubleToString(object objVal)
        {
            if (DBNull.Value == objVal || null == objVal || Convert.ToDouble(objVal) == 0)
            {
                return "";
            }
            return ToMoney(true, objVal);
        }

        /// <summary>
        ///  转货币格式，千分位带逗号(,)
        /// </summary>
        /// <param name="objMoney"></param>
        /// <returns></returns>
        public static string ToMoney(object objMoney)
        {
            return ToMoney(false, objMoney);
        }

        /// <summary>
        /// 金额转化（小数点保留2位、3位或4位）
        /// </summary>
        /// <param name="blFlag">true:千分位不带逗号, false:带逗号</param>
        /// <param name="objMoney"></param>
        /// <returns></returns>
        public static string ToMoney(bool blFlag, object objMoney)
        {
            double nMoney = 0;
            if (objMoney != null)
            {
                double.TryParse(objMoney.ToString(), out nMoney);
            }

            string szMoney = nMoney.ToString("N4");
            if (blFlag)
            {
                szMoney = nMoney.ToString("F4");
            }
            string szIntMoney = szMoney.Substring(0, szMoney.IndexOf("."));
            string szDigitalMoney = szMoney.Substring(szMoney.IndexOf(".") + 1);
            StringBuilder szVal = new StringBuilder();
            for (int i = 0; i < szDigitalMoney.Length; i++)
            {

                if (i < 2)
                {
                    szVal.Append(szDigitalMoney[i]);
                }
                else
                {

                    if (!szDigitalMoney[i].ToString().Equals("0"))
                    {
                        szVal.Append(szDigitalMoney[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return szIntMoney + "." + szVal.ToString();
        }


        #endregion



        #region 生日年龄
        /// <summary>
        /// 根据出生日期来获取年龄
        /// </summary>
        public static int GetAgeByBirthday(object objBirthday)
        {
            int age = 0;
            if (DBNull.Value == objBirthday || null == objBirthday)
            {
            }
            else
            {
                try
                {
                    DateTime birthday = DateTime.Parse(objBirthday.ToString());
                    age = DateTime.Now.Year - birthday.Year;
                }
                catch
                {
                }
            }
            return age;
        }
        #endregion


        #region 获取网页内容
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="WebUrl"></param>
        /// <param name="keyword"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetWebPageContents(string WebUrl, string keyword, Encoding encoding)
        {
            CookieContainer cookie = new CookieContainer();
            string contentType = "application/x-www-form-urlencoded;";
            string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
            string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            string pageHtml = "", exceptionInfo = "";

            //编码
            encoding = (null == encoding ? Encoding.UTF8 : encoding);
            string newUrl = WebUrl + (!string.IsNullOrEmpty(keyword) ? System.Uri.EscapeUriString(keyword) : "");
            //不编码：网站如果支持就可以不编码
            //newUrl = url + keyword;

            WebResponse response = null;
            HttpWebRequest request = null;
            Stream responseStream = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(newUrl);
                request.UserAgent = userAgent;
                request.ContentType = contentType;
                request.CookieContainer = cookie;
                request.Accept = accept;
                request.Method = "GET";
                request.Timeout = 30 * 1000;
                //request.Host = "www.gzwebs.net";
                //request.UserAgent = "User-Agent    Mozilla/5.0 (Windows NT 6.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";

                response = request.GetResponse();
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, encoding);
                pageHtml = reader.ReadToEnd();
            }
            catch (System.Net.WebException err)
            {
                exceptionInfo = err.Message;
            }
            catch (Exception err)
            {
                exceptionInfo = err.Message;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (responseStream != null) responseStream.Close();
                if (response != null) response.Close();
                if (request != null) request = null;
            }

            return pageHtml;
        }
        #endregion


        #region 提交数据，并获取返回值
        /// <summary>
        /// 提交数据，并获取返回值
        /// </summary>
        public static string PostDataToServer(string ServerUrl, string data)
        {
            try
            {
                HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(ServerUrl);
                wReq.Method = "POST";
                ASCIIEncoding encoding = new ASCIIEncoding();

                //获取报文的字节数
                byte[] buffer = Encoding.UTF8.GetBytes(data);

                //头部参数设置
                //wReq.Headers.Add("partner", partner); //加入合作Id

                //设置发送的内容长度
                wReq.ContentLength = buffer.Length;

                Stream newStream = wReq.GetRequestStream();
                // Send the data.
                newStream.Write(buffer, 0, buffer.Length);
                newStream.Close();

                HttpWebResponse wRes = (HttpWebResponse)wReq.GetResponse();
                StreamReader sr = new StreamReader(wRes.GetResponseStream(), Encoding.UTF8);

                //获取返回数据，xml格式
                string result = sr.ReadToEnd();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion


        #region 写日志
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="szEvent"></param>
        public static void WriteLog(string szEvent)
        {
            try
            {
                string fileName = "/App_Data/Log/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                string filepath = System.Web.HttpContext.Current.Server.MapPath(fileName);
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Close();
                }
                FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine(string.Format("[{0}]：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), szEvent));
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }
        #endregion

        #region 获取地址栏中的参数值
        #region 获取参数值
        public static string GetQueryString(string paramName, bool bDESDecrypt = false)
        {
            string paramValue = HttpContext.Current.Request.QueryString[paramName];
            paramValue = string.IsNullOrEmpty(paramValue) ? "" : paramValue.Trim();
            if (paramValue.Length > 0 && bDESDecrypt)
            {
                paramValue = SL.DESDecrypt(paramValue);
            }
            return paramValue;
        }

        public static int GetQueryInt(string paramName, bool bDESDecrypt = false)
        {
            string paramValue = SL.GetQueryString(paramName, bDESDecrypt);
            if (paramValue.Length > 0)
            {
                int iValue = 0;
                int.TryParse(paramValue, out iValue);
                return iValue;
            }
            return 0;
        }

        public static string GetFormString(string paramName, bool bDESDecrypt = false)
        {
            string paramValue = HttpContext.Current.Request.Form[paramName];
            paramValue = string.IsNullOrEmpty(paramValue) ? "" : paramValue.Trim();
            if (paramValue.Length > 0 && bDESDecrypt)
            {
                paramValue = SL.DESDecrypt(paramValue);
            }
            return paramValue;

        }

        public static int GetFormInt(string paramName, bool bDESDecrypt = false)
        {
            string paramValue = SL.GetFormString(paramName, bDESDecrypt);
            if (paramValue.Length > 0)
            {
                int iValue = 0;
                int.TryParse(paramValue, out iValue);
                return iValue;
            }
            return 0;
        }
        #endregion



        /// <summary>
        /// 获取参数值（整数），无数值时返回0
        /// </summary>
        public static int GetQueryIntValue(string queryname)
        {
            int rs = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[queryname]))
            {
                int.TryParse(GetQueryStringValue(queryname), out rs);
            }
            return rs;
        }



        /// <summary>
        /// 获取参数值（字符），无数值时返回空
        /// </summary>
        public static string GetQueryStringValue(string queryname)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[queryname]))
            {
                return HttpContext.Current.Request[queryname].ToString().Trim();
            }
            return "";
        }

        public static double GetQueryDoubleValue(string queryname)
        {
            double rs = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[queryname]))
            {
                double.TryParse(GetQueryStringValue(queryname), out rs);
            }
            return rs;
        }

        public static int GetQueryFormIntValue(string queryname)
        {
            int rs = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[queryname]))
            {
                int.TryParse(GetQueryFormStringValue(queryname), out rs);
            }
            return rs;
        }


        public static double GetQueryFormDoubleValue(string queryname)
        {
            double rs = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[queryname]))
            {
                double.TryParse(GetQueryFormStringValue(queryname), out rs);
            }
            return rs;
        }

        public static string GetQueryFormStringValue(string queryname)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form[queryname]))
            {
                return HttpContext.Current.Request.Form[queryname].ToString().Trim();
            }
            return "";
        }

        #endregion




        #region 图片处理
        /// <summary>
        /// 图片水印（图案）
        /// </summary>
        /// <param name="fromFileUrl"></param>
        /// <param name="waterImageUrl"></param>
        /// <param name="alpha"></param>
        /// <param name="postion">0：LeftTop, 1：LeftBottom, 2：RightTop , 3：RigthBottom, 4：TopMiddle , 5：BottomMiddle , 6：Center </param>
        public void ImageDrawWater(string fromFileUrl, string waterImageUrl, float alpha, int position)
        {
            string fromFilePath = HttpContext.Current.Server.MapPath(fromFileUrl);
            string fileExtension = Path.GetExtension(fromFileUrl).ToLower();

            //复制文件
            string ToFilePath = Path.GetDirectoryName(fromFilePath) + "/" + Path.GetFileNameWithoutExtension(fromFilePath) + "_copy" + fileExtension;
            File.Copy(fromFilePath, ToFilePath, true);

            try
            {
                File.Delete(fromFilePath);
            }
            catch { }


            //   
            // 将需要加上水印的图片装载到Image对象中   
            //   
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(ToFilePath);
            //   
            // 确定其长宽   
            //   
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;

            string waterImagePath = HttpContext.Current.Server.MapPath(waterImageUrl);

            string fileSourceExtension = System.IO.Path.GetExtension(ToFilePath).ToLower();
            string fileWaterExtension = System.IO.Path.GetExtension(waterImagePath).ToLower();
            //   
            // 判断文件是否存在,以及类型是否正确   
            //   
            if (System.IO.File.Exists(ToFilePath) == false ||
                System.IO.File.Exists(waterImagePath) == false || (
                fileSourceExtension != ".gif" &&
                fileSourceExtension != ".jpg" &&
                fileSourceExtension != ".png") || (
                fileWaterExtension != ".gif" &&
                fileWaterExtension != ".jpg" &&
                fileWaterExtension != ".png")
                )
            {
                return;
            }

            //   
            // 目标图片名称及全路径   
            //   
            string targetImage = fromFilePath;


            //   
            // 封装 GDI+ 位图，此位图由图形图像及其属性的像素数据组成。   
            //   
            System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(phWidth, phHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //   
            // 设定分辨率   
            //    
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            //   
            // 定义一个绘图画面用来装载位图   
            //   
            System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);

            //   
            //同样，由于水印是图片，我们也需要定义一个Image来装载它   
            //   
            System.Drawing.Image imgWatermark = new System.Drawing.Bitmap(waterImagePath);

            //   
            // 获取水印图片的高度和宽度   
            //   
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;

            //SmoothingMode：指定是否将平滑处理（消除锯齿）应用于直线、曲线和已填充区域的边缘。   
            // 成员名称   说明    
            // AntiAlias      指定消除锯齿的呈现。     
            // Default        指定不消除锯齿。     
            // HighQuality  指定高质量、低速度呈现。     
            // HighSpeed   指定高速度、低质量呈现。     
            // Invalid        指定一个无效模式。     
            // None          指定不消除锯齿。    
            grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //   
            // 第一次描绘，将我们的底图描绘在绘图画面上   
            //   
            grPhoto.DrawImage(imgPhoto,
                                        new System.Drawing.Rectangle(0, 0, phWidth, phHeight),
                                        0,
                                        0,
                                        phWidth,
                                        phHeight,
                                        System.Drawing.GraphicsUnit.Pixel);

            //   
            // 与底图一样，我们需要一个位图来装载水印图片。并设定其分辨率   
            //   
            System.Drawing.Bitmap bmWatermark = new System.Drawing.Bitmap(bmPhoto);
            bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            //   
            // 继续，将水印图片装载到一个绘图画面grWatermark   
            //   
            System.Drawing.Graphics grWatermark = System.Drawing.Graphics.FromImage(bmWatermark);

            //   
            //ImageAttributes 对象包含有关在呈现时如何操作位图和图元文件颜色的信息。   
            //          
            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();

            //   
            //Colormap: 定义转换颜色的映射   
            //   
            System.Drawing.Imaging.ColorMap colorMap = new System.Drawing.Imaging.ColorMap();

            //   
            //我的水印图被定义成拥有绿色背景色的图片被替换成透明   
            //   
            colorMap.OldColor = System.Drawing.Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);

            System.Drawing.Imaging.ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, System.Drawing.Imaging.ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
           new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f}, // red红色   
           new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f}, //green绿色   
           new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f}, //blue蓝色          
           new float[] {0.0f,  0.0f,  0.0f,  alpha, 0.0f}, //透明度        
           new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};//   

            //  ColorMatrix:定义包含 RGBA 空间坐标的 5 x 5 矩阵。   
            //  ImageAttributes 类的若干方法通过使用颜色矩阵调整图像颜色。   
            System.Drawing.Imaging.ColorMatrix wmColorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);


            imageAttributes.SetColorMatrix(wmColorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default,
              System.Drawing.Imaging.ColorAdjustType.Bitmap);

            //   
            //上面设置完颜色，下面开始设置位置   
            //   
            int xPosOfWm;
            int yPosOfWm;

            //0：LeftTop, 1：LeftBottom, 2：RightTop , 3：RigthBottom, 4：TopMiddle , 5：BottomMiddle , 6：Center 
            switch (position)
            {
                case 5:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case 6:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case 1:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case 0:
                    xPosOfWm = 10;
                    yPosOfWm = 10;
                    break;
                case 2:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = 10;
                    break;
                case 3:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case 4:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = 10;
                    break;
                default:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }

            //   
            // 第二次绘图，把水印印上去   
            //   
            grWatermark.DrawImage(imgWatermark,
             new System.Drawing.Rectangle(xPosOfWm,
                                 yPosOfWm,
                                 wmWidth,
                                 wmHeight),
                                 0,
                                 0,
                                 wmWidth,
                                 wmHeight,
                                 System.Drawing.GraphicsUnit.Pixel,
                                 imageAttributes);


            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();

            //   
            // 保存文件到服务器的文件夹里面   
            //   
            imgPhoto.Save(targetImage, System.Drawing.Imaging.ImageFormat.Jpeg);
            imgPhoto.Dispose();
            imgWatermark.Dispose();

            try
            {
                File.Delete(ToFilePath);
            }
            catch { }
        }


        /// <summary>
        /// 图片水印（文字）
        /// </summary>
        /// <param name="fromFileUrl"></param>
        /// <param name="waterWords"></param>
        /// <param name="alpha"></param>
        /// <param name="position">0：LeftTop, 1：LeftBottom, 2：RightTop , 3：RigthBottom, 4：TopMiddle , 5：BottomMiddle , 6：Center </param>
        public static void ImageDrawWord(string fromFileUrl, string waterWords, float alpha, int position)
        {
            string fromFilePath = HttpContext.Current.Server.MapPath(fromFileUrl);
            string fileExtension = Path.GetExtension(fromFileUrl).ToLower();

            //   
            // 判断文件是否存在,以及文件名是否正确   
            //   
            if (System.IO.File.Exists(fromFilePath) == false || (fileExtension != ".gif" && fileExtension != ".jpg" && fileExtension != ".png"))
            {
                return;
            }

            //复制文件
            string ToFilePath = Path.GetDirectoryName(fromFilePath) + "/" + Path.GetFileNameWithoutExtension(fromFilePath) + "_copy" + fileExtension;
            File.Copy(fromFilePath, ToFilePath, true);

            try
            {
                File.Delete(fromFilePath);
            }
            catch { }

            //   
            // 目标图片名称及全路径   
            //   
            string targetImage = fromFilePath;

            //创建一个图片对象用来装载要被添加水印的图片   
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(ToFilePath);

            //获取图片的宽和高   
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;

            //   
            //建立一个bitmap，和我们需要加水印的图片一样大小   
            System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(phWidth, phHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //SetResolution：设置此 Bitmap 的分辨率   
            //这里直接将我们需要添加水印的图片的分辨率赋给了bitmap   
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            //Graphics：封装一个 GDI+ 绘图图面。   
            System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);

            //设置图形的品质   
            grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //将我们要添加水印的图片按照原始大小描绘（复制）到图形中   
            grPhoto.DrawImage(
             imgPhoto,                                           //   要添加水印的图片   
             new System.Drawing.Rectangle(0, 0, phWidth, phHeight), //  根据要添加的水印图片的宽和高   
             0,                                                     //  X方向从0点开始描绘   
             0,                                                     // Y方向    
             phWidth,                                            //  X方向描绘长度   
             phHeight,                                           //  Y方向描绘长度   
             System.Drawing.GraphicsUnit.Pixel);                              // 描绘的单位，这里用的是像素   

            //根据图片的大小我们来确定添加上去的文字的大小   
            //在这里我们定义一个数组来确定   
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };

            //字体   
            System.Drawing.Font crFont = null;
            //矩形的宽度和高度，SizeF有三个属性，分别为Height高，width宽，IsEmpty是否为空   
            System.Drawing.SizeF crSize = new System.Drawing.SizeF();

            //利用一个循环语句来选择我们要添加文字的型号   
            //直到它的长度比图片的宽度小   
            for (int i = 0; i < 7; i++)
            {
                crFont = new System.Drawing.Font("arial", sizes[i], System.Drawing.FontStyle.Bold);

                //测量用指定的 Font 对象绘制并用指定的 StringFormat 对象格式化的指定字符串。   
                crSize = grPhoto.MeasureString(waterWords, crFont);

                // ushort 关键字表示一种整数数据类型   
                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }

            //截边5%的距离，定义文字显示(由于不同的图片显示的高和宽不同，所以按百分比截取)   
            int yPixlesFromBottom = (int)(phHeight * .05);

            //定义在图片上文字的位置   
            float wmHeight = crSize.Height;
            float wmWidth = crSize.Width;

            float xPosOfWm;
            float yPosOfWm;

            switch (position)
            {
                case 5:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case 6:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case 1:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case 0:
                    xPosOfWm = 10;
                    yPosOfWm = 10;
                    break;
                case 2:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = 10;
                    break;
                case 3:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case 4:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = 10;
                    break;
                default:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }

            //封装文本布局信息（如对齐、文字方向和 Tab 停靠位），显示操作（如省略号插入和国家标准 (National) 数字替换）和 OpenType 功能。   
            System.Drawing.StringFormat StrFormat = new System.Drawing.StringFormat();

            //定义需要印的文字居中对齐   
            StrFormat.Alignment = System.Drawing.StringAlignment.Center;

            //SolidBrush:定义单色画笔。画笔用于填充图形形状，如矩形、椭圆、扇形、多边形和封闭路径。   
            //这个画笔为描绘阴影的画笔，呈灰色   
            int m_alpha = Convert.ToInt32(256 * alpha);
            System.Drawing.SolidBrush semiTransBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(m_alpha, 0, 0, 0));

            //描绘文字信息，这个图层向右和向下偏移一个像素，表示阴影效果   
            //DrawString 在指定矩形并且用指定的 Brush 和 Font 对象绘制指定的文本字符串。   
            grPhoto.DrawString(waterWords,                                    //string of text   
                                       crFont,                                         //font   
                                       semiTransBrush2,                            //Brush   
                                       new System.Drawing.PointF(xPosOfWm + 1, yPosOfWm + 1),  //Position   
                                       StrFormat);

            //从四个 ARGB 分量（alpha、红色、绿色和蓝色）值创建 Color 结构，这里设置透明度为153   
            //这个画笔为描绘正式文字的笔刷，呈白色   
            System.Drawing.SolidBrush semiTransBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(153, 255, 255, 255));

            //第二次绘制这个图形，建立在第一次描绘的基础上   
            grPhoto.DrawString(waterWords,                 //string of text   
                                       crFont,                                   //font   
                                       semiTransBrush,                           //Brush   
                                       new System.Drawing.PointF(xPosOfWm, yPosOfWm),  //Position   
                                       StrFormat);

            //imgPhoto是我们建立的用来装载最终图形的Image对象   
            //bmPhoto是我们用来制作图形的容器，为Bitmap对象   
            imgPhoto = bmPhoto;
            //释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满               
            grPhoto.Dispose();

            //将grPhoto保存   
            imgPhoto.Save(targetImage, System.Drawing.Imaging.ImageFormat.Jpeg);
            imgPhoto.Dispose();


            try
            {
                File.Delete(ToFilePath);
            }
            catch { }
        }



        // <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">W,H,HW,Cut</param>
        public static void ImageMakeThumbnail(string fromFilePath, string toFilePath, int width, int height, EUploadMode Mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(fromFilePath);

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (Mode)
            {
                case EUploadMode.HW:
                    break;
                case EUploadMode.W:
                    width = (ow > width ? width : ow);
                    break;
                case EUploadMode.H:
                    height = (oh > height ? height : oh);
                    break;
                case EUploadMode.CUT:
                    break;
                default:
                    break;
            }

            int towidth = width;
            int toheight = height;

            switch (Mode)
            {
                case EUploadMode.HW:     //指定高宽缩放（可能变形）
                    break;
                case EUploadMode.W:     //指定宽，高按比例
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case EUploadMode.H:     //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case EUploadMode.CUT:   //指定高宽裁减（不变形）
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }




            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(toFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="filePath">原图绝对位置</param>
        /// <param name="nLevel">压缩质量 1-100</param>
        /// <returns></returns>
        public static bool ImageCompression(string filePath, int nLevel)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(filePath);

            int dHeight = iSource.Height;
            int dWidth = iSource.Width;

            ImageFormat tFormat = iSource.RawFormat;

            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth) //将**改成c#中的或者操作符号
            {
                if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);

            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);

            g.CompositingQuality = CompositingQuality.HighQuality;

            g.SmoothingMode = SmoothingMode.HighQuality;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量

            EncoderParameters ep = new EncoderParameters();

            long[] qy = new long[1];

            qy[0] = nLevel;//设置压缩的比例1-100

            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);

            ep.Param[0] = eParam;

            try
            {

                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();

                ImageCodecInfo jpegICIinfo = null;

                for (int x = 0; x < arrayICI.Length; x++)
                {

                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }

                //压缩后的文件路径
                string dFile = filePath.Substring(0, filePath.Length - 4) + "_press" + System.IO.Path.GetExtension(filePath);
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }

                iSource.Dispose();
                ob.Dispose();

                File.Delete(filePath);

                //重命名压缩图片为新图
                FileInfo fileInfo = new FileInfo(dFile);
                fileInfo.MoveTo(filePath);


                return true;
            }

            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
                return false;

            }

            finally
            {
                if (iSource != null)
                {
                    try
                    {
                        iSource.Dispose();
                    }
                    catch { }
                }

                if (ob != null)
                {
                    try
                    {
                        ob.Dispose();
                    }
                    catch { }
                }

            }



        }



        /// <summary>
        /// 上传新图片，返回新图片的地址
        /// </summary>
        /// <param name="fileNewDir">新图文件夹，如 /upfile/photo/</param>
        /// <param name="fileOrgUrl">旧图地址，如 /upfile/photo/1.jpg</param>
        /// <returns></returns>
        public static void UploadPhoto(FileUpload ctrlFileUpload, string fileNewDir, ref string fileUrl)
        {
            if (ctrlFileUpload.HasFile)
            {
                if (SL.IsImageExt(fileUrl))
                {
                    //删除旧的文件
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileUrl));
                }

                //上传新的文件
                fileUrl = fileNewDir + DateTime.Now.ToString("yyyyMMddHHmmssffff") + System.IO.Path.GetExtension(ctrlFileUpload.FileName);
                ctrlFileUpload.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(fileUrl));
            }
        }
        #endregion



        #region 发送手机短信
        /// <summary>
        /// 发送手机短信
        /// </summary> 
        public static string SendMobileMessage(string telphone, string strMsg)
        {
            string resultString = string.Empty;
            if (!string.IsNullOrEmpty(telphone) || telphone.Trim().Length == 11)
            {
                string url = string.Format("http://utf8.sms.webchinese.cn/?Uid=puker&Key=54cbc23f01e7ac9f3307&smsMob={0}&smsText={1}", telphone, strMsg);
                resultString = GetHtmlFromUrl(url);
            }
            return resultString;
        }

        public static string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch
            {
                strRet = null;
            }
            return strRet;
        }
        public static string GetResponseText(string strUrl)
        {
            string content = "";
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(strUrl);
            req.Method = "GET";
            using (System.Net.WebResponse wr = req.GetResponse())
            {
                System.Net.HttpWebResponse myResponse = (System.Net.HttpWebResponse)req.GetResponse();
                System.IO.StreamReader reader = new System.IO.StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                content = reader.ReadToEnd();
            }
            return content;
        }
        #endregion


        #region JSON转化
        public static string Encode(object o)
        {
            return JsonUtil.Encode(o);
        }

        public static object Decode(string o)
        {
            return JsonUtil.Decode(o);
        }
        #endregion


        #region 真实IP地址
        /// <summary>
        /// 判断访问的客户端真实IP地址
        /// </summary>
        /// <returns></returns>
        public static String getRemoteHost()
        {
            string IpAddress = "";
            if ((HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
            && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty))
            {
                IpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else
            {
                IpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return IpAddress.Equals("::1") ? "127.0.0.1" : IpAddress;
        }

        #endregion


        #region 分页

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageSize"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns>页码是否存在</returns>
        public static bool GetPager(ref int PageIndex, int RecordCount, int PageSize, out int startIndex, out int endIndex)
        {
            bool isPageExist = false;
            int PageCount = (RecordCount % PageSize == 0 ? RecordCount / PageSize : RecordCount / PageSize + 1);
            PageIndex = (PageIndex < 1 ? 1 : PageIndex);
            isPageExist = PageIndex <= PageCount;
            PageIndex = (PageIndex > PageCount ? PageCount : PageIndex);
            startIndex = (PageIndex - 1) * PageSize + 1;
            endIndex = PageIndex * PageSize;
            return isPageExist;
        }


        public static string GetPagerNavigator(int PageIndex, int RecordCount, string szQueryParams, int DisplayType, string fileName, out int startIndex, out int endIndex)
        {
            int PageSize = 15;//20
            int PageCount = (RecordCount % PageSize == 0 ? RecordCount / PageSize : RecordCount / PageSize + 1);
            PageIndex = (PageIndex < 1 ? 1 : PageIndex);
            PageIndex = (PageIndex > PageCount ? PageCount : PageIndex);
            startIndex = (PageIndex - 1) * PageSize + 1;
            endIndex = PageIndex * PageSize;
            return GetPagerNavigator(PageIndex, PageSize, PageCount, RecordCount, szQueryParams, DisplayType, fileName);
        }


        public static string GetPagerNavigator(int PageIndex, int PageSize, int PageCount, int RecordCount, string szQueryParams, int DisplayType)
        {
            return GetPagerNavigator(PageIndex, PageSize, PageCount, RecordCount, szQueryParams, DisplayType, null);
        }
        /// <summary>
        /// GridView或Table列表分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="RecordCount"></param>
        /// <param name="szQueryParams"></param>
        /// <param name="DisplayType">1：表格，2：li，3：</param>
        /// <param name="fileName">文件名：如/page.aspx</param>
        /// <returns></returns>
        public static string GetPagerNavigator(int PageIndex, int PageSize, int PageCount, int RecordCount, string szQueryParams, int DisplayType, string fileName)
        {

            fileName = (null == fileName || string.IsNullOrEmpty(fileName) ? "" : fileName);

            int ShowPageCount = 5;
            StringBuilder pageList = new StringBuilder();

            if (DisplayType == 1)
            {
                #region 表格方式显示
                pageList.Append("<table width='99%'>");
                pageList.Append("<tr>");
                pageList.AppendFormat("<td class='pager-total'>共 <b>{0}</b> 条记录, <b>{1}</b> 页 </td>", RecordCount, PageCount);
                pageList.AppendFormat("<td class='pager-button'>");
                if (PageCount > 1)
                {
                    pageList.AppendFormat(" <a class='home' href='{0}?pageid=1{1}'>首页</a>", fileName, szQueryParams);
                    if (PageCount > 1 && PageIndex > 1)
                    {
                        pageList.AppendFormat("<a class='prev' href='{0}?pageid={1}{2}'>«上一页</a> ", fileName, PageIndex - 1, szQueryParams);
                    }

                    //显示中间5页面
                    if (PageCount < ShowPageCount)
                    {
                        for (int i = 1; i < PageCount + 1; i++)
                        {
                            pageList.AppendFormat("<a class='{0}'  href='{1}?pageid={2}{3}'>{2}</a> ", (PageIndex == i ? "on" : ""), fileName, i, szQueryParams);
                        }
                    }
                    else
                    {

                        int spanPage = ShowPageCount % 2 == 0 ? ShowPageCount / 2 : ShowPageCount / 2 + 1;

                        int startPageIndex = 0;
                        if (PageIndex <= spanPage)
                        {
                            startPageIndex = 1;
                        }
                        else
                        {
                            if (PageIndex <= PageCount - spanPage)
                            {
                                // 当前4 页，则 4 - 3 + 1 ，结尾为 2
                                // 当前11页，则 11 - 3 + 1 ，结尾为 9
                                startPageIndex = PageIndex - spanPage + 1;
                            }
                            else
                            {
                                // 当前12页，则 14-5+1 ，结尾为 10
                                startPageIndex = PageCount - ShowPageCount + 1;
                            }
                        }


                        int endPageIndex = 0;

                        if (PageIndex <= spanPage)
                        {
                            endPageIndex = ShowPageCount;
                        }
                        else
                        {
                            if (PageIndex <= PageCount - spanPage)
                            {
                                // 当前4 页，则 4 + 3 - 1 ，结尾为 6
                                // 当前11页，则 11 + 3 - 1 ，结尾为 13
                                endPageIndex = PageIndex + spanPage - 1;
                            }
                            else
                            {
                                endPageIndex = PageCount;
                            }
                        }

                        for (int i = startPageIndex; i <= endPageIndex; i++)
                        {
                            //pageList.AppendFormat("<a class='{1}'  href='?pageid={0}{2}'>{0}</a> ", i, PageIndex == i ? "on" : "", szQueryParams);
                            pageList.AppendFormat("<a class='{0}'  href='{1}?pageid={2}{3}'>{0}</a> ", (PageIndex == i ? "on" : ""), fileName, i, szQueryParams);
                        }

                    }

                    if (PageCount > 1 && PageIndex < PageCount)
                    {
                        pageList.AppendFormat("<a class='next' href='{0}?pageid={1}{2}'>下一页»</a> ", fileName, PageIndex + 1, szQueryParams);
                    }
                    pageList.AppendFormat(" <a href='{0}?pageid={1}{2}' class='last'>末页</a>", fileName, PageCount, szQueryParams);
                }
                pageList.Append("</td>");
                pageList.Append("</tr>");
                pageList.Append("</table>");

                if (PageCount > 5)
                {
                    //            pageList.Append("<div class='jumpto'>");
                    //            pageList.Append(@"跳转到：<span class='page-skip'>
                    //                            <input type='text' title='指定页码' class='page-num' style='width:40px' class='only_number'>
                    //                            <span>页</span>                        
                    //                   </span>");
                    //            pageList.Append("</div>");
                }
                #endregion
            }
            else if (DisplayType == 2)
            {
                #region Li方式显示分页
                pageList.Append("<div class='pagein'>");
                pageList.Append("<ul>");
                pageList.AppendFormat("<li class='pageNum'>共<b>{2}</b>条记录, 第<b>{0}/{1}</b>页</li>", PageIndex, PageCount, RecordCount);

                if (PageCount > 1)
                {
                    if (PageCount > ShowPageCount)
                    {
                        pageList.AppendFormat("<li><a class='home' href='{0}?pageid=1{1}' title='首页'><<</a>", fileName, szQueryParams);
                    }

                    if (PageIndex > 1)
                    {
                        pageList.AppendFormat("<li><a class='prev' href='{0}?pageid={1}{2}'><</a></li>", fileName, PageIndex - 1, szQueryParams);
                    }
                    else
                    {
                        pageList.AppendFormat("<li><span class='prev'>< </span></li>");
                    }

                    //显示中间5页面
                    if (PageCount < ShowPageCount)
                    {
                        for (int i = 1; i < PageCount + 1; i++)
                        {
                            if (PageIndex == i)
                            {
                                pageList.AppendFormat("<li><span class='current'>{0}</span></li>", i);
                            }
                            else
                            {
                                pageList.AppendFormat("<li><a href='{0}?pageid={1}{2}'>{1}</a></li>", fileName, i, szQueryParams);
                            }
                        }
                    }
                    else
                    {

                        int spanPage = ShowPageCount % 2 == 0 ? ShowPageCount / 2 : ShowPageCount / 2 + 1;

                        int startPageIndex = 0;
                        if (PageIndex <= spanPage)
                        {
                            startPageIndex = 1;
                        }
                        else
                        {
                            if (PageIndex <= PageCount - spanPage)
                            {
                                // 当前4 页，则 4 - 3 + 1 ，结尾为 2
                                // 当前11页，则 11 - 3 + 1 ，结尾为 9
                                startPageIndex = PageIndex - spanPage + 1;
                            }
                            else
                            {
                                // 当前12页，则 14-5+1 ，结尾为 10
                                startPageIndex = PageCount - ShowPageCount + 1;
                            }
                        }


                        int endPageIndex = 0;

                        if (PageIndex <= spanPage)
                        {
                            endPageIndex = ShowPageCount;
                        }
                        else
                        {
                            if (PageIndex <= PageCount - spanPage)
                            {
                                // 当前4 页，则 4 + 3 - 1 ，结尾为 6
                                // 当前11页，则 11 + 3 - 1 ，结尾为 13
                                endPageIndex = PageIndex + spanPage - 1;
                            }
                            else
                            {
                                endPageIndex = PageCount;
                            }
                        }



                        for (int i = startPageIndex; i <= endPageIndex; i++)
                        {
                            if (PageIndex == i)
                            {
                                pageList.AppendFormat("<li><span class='current'>{0}</span></li>", i);
                            }
                            else
                            {
                                pageList.AppendFormat("<li><a href='{0}?pageid={1}{2}'>{1}</a></li>", fileName, i, szQueryParams);
                            }
                        }
                    }

                    if (PageCount > 1 && PageIndex < PageCount)
                    {
                        pageList.AppendFormat("<li><a class='next' href='{0}?pageid={1}{2}'>></a></li>", fileName, PageIndex + 1, szQueryParams);
                    }
                    else
                    {
                        pageList.Append("<li><span class='prev'> ></span></li>");
                    }

                    if (PageCount > ShowPageCount)
                    {
                        pageList.AppendFormat("<li><a href='{0}?pageid={1}{2}' class='last' title='最后一页'>>></a></li>", fileName, PageCount, szQueryParams);
                    }
                }
                pageList.Append("</ul>");
                pageList.Append("</div>");

                #endregion
            }
            else if (DisplayType == 3)
            {
                //显示总数
                int PrevId = (PageIndex < 1 ? 1 : PageIndex - 1);
                int NextId = (PageIndex >= PageCount ? PageCount : PageIndex + 1);
                int LastId = PageIndex * PageSize > RecordCount ? RecordCount : PageIndex * PageSize;

                if (RecordCount > 0)
                {
                    //pageList.AppendFormat("<span>第 {0} / {1}页 | 共 <b>{2}</b> 条</span>", PageIndex, PageCount, RecordCount);
                    if (RecordCount >= PageSize || 1 == 1)
                    {
                        pageList.AppendFormat(@"<ul>
                                        <li class='pre'><a href='{0}?pageid={1}{2}' title='首页'><<</a></li>
                                        ", fileName, 1, szQueryParams);
                        for (int i = 1; i <= PageCount; i++)
                        {
                            pageList.AppendFormat("<li class='paget {0}'><a href='{1}?pageid={2}{3}'>{2}</a></li>", PageIndex == i ? "on active" : "", fileName, i, szQueryParams);
                        }
                        pageList.AppendFormat(@"<li class='next'><a href='{0}?pageid={1}{2}' title='最后一页'>>></a></li>
                                    </ul>", fileName, PageCount, szQueryParams);
                    }
                }
            }
            else if (DisplayType == 4)
            {
                //显示总数
                int PrevId = (PageIndex < 2 ? 1 : PageIndex - 1);
                int NextId = (PageIndex >= PageCount ? PageCount : PageIndex + 1);
                int LastId = PageIndex * PageSize > RecordCount ? RecordCount : PageIndex * PageSize;

                string prefixUrl = (fileName.IndexOf("?") > -1 ? fileName + "&" : fileName + "?");

                if (RecordCount > 0 && PageCount > 1)
                {
                    pageList.AppendFormat("<div class='pre'><a href='{0}pageid={1}{2}'>上一页</a></div>", prefixUrl, PrevId, szQueryParams);
                    pageList.Append("<ul>");
                    for (int i = 1; i <= PageCount; i++)
                    {
                        pageList.AppendFormat("<li class='paget {0}'><a href='{1}pageid={2}{3}'>{2}</a></li>", PageIndex == i ? "on" : "", prefixUrl, i, szQueryParams);
                    }
                    pageList.Append("</ul>");
                    pageList.AppendFormat("<div class='next'><a href='{0}pageid={1}{2}'>下一页</a></div>", prefixUrl, NextId, szQueryParams);
                }
            }

            return pageList.ToString();
        }

        #endregion


        #region 发邮件
        /// <summary>
        /// 发邮件
        /// </summary>
        public static void SendMail(string smtphost, string username, string password, string sendername,
            string fromaddress, string toaddress, string replyaddress, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(toaddress);

            System.Text.Encoding GB2312 = System.Text.Encoding.GetEncoding("GB2312");
            msg.Subject = subject;
            msg.SubjectEncoding = GB2312;
            msg.Body = body;
            msg.BodyEncoding = GB2312;
            msg.From = new MailAddress(fromaddress, sendername);
            if (!string.IsNullOrEmpty(replyaddress))
            {
                msg.ReplyToList.Add(new MailAddress(replyaddress, sendername));
            }
            msg.IsBodyHtml = true;
            msg.Priority = System.Net.Mail.MailPriority.Normal;
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            client.Port = 25;
            client.Host = smtphost;

            client.Send(msg);
        }

        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="toaddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string toaddress, string subject, string body)
        {
            NameValueCollection collection = System.Configuration.ConfigurationManager.GetSection("SectionGroup/MailSection") as NameValueCollection;
            if (collection != null)
            {
                string smtphost = collection.Get("smtp");
                string username = collection.Get("username");
                string password = collection.Get("password");
                string fromaddress = collection.Get("fromaddress");
                string displayname = collection.Get("displayname");

                MailMessage msg = new MailMessage();
                msg.To.Add(toaddress);
                System.Text.Encoding GB2312 = System.Text.Encoding.GetEncoding("GB2312");
                msg.Subject = subject;
                msg.SubjectEncoding = GB2312;
                msg.Body = body;
                msg.BodyEncoding = GB2312;
                msg.From = new MailAddress(fromaddress, displayname);
                msg.IsBodyHtml = true;
                msg.Priority = System.Net.Mail.MailPriority.Normal;
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential(username, password);
                client.Port = 25;
                client.Host = smtphost;

                client.Send(msg);
            }
        }


        #endregion


        #region 加密解密

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="eStr"></param>
        /// <returns></returns>
        public static string DESEncrypt(string eStr)
        {
            return Common.DESEncrypt.Encrypt(eStr);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="eStr"></param>
        /// <returns></returns>
        public static string DESDecrypt(string eStr)
        {
            return Common.DESEncrypt.Decrypt(eStr);
        }


        #endregion

        #region 提交参数过滤

        public static string FilterQueryValue(object objHtml, bool bHtml = false)
        {
            bool isFilter = false;
            return FilterQueryValue(out isFilter, objHtml, bHtml);

        }

        /// <summary>
        /// 安全内容
        /// </summary>
        /// <param name="objHtml"></param>
        /// <returns></returns>
        public static string FilterQueryValue(out bool isFilter, object objHtml, bool bHtml = false, string filterWordsContent = "")
        {

            if (filterWordsContent.IsNullOrWhiteSpace())
            {
                filterWordsContent = FilterWordsContents;

            }
            //


            string strHtml = string.Empty;
            isFilter = false;

            if (objHtml != null && objHtml.ToString().Trim().Length > 0)
            {
                strHtml = objHtml.ToString().Trim();
                int countSorce = strHtml.Length;

                Regex regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
                Regex regex2 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
                Regex regex3 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
                Regex regex4 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);

                strHtml = regex1.Replace(strHtml, "");
                strHtml = regex2.Replace(strHtml, "");
                strHtml = regex3.Replace(strHtml, "");
                strHtml = regex4.Replace(strHtml, "");

                if (!bHtml)
                {
                    Regex regex5 = new Regex(@"(?is)<style[^>]*>.*?</style>", RegexOptions.IgnoreCase);
                    Regex regex6 = new Regex(@"<[^<>]*>", RegexOptions.IgnoreCase);
                    Regex regex7 = new Regex(@"<.+?>", RegexOptions.IgnoreCase);
                    strHtml = regex5.Replace(strHtml, "");
                    strHtml = regex6.Replace(strHtml, "");
                    strHtml = regex7.Replace(strHtml, "");

                    strHtml = strHtml.Replace("<", "&lt;");
                    strHtml = strHtml.Replace(">", "&gt;");

                    // 过滤 SQL执行语句
                    strHtml = FilterSqlInjection(strHtml);
                }

                // 过滤 敏感词
                if (!string.IsNullOrEmpty(strHtml))
                {
                    string filterWordContents = filterWordsContent.Replace("\r", " ").Replace("\n", " ");
                    if (!string.IsNullOrEmpty(filterWordContents))
                    {
                        string[] filterWords = filterWordContents.Split(new char[] { ' ' });
                        if (filterWords.Length > 0)
                        {
                            for (int i = 0; i < filterWords.Length; i++)
                            {
                                string word = filterWords[i].Trim();
                                if (word.Length > 0 && word.IndexOf(".") == -1 && strHtml.IndexOf(word) > -1)
                                {
                                    strHtml = strHtml.Replace(word, new string('*', word.Length));

                                    isFilter = true;
                                }
                            }
                        }
                    }
                }
                isFilter = isFilter || (countSorce != strHtml.Length);
            }
            return strHtml;
        }

        /// <summary>
        /// 防止sql注入,替换危险字符
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string FilterSqlInjection(string Text)
        {
            string[] replace = new string[] { "sp_", "'", "create ", "drop ", "\"", "exec ", "xp_", "insert ", "delete ", "select ", "update ", "like ", "or ", "alert" };
            foreach (string str in replace)
            {
                Text = Regex.Replace(Text, str, "", RegexOptions.IgnoreCase);
            }
            return Text;
        }

        /// <summary>
        /// 通过正则表达示过滤敏感关键词
        /// </summary>
        /// <param name="contents"></param>
        /// <param name="filterWord"></param>
        /// <returns></returns>
        private static string FilterBadWordsByMatch(string contents, string filterWord)
        {
            if (string.IsNullOrEmpty(contents) || string.IsNullOrEmpty(filterWord))
            {
                return "";
            }

            if (filterWord.IndexOf("*") > -1)
            {
                string pattern = "";

                int total = 0;
                string[] arrays = filterWord.Split(new char[] { '*' });

                for (int j = 0; j < arrays.Length; j++)
                {
                    if (string.IsNullOrEmpty(arrays[j]) && j < arrays.Length - 1)
                    {
                        total++;
                        continue;
                    }
                    else
                    {
                        if (j > 0)
                        {
                            string ps = @"((\s)*?(\w)(\s)*?){" + (total + 1) + "}";
                            pattern += ps;
                        }

                        pattern += arrays[j];
                        total = 0;
                    }
                }

                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                contents = regex.Replace(contents, "");
            }
            else
            {
                contents = contents.Replace(filterWord, new string('*', filterWord.Length));
            }

            return contents;
        }

        #endregion 提交参数过滤



        #region 将DataSet转Model
        public static string GetObjectValue(System.Reflection.PropertyInfo propertyInfo, object objValue)
        {
            if (null == objValue) return "";


            string result = null;
            switch (propertyInfo.PropertyType.ToString())
            {
                case "System.Boolean":
                    if (null == objValue || string.IsNullOrEmpty(objValue.ToString()))
                    {
                        result = "0";
                    }
                    else
                    {
                        if ("1".Equals(objValue.ToString()) || "0".Equals(objValue.ToString()))
                        {
                            result = Convert.ToInt32(objValue).ToString();
                        }
                        else
                        {
                            if ("true".Equals(objValue.ToString().ToLower()) || "false".Equals(objValue.ToString().ToLower()))
                            {
                                result = Convert.ToBoolean(objValue) ? "1" : "0";
                            }
                            else
                            {
                                result = objValue.ToString().Trim();
                            }
                        }
                    }
                    break;

                case "System.Int32":
                    if (null == objValue || objValue.ToString().Length == 0)
                    {
                        result = "0";
                    }
                    else
                    {
                        int n = 0;
                        int.TryParse(objValue.ToString(), out n);
                        result = n.ToString();
                    }
                    break;

                case "System.DateTime":
                    result = Convert.ToDateTime(objValue).ToString("yyyy-MM-dd HH:mm:ss");
                    break;

                case "System.Nullable`1[System.DateTime]":
                    result = Convert.ToDateTime(objValue).ToString("yyyy-MM-dd HH:mm:ss");
                    break;


                default:
                    result = objValue.ToString().Trim();
                    break;
            }

            return result;
        }
        public static T SetObjectValue<T>(System.Reflection.PropertyInfo propertyInfo, T model, string text)
        {


            switch (propertyInfo.PropertyType.ToString())
            {
                case "System.String":
                    propertyInfo.SetValue(model, text, null);
                    break;

                case "System.Boolean":
                    bool b = false;
                    if ("true".Equals(text.ToLower()) || "1".Equals(text)) b = true;
                    if ("false".Equals(text.ToLower()) || "0".Equals(text)) b = false;
                    propertyInfo.SetValue(model, b, null);
                    break;

                case "System.Int32":
                    int n = 0;
                    int.TryParse(text, out n);
                    propertyInfo.SetValue(model, n, null);
                    break;

                case "System.Decimal":
                    decimal dm = 0.00m;
                    Decimal.TryParse(text, out dm);
                    propertyInfo.SetValue(model, dm, null);
                    break;

                case "System.Double":
                    double db = 0.00;
                    Double.TryParse(text, out db);
                    propertyInfo.SetValue(model, db, null);
                    break;

                case "System.DateTime":

                    if (!string.IsNullOrEmpty(text))
                    {
                        propertyInfo.SetValue(model, Convert.ToDateTime(text), null);
                    }
                    break;

                case "System.Nullable`1[System.DateTime]":
                    try
                    {
                        propertyInfo.SetValue(model, (DateTime?)DateTime.ParseExact(text, "yyyy-MM-dd HH:mm:ss", null), null);
                    }
                    catch
                    {
                        propertyInfo.SetValue(model, (DateTime?)DateTime.ParseExact(text, "yyyy-MM-dd", null), null);
                    }
                    break;
                default:
                    propertyInfo.SetValue(model, null, null);
                    break;
            }
            return model;
        }

        /// <summary>
        /// 将DataSet转List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dsList"></param>
        /// <returns></returns>
        public static List<T> DataSetToModel<T>(DataSet dsList)
        {
            List<T> result = new List<T>();

            if (dsList != null)
            {
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    T obj = DataRowToModel<T>(row);
                    result.Add(obj);
                }
            }
            return result;
        }


        /// <summary>
        /// 将DataRow转T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dsList"></param>
        /// <returns></returns>
        public static T DataRowToModel<T>(DataRow row)
        {
            T obj = Activator.CreateInstance<T>();
            if (row != null)
            {
                Type tp = obj.GetType();
                System.Reflection.PropertyInfo[] ps = tp.GetProperties();
                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    foreach (DataColumn col in row.Table.Columns)
                    {

                        if (col.ColumnName.ToLower().Equals(p.Name.ToLower()))
                        {
                            object value = row[p.Name];
                            string text = (null == value ? "" : value.ToString().Trim());
                            obj = SetObjectValue(p, obj, text);
                            break;
                        }
                    }

                }
            }
            return obj;
        }

        public static T XmlNodeToModel<T>(XmlNode node)
        {
            T obj = Activator.CreateInstance<T>();
            Type tp = obj.GetType();
            System.Reflection.PropertyInfo[] ps = tp.GetProperties();

            foreach (System.Reflection.PropertyInfo p in ps)
            {
                object value = node.ParentNode[p.Name.Trim().ToLower()].InnerText;
                string text = GetObjectValue(p, value);

                obj = SetObjectValue(p, obj, text);
            }

            return obj;
        }
        #endregion

        #region 获取分页代码
        /// <summary>
        /// 分页代码
        /// </summary>
        /// <param name="RecordCount"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="hrefTextSuffix"></param>
        /// <returns></returns>
        public static string GetPaginationJSCode(int RecordCount, int CurrentPage, int PageSize, string hrefTextSuffix = "")
        {
            string queryString = "";
            if (string.IsNullOrEmpty(hrefTextSuffix))
            {
                if (HttpContext.Current.Request.QueryString != null)
                {
                    foreach (string key in HttpContext.Current.Request.QueryString)
                    {
                        if (!"page".Equals(key))
                        {
                            queryString += string.Format("&{0}={1}", key, HttpContext.Current.Request.QueryString[key]);
                        }
                    }
                }
            }

            string jsPagerCode = string.Format(@" <link rel='stylesheet' type='text/css' href='/style/css/simplePagination.css' />
                                                <script src='/js/jquery.simplePagination.js' type='text/javascript'></script>");

            jsPagerCode += @"<script>
                                              $(function(){
                                                     $('#light-pagination').pagination({";
            jsPagerCode += string.Format(@"
                                                            items:  {0},
                                                            currentPage:{1},
                                                            itemsOnPage: {2},
                                                            cssStyle: 'page-theme',
                                                            hrefTextPrefix:'?page=',
                                                            hrefTextSuffix: {3} ", RecordCount, CurrentPage, PageSize, string.IsNullOrEmpty(hrefTextSuffix) ? string.Format(" '{0}' ", queryString) : hrefTextSuffix.Trim());
            jsPagerCode += @"        });   ";

            if (RecordCount == 0)
            {
                jsPagerCode += "  $('.allNum').hide(); ";
            }

            jsPagerCode += @"  var _wpage = $('.pageTurning .r').width()+30;
                                               
                                  }); </script>";
            // $('.pageTurning').attr('style', 'margin:30px auto;width:' + _wpage + 'px'); 


            return jsPagerCode;

            /* 如果调用： onPageClick事件如下
             * onPageClick: changePage
             *   function changePage() {
                        page_index = $("#light-pagination").pagination('getCurrentPage') - 1;   
                    }
             */
        }
        #endregion

        /// <summary>
        /// 转化为带http://的地址
        /// </summary>
        /// <param name="objImageURL"></param>
        /// <param name="web">0 官网  1 物流城共用（由后台地址决定） 2 物流城地址</param>
        /// <returns></returns>
        public static string GetHttpImageURL(object objImageURL, int web = 0)
        {
            if (!IsImageExt(objImageURL)) return "";

            string imageURL = objImageURL.ToString().Trim();
            string strDomain = "";
            //         
            //if (imageURL.IndexOf("http://") == -1)
            //{
            //    if (imageURL.ToString().IndexOf("/") != 0)
            //    {
            //        imageURL = "http://" + strDomain + "/" + imageURL;
            //    }
            //    else
            //    {
            //        imageURL = "http://" + strDomain + imageURL;
            //    }
            //}
            return imageURL;
        }






        #region 常数

        private const string FilterWordsContents = @"和谐 党 俯卧撑 SB 妈 母 娘 逼 粪 屎 放屁 社会主义 人木又 政府 无界 GFW 煤矿 坦克 独裁 领导人 垃圾 lj 公安 警察 藏 网监 人大";

        #endregion 常数


    }


}



