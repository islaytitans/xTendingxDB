using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace JonathanRobbins.xTendingxDB.Products.Entities
{
    public class Faction
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public Faction(Item item)
        {
            if (item == null)
            {
                return;
            }

            Title = item["Title"];

            ImageField imageField = item.Fields["Image"];
            if (imageField?.MediaItem != null)
            {
                ImageUrl = MediaManager.GetMediaUrl(imageField.MediaItem);
            }
        }
    }
}
