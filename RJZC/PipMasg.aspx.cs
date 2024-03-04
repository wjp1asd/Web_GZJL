using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZXing;
using ZXing.Common;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Configuration;


namespace Web_GZJL.RJZC
{
    public partial class PipMasg : System.Web.UI.Page
    {

        public string t1 = "", t0 = ""; string sql = "";
        public string cl = "https://open-api.cli.im/cli-open-platform-service/v1/labelStyle/create?cliT=B216&cliD=%E5%9B%BE%E7%89%87%E6%A0%B7%E5%BC%8F%E4%BA%8C%E7%BB%B4%E7%A0%81&cliF1=%E5%AE%B9%E5%99%A8%E7%BC%96%E5%8F%B7%EF%BC%9A123&cliF2=%E6%B5%8B%E7%82%B9%E7%BC%96%E5%8F%B7";

        protected void Page_Load(object sender, EventArgs e)
        {

            //Session["userid"] = "admin";
            //Session["XZQH"] = "130100";
            //Session["userid"] = "zhangsan";
            //Session["XZQH"] = "130102";
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

            }

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

        public void alert(string msg)
        {
            Response.Write("<script language=javascript>alert('" + msg + "');</" + "script>");
        }
        protected void btnGenerateQRCode_Click(object sender, EventArgs e)
        {
           

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

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            if (sql != "")
            {
                dt = DataBase.Exe_dt("select id,NumBer,ConName ,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum,YonghuName,Image,GuanJianNum from PipManager where  " + ViewState["where"].ToString() + "            ORDER BY id ");
              }
            else
            {
                dt = DataBase.Exe_dt("select id,NumBer,ConName ,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName,Image,GuanJianNum from PipManager ORDER BY id ");
            }
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (orgname.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入公司！');", true);
                return;
            }
            if (bdsl.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入布点数量！');", true);
                return;
            }
            if (TextBox4.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入管件名称！');", true);
                return;
            }
            if (TextBox2.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入管道规格！');", true);
                return;
            }
            if (DataBase.Exe_count("PipManager", " NumBer='" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('关键编号已存在！');", true);
                return;
            }
         
            // 编号生成 
            string id = DataOper.getlsh("PipManager", "id");
            string path = "~" + urlconvertor(Qrcode.Generate1(DataOper.setTrueString("GD-"+id)));
           
            //id,'" + DataOper.getlsh("PipManager", "id") + "',
            if (DataBase.Exe_cmd("insert into PipManager(id,NumBer,ConName," +
                "GuandaoType,GudandaoJibie," +
                "Guandaocaizhi,JiantiHoudu," +
                "FengtouHoudu,BudianNum," +
                "YonghuName,Image," +
                "GuanJianNum" +
                ") values('"
                + id + "','" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "','" + DataOper.setTrueString(txt_lbmcbz.Text.Trim())

                + "','" + DataOper.setTrueString(TextBox2.Text.Trim()) + "','" + DataOper.setTrueString(txt_man.Text.Trim()) 
                + "','" + DataOper.setTrueString(txt_tel.Text.Trim()) + "','" + DataOper.setTrueString(txt_ema.Text.Trim()) 
                + "','" + DataOper.setTrueString(TextBox3.Text.Trim()) + "','" + DataOper.setTrueString(bdsl.Text.Trim()) 
                + "','" + DataOper.setTrueString(orgname.Text.Trim()) + "','" + DataOper.setTrueString(path)  
                +"','" + DataOper.setTrueString(TextBox4.Text.Trim()) + "')"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('管道信息添加失败！');", true);
            }

            clear();
            getData();
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
        /// <summary>
        /// 删除GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  PipManager WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("PipManager") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'PipManager '");
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

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
           
         
          
           string values = ((LinkButton)sender).CommandArgument; 
            string[] valueParts = values.Split('|');
            string value1 = valueParts[0];
            string value2 = valueParts[1];
            string value3 = valueParts[2];
            string a1 = "GD-"+value1;
            string a2 = "管道编号："+value3;
            string a3 = "管件编号："+value2;
            string cl = "https://open-api.cli.im/cli-open-platform-service/v1/labelStyle/create?cliT=B216&cliD=" +
                a1 +
                "&cliF1=" +a2+
                "&cliF2="+a3;

            var response = base.Response;
            response.Redirect(cl, false);

          
        }
        /// <summary>
        /// 编辑GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            getData();
        }
        /// <summary>
        /// 更新GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox mc = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_mc");
            TextBox bz = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_na");
            TextBox gz = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_gz");
            TextBox jb = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_jb");
            TextBox cz = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_cz");
            TextBox th = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_th");
            TextBox fh = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_fh");
            TextBox bd = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_bd");

            TextBox un = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_uscn");
            if (mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入管道编号！');", true);
                return;
            }

            if (DataBase.Exe_cmd("update PipManager set NumBer='" + DataOper.setTrueString(mc.Text.Trim()) + "',ConName='" + DataOper.setTrueString(bz.Text.Trim()) + "',    GuandaoType='" + DataOper.setTrueString(gz.Text.Trim()) + "',   GudandaoJibie ='" + DataOper.setTrueString(jb.Text.Trim()) + "',    Guandaocaizhi='" + DataOper.setTrueString(cz.Text.Trim()) + "',    JiantiHoudu='" + DataOper.setTrueString(th.Text.Trim()) + "',    FengtouHoudu='" + DataOper.setTrueString(fh.Text.Trim()) + "',    BudianNum='" + DataOper.setTrueString(bd.Text.Trim()) + "'     ,YonghuName='" + DataOper.setTrueString(un.Text.Trim()) + "'     where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('管道信息编辑失败！');", true);
            }

            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }
        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            txt_lbmc.Text = "";
            txt_lbmcbz.Text = "";
            TextBox2.Text = "";
txt_man.Text = "";
txt_tel.Text = "";
txt_ema.Text = "";
TextBox3.Text = "";

orgname.Text = "";

        }


