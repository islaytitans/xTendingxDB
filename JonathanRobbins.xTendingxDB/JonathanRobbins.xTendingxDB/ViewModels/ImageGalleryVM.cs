using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class ImageGalleryVM
    {
        public string Title { get; set; }
        public List<KeyValuePair<string, string>> Images { get; set; }
        public IEnumerable<string> ProductNames { get; set; }

        public ImageGalleryVM(string imageGalleryId)
        {
            if (string.IsNullOrEmpty(imageGalleryId))
            {
                return;
            }

            ID id;
            if (!ID.TryParse(imageGalleryId, out id))
            {
                return;
            }

            Item imageGallery = Sitecore.Context.Database.GetItem(id);

            Title = imageGallery?["Title"];
            var productItems = ((MultilistField)imageGallery?.Fields["Products"])?.GetItems();
            ProductNames = (from p in productItems
                            where p != null
                            select p["Title"]);

            MultilistField multilistField = imageGallery?.Fields["Slides"];
            if (multilistField?.TargetIDs != null)
            {
                foreach (MediaItem mediaItem in multilistField.GetItems())
                {
                    if (Images == null)
                    {
                        Images = new List<KeyValuePair<string, string>>();
                    }

                    Images.Add(new KeyValuePair<string, string>(MediaManager.GetMediaUrl(mediaItem), mediaItem.Alt));
                }
            }
        }
    }
}