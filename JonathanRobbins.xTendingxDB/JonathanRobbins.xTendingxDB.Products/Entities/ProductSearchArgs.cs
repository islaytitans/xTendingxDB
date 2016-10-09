using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.SearchLogic.Interfaces;
using Sitecore.ContentSearch.SearchTypes;

namespace JonathanRobbins.xTendingxDB.Products.Entities
{
    public class ProductSearchArgs//<T> where T : SearchResultItem
    {
        public string IndexName { get; private set; }
        //public ISearchUtility<T> SearchUtility { get; private set; }

        public ProductSearchArgs(string indexName) // , ISearchUtility<T> searchUtility)
        {
            IndexName = indexName;
            //SearchUtility = searchUtility;
        }
    }
}
