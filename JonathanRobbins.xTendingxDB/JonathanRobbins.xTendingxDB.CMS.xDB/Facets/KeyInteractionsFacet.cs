using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Facets;
using Sitecore.Analytics.Model.Framework;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Facets
{
    public class KeyInteractionsFacet : Facet, IKeyInteractionsFacet
    {
        public static readonly string FacetName = "KeyInteractions";

        public const string BrochuresDownloadName = "BrochuresDownload";
        public const string GalleriesViewedName = "GalleriesViewed";
        public const string SamplesOrderedName = "SamplesOrdered";

        public KeyInteractionsFacet()
        {
            EnsureCollection<IBrochureDownload>(BrochuresDownloadName);
            EnsureCollection<IGalleryViewed>(GalleriesViewedName);
            EnsureCollection<ISampleOrder>(SamplesOrderedName);
        }

        public IElementCollection<IBrochureDownload> BrochuresDownloaded => GetCollection<IBrochureDownload>(BrochuresDownloadName);

        public IElementCollection<IGalleryViewed> GalleriesViewed => GetCollection<IGalleryViewed>(GalleriesViewedName);

        public IElementCollection<ISampleOrder> SamplesOrdered => GetCollection<ISampleOrder>(SamplesOrderedName);
    }
}
