using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;
using Tools.DataStore.Providers;
//using Tools.WidgetsManage.Providers;

namespace Tools.DataStore
{
    public class StringDictionaryBehavior: ISettingsBehavior
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public StringDictionaryBehavior()
        {
           
        }

        private int siteid = 0;
        //private static ProviderSection _section = (ProviderSection)ConfigurationManager.GetSection("BlogEngine/blogProvider");
        /// <summary>
        /// Saves String Dictionary to Data Store
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension Id</param>
        /// <param name="settings">StringDictionary settings</param>
        /// <returns></returns>
        public bool SaveSettings(ExtensionType exType, string exId, object settings)
        {
            try
            {
                StringDictionary sd = (StringDictionary)settings;
                SerializableStringDictionary ssd = new SerializableStringDictionary();

                foreach (DictionaryEntry de in sd)
                {
                    ssd.Add(de.Key.ToString(), de.Value.ToString());
                }

                XmlProviders.SaveToDataStore(exType, exId, ssd);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retreaves StringDictionary object from database or file system
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension Id</param>
        /// <returns>StringDictionary object as Stream</returns>
        public object GetSettings(ExtensionType exType, string exId)
        {
            SerializableStringDictionary ssd = null;
            StringDictionary sd = new StringDictionary();
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableStringDictionary));

            Stream stm = (Stream)XmlProviders.LoadFromDataStore(exType, exId);
            if (stm != null)
            {
                ssd = (SerializableStringDictionary)serializer.Deserialize(stm);
                stm.Close();
                sd = (StringDictionary)ssd;
            }
            return sd;
        }
    }
}
