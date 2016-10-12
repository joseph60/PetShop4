using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Model;
using PetShop.IDAL;
namespace PetShop.BLL
{
    class General
    {
        private static readonly IGeneral dal = PetShop.DALFactory.DataAccess.CreateGeneral();
        /// <summary>
        /// 根据APPID，查询条件查询并返回相应数据
        /// </summary>
        /// <param name="APPID">根据此ID确定需要执行的查询操作：SP，SQL</param>
        /// <param name="Params">查询参数</param>
        /// <returns></returns>
        public string GetData(string APPID, string Params)
        {
            string ret="";
            if(!Params.Equals(string.Empty) || APPID.Equals(string.Empty))
            {

            }
            return ret;

        }
    }
}
