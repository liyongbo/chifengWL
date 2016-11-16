using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Tools
{
    public static class GetConfig
    {

        //private static readonly bool enableCaching = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableCaching"]);
        //private static readonly int XmlConfig = int.Parse(System.Configuration.ConfigurationManager.AppSettings["XmlConfig"]);
        //private static readonly int categoryTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ConfigCacheDuration"]);
        private const string CachingConfig = "Caching{0}";

        private const string PATH = "ConfigsFile\\{0}.xml";
        public static System.Xml.XmlDocument setConfigBefore(String fileName, ref string path)
        {
            path = HttpContext.Current.Server.MapPath(String.Format("\\ConfigsFile\\{0}.xml", fileName));
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(path);
            return xmlDoc;
        }
        public static System.Data.DataTable getConfigNC(String fileName)
        {

            System.Data.DataSet dt = new System.Data.DataSet();


            string file = HttpContext.Current.Request.PhysicalApplicationPath + String.Format(PATH, fileName);

            if (System.IO.File.Exists(file))
            {
                dt.ReadXml(file);
                try
                {
                    return dt.Tables[0];
                }
                catch { return new System.Data.DataTable(); }
            }
            else
            {
                // Create a new XmlTextWriter instance
                System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(file, System.Text.Encoding.UTF8);

                // start writing!
                writer.WriteStartDocument();
                writer.Formatting = System.Xml.Formatting.Indented;
                writer.WriteStartElement("base");
                ////content
                //writer.Formatting = Formatting.Indented;
                //writer.WriteElementString("item", content);
                //writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Close();
                return new System.Data.DataTable();
            }
        }
        /// <summary>
        /// 返回XML文件
        /// </summary>
        /// <param name="file">文件名（不含扩展名，只能是放在ConfigsFile文件夹下的XML格式的文件）</param>
        /// <returns></returns>
        public static System.Data.DataTable getConfig(String fileName)
        {

            System.Data.DataSet dt = new System.Data.DataSet();

            string file = HttpContext.Current.Request.PhysicalApplicationPath + String.Format("ConfigsFile\\{0}.xml", fileName);
            dt.ReadXml(file);
            try
            {
                return dt.Tables[0];
            }
            catch { return new System.Data.DataTable(); }
        }

        public static System.Data.DataSet getConfigSet(String fileName)
        {

            System.Data.DataSet dt = new System.Data.DataSet();

            string file = HttpContext.Current.Request.PhysicalApplicationPath + String.Format(PATH, fileName);

            dt.ReadXml(file);
            return dt;
        }
        ///// <summary>
        ///// 返回XML文件
        ///// </summary>
        ///// <param name="file">文件名（不含扩展名，只能是放在ConfigsFile文件夹下的XML格式的文件）</param>
        ///// <returns></returns>
        //public static System.Data.DataTable getConfigCach(String fileName)
        //{

        //    string key = string.Format("Caching{0}", fileName);
        //    System.Data.DataTable data = (System.Data.DataTable)HttpRuntime.Cache[key];

        //    // Check if the data exists in the data cache
        //    if (data == null)
        //    {
        //        data = getConfig(fileName);
        //        HttpRuntime.Cache.Add(key, data, null, DateTime.Now.AddHours(categoryTimeout), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        //    }
        //    return data;
        //}
        /// <summary>
        /// 把swf文件放在flash文件夹下
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="xmlName">xml文件名，不含扩展名</param>
        /// <param name="xmlName">flash文件名，不含扩展名</param>
        /// <returns></returns>
        public static String getFlash(String width, String height, String xmlName, String flashes)
        {

            System.Text.StringBuilder sbb = new System.Text.StringBuilder();
            sbb.Append("<script type=\"text/javascript\">");
            string pices = String.Empty, linkes = String.Empty, textes = String.Empty;



            System.Xml.XmlDocument xmlDocs = new System.Xml.XmlDocument();
            xmlDocs.Load(HttpContext.Current.Server.MapPath(String.Format("..\\ConfigsFile\\{0}.xml", xmlName)));
            System.Xml.XmlNodeList nodeLists = xmlDocs.SelectSingleNode("bcaster").ChildNodes;//获取bookstore节点的所有子节点

            for (int i = 0; i < nodeLists.Count; i++)
            {
                linkes += ((System.Xml.XmlElement)nodeLists[i]).GetAttribute("imgLink") + "|";
                pices += ".." + ((System.Xml.XmlElement)nodeLists[i]).GetAttribute("imgUrl") + "|";
            }

            sbb.AppendFormat("document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"{0}\" height=\"{1}\">');", width, height);
            sbb.AppendFormat("document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\"><param name=\"movie\" value=\"{0}\"><param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"#F0F0F0\">');", HttpContext.Current.Request.ApplicationPath + "flash/{0}.swf", flashes);
            sbb.AppendFormat("document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"transparent\">');");
            sbb.AppendFormat("document.write('<param name=\"FlashVars\" value=\"bcastr_file={0}&bcastr_link={1}&bcastr_title=&TitleTextColor=0xFFFFFF&TitleBgColor=0xFF6600&TitleBgAlpha=0&TitleBgPosition=100&BtnDefaultColor=0xFF6600&BtnOverColor=0x000033&AutoPlayTime=3&Tween=2&WinOpen=_blank&IsShowBtn=0\">');", pices.Remove(pices.Length - 1), linkes.Remove(linkes.Length - 1));
            //sb.Append("document.write('<param name=\"FlashVars\" value=\"pics={0}&links={1}'&texts={2}&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'\">');");
            sbb.AppendFormat("document.write('<embed src=\"flash/{4}.swf\" FlashVars=\"bcastr_file={0}&bcastr_link={1}&bcastr_title=&TitleTextColor=0xFFFFFF&TitleBgColor=0xFF6600&TitleBgAlpha=0&TitleBgPosition=100&BtnDefaultColor=0xFF6600&BtnOverColor=0x000033&AutoPlayTime=3&Tween=2&WinOpen=_blank&IsShowBtn=0\" width=\"{2}\" height=\"{3}\" loop=\"false\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" salign=\"T\" name=\"scriptmain\" menu=\"false\" wmode=\"transparent\"></embed>');", pices.Remove(pices.Length - 1), linkes.Remove(linkes.Length - 1), width, height, flashes);
            sbb.Append("document.write('</object>');");
            sbb.Append("</script>");
            return sbb.ToString();
        }
        /// <summary>
        /// 返回XML文件
        /// </summary>
        /// <param name="file">文件名（不含扩展名，只能是放在ConfigsFile文件夹下的XML格式的文件）</param>
        /// <returns></returns>
        public static System.Xml.XmlDocument setConfig(String fileName, ref string path)
        {
            path = HttpContext.Current.Server.MapPath(String.Format("\\ConfigsFile\\{0}.xml", fileName));
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(path);
            return xmlDoc;
        }
        public static System.Xml.XmlDocument setConfig2(String fileName, ref string path)
        {
            path = HttpContext.Current.Server.MapPath(String.Format("\\ConfigsFile\\color\\{0}.xml", fileName));
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(path);
            return xmlDoc;
        }

    }
}