        #region 查询
       //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {
         
            if (txt_lbmc.Text.Trim() != "")
            {

                sql += "    NumBer   like  '%" + txt_lbmc.Text.Trim() + "%' ";
            }

            if (txt_lbmcbz.Text.Trim() != "")
            {
                
                if (sql == "")
                {
                    sql += "   ConName  LIKE  '%" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  ConName  LIKE  '%" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "%'";
                }
            }

                if (TextBox2.Text.Trim() != "")
            {
                
                if (sql == "")
                {
                    sql += "   GuandaoType  LIKE  '%" + DataOper.setTrueString(TextBox2.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  GuandaoType  LIKE  '%" + DataOper.setTrueString(TextBox2.Text.Trim()) + "%'";
                }
            }


            if (txt_man.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "   GudandaoJibie  LIKE  '%" + DataOper.setTrueString(txt_man.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  GudandaoJibie  LIKE  '%" + DataOper.setTrueString(txt_man.Text.Trim()) + "%'";
                }
            }

            
            if (txt_tel.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "   Guandaocaizhi  LIKE  '%" + DataOper.setTrueString(txt_tel.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Guandaocaizhi  LIKE  '%" + DataOper.setTrueString(txt_tel.Text.Trim()) + "%'";
                }
            }

             if (txt_ema.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "   JiantiHoudu  LIKE  '%" + DataOper.setTrueString(txt_ema.Text.Trim()) + "%'";
         
                }
                else
                {
                    sql += " AND  JiantiHoudu  LIKE  '%" + DataOper.setTrueString(txt_ema.Text.Trim()) + "%'";
                }
            }

            if (TextBox3.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "   FengtouHoudu  LIKE  '%" + DataOper.setTrueString(TextBox3.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  FengtouHoudu  LIKE  '%" + DataOper.setTrueString(TextBox3.Text.Trim()) + "%'";
                }
            }
           
            if (orgname.Text.Trim() != ""&&orgname.SelectedIndex!=0)
            {
                if (sql == "")
                {
                    sql += "   YonghuName  LIKE  '%" + DataOper.setTrueString(orgname.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  YonghuName  LIKE  '%" + DataOper.setTrueString(orgname.Text.Trim()) + "%'";
                }
            }
            ViewState["where"] = sql;
            getData();

        }

        #endregion

        //委托

        protected void btn_WT_Click(object sender, EventArgs e)
        {
           
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvRow.FindControl("chkItem");
             
                if (chk.Checked)
                {
                  //  string id = DataOper.getlsh("PipManager", "id");
                    if (DataBase.Exe_cmd("insert into entrust(id,cpid,cptype,etst,state) values('" + GridView1.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "','管道','" + DateTime.Now.ToString() + "','待检验')"))
                    {
                        if (DataBase.Exe_cmd("update PipManager set state='已委托'     where id='" + GridView1.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "'"))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('信息委托成功！');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('信息委托失败！');", true);
                    }
                }
            }

            getData();


        }
    }
}