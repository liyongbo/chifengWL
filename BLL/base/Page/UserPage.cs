using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL.Base.Page
{
    public class UserPage : BasePage
    {
        protected int pageindex = 1;
        protected int pagesize = 10;


        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="serverfilpath"></param>
        /// <param name="filename"></param>
        public void ToDownload(byte[] serverfilpath, string filename)
        {
            MemoryStream fileStream = new MemoryStream(serverfilpath);
            long fileSize = fileStream.Length;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(filename));
            HttpContext.Current.Response.AddHeader("Content-Length", fileSize.ToString());
            Response.ContentType = "application/ms-excel";
            fileStream.Read(serverfilpath, 0, (int)fileSize);
            HttpContext.Current.Response.BinaryWrite(serverfilpath);
            fileStream.Close();
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public UserPage()
        {
            this.Load += new EventHandler(this.UserPage_Load);
        }
        /// <summary>
        /// LOAD�¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UserPage_Load(object sender, EventArgs e)
        {
            //��֤��ǰ�û��Ƿ��Ѿ���¼(�ʺ�+����),�����δ��¼����ת����¼ҳ��
            CheckFrontUserIsLogin();
        }


      

     


        public void initData()
        {
           
        }

   
    }
}