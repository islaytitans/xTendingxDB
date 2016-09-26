using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements;
using Sitecore.Analytics.Model.Framework;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Facets
{
    public interface IKeyInteractionsFacet : IFacet
    {
        IElementCollection<IBrochureDownload> BrochuresDownloaded { get; }
        IElementCollection<IGalleryViewed> GalleriesViewed { get; }
        IElementCollection<ISampleOrder> SamplesOrdered { get; }
    }
}
