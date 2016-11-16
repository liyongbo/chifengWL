using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBFactory
{
    public sealed class DataAccess
    {
        public static DataProviderCms DALCMS()
        {
            return new DataProviderCms();
        }

    }
}
