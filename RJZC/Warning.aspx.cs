using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GZJL.RJZC
{
    public partial class Warning : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
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
            dt = DataBase.Exe_dt("select * from yujing ORDER BY id ");
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (type.Text.Trim() == ""&&type.SelectedIndex!=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入类型！');", true);
                return;
            }
         

            if (DataBase.Exe_cmd("insert into yujing(Type,Times,ystandard) values('"
               + DataOper.setTrueString(type.Text.Trim())
                 + "','" + DataOper.setTrueString(times.Text.Trim())
                + "','" + DataOper.setTrueString(ystandard.Text.Trim()) + "')"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加失败！');", true);
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
            if (DataBase.Exe_cmd("DELETE FROM  yujing WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
              
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
            TextBox mc = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_type");
            TextBox bz = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_times");
            TextBox mc1 = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_ystand");
          //  "update TB_WTFL set wtflname='" + DataOper.setTrueString(mc.Text.Trim())
          //  + "',beizhu='" + DataOper.setTrueString(bz.Text.Trim())
          //  + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"
            string msg = "update yujing set Type='"
                + DataOper.setTrueString(mc.Text.Trim()) 
                + "',Times='" + DataOper.setTrueString(bz.Text.Trim())
                + "',ystandard='" + DataOper.setTrueString(mc1.Text.Trim())
                +"' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            if (DataBase.Exe_cmd(msg))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑失败！"+msg+"');", true);
            }

            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }
        protected void ddl_zhiwu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {   
           
            times.Text = "";
            ystandard.Text = "";
        }

    }
}