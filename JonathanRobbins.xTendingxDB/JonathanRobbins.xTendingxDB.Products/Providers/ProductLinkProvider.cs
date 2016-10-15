using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace JonathanRobbins.xTendingxDB.Products.Providers
{
    public class ProductLinkProvider : IProductLinkProvider
    {
        public string GetProductUrl(string productName)
        {
            string url = LinkManager.GetItemUrl(SitecoreConfig.Nodes.ProductDetails);

            if (url.EndsWith("/"))
            {
                url = url.Remove(url.LastIndexOf('/'));
            }

            int lastSlash = url.LastIndexOf('/');
            url = (lastSlash > -1) ? url.Substring(0, lastSlash + 1) : url;

            return $"{url}{productName.ToLower().Trim().Replace(" ", "-")}";
        }
    }
}
