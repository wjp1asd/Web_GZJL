using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.JFGL
{
    public partial class CoverT : System.Web.UI.Page
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
                dt = DataBase.Exe_dt("select  *  from  CoverTest         where  " + ViewState["where"].ToString() + "           order  by  ID   ");
         
           
            }
            else
            {
                dt = DataBase.Exe_dt("select  *  from  CoverTest  order  by  ID   ");
            }
            return dt;     
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_cna.Text.Trim() == "")
            { 
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入单位名称！');", true);
                return;
            }
//wtflname
            if (DataBase.Exe_count("CoverTest", " Orgname='" + DataOper.setTrueString(txt_cna.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('名称已存在！');", true);
                return;
            }//id,wtflname,beizhu   ,'" + DataOper.setTrueString(txt_adres.Text.Trim()) + "','" + DataOper.setTrueString(txt_man.Text.Trim()) + "','" + DataOper.setTrueString(txt_tel.Text.Trim()) + "','" + DataOper.setTrueString(txt_ema.Text.Trim()) + "')
            //ID,'" + DataOper.getlsh("CoverTest", "ID") + "',
            if (DataBase.Exe_cmd("insert into CoverTest(Orgname,Orgadd,Orguser,Orgtel,Emaill,Role) values('" + DataOper.setTrueString(txt_cna.Text.Trim()) + "' ,'" + DataOper.setTrueString(txt_adres.Text.Trim()) + "','" + DataOper.setTrueString(txt_man.Text.Trim()) + "','" + DataOper.setTrueString(txt_tel.Text.Trim()) + "','" + DataOper.setTrueString(txt_ema.Text.Trim()) + "','" + DataOper.setTrueString(txt_role.Text.Trim()) + "')"))
            {
              //   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('单位名称添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('单位名称添加失败！');", true);
            }

            clear();
            getData();
        }

//查询
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_cna.Text.Trim() != "" && txt_cna.Text.Trim() != "")
            {

                sql += "    Orgname   like  '%" + txt_cna.Text.Trim() + "%' ";
            }
            if (txt_adres.Text.Trim() != "")
            {
               
                if (sql == "")
                {
                    sql += "   Orgadd  LIKE  '%" + DataOper.setTrueString(txt_adres.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Orgadd  LIKE  '%" + DataOper.setTrueString(txt_adres.Text.Trim()) + "%'";
                }
            }
            if (txt_man.Text.Trim() != "")
            {
               
                if (sql == "")
                {
                    sql += "   Orguser  LIKE  '%" + DataOper.setTrueString(txt_man.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Orguser  LIKE  '%" + DataOper.setTrueString(txt_man.Text.Trim()) + "%'";
                }
            }
            if (txt_tel.Text.Trim() != "")
            {
               
                if (sql == "")
                {
                    sql += "   Orgtel  LIKE  '%" + DataOper.setTrueString(txt_tel.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Orgtel  LIKE  '%" + DataOper.setTrueString(txt_tel.Text.Trim()) + "%'";
                }
            }
            if (txt_ema.Text.Trim() != "")
            {
               
                if (sql == "")
                {
                    sql += "   Emaill   LIKE  '%" + DataOper.setTrueString(txt_ema.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Emaill   LIKE  '%" + DataOper.setTrueString(txt_ema.Text.Trim()) + "%'";
                }
            }
            if (txt_role.Text.Trim() != "")
            {

                if (sql == "")
                {
                    sql += "   Role  LIKE  '%" + DataOper.setTrueString(txt_role.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Role   LIKE  '%" + DataOper.setTrueString(txt_role.Text.Trim()) + "%'";
                }
            }
            ViewState["where"] = sql;
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
            if (DataBase.Exe_cmd("DELETE FROM  CoverTest WHERE  ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("CoverTest") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'CoverTest '");
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
            TextBox mc = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_mc");//单位名称
            TextBox bz = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_bz");//地址   

            TextBox peo = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_peo");//联系人
            TextBox pho = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_pho");//联系电话   
            TextBox ill = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_ill");//邮件
            TextBox role = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_role");//邮件
            if (mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入单位名称名称！');", true);
                return;
            }

            if (DataBase.Exe_cmd("update CoverTest set Orgname='" + DataOper.setTrueString(mc.Text.Trim()) + "',Role='" + DataOper.setTrueString(role.Text.Trim()) + "',Orgadd='" + DataOper.setTrueString(bz.Text.Trim()) + "' ,Orguser='" + DataOper.setTrueString(peo.Text.Trim()) + "' ,Orgtel='" + DataOper.setTrueString(pho.Text.Trim()) + "' ,Emaill='" + DataOper.setTrueString(ill.Text.Trim()) + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('用户名称编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('单位名称编辑失败！');", true);
            }

            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            txt_cna.Text = "";
            txt_adres.Text = "";
            txt_man.Text = "";
            txt_tel.Text = "";
            txt_ema.Text = "";
            txt_role.Text = "";
        }

    }
}