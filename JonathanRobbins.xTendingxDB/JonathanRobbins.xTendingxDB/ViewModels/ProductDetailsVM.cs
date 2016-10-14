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
using Image = Glass.Mapper.Sc.Fields.Image;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class ProductDetailsVM
    {
        public ProductDetailsVM(Product product)
        {
            if (product == null)
            {
                return;
            }
            if (product.Item == null)
            {
                
            }

            Title = product.Title;
            Description = product.Description;
            Sku = product.Sku;
            Price = product.Price;
            Quote = product.Quote;

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
            ImageGallery = new ImageGalleryVM(product.Item["Image gallery"]);
        }

        public string Quote { get; set; }

        public string Sku { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public ImageGalleryVM ImageGallery { get; set; }
        public double Price { get; set; }
        public string PriceString => $"${Price:N2}";
        public string Type { get; set; }
        public List<Faction> Factions { get; set; }
    }
}