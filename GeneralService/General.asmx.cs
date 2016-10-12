using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PetShop.BLL;
using System.Web.UI;

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
    public class General : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 根据指定的条件，返回检索结果 
        /// 参数应包括：UserID（部门ID+APPID？），功能ID，参数串（以name=value|name=value形式）
        /// </summary>
        /// <returns>
        /// 返回结果，以Json格式封装
        /// </returns>
        [WebMethod]
        public string GetData(string APPID,string Params)
        {
            if (APPID.Equals(string.Empty)) return "必须指定APPID";
            
           
            return "Hello World";
        }
    }
}
