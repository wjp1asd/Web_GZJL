using MathNet.Numerics.Distributions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using static System.Net.WebRequestMethods;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using DataTable = System.Data.DataTable;

namespace Web_GZJL
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler
    {

        public void ProcessRequest(HttpContext context )
        {
            string method = context.Request.QueryString["do"];
          //  context.Response.Write(method);
            // 状态来切换对应函数
            switch (method) {
            case "login":
                    this.Login(context);
                    break;
                case "testadmin":
                    this.Testadmin(context);
                    break;
                case "task":
                    this.Task(context);
                    break;
                case "task1":
                    this.Task1(context);
                    break;
                case "check":
                    this.Check(context);
                    break;
            case "shebei":
                    this.sheBei(context);
                    break;
                case "guandaoinfo":
                    this.guandaoinfo(context);
                    break;
                case "rongqiinfo":
                    this.rongqiinfo(context);
                    break;
                case "yuhe":
                    this.yuhe(context);
                    break;
                case "cedian":
                    this.cedian(context);
                    break;
                case "upcedian":
                    this.upcedian(context);

                    break;
                case "yujing":
                    this.yujing(context);
                    break;
//
                case "com":
                    this.com(context);
                    break;
                case "jigou":
                    this.jigou(context);
                    break;
            }
           
          
        }

        private void upcedian(HttpContext context)
        {
            String id = context.Request.QueryString["id"];
            String p1 = context.Request.QueryString["p1"];
            String p2 = context.Request.QueryString["p2"];
            String p3 = context.Request.QueryString["p3"];
            String p4 = context.Request.QueryString["p4"];
            String p5 = context.Request.QueryString["p5"];
            String p6 = context.Request.QueryString["p6"];
            String p7 = context.Request.QueryString["p7"];
            String p8 = context.Request.QueryString["p8"];
            String p9 = context.Request.QueryString["p9"];
            String p10= context.Request.QueryString["p10"];
            String p11 = context.Request.QueryString["p11"];
            String p12 = context.Request.QueryString["p12"];
            String p13 = context.Request.QueryString["p13"];

            string str = "update TestInfmin Set Mptkns1 ='" + DataOper.setTrueString(p1) + "',"
                
                 + "Mptkns2 ='" + DataOper.setTrueString(p2) + "',"
              
                 + "Mptkns3 ='" + DataOper.setTrueString(p3) + "',"
               
                 + "Mptkns4='" + DataOper.setTrueString(p4) + "',"
              
                 + "Mptkns5 ='" + DataOper.setTrueString(p5) + "',"
               
                 + "Mptkns6 ='" + DataOper.setTrueString(p6) + "',"
               
                 + "Mptkns7 ='" + DataOper.setTrueString(p7) + "',"
               
                 + "Mptkns8 ='" + DataOper.setTrueString(p8) + "',"
               
                 + "Mptkns9 ='" + DataOper.setTrueString(p9) + "',"
               
                 + "Mptkns10='" + DataOper.setTrueString(p10) + "',"
               
                 + "Mptkns11 ='" + DataOper.setTrueString(p11) + "',"
               
                 + "Mptkns12 ='" + DataOper.setTrueString(p12) + "',"
                 
                 + "Mptkns13 ='" + DataOper.setTrueString(p13) + "',"
               
                 + "wrtime ='" + DataOper.setTrueString(DateTime.Now.ToString().Trim())+ "'"
                 +" where id =" + id;

            if (DataBase.Exe_cmd(str))
            {
                //    upimg();
                JObject o = new JObject();
                o["err"] = 0;
                o["message"] = "提交成功";
                string json = JsonConvert.SerializeObject(o);
                context.Response.Write(json);
            }
            else
            {

                JObject o = new JObject();
                o["err"] = 1;
                o["message"] = "提交失败"+str;
                string json = JsonConvert.SerializeObject(o);
                context.Response.Write(json);
            }
        }

        private void jigou(HttpContext context)
        {

            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select DEPARTNAME from SYS_DEPART");


            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }
        private void com(HttpContext context)
        {

            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select OrgName from CoverTest");


            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }
        private void yujing(HttpContext context)
        {

            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from yujing");


            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }
        private void yuhe(HttpContext context)
        {
           
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select id,wtflname,beizhu from TB_WTFL ORDER BY id ");
        

            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }
        
     private void cedian(HttpContext context)
        {
          //  String sql = context.Request.QueryString["rw"];
            DataTable dt = new DataTable();
        //    if (sql.Length>0)
        //    { dt = DataBase.Exe_dt("select *  from TestInfmin    where RWNo = " + sql + "   ORDER BY id "); }
        //   else  {
       dt = DataBase.Exe_dt("select *  from TestInfmin"); 
            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }
       
        //容器信息列表 +id 查询123
        private void rongqiinfo(HttpContext context)
        {
            String sql = context.Request.QueryString["cid"];
            DataTable dt = new DataTable();
            if (sql.Length>0)
            { dt = DataBase.Exe_dt("select * from ConManager    where id = " + sql + "   ORDER BY id "); }
            else
            {
                dt = DataBase.Exe_dt("select * from ConManager      ORDER BY id ");
            }

            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }

        //管道信息列表 +id 查询
        private void guandaoinfo(HttpContext context)
        {
            String sql = context.Request.QueryString["gid"];
            DataTable dt = new DataTable();
            string str = "select * from PipManager where  id =" + sql + "";
            if (sql.Length > 0)
            {
                dt = DataBase.Exe_dt(str);

            }
            else {
                dt = DataBase.Exe_dt("select * from PipManager");

            }
            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));

            // 返回结果  



        }

        //测厚仪查询
        private void sheBei(HttpContext context)
        {
            String sql = context.Request.QueryString["mac"];
            DataTable dt = new DataTable();
            if (sql.Length > 0)
            {
                dt = DataBase.Exe_dt("select id,Sbjingdu,Sbnumber,Mac,State from ShebeiManager       where Mac= " +sql + "      ORDER BY id ");

            }
            else
            {

                dt = DataBase.Exe_dt("select id,Sbjingdu,Sbnumber,Mac,State from ShebeiManager ORDER BY id ");
            }

            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));

        }

        private void Check(HttpContext context)
        {
            throw new NotImplementedException();
        }
        private void Task1(HttpContext context)
        {
            String writme = context.Request.QueryString["wrtime"];
            String gid = context.Request.QueryString["GJNO"];
            DataTable dt = new DataTable();


            if (gid.Length > 0)
            {
         
                dt = DataBase.Exe_dt("select top 1 * from   TestInfmin " + "where GJNo = " + gid  + " and wrtime <= '" +writme  + "'order by wrtime desc");
            }

             context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {

                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }



        // 任务列表
        private void Task(HttpContext context)
        {
            String type = context.Request.QueryString["type"];
            DataTable dt = new DataTable();
            
          
           
            if (type == "容器")
            {
                dt = DataBase.Exe_dt("select  Entrust.ID,   cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager          on cpid=ConManager.ID   where   cptype='容器' ");
                //DataBase.Exe_dt("select id,NumBer,ConName,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName   ,stype='容器'    from ConManager      where    state='已委托'      ORDER BY id "); 
            }
            else if (type == "管道")
            {
                dt = DataBase.Exe_dt("select   Entrust.ID,    cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  PipManager   on cpid=PipManager.id  where  cptype='管道'");
                //DataBase.Exe_dt("select id,NumBer,ConName ,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName    ,stype='管道'     from PipManager        where    state='已委托'      ORDER BY id ");
            }
            else
            {
                dt = DataBase.Exe_dt("select  ID,cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu   from  (     select   Entrust.ID,    cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager  on cpid=ConManager.ID   where    cptype='容器'  union All  select    Entrust.ID,     cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  PipManager   on cpid=PipManager.id  where  cptype='管道'    )  as a ");
                //DataBase.Exe_dt("select id,NumBer,ConName ,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName   ,stype='管道'     from PipManager           where    state='已委托'             union  all  select id,NumBer,ConName,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName   ,stype='容器'    from ConManager        where    state='已委托'       ORDER BY id ");
            }
            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            
            context.Response.Write(jsSerializer.Serialize(parentRow));
        }

        private void Testadmin(HttpContext context)
        {
            //string type = context.Request.QueryString["type"];
            DataTable dt = new DataTable();
            string kj = context.Request.QueryString["key"];


            if (kj.Length>0)
            {
                dt = DataBase.Exe_dt("select * from   TestInfmin " + "where state like " + "'%" + kj + "%'" + " or WTNo like" + "'%" + kj + "%'" + " or FNo like" + "'%" + kj + "%'" + " or GJNo like" + "'%" + kj + "%'") ;
            }
            else
            {
                dt = DataBase.Exe_dt("select * from   TestInfmin");
            }
            context.Response.ContentType = "application/json";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                  
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            context.Response.Write(jsSerializer.Serialize(parentRow));
        }

        //

        // 登录
        public void Login(HttpContext context) {
          
            context.Response.ContentType = "application/json";
            String name = context.Request.QueryString["userid"];
            String pass = context.Request.QueryString["password"];
            String Jname = context.Request.QueryString["Jname"];
           
            if (DataBase.Exe_count("tb_czjuser", "shouji='" + name + "' and  pass='" + pass+ "' and JCName='" + Jname + "'") > 0)
            {
            
                JObject o = new JObject();
                DataTable dt = new DataTable();
                dt = DataBase.Exe_dt("select * from  tb_czjuser " + "where shouji like " + "'%" + name + "%'" );
                context.Response.ContentType = "application/json";
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dt.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);
                    }
                    parentRow.Add(childRow);
                }

             //   context.Response.Write(jsSerializer.Serialize(parentRow));
                o["err"] = 0;
                o["message"] = "登录成功";
                o["person"] = JsonConvert.SerializeObject(parentRow[0]);
                string json = JsonConvert.SerializeObject(o);
                context.Response.Write(json);
              
            }
            else
            {
                context.Response.Write("shouji='" + name + "' and  pass='" + pass + "' and  JCName='" + Jname + "'");
                JObject o = new JObject();
                o["err"] = 1;
                o["message"] = "登录失败";
                string json = JsonConvert.SerializeObject(o);
                context.Response.Write(json);
                return;
            }
         
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}