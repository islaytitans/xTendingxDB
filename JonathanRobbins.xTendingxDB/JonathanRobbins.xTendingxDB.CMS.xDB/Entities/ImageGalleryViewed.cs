using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Entities
{
    public class ImageGalleryViewed
    {
        public string Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductSku { get; set; }
        public IEnumerable<string> Factions { get; set; }
        public string ProductType { get; set; }
    }
}
