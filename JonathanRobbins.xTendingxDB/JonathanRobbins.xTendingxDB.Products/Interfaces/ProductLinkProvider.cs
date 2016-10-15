using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanRobbins.xTendingxDB.Products.Interfaces
{
    public interface IProductLinkProvider
    {
        string GetProductUrl(string productName);
    }
}
