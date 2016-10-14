using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Model;
using System.Data.SqlClient;
using System.Data;

namespace PetShop.IDAL
{
    public interface IGeneralQuery
    {
        /// <summary>
		/// Method to search products by a set of keyword
		/// </summary>
		/// <param name="keywords">An array of keywords to search by</param>
		/// <returns>Interface to Model Collection Generic of search results</returns>
        string GetString(int APPID, int FUNCID, SqlParameter[] Params);
        DataSet GetDataSet(int APPID, int FUNCID, SqlParameter[] Params);
    }
}
