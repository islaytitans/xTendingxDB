using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.Products.Entities;
using Sitecore.ContentSearch.SearchTypes;

namespace JonathanRobbins.xTendingxDB.Products.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Search(ProductSearchArgs args);
        Product GetProductByUrl(Uri url);
    }
}
