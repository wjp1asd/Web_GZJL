using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using ZXing.QrCode;
using ZXing;
using System.IO;

namespace Web_GZJL
{
    public class Qrcode
    {

        /// <summary>
        /// 生成二维码,保存成图片
        /// </summary>
        public static string Generate1(string text)
        {

            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = 500;
            options.Height = 500;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            Bitmap map = writer.Write(text);
            string applicationPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string qrpath = applicationPath + "\\Qrcode\\";
            if (!Directory.Exists(qrpath)) {
                Directory.CreateDirectory(qrpath);
            }
            DateTime timestamp = DateTime.Now;
          
            string filename = qrpath+"\\"+ DateTime.Now.ToUniversalTime().Ticks +text+ ".png";
           // Console.Write(filename);
           map.Save(filename, ImageFormat.Png);
           map.Dispose();

            return filename;
        }



    }
}