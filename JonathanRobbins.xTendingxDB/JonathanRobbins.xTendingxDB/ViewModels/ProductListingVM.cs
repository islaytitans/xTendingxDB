using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using JonathanRobbins.xTendingxDB.App_Start;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig;
using JonathanRobbins.xTendingxDB.Products.Entities;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using JonathanRobbins.xTendingxDB.Products.Providers;
using Microsoft.Practices.Unity;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Publishing.Pipelines.Publish;
using Sitecore.Web.UI.WebControls;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class ProductListingVM
    {
        private readonly IUnityContainer _container = UnityConfig.GetConfiguredContainer();

        public string Title { get; set; }
        public string Summary { get; set; }
        public HtmlString Image { get; set; }
        public double Price { get; set; }
        public string PriceString => $"${Price:N2}";
        public string Type { get; set; }
        public string Sku { get; set; }
        public List<Faction> Factions { get; set; }
        public string ProductDetailsUrl { get; set; }
        public BrochureVM Brochure { get; set; }

        public ProductListingVM(Product product)
        {
            Title = product.Item["Title"];
            Summary = product.Item["Summary"];
            Image = new HtmlString(FieldRenderer.Render(product.Item, "Image", "w=300&h300"));
            Price = product.Price;
            Brochure = new BrochureVM(product.Item);
            Sku = product.Sku;

            var productLinkProvider = _container.Resolve<IProductLinkProvider>();
            ProductDetailsUrl = productLinkProvider.GetProductUrl(product.Item.Name);

            if (!string.IsNullOrWhiteSpace(product.Item["Type"]))
            {
                Item typeItem = Sitecore.Context.Database.GetItem(product.Item["Type"]);
                if (typeItem != null)
                {
                    Type = typeItem["Title"];
                }
            }
            if (!string.IsNullOrWhiteSpace(product.Item["Factions"]))
            {
                MultilistField multilistField = product.Item.Fields["Factions"];
                if (multilistField?.TargetIDs != null)
                {
                    foreach (var item in multilistField.GetItems())
                    {
                        if (Factions == null)
                        {
                            Factions = new List<Faction>();
                        }
                        Factions.Add(new Faction(item));
                    }
                }
            }
        }
    }
}