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
using Web_GZJL.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Web_GZJL.RJZC
{
    public partial class Etcp : System.Web.UI.Page
    {
        public string t1 = "", t0 = ""; string sql = ""; public string getGV ;//委托单号
        public string gid = "", img = "";
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
                getCom();
                getPeo();
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

            if (sql != "")
            {
                dt = DataBase.Exe_dt("select  Entrust.ID,Entrust.state as st,cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager          on cpid=ConManager.ID  where  " + ViewState["where"].ToString() + "      ORDER BY id ");


            }
            else {

                dt = DataBase.Exe_dt("select  ID,   cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu   from  (     select   Entrust.ID,Entrust.state as st,cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager  on cpid=ConManager.ID   where    cptype='容器'  union All  select    Entrust.ID,Entrust.state as st,cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  PipManager   on cpid=PipManager.id  where  cptype='管道'    )  as a ");


            }

            
           
            return dt;
        }
        protected void ddl_zhiwu_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            type.Text = "";
         
        }

        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {

            if (orgname.Text.Trim() != "" && orgname.SelectedIndex !=0)
            {

                sql += "    yonghuName      like  '%" + orgname.Text.Trim() + "%' ";
            }

            if (type.SelectedItem.Text != "" && type.SelectedIndex != 0)
            {
                if (sql == "")
                {
                    sql += "  cptype   LIKE  '%" + DataOper.setTrueString(type.SelectedItem.Text) + "%'";

                }
                else
                {
                    sql += " AND  cptype  LIKE  '%" + DataOper.setTrueString(type.SelectedItem.Text) + "%'";
                }
            }
          



            ViewState["where"] = sql;
            getData();
        }

        #endregion
   
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            WT_ID .Text= getGV = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
           
         
            Panel1.Visible = false;
            Panel2.Visible = true;
            string id = DataOper.getlsh("TestInfmin", "id");

            RW_no.Text = "RW-" + id;
            RW_Fno.Text = id;

            
            DataTable dt = new DataTable();  DataTable dt1 = new DataTable();
         
            dt =DataBase.Exe_dt(" select  cpid,cptype  from  Entrust  where  ID='"+getGV+"'  ");
            if(dt.Rows.Count>0)
            {
                cptp.Text = dt.Rows[0]["cptype"].ToString(); 
                gid = dt.Rows[0]["cpid"].ToString();
                gjid.Text = gid;
                if (dt.Rows[0]["cptype"].ToString()=="容器")
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
            if (DataBase.Exe_count("TestInfmin", " FNo='" + DataOper.setTrueString(RW_Fno.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('分编号已存在！');", true);
                return;
            }
            if (ohj.SelectedIndex == 0 || ohj.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请选择耦合剂！');", true);
                return;
            }
            if (factp.SelectedIndex == 0 || factp.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请选择表面质量！');", true);
                return;
            }

            if (DropDownList3.SelectedIndex==0||DropDownList3.Text.Length==0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请选择检验人！');", true);
                return;
            }
          
            if (DataBase.Exe_cmd("insert into TestInfmin(" +
                "RWNo,FNo,WTNo,Oname,ChNo,Surface," +
                "Mpref1,Mptkns1,Mpref2,Mptkns2,Mpref3,Mptkns3,Mpref4,Mptkns4," +
                "Mpref5,Mptkns5,Mpref6,Mptkns6,Mpref7,Mptkns7,Mpref8,Mptkns8," +
                "Mpref9,Mptkns9,Mpref10,Mptkns10,Mpref11,Mptkns11,Mpref12,Mptkns12,Mpref13,Mptkns13,state,wrtime,Jianyanren,GJNo,WT_pho" +
                ") values('"
                
                + DataOper.setTrueString(RW_no.Text.Trim()) + "','" + DataOper.setTrueString(RW_Fno.Text.Trim()) + 
                "','" + DataOper.setTrueString(WT_ID.Text.Trim()) + "','" + DataOper.setTrueString(ohj.SelectedItem.Text) + 
                "','" + DataOper.setTrueString(D_co.SelectedItem.Text) + "','" + DataOper.setTrueString(factp.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn1.Text.Trim()) + "','" + DataOper.setTrueString(ch1.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn2.Text.Trim()) + "','" + DataOper.setTrueString(ch2.Text.Trim()) +
                "','" + DataOper.setTrueString(cn3.Text.Trim()) + "','" + DataOper.setTrueString(ch3.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn4.Text.Trim()) + "','" + DataOper.setTrueString(ch4.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn5.Text.Trim()) + "','" + DataOper.setTrueString(ch5.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn6.Text.Trim()) + "','" + DataOper.setTrueString(ch6.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn7.Text.Trim()) + "','" + DataOper.setTrueString(ch7.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn8.Text.Trim()) + "','" + DataOper.setTrueString(ch8.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn9.Text.Trim()) + "','" + DataOper.setTrueString(ch9.Text.Trim()) + 
                "','" + DataOper.setTrueString(cn10.Text.Trim()) + "','" + DataOper.setTrueString(ch10.Text.Trim()) +
                "','" + DataOper.setTrueString(cn11.Text.Trim()) + "','" + DataOper.setTrueString(ch11.Text.Trim()) +
                  "','" + DataOper.setTrueString(cn12.Text.Trim()) + "','" + DataOper.setTrueString(ch12.Text.Trim()) +
                  "','" + DataOper.setTrueString(cn13.Text.Trim()) + "','" + DataOper.setTrueString(ch13.Text.Trim()) +
                "','" + DataOper.setTrueString(cptp.Text.Trim()) + "','" + DateTime.Now.ToString()+
                "','" + DataOper.setTrueString(DropDownList3.SelectedItem.Text) + 
                "','"  + DataOper.setTrueString(gjid.Text.Trim()) +
                 "','" + this.imgShow.ImageUrl +
                "')"))
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
            cn12.Text = ""; ch12.Text = "";
            cn13.Text = ""; ch13.Text = "";
            cptp.Text = ""; this.imgShow.ImageUrl = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getCom()
        {

            DataTable dt = DataBase.Exe_dt("select OrgName from CoverTest");

            List<string> roles = new List<string>();
            roles.Add("选择公司");
            foreach (DataRow row in dt.Rows) // 遍历所有行
            {
                // 读取列的值
                roles.Add(row["OrgName"].ToString());


            }

            orgname.DataSource = roles;
            orgname.DataBind();
        }

        private void getPeo()
        {

            DataTable dt = DataBase.Exe_dt("select * from tb_czjuser");

            List<User> roles = new List<User>();
            User a = new User();
            a.Id = "-1";
            a.Name = "选择人员";
            roles.Add(a);
            foreach (DataRow row in dt.Rows) // 遍历所有行
            {
                // 读取列的值
                User a1 = new User();
                a1.Id = row["id"].ToString();
                a1.Name= row["usrname"].ToString();
                roles.Add(a1);


            }

            DropDownList3.DataSource = roles;
            DropDownList3.DataValueField = "id";
            DropDownList3.DataTextField = "name";
            DropDownList3.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
               Panel1.Visible = false;
               Panel2.Visible = true;
        }

        protected void guanjian_TextChanged(object sender, EventArgs e)
        {

            cn1.Text = guanjian.Text + "-1";
            cn2.Text = guanjian.Text + "-2";
            cn3.Text = guanjian.Text + "-3";
            cn4.Text = guanjian.Text + "-4";
            cn5.Text = guanjian.Text + "-5";
            cn6.Text = guanjian.Text + "-6";
            cn7.Text = guanjian.Text + "-7";
            cn8.Text = guanjian.Text + "-8";
            cn9.Text = guanjian.Text + "-9";
            cn10.Text = guanjian.Text + "-10";
            cn11.Text = guanjian.Text + "-11";
            cn12.Text = guanjian.Text + "-12";
            cn13.Text = guanjian.Text + "-13";
        }
        // 本地路径转换成URL相对路径
        private string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            //imagesurl2 = imagesurl2.Replace(@"Aspx_Uc/", @"");
            return imagesurl2;
        }
        // 相对路径转换成服务器本地物理路径
        private string urlconvertorlocal(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"\"); //转换成绝对路径
            return imagesurl2;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  Entrust WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TestInfmin") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'Entrust '");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (guanjian.Text.Length > 0&&RW_no.Text.Length>0&&RW_Fno.Text.Length>0)
            {
                cn1.Text = guanjian.Text + "-1";
                cn2.Text = guanjian.Text + "-2";
                cn3.Text = guanjian.Text + "-3";
                cn4.Text = guanjian.Text + "-4";
                cn5.Text = guanjian.Text + "-5";
                cn6.Text = guanjian.Text + "-6";
                cn7.Text = guanjian.Text + "-7";
                cn8.Text = guanjian.Text + "-8";
                cn9.Text = guanjian.Text + "-9";
                cn10.Text = guanjian.Text + "-10";
                cn11.Text = guanjian.Text + "-11";
             
               
               

            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入任务单号/批次编号/管件名称！');", true);

            }
            
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
                            img = appImgPath;
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