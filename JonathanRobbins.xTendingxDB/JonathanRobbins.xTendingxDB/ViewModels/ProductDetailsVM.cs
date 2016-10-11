using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonathanRobbins.xTendingxDB.Products.Entities;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class ProductDetailsVM
    {
        public ProductDetailsVM(Product product)
        {
            Title = product.Item["Title"];
            Summary = product.Item["Summary"];
            Price = product.Price;

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
            if (!string.IsNullOrWhiteSpace(product.Item["Image gallery"]))
            {
                MultilistField multilistField = product.Item.Fields["Image gallery"];
                if (multilistField?.TargetIDs != null)
                {
                    foreach (var item in multilistField.GetItems())
                    { 
                        if (ImageUrls == null)
                        {
                            ImageUrls = new List<string>();
                        }

                        ImageUrls.Add(MediaManager.GetMediaUrl(item));
                    }
                }
            }
        }

        public string Title { get; set; }
        public string Summary { get; set; }
        public List<string> ImageUrls { get; set; }
        public double Price { get; set; }
        public string PriceString => $"${Price:N2}";
        public string Type { get; set; }
        public List<Faction> Factions { get; set; }
    }
}