using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Tools
{
    public class ConvertImage
    {
        #region 图片转为base64编码的文本
        /// <summary>
        /// 图片转为base64编码的文本
        /// </summary>
        /// <param name="Imagefilename">图片物理路径</param>
        /// <returns>base64字符串</returns>
        public string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                MemoryStream ms = new MemoryStream();
                string ExtenName = System.IO.Path.GetExtension(Imagefilename);//获取扩展名
                if (ExtenName == ".jpeg" || ExtenName == ".jpg")
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (ExtenName == ".gif")
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                }
                else if (ExtenName == ".png")
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (ExtenName == ".bmp")
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbase64 = Convert.ToBase64String(arr);
                return strbase64;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #region base64编码的字符串转为图片
        /// <summary>
        /// base64编码的字符串转为图片
        /// </summary>
        /// <param name="strbase64">base64字符串</param>
        /// <param name="filename">要保存的文件名(带物理路径的文件名)</param>
        public void Base64StringToImage(string strbase64, string filename)
        {
            byte[] arr = Convert.FromBase64String(strbase64);
            MemoryStream ms = new MemoryStream(arr);
            try
            {
                Bitmap bmp = new Bitmap(ms);
                string ExtendName = filename.Substring(filename.LastIndexOf(".") + 1);//得到文件后缀名
                if (ExtendName == "jpg" || ExtendName == "jpeg")
                {
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (ExtendName == "bmp")
                {
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else if (ExtendName == "gif")
                {
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Gif);
                }
                else if (ExtendName == "png")
                {
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                ms.Close();
                //if (File.Exists(txtFileName))
                //{
                //    File.Delete(txtFileName);
                //}
            }
            catch (Exception ex)
            {
                ms.Close();
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #region base64编码的文本转为图片
        /// <summary>
        /// base64编码的文本转为图片
        /// </summary>
        /// <param name="txtFileName">base64文本文件名</param>
        public void Base64txtToImage(string txtFileName)
        {
            try
            {
                FileStream ifs = new FileStream(txtFileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(ifs);

                String inputStr = sr.ReadToEnd();
                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                bmp.Save(txtFileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //bmp.Save(txtFileName + ".bmp", ImageFormat.Bmp);
                //bmp.Save(txtFileName + ".gif", ImageFormat.Gif);
                //bmp.Save(txtFileName + ".png", ImageFormat.Png);
                ms.Close();
                sr.Close();
                ifs.Close();

                if (File.Exists(txtFileName))
                {
                    File.Delete(txtFileName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion
    }
}
