using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.Products.SitecoreConfig;
using JonathanRobbins.xTendingxDB.SearchLogic.Entities;
using JonathanRobbins.xTendingxDB.SearchLogic.Interfaces;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.Products.Entities
{
    public class ProductSearchArgs : SearchArgs
    {
        public ProductSearchArgs(int page, int pageSize) : base(page, pageSize)
        {
            TemplateIds = new List<ID>()
            {
                Templates.Product
            };
        }
    }
}
