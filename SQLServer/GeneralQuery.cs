using PetShop.DBUtility;
using PetShop.IDAL;
using PetShop.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
//using System.Web.Script.Serialization;

namespace PetShop.SQLServerDAL
{
    class GeneralQuery : IGeneralQuery
    {
        ///根据APPID查询所要执行的查询的相关信息
        ///1.数据库连接：连接字符串
        ///2.查询类型：存储过程，SQL脚本
        ///3.查询执行的文本
        private const string SQL_SELECT_GENERAL_QUERY_BY_APPID = "SELECT  DBType,DBConnection, COMMANDTYPE, SQL FROM MS_APPCONFIG WHERE SystemId = @APPId AND FunctionID=@FunID";
        private const string PARM_APPID = "@AppID";
        private const string PARM_FUNID = "@FunID";


        /// <summary>
        /// 从数据库取得相关功能的查询配置信息
        /// </summary>
        /// <param name="APPID"></param>
        /// <param name="FUNCID"></param>
        /// <returns></returns>
        private QueryInfo GetQueryInfo(int APPID, int FUNCID)
        {
            QueryInfo qi;
            SqlParameter[] Params = new SqlParameter[2];
            SqlParameter p = new SqlParameter(PARM_APPID, SqlDbType.Int);
            p.Value = APPID;
            Params[0] = p;

            p = new SqlParameter(PARM_FUNID, SqlDbType.Int);
            p.Value = FUNCID;

            Params[1] = p;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_GENERAL_QUERY_BY_APPID, Params))
            {
                if (rdr.Read())
                {
                    qi = new QueryInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));

                }
                else
                    throw new ArgumentException("无法找到关联的查询配置信息。");
            }

            return qi;
        }

        private string GetString(QueryInfo qi, SqlParameter[] Params)
        {
            string strRet = string.Empty;
            if (qi.DBTYPE == "1") //通过GeneralQuery直接访问数据库
                strRet = SqlHelper.ExecuteScalar(qi.ConnectionString, qi.ScriptType, qi.SQL, Params).ToString();
            else if (qi.DBTYPE == "2") //通过加载dll实现
            {
                Assembly ass = Assembly.LoadFrom(qi.ConnectionString);
                Type type = ass.GetType(qi.TypeName);
                Object obj = Activator.CreateInstance(type);
                MethodInfo mi = type.GetMethod(qi.SQL, new System.Type[] { typeof(System.String) });
                object[] args = new object[1];
                args[0] = Params[0].Value;
                strRet = (string)mi.Invoke(obj, args);
            }

            return strRet;
        }

        private DataSet GetDataSet(QueryInfo qi, SqlParameter[] Params)
        {
            DataSet ds = new DataSet();
            if (qi.DBTYPE == "1") //通过GeneralQuery直接访问数据库
                ds = SqlHelper.ExecuteQuery(qi.ConnectionString, qi.ScriptType, qi.SQL, Params);
            else if (qi.DBTYPE == "2") //通过加载dll实现
            {
                Assembly ass = Assembly.LoadFrom(qi.ConnectionString);
                Type type = ass.GetType(qi.TypeName);
                Object obj = Activator.CreateInstance(type);
                MethodInfo mi = type.GetMethod(qi.SQL, new System.Type[] { typeof(System.String) });
                object[] args = new object[1];
                args[0] = Params[0].Value;
                ds = (DataSet)mi.Invoke(obj, args);
            }

            return ds;
        }
        public string GetString(int APPID, int FUNCID, SqlParameter[] Params)
        {
            string strRet = string.Empty;
            QueryInfo qi = GetQueryInfo(APPID, FUNCID);


            strRet = GetString(qi, Params);// SqlHelper.ExecuteScalar(qi.ConnectionString, qi.ScriptType, qi.SQL, Params).ToString();

            //strRet = new JavaScriptSerializer().Serialize(qi);
            //qi = new JavaScriptSerializer().Deserialize<QueryInfo>(strRet);
            return strRet;
        }

        public DataSet GetDataSet(int APPID, int FUNCID, SqlParameter[] Params)
        {
            QueryInfo qi = GetQueryInfo(APPID, FUNCID);

            return GetDataSet(qi, Params);
        }
    }
}
