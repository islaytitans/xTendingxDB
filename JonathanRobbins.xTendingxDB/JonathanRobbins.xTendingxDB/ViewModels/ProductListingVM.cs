using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig;
using JonathanRobbins.xTendingxDB.Products.Entities;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Publishing.Pipelines.Publish;
using Sitecore.Web.UI.WebControls;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class ProductListingVM
    {
        public ProductListingVM(Product product)
        {
            Title = product.Item["Title"];
            Summary = product.Item["Summary"];
            Image = new HtmlString(FieldRenderer.Render(product.Item, "Image"));
            Price = product.Price;
            Brochure = new HtmlString(FieldRenderer.Render(product.Item, "Brochure"));

            string url = LinkManager.GetItemUrl(Products.SitecoreConfig.Nodes.ProductDetails);

            if (url.EndsWith("/"))
            {
                url = url.Remove(url.LastIndexOf('/'));
            }

            int lastSlash = url.LastIndexOf('/');
            url = (lastSlash > -1) ? url.Substring(0, lastSlash + 1) : url;

            ProductDetailsUrl = $"{url}/{product.Title}";

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

        public string Title { get; set; }
        public string Summary { get; set; }
        public HtmlString Image { get; set; }
        public double Price { get; set; }
        public string PriceString => $"${Price:N2}";
        public string Type { get; set; }
        public List<Faction> Factions { get; set; }
        public string ProductDetailsUrl { get; set; }
        public HtmlString Brochure { get; set; }
    }
}