using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{ /// <summary>
    /// 密码加密格式
    /// </summary>
    public enum PassWordType
    {
        /// <summary>
        /// 采用md5加密
        /// </summary>
        MD5 = 0,
        /// <summary>
        /// 采用哈希加密
        /// </summary>
        Hashed = 1,
        /// <summary>
        /// 采用两次md5加密
        /// </summary>
        MD5MD5 = 2,
        /// <summary>
        /// 使用一次md5加密后，加使用一次Hashed加密
        /// </summary>
        MD5Hashed = 3
    }
}
