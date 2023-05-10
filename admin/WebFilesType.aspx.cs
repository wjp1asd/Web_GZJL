﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
/*
 * 张少鹏
 * 文档类别
 */
namespace Web_GZJL.admin
{
    public partial class WebFilesType : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["userid"] = "admin";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/error.aspx", true);
                return;
            }


            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!Page.IsPostBack)
            {
                BindDate();
            }

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_add_Click(object sender, EventArgs e)
        {
            if (txtTypeName.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('类别名称不能为空！')", true);
            }
            else if (txtManual.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('类别说明不能为空！')", true);
            }
            else
            {
                //添加文档类型到数据库
                InsertFiletype();
                Clear();
                BindDate();
            }

        }

        #region 绑定gridview数据
        /// <summary>
        /// 绑定gridview数据
        /// </summary>
        private void BindDate()
        {
            string sql = string.Format("select id,typename,[manual] from tb_fileType");
            try
            {
                DataTable dt = DataBase.Exe_dt(sql);
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gv_filetype.DataSource = dt;
                    gv_filetype.DataBind();
                    int columnCount = gv_filetype.Rows[0].Cells.Count;
                    gv_filetype.Rows[0].Cells.Clear();
                    gv_filetype.Rows[0].Cells.Add(new TableCell());
                    gv_filetype.Rows[0].Cells[0].ColumnSpan = columnCount;
                    gv_filetype.Rows[0].Cells[0].Text = "";
                }
                else
                {
                    gv_filetype.DataSource = dt;
                    gv_filetype.DataKeyNames = new string[] { "id" };//主键列
                    gv_filetype.DataBind();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 添加文档类型
        /// <summary>
        /// 添加文档类型
        /// </summary>
        private void InsertFiletype()
        {
            string id = DataOper.getlsh("tb_filetype", "id");
            string typename = txtTypeName.Text.Trim();
            string manual = txtManual.Text.Trim();

            string sql = string.Format("insert into tb_FileType(id,typename,[manual]) values('{0}','{1}','{2}')",id,typename,manual);
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                   // ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('添加成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('添加失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 根据id更新文档类型的信息
        /// <summary>
        /// 根据id更新文档类型的信息
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="typename">文档类型名称</param>
        /// <param name="manual">类型说明</param>
        private void UpdateFileType(string id,string typename,string manual)
        {
            string sql = string.Format("update tb_fileType set typename='{0}',[manual]='{1}' where id='{2}'",typename,manual,id);
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                  //  ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('更新成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('更新失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 清空
        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            txtManual.Text = "";
            txtTypeName.Text = "";
        }
        #endregion
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_filetype.EditIndex = -1;
            BindDate();
        }
        /// <summary>
        /// 数据绑定时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (DataBase.Exe_cmd("DELETE FROM  tb_fileType WHERE  ID ='" + gv_filetype.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("tb_fileType") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'tb_fileType '");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                BindDate();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_filetype.EditIndex = e.NewEditIndex;
            BindDate();
            
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox type = (TextBox)gv_filetype.Rows[e.RowIndex].Cells[0].FindControl("txtType");
            TextBox manual = (TextBox)gv_filetype.Rows[e.RowIndex].Cells[0].FindControl("txtmanual");
            if (type.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('请输入文档类型名称！');", true);
                return;
            } if (manual.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('请输入文档类型说明！');", true);
            }
            else
            {
                UpdateFileType(gv_filetype.DataKeys[e.RowIndex].Value.ToString(),type.Text.Trim(),manual.Text.Trim());
            }
     
            this.gv_filetype.EditIndex = -1;
            BindDate();
        }


    }
}
