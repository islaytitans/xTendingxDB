using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

            var results = _searchUtility.SearchByTemplateId(args);

            var products = new List<Product>();

            foreach (SearchHit<SearchResultItem> hit in results.Hits)
            {
                products.Add(new Product(hit.Document.GetItem()));
            }

            return products;
        }

        public Product GetProductByUrl(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            string term = url.AbsolutePath.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries).Last();
            term = WebUtility.HtmlDecode(term).Replace("-", " ");

            if (string.IsNullOrEmpty(term))
            {
                return null;
            }

            var products = Search(new ProductSearchArgs(0, 1)
            {
                Term = term,
            }).ToList();

            return products.FirstOrDefault();
        }
    }
}
