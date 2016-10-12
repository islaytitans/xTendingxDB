using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class BrochureVM
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }

        public BrochureVM(Item productItem)
        {
            if (string.IsNullOrEmpty(productItem?["Brochure"]))
            {
                return;
            }

            LinkField linkField = productItem.Fields["Brochure"];

            MediaItem mediaItem = linkField.TargetItem;

            Url = MediaManager.GetMediaUrl(mediaItem);
            Title = mediaItem.Title;
            Id = mediaItem.ID.ToString();
        }
    }
}