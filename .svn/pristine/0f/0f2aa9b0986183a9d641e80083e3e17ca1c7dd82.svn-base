
using System.Web.Script.Serialization;

namespace Entity
{
    /// <summary>
    /// JSON response.
    /// </summary>
    public class JsonResponse
    {
        #region Properties

        /// <summary>
        ///     UserID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        ///     UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     HeadImgUrl
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        ///    NickName
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        ///     UserDesc
        /// </summary>
        public string UserDesc { get; set; }
        /// <summary>
        /// 成功可能时返回的数据
        /// </summary>
        public bool isColl { get; set; }
        /// <summary>
        ///     Gets or sets Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether Success.
        /// </summary>
        public bool Success { get; set; }

        public int Type { get; set; }

        #endregion
    }

    /// <summary>
    /// JSON response with a strongly typed data.
    /// </summary>
    public class JsonResponse<T>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets Data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///     Gets or sets Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether Success.
        /// </summary>
        public bool Success { get; set; }

        #endregion
    }

    public class AjaxResult
    {
        private bool iserror;
        private bool islogoff;

        private AjaxResult()
        {
        }

        /// <summary>
        /// 是否产生错误
        /// </summary>
        public bool IsError
        {
            get { return iserror; }
        }

        /// <summary>
        /// 是否产生错误
        /// </summary>
        public bool IsLogOff
        {
            get { return islogoff; }
        }

        /// <summary>
        /// 错误信息，或者成功信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功可能时返回的数据
        /// </summary>
        public object Data { get; set; }



        #region Error

        public static AjaxResult Error()
        {
            return new AjaxResult
            {
                iserror = true
            };
        }

        public static AjaxResult Error(string message)
        {
            return new AjaxResult
            {
                iserror = true,
                Message = message
            };
        }

        public static AjaxResult LogOff(string message)
        {
            return new AjaxResult
            {
                islogoff = true,
                Message = message
            };
        }

        #endregion

        #region Success

        public static AjaxResult Success()
        {
            return new AjaxResult
            {
                iserror = false
            };
        }

        public static AjaxResult Success(string message)
        {
            return new AjaxResult
            {
                iserror = false,
                Message = message
            };
        }

        public static AjaxResult Success(object data)
        {
            return new AjaxResult
            {
                iserror = false,
                Data = data
            };
        }

        public static AjaxResult Success(object data, string message)
        {
            return new AjaxResult
            {
                iserror = false,
                Data = data,
                Message = message
            };
        }

        #endregion

        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
