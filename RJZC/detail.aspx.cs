using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GZJL.RJZC
{
    public partial class detail : System.Web.UI.Page
    {
        public string t1 = "", t0 = ""; string sql = ""; public string getGV;//委托单号

        public string id1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");

            if (Request.QueryString["id"].Length > 0) {
                rwid.Text += Request.QueryString["id"];
                id1= Request.QueryString["id"];
            }
           

            if (!this.IsPostBack)
            {

                //getData(id1);
                Panel2.Visible = true;
            }

        }
        public void alert(string msg)
        {
            Response.Write("<script language=javascript>alert('" + msg + "');</" + "script>");
        }

        /// <summary>
        /// GridView1数据绑定
        /// </summary>
        private void getData(string id)
        {
            DataTable bum1 = new DataTable();
            bum1 = DataBase.Exe_dt("select * from  TestInfmin where id = '"+id+"'");
            if (bum1.Rows.Count != 0)
            {
  
                RW_no.Text = bum1.Rows[0]["RWNo"].ToString();
                RW_Fno.Text = bum1.Rows[0]["FNo"].ToString(); 
                WT_ID.Text = bum1.Rows[0]["WTNo"].ToString();
                factp.Text = bum1.Rows[0]["Surface"].ToString();
                cn1.Text = bum1.Rows[0]["Mpref1"].ToString();
                ch1.Text = bum1.Rows[0]["Mptkns1"].ToString();
                cn2.Text = bum1.Rows[0]["Mpref2"].ToString();
                ch2.Text = bum1.Rows[0]["Mptkns2"].ToString();
                cn3.Text = bum1.Rows[0]["Mpref3"].ToString();
                ch3.Text = bum1.Rows[0]["Mptkns3"].ToString();
                cn4.Text = bum1.Rows[0]["Mpref4"].ToString();
                ch4.Text = bum1.Rows[0]["Mptkns4"].ToString();
                cn5.Text = bum1.Rows[0]["Mpref5"].ToString();
                ch5.Text = bum1.Rows[0]["Mptkns5"].ToString();
                cn6.Text = bum1.Rows[0]["Mpref6"].ToString();
                ch6.Text = bum1.Rows[0]["Mptkns6"].ToString();
                cn7.Text = bum1.Rows[0]["Mpref7"].ToString();
                ch7.Text = bum1.Rows[0]["Mptkns7"].ToString();
                cn8.Text = bum1.Rows[0]["Mpref8"].ToString();
                ch8.Text = bum1.Rows[0]["Mptkns8"].ToString();
                cn9.Text = bum1.Rows[0]["Mpref9"].ToString();
                ch9.Text = bum1.Rows[0]["Mptkns9"].ToString();
                cn10.Text = bum1.Rows[0]["Mpref10"].ToString();
                ch10.Text = bum1.Rows[0]["Mptkns10"].ToString();
                cn11.Text = bum1.Rows[0]["Mpref11"].ToString();
                ch11.Text = bum1.Rows[0]["Mptkns11"].ToString();
                cptp.Text = bum1.Rows[0]["state"].ToString();
                this.imgShow.ImageUrl = bum1.Rows[0]["WT_pho"].ToString();

            }

        }







        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
          
        }

        //P2添加
        protected void btn_JCadd_Click(object sender, EventArgs e)
        {
            string str = "update TestInfmin Set RWNo ='" + DataOper.setTrueString(RW_no.Text.Trim()) + "',"
                  + "FNo ='" + DataOper.setTrueString(RW_Fno.Text.Trim()) + "',"
                  + "WTNo ='" + DataOper.setTrueString(WT_ID.Text.Trim()) + "',"
                  + "Oname ='" + DataOper.setTrueString(ohj.Text.Trim()) + "',"
                  + "ChNo ='" + DataOper.setTrueString(Ch_no.Text.Trim()) + "',"
                  + "Surface ='" + DataOper.setTrueString(factp.Text.Trim()) + "',"
                  + "Mpref1 ='" + DataOper.setTrueString(cn1.Text.Trim()) + "',"
                  + "Mptkns1 ='" + DataOper.setTrueString(ch1.Text.Trim()) + "',"
                  + "Mpref2 ='" + DataOper.setTrueString(cn2.Text.Trim()) + "',"
                  + "Mptkns2 ='" + DataOper.setTrueString(ch2.Text.Trim()) + "',"
                  + "Mpref3 ='" + DataOper.setTrueString(cn3.Text.Trim()) + "',"
                  + "Mptkns3 ='" + DataOper.setTrueString(ch3.Text.Trim()) + "',"
                  + "Mpref4 ='" + DataOper.setTrueString(cn4.Text.Trim()) + "',"
                  + "Mptkns4='" + DataOper.setTrueString(ch4.Text.Trim()) + "',"
                  + "Mpref5 ='" + DataOper.setTrueString(cn5.Text.Trim()) + "',"
                  + "Mptkns5 ='" + DataOper.setTrueString(ch5.Text.Trim()) + "',"
                  + "Mpref6 ='" + DataOper.setTrueString(cn6.Text.Trim()) + "',"
                  + "Mptkns6 ='" + DataOper.setTrueString(ch6.Text.Trim()) + "',"
                   + "Mpref7 ='" + DataOper.setTrueString(cn7.Text.Trim()) + "',"
                  + "Mptkns7 ='" + DataOper.setTrueString(ch7.Text.Trim()) + "',"
                  + "Mpref8 ='" + DataOper.setTrueString(cn8.Text.Trim()) + "',"
                  + "Mptkns8 ='" + DataOper.setTrueString(ch8.Text.Trim()) + "',"
                  + "Mpref9 ='" + DataOper.setTrueString(cn9.Text.Trim()) + "',"
                  + "Mptkns9 ='" + DataOper.setTrueString(ch9.Text.Trim()) + "',"
                  + "Mpref10 ='" + DataOper.setTrueString(cn10.Text.Trim()) + "',"
                  + "Mptkns10='" + DataOper.setTrueString(ch10.Text.Trim()) + "',"
                  + "Mpref11 ='" + DataOper.setTrueString(cn11.Text.Trim()) + "',"
                  + "Mptkns11 ='" + DataOper.setTrueString(ch11.Text.Trim()) + "',"
                   + "Mpref12 ='" + DataOper.setTrueString(cn12.Text.Trim()) + "',"
                  + "Mptkns12 ='" + DataOper.setTrueString(ch12.Text.Trim()) + "',"
                   + "Mpref13 ='" + DataOper.setTrueString(cn13.Text.Trim()) + "',"
                  + "Mptkns13 ='" + DataOper.setTrueString(ch13.Text.Trim()) + "',"
                  + "state ='" + DataOper.setTrueString(cptp.Text.Trim()) + "',"
                  + "wrtime ='" + DataOper.setTrueString(DateTime.Now.ToString().Trim()) +
                  "where id =" + id1;
            if (DataBase.Exe_cmd(str
            ))
            {
                //    upimg();
                p2clear();


            
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('检测信息添加失败！');", true);
            }

        }

        private void p2clear()
        {
            RW_no.Text = ""; RW_Fno.Text = ""; WT_ID.Text = ""; factp.Text = "";
            cn1.Text = ""; ch1.Text = "";
            cn2.Text = ""; ch2.Text = "";
            cn3.Text = ""; ch3.Text = "";
            cn4.Text = ""; ch4.Text = "";
            cn5.Text = ""; ch5.Text = "";
            cn6.Text = ""; ch6.Text = "";
            cn7.Text = ""; ch7.Text = "";
            cn8.Text = ""; ch8.Text = "";
            cn9.Text = ""; ch9.Text = "";
            cn10.Text = ""; ch10.Text = "";
            cn11.Text = ""; ch11.Text = "";
            cptp.Text = ""; this.imgShow.ImageUrl = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
           
        }

       




        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //    upimg();
            //}




            //private void upimg()
            //{

            if (this.fileSelect.FileName == "")
            {
                this.labTipMsg.Text = "上传文件不能为空";
                return;
            }

            //如果确认了上传文件，则判断文件类型是否符合要求 
            if (this.fileSelect.HasFile)
            {
                //1、检查上传的文件路径是否存在
                //获取当前程序集的文件路径
                string applicationPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                //获取存放的文件夹名称
                string uploadfolder = ConfigurationManager.AppSettings["UploadImage"] == null ? "UploadImages" : ConfigurationManager.AppSettings["UploadImage"].ToString();
                //获取限制文件大小 MB
                int uploadSize = ConfigurationManager.AppSettings["UploadFileSize"] == null ? 4 : Convert.ToInt32(ConfigurationManager.AppSettings["UploadFileSize"]);
                //获取程序集路径+文件夹路径
                string toServerPath = applicationPath + "\\" + uploadfolder;
                //拼接上年月文件夹( C:\\UploadFiles\\201904 )
                toServerPath = toServerPath + "\\" + DateTime.Now.ToString("yyyyMM");
                //判断服务器文件夹路径是否存在
                if (!Directory.Exists(toServerPath))
                {
                    //不存在路径，则创建
                    Directory.CreateDirectory(toServerPath);
                }

                //获取上传文件的后缀 
                string fileExt = Path.GetExtension(this.fileSelect.FileName).ToLower();
                string[] fileExts = { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".ico" };
                //判断文件类型是否符合要求 
                if (fileExts.Contains(fileExt))
                {
                    //检查文件大小
                    if (fileSelect.PostedFile.ContentLength > (uploadSize * 1024 * 1024))
                    {
                        this.labTipMsg.Text = string.Format("上传文件超过最大限制{0}MB！", uploadSize);
                    }
                    else
                    {
                        try
                        {
                            //获取新文件名（包含后缀名），如：test_211104171831.jpg
                            string newFileName = this.fileSelect.FileName;  // "admin" + "_" + DateTime.Now.ToString("yyMMddHHmmss") + fileExt;
                            //获取绝对路径，如：D:\Project\Cpap\CpapWebForm\\UploadImages\202111\test_211104171831.jpg
                            string newFilePath = toServerPath + "\\" + newFileName;
                            //获取相对路径，如：\UploadImages\202111\test_211104171831.jpg
                            string relatePath = newFilePath.Substring(applicationPath.Length, newFilePath.Length - applicationPath.Length);
                            //拼接返回应用图片路径(将符号（\）替换成符号（/）), 如： ~/UploadImages/202111/test_211104171831.png
                            string appImgPath = "~" + relatePath.Replace('\\', '/');

                            //检查保存是否已存在，存在不做保存
                            if (!System.IO.File.Exists(newFilePath))
                            {
                                //3、保存上传的文件
                                this.fileSelect.SaveAs(newFilePath);
                            }
                            //显示图片  "~/UploadImage/" + FileUpload1.FileName;
                            this.imgShow.ImageUrl = appImgPath;

                            this.labTipMsg.Text = "上传文件成功！";
                        }
                        catch (Exception ex)
                        {
                            this.labTipMsg.Text = "上传文件失败,原因：" + ex.Message;
                        }

                    }
                }
                else
                {
                    this.labTipMsg.Text = "只能够上传后缀为.gif,.jpg,.bmp,.png的文件";
                }

            }
        }






    }
}