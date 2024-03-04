using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace Web_GZJL.RJZC
{
    public partial class Jour : System.Web.UI.Page
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
              //  DataBase.Exe_filllist(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");
               
                getData();

            }

        }

        private void getrole()
        {

            DataTable dt = DataBase.Exe_dt("select rolename from sys_role");

            List<string> roles = new List<string>();
            roles.Add("选择角色");
            foreach (DataRow row in dt.Rows) // 遍历所有行
            {
                // 读取列的值
                roles.Add(row["rolename"].ToString());


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
                dt = DataBase.Exe_dt("select  id,  usrname,  JCName,usrzhiwu,shouji,bangongdh,Pemail,PeoRole,pass  from tb_czjuser       where  " + ViewState["where"].ToString() + "      ORDER BY id ");

            }
            else
            {

                dt = DataBase.Exe_dt("select   id, usrname,   JCName,usrzhiwu,shouji,bangongdh,Pemail,PeoRole,pass from tb_czjuser ORDER BY id ");
            }
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
           
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
           

            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }
        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            txt_pname.Text = "";
          
        }

        protected void ddl_zhiwu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {

            if (txt_pname.Text.Trim() != "" && txt_pname.Text.Trim() != "")
            {

                sql += "    usrname       like  '%" + txt_pname.Text.Trim() + "%' ";
            }


           
            ViewState["where"] = sql;
            getData();
        }

        #endregion
    }
}