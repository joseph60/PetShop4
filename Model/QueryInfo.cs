using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PetShop.Model
{
    [Serializable]
    /// <summary>
    /// 所要执行的数据库查询的配置信息
    /// </summary>
    public class QueryInfo
    {

        private string _DBType;
        private string _DBConnection;
        private CommandType _COMMANDTYPE;
        private string _SQL;
        private string _TypeName;
        public QueryInfo() { }
        public QueryInfo(string DBTYPE, string DBConnection,string COMMANDTYPE,string SQL) {
            _DBType = DBTYPE;
            _DBConnection = DBConnection;
            if (DBTYPE == "1")
            {
                if (COMMANDTYPE == "TEXT") _COMMANDTYPE = CommandType.Text;
                else
                    if (COMMANDTYPE == "SP") _COMMANDTYPE = CommandType.StoredProcedure;
            }
            else
            {
                _TypeName = COMMANDTYPE;
            }
            _SQL = SQL;

        }

        public string DBTYPE
        {
            get
            {
                return _DBType;
            }

          
        }

        public string TypeName
        {
            get
            {
                return _TypeName;
            }


        }

        public string ConnectionString
        {
            get
            {
                return _DBConnection;
            }

           
        }

        public CommandType ScriptType
        {
            get
            {
                return _COMMANDTYPE;
            }

           
        }

        public string SQL
        {
            get
            {
                return _SQL;
            }

           
        }
    }
}
