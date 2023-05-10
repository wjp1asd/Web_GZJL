using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GZJL.admin
{
    public partial class people : System.Web.UI.Page
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
                DataBase.Exe_filllist(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");

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
                dt = DataBase.Exe_dt("select  id,  usrname,  JCName,usrzhiwu,shouji,bangongdh,Pemail  from tb_czjuser       where  " + ViewState["where"].ToString() + "      ORDER BY id ");

            }
            else
            {

                dt = DataBase.Exe_dt("select   id, usrname,   JCName,usrzhiwu,shouji,bangongdh,Pemail  from tb_czjuser ORDER BY id ");
            }
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('选择机构！');", true);
                return;
            }
            if (DataBase.Exe_count("tb_czjuser", " shouji='" + DataOper.setTrueString(txt_Tel.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('此手机号码已存在！');", true);
                return;
            }

            if (DataBase.Exe_cmd("insert into tb_czjuser( ID,JCName,usrzhiwu,usrname,shouji,bangongdh,Pemail  ) values('" + DataOper.getlsh("TB_CZJUSER", "ID") + "','" + DataOper.setTrueString(DropDownList1.SelectedItem.Text) + "','" + DataOper.setTrueString(ddl_zhiwu.SelectedItem.Text) + "','" + DataOper.setTrueString(txt_pname.Text.Trim()) + "','" + DataOper.setTrueString(txt_Tel.Text.Trim()) + "','" + DataOper.setTrueString(txt_phone.Text.Trim()) + "','" + DataOper.setTrueString(txt_email.Text.Trim()) + "')"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('人员信息添加失败！');", true);
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
            if (DataBase.Exe_cmd("DELETE FROM  tb_czjuser WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("tb_czjuser") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'tb_czjuser '");
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
            TextBox  sj= (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_sj");
            TextBox  dh= (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_dh");
            TextBox  eml= (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_Eml");
            TextBox  xm= (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_xm");

            //if (txt_hbh.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入测厚仪编号！');", true);
            //    return;
            //}

            //if (DataBase.Exe_count("tb_czjuser", " shouji='" + DataOper.setTrueString(txt_Tel.Text.Trim()) + "' ") > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('此手机号码已存在！');", true);
            //    return;
            //}
            //if (DataBase.Exe_count("tb_czjuser", " Mac='" + DataOper.setTrueString(txt_Mac.Text.Trim()) + "' ") > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('Mac地址已存在！');", true);
            //    return;
            //}
            if (DataBase.Exe_cmd("update tb_czjuser set usrname='" + DataOper.setTrueString(xm.Text.Trim()) + "',shouji='" + DataOper.setTrueString(sj.Text.Trim()) + "',bangongdh='" + DataOper.setTrueString(dh.Text.Trim()) + "',Pemail='" + DataOper.setTrueString(eml.Text.Trim()) + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('人员信息编辑失败！');", true);
            }

            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }
        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            txt_pname.Text = "";
            txt_Tel.Text = "";
            txt_phone.Text = "";
            txt_email.Text = "";
        }
        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {

            if (txt_pname.Text.Trim() != "" && txt_pname.Text.Trim() != "")
            {

                sql += "    usrname       like  '%" + txt_pname.Text.Trim() + "%' ";
            }


            if (DropDownList1.SelectedItem.Text != "")
            {
                if (sql == "")
                {
                    sql += "  JCName   LIKE  '%" + DataOper.setTrueString(DropDownList1.SelectedItem.Text) + "%'";

                }
                else
                {
                    sql += " AND  JCName  LIKE  '%" + DataOper.setTrueString(DropDownList1.SelectedItem.Text) + "%'";
                }
            }
            if (ddl_zhiwu.SelectedItem.Text != "")
            {
                if (sql == "")
                {
                    sql += "  usrzhiwu   LIKE  '%" + DataOper.setTrueString(ddl_zhiwu.SelectedItem.Text) + "%'";

                }
                else
                {
                    sql += " AND  usrzhiwu  LIKE  '%" + DataOper.setTrueString(ddl_zhiwu.SelectedItem.Text) + "%'";
                }
            }







            if (txt_Tel.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "  shouji   LIKE  '%" + DataOper.setTrueString(txt_Tel.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  shouji  LIKE  '%" + DataOper.setTrueString(txt_Tel.Text.Trim()) + "%'";
                }
            }
            if (txt_phone.Text.Trim() != "")
            {

                if (sql == "")
                {
                    sql += "   bangongdh  LIKE  '%" + DataOper.setTrueString(txt_phone.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  bangongdh  LIKE  '%" + DataOper.setTrueString(txt_phone.Text.Trim()) + "%'";
                }
            }
            if (txt_email.Text.Trim() != "")
            {

                if (sql == "")
                {
                    sql += "   Pemail   LIKE  '%" + DataOper.setTrueString(txt_email.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Pemail   LIKE  '%" + DataOper.setTrueString(txt_email.Text.Trim()) + "%'";
                }
            }

            ViewState["where"] = sql;
            getData();
        }

        #endregion
    }
}