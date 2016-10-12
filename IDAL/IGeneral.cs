using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Model;

namespace PetShop.IDAL
{
    public interface IGeneral
    {
        /// <summary>
		/// Method to search products by a set of keyword
		/// </summary>
		/// <param name="keywords">An array of keywords to search by</param>
		/// <returns>Interface to Model Collection Generic of search results</returns>
        IList<ProductInfo> GetDataBySearch(string keywords);
    }
}
