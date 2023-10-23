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
            case "task":
                    this.Task(context);
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
            }
           
          
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
       
        //容器信息列表 +id 查询
        private void rongqiinfo(HttpContext context)
        {
            String sql = context.Request.QueryString["cid"];
            DataTable dt = new DataTable();
            if (sql.Length>0)
            { dt = DataBase.Exe_dt("select id,NumBer,ConName,JiantiHoudu,FengtouHoudu,BudianNum,YonghuName  from ConManager    where id = " + sql + "   ORDER BY id "); }
            else
            {
                dt = DataBase.Exe_dt("select id,NumBer,ConName,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName from ConManager      ORDER BY id ");
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
            if (sql.Length > 0)
            {
                dt = DataBase.Exe_dt("select id,NumBer,ConName ,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum,YonghuName    from PipManager        where  id =" + sql + "            ORDER BY id ");
            }
            else
            {
                dt = DataBase.Exe_dt("select id,NumBer,ConName ,GuandaoType,GudandaoJibie,Guandaocaizhi,JiantiHoudu,FengtouHoudu,BudianNum ,YonghuName    from PipManager ORDER BY id ");
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
                dt = DataBase.Exe_dt("select  ID,   cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu   from  (     select   Entrust.ID,    cpid, YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  ConManager  on cpid=ConManager.ID   where    cptype='容器'  union All  select    Entrust.ID,     cpid,YonghuName,ConName,cptype,JiantiHoudu,FengtouHoudu  from  Entrust left  join  PipManager   on cpid=PipManager.id  where  cptype='管道'    )  as a ");
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
        // 登录
        public void Login(HttpContext context) {
          
            context.Response.ContentType = "application/json";
            String name = context.Request.QueryString["userid"];
            String pass = context.Request.QueryString["password"];
            if (DataBase.Exe_count("SYS_USER", " USERID='" + name + "' and  USERPASS='" + DataOper.encryptsha1(pass.ToLower()) + "'") > 0)
            {
            
                JObject o = new JObject();
                o["err"] = 0;
                o["message"] = "登录成功";
                string json = JsonConvert.SerializeObject(o);
                context.Response.Write(json);
              
            }
            else
            {
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