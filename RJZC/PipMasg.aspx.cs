using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Web_GZJL.RJZC
{
    public partial class PipMasg : System.Web.UI.Page
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
                dt = DataBase.Exe_dt("select id,NumBer,ConName ,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum,YonghuName    from PipManager        where  " + ViewState["where"].ToString() + "            ORDER BY id ");
              }
            else
            {
                dt = DataBase.Exe_dt("select id,NumBer,ConName ,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName    from PipManager ORDER BY id ");
            }
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入管道规格！');", true);
                return;
            }
            if (DataBase.Exe_count("PipManager", " NumBer='" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编号已存在！');", true);
                return;
            }
            if (DataBase.Exe_count("PipManager", " ConName='" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('名称已存在！');", true);
                return;
            }
            //id,'" + DataOper.getlsh("PipManager", "id") + "',
            if (DataBase.Exe_cmd("insert into PipManager(NumBer,ConName,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum,YonghuName) values('" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "','" + DataOper.setTrueString(txt_lbmcbz.Text.Trim()) + "','" + DataOper.setTrueString(TextBox2.Text.Trim()) + "','" + DataOper.setTrueString(txt_man.Text.Trim()) + "','" + DataOper.setTrueString(txt_tel.Text.Trim()) + "','" + DataOper.setTrueString(txt_ema.Text.Trim()) + "','" + DataOper.setTrueString(TextBox3.Text.Trim()) + "','" + DataOper.setTrueString(TextBox1.Text.Trim()) + "','" + DataOper.setTrueString(TextBox4.Text.Trim()) + "')"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
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
TextBox1.Text = "";

TextBox4.Text = "";

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
            if (TextBox4.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "   YonghuName  LIKE  '%" + DataOper.setTrueString(TextBox4.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  YonghuName  LIKE  '%" + DataOper.setTrueString(TextBox4.Text.Trim()) + "%'";
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
                    if (DataBase.Exe_cmd("insert into entrust(cpid,cptype,etst,state) values('" + GridView1.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "','管道','" + DateTime.Now.ToString() + "','待检验')"))
                    {
                        if (DataBase.Exe_cmd("update PipManager set state='已委托'     where id='" + GridView1.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "'"))
                        { }
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