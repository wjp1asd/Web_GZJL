using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace Web_GZJL.RJZC
{
    public partial class Etcp : System.Web.UI.Page
    {
        public string t1 = "", t0 = ""; string sql = ""; public string getGV ;//委托单号
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!this.IsPostBack)
            {
        
                getData();

            }

        }

        /// <summary>
        /// GridView1数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = GetDataToTable();

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columnCount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView1.DataSource = dt;
                GridView1.DataKeyNames = new string[] { "id" };//主键列
                this.GridView1.DataBind();

            }
        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            
        
                if (txt_copi.Text.Trim() == "容器")
                {
                    dt = DataBase.Exe_dt("select  Entrust.ID,   cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager          on cpid=ConManager.ID   where   cptype='容器' ");
                    //DataBase.Exe_dt("select id,NumBer,ConName,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName   ,stype='容器'    from ConManager      where    state='已委托'      ORDER BY id "); 
                }
                else if (txt_copi.Text.Trim() == "管道")
                {
                    dt = DataBase.Exe_dt("select   Entrust.ID,    cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  PipManager   on cpid=PipManager.id  where  cptype='管道'");
                        //DataBase.Exe_dt("select id,NumBer,ConName ,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName    ,stype='管道'     from PipManager        where    state='已委托'      ORDER BY id ");
                }
                else
                {
                    dt = DataBase.Exe_dt("select  ID,   cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu   from  (     select   Entrust.ID,    cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager  on cpid=ConManager.ID   where    cptype='容器'  union All  select    Entrust.ID,     cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  PipManager   on cpid=PipManager.id  where  cptype='管道'    )  as a ");
                    //DataBase.Exe_dt("select id,NumBer,ConName ,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName   ,stype='管道'     from PipManager           where    state='已委托'             union  all  select id,NumBer,ConName,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName   ,stype='容器'    from ConManager        where    state='已委托'       ORDER BY id ");
                }
           
            return dt;
        }

   
        /// <summary>
        /// 取消GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            getData();
            clear();
        }
      
      
     
        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            txt_copi.Text = "";
         
        }

        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {          
            getData();
        }

        #endregion
   
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            WT_ID .Text=getGV = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();            
            Panel1.Visible = false;
            Panel2.Visible = true;
        
             DataTable dt = new DataTable();  DataTable dt1 = new DataTable();
            dt=DataBase.Exe_dt(" select  cpid,cptype  from  Entrust  where  ID='"+getGV+"'  ");
            if(dt.Rows.Count>0)
            {
                cptp.Text = dt.Rows[0]["cptype"].ToString(); 
                if(dt.Rows[0]["cptype"].ToString()=="容器")
                {
                    dt1 = DataBase.Exe_dt(" select ConName  from  Entrust left  join  ConManager on cpid=ConManager.ID   where   cptype='容器'    and  ConName  is not null");
                  

                }
                else  if  (dt.Rows[0]["cptype"].ToString()=="管道")
                {
                    dt1 = DataBase.Exe_dt(" select ConName  from   Entrust left  join  PipManager on cpid=PipManager.id  where  cptype='管道'   and  ConName  is not null");
                   
                }

         if (dt1.Rows[0]["ConName"].ToString()!="" && dt1.Rows[0]["ConName"].ToString() !="Null")
                    {
                        cp_name.Text = dt1.Rows[0]["ConName"].ToString();
                    }
                     
            }
            

            ohj.Items.Clear(); D_co.Items.Clear();
            DataTable bum1 = new DataTable();
            bum1 = DataBase.Exe_dt("select  wtflname  from   TB_WTFL");
            if (bum1.Rows.Count != 0)
            {
                for (int i = 0; i < bum1.Rows.Count; i++)
                {
                    string xial = "" + bum1.Rows[i]["wtflname"].ToString() + "";
                    this.ohj.Items.Add("" + xial + "");
                }
                ohj.Items.Insert(0, new ListItem("请选择", ""));
                ohj.SelectedIndex = 0;
            }
            DataTable bum2 = new DataTable();
            bum2 = DataBase.Exe_dt("select Sbnumber from  ShebeiManager");
            if (bum2.Rows.Count != 0)
            {
                for (int i = 0; i < bum2.Rows.Count; i++)
                {
                    string xial = "" + bum2.Rows[i]["Sbnumber"].ToString() + "";
                    this.D_co.Items.Add("" + xial + "");
                }
                D_co.Items.Insert(0, new ListItem("请选择", ""));
                D_co.SelectedIndex = 0;
            }
        }
       
        //P2添加
        protected void btn_JCadd_Click(object sender, EventArgs e)
        {
//WT_pho ,,'" + DataOper.setTrueString(TextBox24.Text.Trim()) + "'
            if (DataBase.Exe_cmd("   insert into TestInfmin(RWNo,FNo,WTNo,Oname,ChNo,Surface,Mpref1,Mptkns1,Mpref2,Mptkns2,Mpref3,Mptkns3,Mpref4,Mptkns4,Mpref5,Mptkns5,Mpref6,Mptkns6,Mpref7,Mptkns7,Mpref8,Mptkns8,Mpref9,Mptkns9,Mpref10,Mptkns10,Mpref11,Mptkns11,state,wrtime) values('" + DataOper.setTrueString(RW_no.Text.Trim()) + "','" + DataOper.setTrueString(RW_Fno.Text.Trim()) + "','" + DataOper.setTrueString(WT_ID.Text.Trim()) + "','" + DataOper.setTrueString(ohj.SelectedItem.Text) + "','" + DataOper.setTrueString(D_co.SelectedItem.Text) + "','" + DataOper.setTrueString(factp.Text.Trim()) + "','" + DataOper.setTrueString(cn1.Text.Trim()) + "','" + DataOper.setTrueString(ch1.Text.Trim()) + "','" + DataOper.setTrueString(cn2.Text.Trim()) + "','" + DataOper.setTrueString(ch2.Text.Trim()) + "','" + DataOper.setTrueString(cn3.Text.Trim()) + "','" + DataOper.setTrueString(cn3.Text.Trim()) + "','" + DataOper.setTrueString(cn4.Text.Trim()) + "','" + DataOper.setTrueString(ch4.Text.Trim()) + "','" + DataOper.setTrueString(cn5.Text.Trim()) + "','" + DataOper.setTrueString(ch5.Text.Trim()) + "','" + DataOper.setTrueString(cn6.Text.Trim()) + "','" + DataOper.setTrueString(ch6.Text.Trim()) + "','" + DataOper.setTrueString(cn7.Text.Trim()) + "','" + DataOper.setTrueString(ch7.Text.Trim()) + "','" + DataOper.setTrueString(cn8.Text.Trim()) + "','" + DataOper.setTrueString(ch8.Text.Trim()) + "','" + DataOper.setTrueString(cn9.Text.Trim()) + "','" + DataOper.setTrueString(ch9.Text.Trim()) + "','" + DataOper.setTrueString(cn10.Text.Trim()) + "','" + DataOper.setTrueString(ch10.Text.Trim()) + "','" + DataOper.setTrueString(cn11.Text.Trim()) + "','" + DataOper.setTrueString(ch11.Text.Trim()) + "','" + DataOper.setTrueString(cptp.Text.Trim()) + "','" + DateTime.Now.ToString() + "')    "))
            {
            //    upimg();
                p2clear();


                Panel1.Visible = true;
           
                Panel2.Visible = false; 
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
        //耦合剂
        //protected void ohj_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable  bum1 = new DataTable ();
        //    bum1 = DataBase.Exe_dt("select  wtflname  from   TB_WTFL");
        //    if (bum1.Rows.Count != 0)
        //    {
        //        for (int i = 0; i < bum1.Rows.Count; i++)
        //        {
        //            string xial = "" + bum1.Rows[i]["wtflname"].ToString() + "";
        //            this.ohj.Items.Add("" + xial + "");
        //        }              
        //        ohj.Items.Insert(0, new ListItem("请选择", ""));
        //        ohj.SelectedIndex = 0;
        //    }
        //}
        ////测厚仪
        //protected void D_co_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable bum2 = new DataTable();
        //    bum2 = DataBase.Exe_dt("select Sbnumber from  ShebeiManager");
        //    if (bum2.Rows.Count != 0)
        //    {
        //        for (int i = 0; i < bum2.Rows.Count; i++)
        //        {
        //            string xial = "" + bum2.Rows[i]["Sbnumber"].ToString() + "";
        //            this.D_co.Items.Add("" + xial + "");
        //        }
        //        D_co.Items.Insert(0, new ListItem("请选择", ""));
        //        D_co.SelectedIndex = 0;
        //    }
        //}




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