
namespace Tools.DataStore
{
    public class ExtensionSettings : Toos.DataStore.SettingsBase
    {
        public string IISPath = string.Empty;
        /// <summary>
        /// 目前给动态组件用
        /// </summary>
        public ExtensionSettings(string setId)
        {
            SettingID = setId;
            ExType = ExtensionType.Extension;
            SettingsBehavior = new ExtensionSettingsBehavior();
        }
    }
    /// <summary>
    /// 给插件使用
    /// </summary>
    public class PluginSettings : Toos.DataStore.SettingsBase
    {
        /// <summary>
        /// 目前给动态组件用
        /// </summary>
        public PluginSettings(string setId)
        {
            SettingID = setId;
            ExType = ExtensionType.PlugIn;
            SettingsBehavior = new ExtensionSettingsBehavior();
        }
    }
}
