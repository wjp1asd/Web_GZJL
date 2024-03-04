using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Web_GZJL.RJZC
{
    public partial class ctest : System.Web.UI.Page
    {
        public string t1 = "", t0 = ""; string sql = "";
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
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TestInfmin WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TestInfmin") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TestInfmin '");
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
        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();

            if (sql != "")
            {
                dt = DataBase.Exe_dt("select  id,   RWNo,FNo,Oname,ChNo,Surface,jianyanren  from   TestInfmin  where state='容器'   " + ViewState["where"].ToString() + "   ");
            }
            else
            { dt = DataBase.Exe_dt("select   id,    RWNo,FNo,Oname,ChNo,Surface,jianyanren   from   TestInfmin  where state='容器'    "); }



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
        private void getCom()
        {

            DataTable dt = DataBase.Exe_dt("select RWNo from   TestInfmin  where state='容器'");

            List<string> roles = new List<string>();
            roles.Add("选择任务编号");
            foreach (DataRow row in dt.Rows) // 遍历所有行
            {
                // 读取列的值
                roles.Add(row["RWNo"].ToString());


            }

            orgname.DataSource = roles;
            orgname.DataBind();
        }

        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            orgname.Text = "";

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        public void alert(string msg)
        {
            Response.Write("<script language=javascript>alert('" + msg + "');</" + "script>");
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            string ID = GridView1.SelectedDataKey.Values["id"].ToString();

            // alert("选中"+index+"id"+ID);
            string url = "../RJZC/detail.aspx?id=" + ID;
            Response.Redirect(url);

        }

        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (orgname.Text.Trim() != "" && orgname.Text.Trim() != "")
            {

                sql += "  and    RWNo   like  '%" + orgname.Text.Trim() + "%' ";
            }

            ViewState["where"] = sql;
            getData();
        }

        #endregion
    }
}