using JonathanRobbins.xTendingxDB.CMS.xDB.Facets;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Facets;
using Sitecore.Analytics.Model.Entities;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Analytics.Pipelines.ContactIndexableLoadFields;
using Sitecore.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace JonathanRobbins.xTendingxDB.Index.Facets.Contacts
{
    public class IndexSampleOrders : ContactIndexableLoadFieldsProcessor
    {
        protected override IEnumerable<IIndexableDataField> GetFields(ContactIndexableLoadFieldsPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            IContact contact = args.Contact;
            Assert.IsNotNull(contact, "contact");
            var fields = new List<IIndexableDataField>();
            var keyInteractionsFacet = contact.GetFacet<IKeyInteractionsFacet>(KeyInteractionsFacet.FacetName);
            if (keyInteractionsFacet != null)
            {
                var skus = (from s in keyInteractionsFacet.SamplesOrdered
                    select s.Sku).Distinct();

                var favouriteType = keyInteractionsFacet.SamplesOrdered.GroupBy(s => s.Type)
                    .OrderByDescending(gp => gp.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();

                // DEBUG
                fields.Add(new IndexableDataField<bool>("contact.SampleOrder.Example", skus.Any()));
                fields.Add(new IndexableDataField<string[]>("contact.SampleOrder.Skus", skus.ToArray()));
                fields.Add(new IndexableDataField<string>("contact.SampleOrder.FavouriteType", favouriteType));
            }
            return fields;
        }
    }
}