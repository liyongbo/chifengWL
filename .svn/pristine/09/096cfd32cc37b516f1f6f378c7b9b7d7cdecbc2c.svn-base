using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
    public class DataConvert
    {


        /// <summary>
        /// 此方法用于检查用户输入除了数字是否包含其他
        /// </summary>
        public static int CleanNonNumber(string text)
        {
            return ToInt32(System.Text.RegularExpressions.Regex.Replace(text, "\\D", ""));
        }
        /// <summary>
        /// 此方法用于确认用户输入的不是恶意信息
        /// </summary>
        /// <param name="text">用户输入信息</param>
        /// <param name="maxLength">输入的最大长度</param>
        /// <returns>处理后的输入信息</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            //将网页中非法和有攻击性的符号替换掉，以防sql注入！返回正常数据
            text = System.Text.RegularExpressions.Regex.Replace(text, "[\\s]{2,}", " ");	// 2个或以上的空格
            text = System.Text.RegularExpressions.Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br> html换行符
            text = System.Text.RegularExpressions.Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;   html空格符
            text = System.Text.RegularExpressions.Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	// 任何其他的标签
            text = text.Replace("'", "''");// 单引号
            return text;
        }
        /// <summary>
        /// 此方法用于确认用户输入的不是恶意信息
        /// </summary>
        /// <param name="text">用户输入信息</param>
        /// <param name="maxLength">输入的最大长度</param>
        /// <returns>处理后的输入信息</returns>
        public static string InputText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = text.Trim();
            //将网页中非法和有攻击性的符号替换掉，以防sql注入！返回正常数据
            text = System.Text.RegularExpressions.Regex.Replace(text, "[\\s]{2,}", " ");	// 2个或以上的空格
            text = System.Text.RegularExpressions.Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br> html换行符
            text = System.Text.RegularExpressions.Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;   html空格符
            text = System.Text.RegularExpressions.Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	// 任何其他的标签
            text = text.Replace("'", "''");// 单引号
            return text;
        }
        public static string InputTex2t(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = text.Trim();
            //将网页中非法和有攻击性的符号替换掉，以防sql注入！返回正常数据
            text = System.Text.RegularExpressions.Regex.Replace(text, "[\\s]{2,}", " ");	// 2个或以上的空格
            //text = System.Text.RegularExpressions.Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br> html换行符
            text = System.Text.RegularExpressions.Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;   html空格符
            text = System.Text.RegularExpressions.Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	// 任何其他的标签
            text = text.Replace("'", "''");// 单引号
            return text;
        }

        /// <summary>
        /// 对象转换成整型
        /// </summary>
        /// <param name="value">要转换的对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt32(object value, int defaultValue)
        {
            int returnValue;
            try
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    returnValue = defaultValue;
                else
                    returnValue = Convert.ToInt32(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }
        public static Int64 ToInt64(object value, Int64 defaultValue)
        {
            Int64 returnValue;
            try
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    returnValue = defaultValue;
                else
                    returnValue = Convert.ToInt64(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }
        /// <summary>
        /// 对象转换成Byte
        /// </summary>
        /// <param name="value">要转换的对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static byte ToByte(object value, byte defaultValue)
        {
            byte returnValue;
            try
            {
                returnValue = Convert.ToByte(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }
        /// <summary>
        /// 对象转换成Byte
        /// </summary>
        /// <param name="value">要转换的对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static byte ToByte(object value)
        {
            byte returnValue;
            try
            {
                returnValue = Convert.ToByte(value);
            }
            catch
            {
                returnValue = 0;
            }
            return returnValue;
        }

        /// <summary>
        /// 对象转换成整型,默认值0
        /// </summary>
        /// <param name="value">要转换的对象</param>
        public static int ToInt32(object value)
        {
            return ToInt32(value, 0);
        }

        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <param name="value">要转换的对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ToString(object value, string defaultValue)
        {
            string returnValue;
            try
            {
                returnValue = Convert.ToString(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(object value)
        {
            return ToString(value, "");
        }

        /// <summary>
        /// 对象转换成Bool型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(object value, bool defaultValue)
        {
            bool returnValue;
            try
            {
                returnValue = Convert.ToBoolean(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        /// <summary>
        /// 对象转换成Bool型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(object value)
        {
            return ToBoolean(value, false);
        }

        /// <summary>
        /// 对象转换成日期
        /// </summary>
        /// <param name="value">要转换的对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object value, DateTime defaultValue)
        {
            DateTime returnValue;
            try
            {
                returnValue = Convert.ToDateTime(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        /// <summary>
        /// 对象转换成日期
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object value)
        {
            return ToDateTime(value, DateTime.Now);
        }

        /// <summary>
        /// 对象转换成十进制类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value, decimal defaultValue)
        {
            decimal returnValue;
            try
            {
                returnValue = Convert.ToDecimal(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        /// <summary>
        /// 对象转换成十进制类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value)
        {
            return ToDecimal(value, 0m);
        }
        /// <summary>
        /// 将对象转换为double
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(object value, double defaultValue)
        {
            double returnValue;
            try
            {
                returnValue = Convert.ToDouble(value);
            }
            catch
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(object value)
        {
            return ToDouble(value, 0);
        }
        /// <summary>
        /// 将当前时间转换成long(unix时间戳)
        /// </summary>
        /// <returns></returns>
        public static long TimeToLong()
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime dtNow = DateTime.Now;
            TimeSpan toNow = dtNow.Subtract(dtStart);
            string timeStamp = toNow.Ticks.ToString();
            timeStamp = timeStamp.Substring(0, timeStamp.Length - 7);
            return ToInt32(timeStamp, 0);
        }
        /// <summary>
        /// 将长整形转换为时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime LongToTime(string timeStamp)
        {
            //string timeStamp = "1144821796";
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }


    }
}
