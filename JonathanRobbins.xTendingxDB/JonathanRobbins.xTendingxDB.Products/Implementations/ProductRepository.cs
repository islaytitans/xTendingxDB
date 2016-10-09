using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.Products.Entities;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using JonathanRobbins.xTendingxDB.Products.SitecoreConfig;
using JonathanRobbins.xTendingxDB.SearchLogic.Interfaces;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Search;

namespace JonathanRobbins.xTendingxDB.Products.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private ISearchUtility<SearchResultItem> _searchUtility;

        public ProductRepository()
        {

        }

        public ProductRepository(ISearchUtility<SearchResultItem> searchUtility)
        {
            _searchUtility = searchUtility;
        }

        public IEnumerable<Product> Search(ProductSearchArgs args)
        {
            if (args == null)
            {
                throw new ArgumentException("args");
            }
            if (string.IsNullOrWhiteSpace(args.IndexName))
            {
                throw new ArgumentException("args.IndexName");
            }

            var results = _searchUtility.SearchByTemplateId(new List<ID>()
            {
                Templates.Product
            });

            var products = new List<Product>();

            foreach (SearchHit<SearchResultItem> hit in results.Hits)
            {
                products.Add(new Product(hit.Document.GetItem()));
            }

            return products;
        } 
    }
}
