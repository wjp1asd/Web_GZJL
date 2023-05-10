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
                dt = DataBase.Exe_dt("select  id,   RWNo,FNo,Oname,ChNo,Surface  from   TestInfmin  where state='容器'   " + ViewState["where"].ToString() + "   ");
            }
            else
            { dt = DataBase.Exe_dt("select   id,    RWNo,FNo,Oname,ChNo,Surface  from   TestInfmin  where state='容器'    "); }



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
            if (txt_copi.Text.Trim() != "" && txt_copi.Text.Trim() != "")
            {

                sql += "  and    RWNo   like  '%" + txt_copi.Text.Trim() + "%' ";
            }

            ViewState["where"] = sql;
            getData();
        }

        #endregion
    }
}