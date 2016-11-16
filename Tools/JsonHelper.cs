using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace Tools
{
    public class JsonHelper
    {
        #region DataContractJsonSerializer


        /// <summary>
        /// 对象转换成json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string DataContractJsonSerialize<T>(T jsonObject)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            string json = null;
            using (MemoryStream ms = new MemoryStream()) //定义一个stream用来存发序列化之后的内容
            {
                serializer.WriteObject(ms, jsonObject);
                json = Encoding.UTF8.GetString(ms.GetBuffer()); //将stream读取成一个字符串形式的数据，并且返回
                ms.Close();
            }
            return json;
        }

        /// <summary>
        /// 对象转换成json
        /// </summary>
        /// <param name="obj">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string SerializeToJson(object obj)
        { 
            JavaScriptSerializer JS = new JavaScriptSerializer();
            string json = string.Empty;
            if (obj != null)
                json = JS.Serialize(obj);
            return json;
        }

        /// <summary>   
        /// 数据表转键值对集合   
        /// 把DataTable转成 List集合, 存每一行   
        /// 集合中放的是键值对字典,存每一列   
        /// </summary>   
        /// <param name="dt">数据表</param>   
        /// <returns>哈希表数组</returns>   
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list
                 = new List<Dictionary<string, object>>();

            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }  

        /// <summary>
        /// json字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">要转换成对象的json字符串</param>
        /// <returns></returns>
        public static T DataContractJsonDeserialize<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            T obj = default(T);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
            }
            return obj;
        }


        public static T Deserialize<T>(string content) where T : new()
        {
            var restResponse = new RestSharp.RestResponse { Content = content };
            var d = new RestSharp.Deserializers.JsonDeserializer();
            var payload = d.Deserialize<T>(restResponse);
            return payload;
        }

        #endregion

    }
}
