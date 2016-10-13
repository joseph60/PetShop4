using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PetShop.BLL;
using System.Web.UI;
using System.Data.SqlClient;

namespace GeneralService
{
    /// <summary>
    /// General 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class GeneralQuery : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 检查参数
        /// </summary>
        /// <param name="APPID"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        private IList<SqlParameter>  PrepareParameters( string Params)
        {
            if(Params.Trim().Length==0)return new List<SqlParameter>();
            IList<SqlParameter> Parameters = new List<SqlParameter>();
            try
            {
                SqlParameter param;


                string[] ParamSplit = Params.Split('|');
                foreach (string str in ParamSplit)
                {
                    param = new SqlParameter(str.Substring(0, str.IndexOf('=')), System.Data.SqlDbType.NVarChar,20);
                    param.Value = str.Substring(str.IndexOf('=') + 1);
                    Parameters.Add(param);
                }
            }
            catch
            {
                throw new ArgumentException("参数解析错误。");
            }
            return Parameters;
        }
        /// <summary>
        /// 根据指定的查询条件，返回字符串 
        /// 参数应包括：UserID（部门ID+APPID？），功能ID，参数串（以name=value|name=value形式）
        /// </summary>
        /// <returns>
        /// 返回结果，以Json格式封装
        /// </returns>
        [WebMethod]
        public string GetString(int APPID, int FUNCID, string Params)
        {
            if (APPID==0) throw new ArgumentException( "必须指定APPID");
            if (FUNCID == 0) throw new ArgumentException("必须指定FUNCID");


            IList<SqlParameter> Parameters = PrepareParameters(Params);
            PetShop.BLL.GeneralQuery gen = new PetShop.BLL.GeneralQuery();
            string strRet = gen.GetString(APPID, FUNCID, Parameters.ToArray());




            return strRet;
        }

        /// <summary>
        /// 根据指定的查询条件，返回数据集 
        /// 参数应包括：UserID（部门ID+APPID？），功能ID，参数串（以name=value|name=value形式）
        /// </summary>
        /// <returns>
        /// 返回结果，以Json格式封装
        /// </returns>
        [WebMethod]
        public string GetDataSet(int APPID, int FUNCID, string Params)
        {
            if ( APPID == 0) throw new ArgumentException("必须指定APPID");
            if ( FUNCID == 0) throw new ArgumentException("必须指定FUNCID"); 


            IList<SqlParameter> Parameters = PrepareParameters(Params);



            return "Hello World";
        }
    }
}
