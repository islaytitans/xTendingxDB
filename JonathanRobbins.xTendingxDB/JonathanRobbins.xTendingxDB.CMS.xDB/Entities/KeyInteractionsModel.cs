using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Entities
{
    public class KeyInteractionsModel
    {
        public IEnumerable<BrochureDownload> BrochureDownload { get; set; }
        public IEnumerable<ImageGalleryViewed> ImageGalleryViewed { get; set; }
        public IEnumerable<SampleOrder> SampleOrders { get; set; }
    }
}
