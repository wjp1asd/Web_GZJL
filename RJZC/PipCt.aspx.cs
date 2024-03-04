using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Web_GZJL.RJZC
{
    public partial class PipCt : System.Web.UI.Page
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
                getorg();
                getData();

            }

        }

        private void getorg()
        {

            DataTable dt = DataBase.Exe_dt("select departid,departname,id from sys_depart");

            List<string> roles = new List<string>();
            roles.Add("选择机构");
            foreach (DataRow row in dt.Rows) // 遍历所有行
            {
                // 读取列的值
                roles.Add(row["departname"].ToString());


            }

            type.DataSource = roles;
            type.DataBind();
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
                dt = DataBase.Exe_dt("select id,Sbjingdu,Sbnumber,Mac,modelNum,instrumentNum,lastVeri,veriExpire,State,Org from ShebeiManager       where  " + ViewState["where"].ToString() + "      ORDER BY id ");
        
            }
            else
            {

                dt = DataBase.Exe_dt("select id,Sbjingdu,Sbnumber,Mac,modelNum,instrumentNum,lastVeri,veriExpire,State,Org from ShebeiManager ORDER BY id ");
            }
            return dt;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_hbh.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入测厚仪编号！');", true);
                return;
            }

            if (DataBase.Exe_count("ShebeiManager", " Mac='" + DataOper.setTrueString(txt_Mac.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('Mac地址已存在！');", true);
                return;
            }
            if (DataBase.Exe_cmd("insert into ShebeiManager(Sbjingdu,Sbnumber,Mac,State,modelNum,instrumentNum,lastVeri,veriExpire,Org) values('" + DataOper.setTrueString(txt_hjd.Text.Trim()) + "','" + DataOper.setTrueString(txt_hbh.Text.Trim()) + "','" + DataOper.setTrueString(txt_Mac.Text.Trim()) + "','" + DataOper.setTrueString(txt_st.Text.Trim())
                + "','" + DataOper.setTrueString(txt_model.Text.Trim()) + "','" + DataOper.setTrueString(txt_instr.Text.Trim()) + "','" + DataOper.setTrueString(txt_lastime.Text.Trim()) 
                + "','" + DataOper.setTrueString(txt_end.Text.Trim())
                + "','" + DataOper.setTrueString(type.SelectedItem.Text.Trim())
                + "')"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('测厚仪添加失败！');", true);
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
            if (DataBase.Exe_cmd("DELETE FROM  ShebeiManager WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("ShebeiManager") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'ShebeiManager '");
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
            TextBox mc = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_no");
            TextBox bz = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_jd");
            TextBox ac = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_mc");
            TextBox zt = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_zt");
            TextBox model = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_modelNum");
            TextBox instrr = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_instNum");
            TextBox last = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_last");
            TextBox end= (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txt_end");
            //if (txt_hbh.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入测厚仪编号！');", true);
            //    return;
            //}

            if (DataBase.Exe_count("ShebeiManager", " Sbnumber='" + DataOper.setTrueString(txt_hbh.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('测厚仪编号已存在！');", true);
                return;
            }
            if (DataBase.Exe_count("ShebeiManager", " Mac='" + DataOper.setTrueString(txt_Mac.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('Mac地址已存在！');", true);
                return;
            }
          //  modelNum,instrumentNum,lastVeri,veriExpire
            if (DataBase.Exe_cmd("update ShebeiManager set Sbnumber='" + DataOper.setTrueString(mc.Text.Trim())
                + "',modelNum='" + DataOper.setTrueString(model.Text.Trim())
                + "',instrumentNum='" + DataOper.setTrueString(instrr.Text.Trim())
                + "',lastVeri='" + DataOper.setTrueString(last.Text.Trim())
                + "',veriExpire='" + DataOper.setTrueString(end.Text.Trim())
                + "',Sbjingdu='" + DataOper.setTrueString(bz.Text.Trim()) + "',Mac='" + DataOper.setTrueString(ac.Text.Trim()) + "',State='" + DataOper.setTrueString(zt.Text.Trim()) + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('测厚仪编辑失败！');", true);
            }

            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }
        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
          
            txt_hbh.Text = "";
txt_hjd.Text = "";
txt_Mac.Text = "";
txt_st.Text = "";
            txt_instr.Text = "";
            txt_model.Text = "";

        }
        #region 查询
        //查询
        protected void btn_find_Click(object sender, EventArgs e)
        {

            if (txt_hbh.Text.Trim() != "" && txt_hbh.Text.Trim() != "")
            {

                sql += "  Sbnumber     like  '%" + txt_hbh.Text.Trim() + "%' ";
            }
            if (txt_hjd.Text.Trim() != "")
            {
                if (sql == "")
                {
                    sql += "  Sbjingdu   LIKE  '%" + DataOper.setTrueString(txt_hjd.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Sbjingdu  LIKE  '%" + DataOper.setTrueString(txt_hjd.Text.Trim()) + "%'";
                }
            }
            if (txt_Mac.Text.Trim() != "")
            {
                
                if (sql == "")
                {
                    sql += "   Mac  LIKE  '%" + DataOper.setTrueString(txt_Mac.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Mac  LIKE  '%" + DataOper.setTrueString(txt_Mac.Text.Trim()) + "%'";
                }
            }
            if (txt_st.Text.Trim() != "")
            {
                
                if (sql == "")
                {
                    sql += "   State   LIKE  '%" + DataOper.setTrueString(txt_st.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  State   LIKE  '%" + DataOper.setTrueString(txt_st.Text.Trim()) + "%'";
                }
            }
            if (txt_lastime.Text.Trim() != "")
            {

                if (sql == "")
                {
                    sql += "   lastVeri   LIKE  '%" + DataOper.setTrueString(txt_st.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  lastVeri   LIKE  '%" + DataOper.setTrueString(txt_st.Text.Trim()) + "%'";
                }
            }
            if (txt_end.Text.Trim() != "")
            {

                if (sql == "")
                {
                    sql += "   veriExpire   LIKE  '%" + DataOper.setTrueString(txt_st.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  veriExpire   LIKE  '%" + DataOper.setTrueString(txt_st.Text.Trim()) + "%'";
                }
            }

            if (type.Text.Trim() != "" &&type.SelectedIndex!=0)
            {

                if (sql == "")
                {
                    sql += "   Org  LIKE  '%" + DataOper.setTrueString(type.Text.Trim()) + "%'";

                }
                else
                {
                    sql += " AND  Org  LIKE  '%" + DataOper.setTrueString(type.Text.Trim()) + "%'";
                }
            }
            ViewState["where"] = sql;
            getData();
        }

        #endregion
    }
}