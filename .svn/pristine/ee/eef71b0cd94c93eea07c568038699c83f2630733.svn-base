using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Tools
{
    /// <summary> 
    /// Stops the ASP.NET AppDomain being restarted (which clears 
    /// Session state, Cache etc.) whenever a folder is deleted. 
    /// </summary> 
    public class StopAppDomainRestartOnFolderDeleteModule : IHttpModule
    {
        private static bool DisableFCNs = false;
        public void Init(HttpApplication context)
        {
            if (DisableFCNs) return;
            PropertyInfo p = typeof(HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            object o = p.GetValue(null, null);
            FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            object monitor = f.GetValue(o);
            MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
            m.Invoke(monitor, new object[] { });
            DisableFCNs = true;
        }
        public void Dispose() { }
    } 
}
