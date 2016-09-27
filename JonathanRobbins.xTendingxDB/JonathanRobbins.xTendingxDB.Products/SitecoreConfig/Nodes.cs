using System.Linq;
using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.Products.SitecoreConfig
{
    public class Nodes : Core.SitecoreConfig.Nodes
    {
        private static Item _productListing;
        public static Item ProductListing
        {
            get
            {
                if (_productListing == null)
                {
                    _productListing = SiteHome.GetChildren().FirstOrDefault(i => i.TemplateID.Equals(Templates.ProductListing));
                }

                return _productListing;
            }
        }
    }
}
