using System;
using System.IO;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace Tools.DataStore.Providers
{
    static public class XmlProviders
    {
        #region Data Store


        /// <summary>
        /// Loads settings from data storage
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension ID</param>
        /// <returns>Settings as stream</returns>
        public static object LoadFromDataStore(ExtensionType exType, string exId)
        {
            //E:\\web\\EbSite\\Project\\EbSite.Web\\datastore\\widgets\\WidgetsZoneList.xml
            string _fileName = StorageLocation(exType) + exId + ".xml";
            StreamReader reader = null;
            Stream str = null;
            try
            {
                if (!Directory.Exists(StorageLocation(exType)))
                    Directory.CreateDirectory(StorageLocation(exType));

                if (File.Exists(_fileName))
                {
                    reader = new StreamReader(_fileName);
                    str = reader.BaseStream;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return str;
        }

        /// <summary>
        /// Saves settings to data store
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extensio ID</param>
        /// <param name="settings">Settings object</param>
        public static void SaveToDataStore(ExtensionType exType, string exId, object settings)
        {
            string _fileName = StorageLocation(exType) + exId + ".xml";
            try
            {
                if (!Directory.Exists(StorageLocation(exType)))
                    Directory.CreateDirectory(StorageLocation(exType));

                TextWriter writer = new StreamWriter(_fileName);
                XmlSerializer x = new XmlSerializer(settings.GetType());
                x.Serialize(writer, settings);
                writer.Close();
            }
            catch (Exception e)
            {
                string s = e.Message;
                throw;
            }
        }

        /// <summary>
        /// Removes object from data store
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension Id</param>
        public static void RemoveFromDataStore(ExtensionType exType, string exId)
        {
            string _fileName = StorageLocation(exType) + exId + ".xml";
            try
            {
                File.Delete(_fileName);
            }
            catch (Exception e)
            {
                string s = e.Message;
                throw;
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        //public static string GetStorageLocation()
        //{
        //    switch (exType)
        //    {
        //        case ExtensionType.Extension:
        //            return HostingEnvironment.MapPath(Path.Combine(BlogSettings.Instance.StorageLocation, @"datastore\extensions\"));
        //        case ExtensionType.Widget:
        //            return HostingEnvironment.MapPath(Path.Combine(BlogSettings.Instance.StorageLocation, @"datastore\widgets\"));
        //        case ExtensionType.Theme:
        //            return HostingEnvironment.MapPath(Path.Combine(BlogSettings.Instance.StorageLocation, @"datastore\themes\"));
        //    }
        //    return string.Empty;
        //}

        /// <summary>
        /// Data Store Location
        /// </summary>
        /// <param name="exType">Type of extension</param>
        /// <returns>Path to storage directory</returns>
        private static string StorageLocation(ExtensionType exType)
        {
            switch (exType)
            {
                case ExtensionType.Extension:
                    return HostingEnvironment.MapPath(Path.Combine("/", @"datastore\extensions\"));

                case ExtensionType.PlugIn:
                    return HostingEnvironment.MapPath(Path.Combine("/", @"datastore\PluginInfo\"));

                case ExtensionType.Widget:
                    return HostingEnvironment.MapPath(Path.Combine("/", @"Widgets\SetupData\"));
            }
            return string.Empty;
        }
        #endregion
    }
}
