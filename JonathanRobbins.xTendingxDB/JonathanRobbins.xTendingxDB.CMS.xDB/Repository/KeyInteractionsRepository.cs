using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using JonathanRobbins.xTendingxDB.CMS.xDB.Facets;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Facets;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using Sitecore.Analytics.Tracking;
using Sitecore.Diagnostics;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Repository
{
    public class KeyInteractionsRepository : IKeyInteractionsRepository
    {
        public KeyInteractionsModel Get(Contact contact)
        {
            contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            throw new NotImplementedException();
        }

        public IEnumerable<BrochureDownload> GetBrochureDownloads(Contact contact)
        {
            IKeyInteractionsFacet facet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            var brochuresDownloaded = new List<BrochureDownload>();

            foreach (IBrochureDownload brochureDownload in facet.BrochuresDownloaded)
            {
                brochuresDownloaded.Add(new BrochureDownload()
                {
                    Id = brochureDownload.Id,
                    Title = brochureDownload.Title,
                    ProductTitle = brochureDownload.ProductTitle,
                    ProductSku = brochureDownload.ProductSku
                });
            }

            return brochuresDownloaded;
        }

        public IEnumerable<SampleOrder> GetSampleOrders(Contact contact)
        {
            IKeyInteractionsFacet facet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            var sampleOrders = new List<SampleOrder>();

            foreach (ISampleOrder sampleOrder in facet.SamplesOrdered)
            {
                sampleOrders.Add(new SampleOrder()
                {
                    Title = sampleOrder.Title,
                    Sku = sampleOrder.Sku,
                    Type = sampleOrder.Type
                });
            }

            return sampleOrders;
        }

        public IEnumerable<ImageGalleryViewed> GetGalleriesViewed(Contact contact)
        {
            IKeyInteractionsFacet facet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            var imageGalleryViewed = new List<ImageGalleryViewed>();

            foreach (var galleryViewed in facet.GalleriesViewed)
            {
                imageGalleryViewed.Add(new ImageGalleryViewed()
                {
                    Id = galleryViewed.Id,
                    Factions = galleryViewed.Factions.Split(new []{","}, StringSplitOptions.RemoveEmptyEntries),
                    ProductTitle = galleryViewed.ProductTitle,
                    ProductSku = galleryViewed.ProductSku,
                    ProductType = galleryViewed.ProductType,
                });
            }

            return imageGalleryViewed;
        }

        public void Set(Contact contact, BrochureDownload brochureDownload)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            if (brochureDownload == null)
            {
                throw new ArgumentNullException(nameof(brochureDownload));
            }

            Log.Info("KeyInteractionsRepository Set " + "Contact - " + contact.ContactId, this);

            IKeyInteractionsFacet facet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            Log.Info("KeyInteractionsRepository Got Facet " + "Contact - " + contact.ContactId, this);

            var brochureDownloaded = facet.BrochuresDownloaded.Create();
            brochureDownloaded.Title = brochureDownload.Title;
            brochureDownloaded.Id = brochureDownload.Id;
            brochureDownloaded.ProductSku = brochureDownload.ProductSku;
            brochureDownloaded.ProductTitle = brochureDownload.ProductTitle;

            Log.Info("KeyInteractionsRepository Created entry in xDB " + "Contact - " + contact.ContactId, this);
        }

        public void Set(Contact contact, ImageGalleryViewed imageGalleryViewed)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            if (imageGalleryViewed == null)
            {
                throw new ArgumentNullException(nameof(imageGalleryViewed));
            }

            Log.Info("KeyInteractionsRepository Set " + "Contact - " + contact.ContactId, this);

            IKeyInteractionsFacet facet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            Log.Info("KeyInteractionsRepository Got Facet " + "Contact - " + contact.ContactId, this);

            var galleriesViewed = facet.GalleriesViewed.Create();
            galleriesViewed.Id = imageGalleryViewed.Id;
            galleriesViewed.ProductTitle = imageGalleryViewed.ProductTitle;
            galleriesViewed.ProductSku = imageGalleryViewed.ProductSku;
            galleriesViewed.Factions = string.Join(",", imageGalleryViewed.Factions);
            galleriesViewed.ProductType = imageGalleryViewed.ProductType;

            Log.Info("KeyInteractionsRepository Created entry in xDB " + "Contact - " + contact.ContactId, this);
        }

        public void Set(Contact contact, SampleOrder sampleOrder)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            if (sampleOrder == null)
            {
                throw new ArgumentNullException(nameof(sampleOrder));
            }

            Log.Info("KeyInteractionsRepository Set " + "Contact - " + contact.ContactId, this);

            IKeyInteractionsFacet facet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);

            Log.Info("KeyInteractionsRepository Got Facet " + "Contact - " + contact.ContactId, this);

            var sampleOrdered = facet.SamplesOrdered.Create();
            sampleOrdered.Title = sampleOrder.Title;
            sampleOrdered.Sku = sampleOrder.Sku;
            sampleOrdered.Type = sampleOrder.Type;

            Log.Info("KeyInteractionsRepository Created entry in xDB " + "Contact - " + contact.ContactId, this);
        }
    }
}
