using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


using System.Linq;
using System.Text;


namespace Web_GZJL.RJZC
{
    public partial class ConMasg : System.Web.UI.Page
    {
        public string t1 = "", t0 = ""; string sql = "";
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

            orgname1.DataSource = roles;
            orgname1.DataBind();
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {



            string values = ((LinkButton)sender).CommandArgument;
            string[] valueParts = values.Split('|');
            string value1 = valueParts[0];
            string value2 = valueParts[1];
            string value3 = valueParts[2];
            string a1 = "RQ-" + value1;
            string a2 = "容器编号：" + value3;
            string a3 = "测点编号：" + value2;
            string cl = "https://open-api.cli.im/cli-open-platform-service/v1/labelStyle/create?cliT=B216&cliD=" +
                a1 +
                "&cliF1=" + a2 +
                "&cliF2=" + a3;

            var response = base.Response;
            response.Redirect(cl, false);

            // 文件路径  
            //string filePath = "path/to/your/file.ext";

            //// 设置响应头信息，告诉浏览器这是一个下载操作  
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=file.ext");
            //Response.WriteFile(filePath); // 将文件内容输出到浏览器  
            //Response.End(); // 结束响应  
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
            { dt = DataBase.Exe_dt("select * from ConManager    where  " + ViewState["where"].ToString() + "   ORDER BY id "); }
            else
            {
                dt = DataBase.Exe_dt("select * from ConManager      ORDER BY id ");
            }
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (orgname1.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入公司！');", true);
                return;
            }

            if (txt_lbmc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入布点数量！');", true);
                return;
            }
            if (txt_lbmcbz.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入管件名称！');", true);
                return;
            }
           
            if (TextBox3.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入容器厚度！');", true);
                return;
            }
            if (TextBox1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入封头厚度！');", true);
                return;
            }
            if (DataBase.Exe_count("ConManager", " NumBer='" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编号已存在！');", true);
                return;
            }
            if (DataBase.Exe_count("ConManager", " ConName='" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('名称已存在！');", true);
                return;
            }
           // orgname.SelectedIndex = orgname.Items.IndexOf(orgname.Items.FindByValue(myReader[0].ToString()));
            // 编号生成 
            string id = DataOper.getlsh("ConManager", "id");
            string path = "~" + urlconvertor(Qrcode.Generate1(DataOper.setTrueString("RQ-" + id)));
            string str = "insert into ConManager(id,NumBer,ConName," +
               "JiantiHoudu," +
               "FengtouHoudu," +
               "BudianNum," +
               "YonghuName," +
               "Image)" +
               " values('"
               + DataOper.setTrueString(id) + "','"
               + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "','"
               + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "','"
               + DataOper.setTrueString(txt_ema.Text.Trim()) + "','"
               + DataOper.setTrueString(TextBox3.Text.Trim()) + "','"
               + DataOper.setTrueString(TextBox1.Text.Trim()) + "','"
               + DataOper.setTrueString(orgname1.Text.Trim()) + "','"
               + DataOper.setTrueString(path.Trim()) + "')";
            if (DataBase.Exe_cmd(str))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('容器信息添加失败！"+str+"');", true);
            }

            clear();
            getData();
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
            if (DataBase.Exe_cmd("DELETE FROM  ConManager WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("ConManager") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'ConManager '");
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
            TextBox th = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_th");
            TextBox fh = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_fh");
            TextBox bd = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_bd");
            TextBox un = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_uscn");
            if (mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入容器编号！');", true);
                return;
            }

            if (DataBase.Exe_cmd("update ConManager set NumBer='" + DataOper.setTrueString(mc.Text.Trim()) + "',ConName='" + DataOper.setTrueString(bz.Text.Trim()) + "',JiantiHoudu='" + DataOper.setTrueString(th.Text.Trim()) + "',FengtouHoudu='" + DataOper.setTrueString(fh.Text.Trim()) + "',BudianNum='" + DataOper.setTrueString(bd.Text.Trim()) + "',YonghuName='" + DataOper.setTrueString(un.Text.Trim()) + "'    where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('容器信息编辑失败！');", true);
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
            txt_ema.Text = "";
            TextBox3.Text = "";
            TextBox1.Text = "";
            
        }

        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_lbmc.Text.Trim() != "" && txt_lbmc.Text.Trim() != "")
            {

                sql += "    NumBer   like  '%" + txt_lbmc.Text.Trim() + "%' ";
            }
            if (txt_lbmcbz.Text.Trim() != "")
            {
                //sql += " and BM = '" + DataOper.setTrueString(txt_lwdwid.Text.Trim()) + "%'";
                if (sql == "")
                {
                    sql += "   ConName  LIKE  '%" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  ConName  LIKE  '%" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "%'";
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
            if (TextBox1.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "   BudianNum  LIKE  '%" + DataOper.setTrueString(TextBox1.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  BudianNum  LIKE  '%" + DataOper.setTrueString(TextBox1.Text.Trim()) + "%'";
                }
            }
            if (orgname1.Text.Trim() != ""&&orgname1.SelectedIndex!=0)
            {
                if (sql == "")
                {
                    sql += "   YonghuName  LIKE  '%" + DataOper.setTrueString(orgname1.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  YonghuName  LIKE  '%" + DataOper.setTrueString(orgname1.Text.Trim()) + "%'";
                }
            }



            ViewState["where"] = sql;
            getData();
        }

        protected void orgname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        //protected void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    //全选CheckBox  chkAll =(CheckBox)sender;
        //    StringBuilder deptIDs = new StringBuilder();
        //    foreach (GridViewRow gvRow in GridView1.Rows)
        //    {
        //        CheckBox chk = (CheckBox)gvRow.FindControl("chkItem");
        //        //全选chkItem.Checked = chkAll.Checked;

        //        if(chk.Checked)
        //        {
        //            deptIDs.Append(",").Append(GridView1.DataKeys[gvRow.RowIndex]["RequestID"].ToString().Trim());
        //        }
        //        string[] sArray = deptIDs.ToString().Split(',');
        //    }
        //}
        //委托

        protected void btn_WT_Click(object sender, EventArgs e)
        {
          
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvRow.FindControl("chkItem");
                //全选chkItem.Checked = chkAll.Checked;

                if (chk.Checked)
                {
                    string id = DataOper.getlsh("entrust", "id");
                    var cpid = GridView1.DataKeys[gvRow.RowIndex].Value.ToString().Trim();
                    var stt = "insert into entrust(id,cpid,cptype,etst,state) values('" 
                        + id + "','" + cpid + "',"+
                        "'容器','" + DateTime.Now.ToString() + "','待检验')";
                if (DataBase.Exe_cmd(stt))
                {
                    if (DataBase.Exe_cmd("update ConManager set state='已委托'     where id='" + GridView1.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "'"))
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
             //string[] sArray = deptIDs.ToString().Split(',');


            getData();
           

        }
    }
}