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
                var types = (from s in keyInteractionsFacet.SamplesOrdered
                    select s.Type).Distinct();


                fields.Add(new IndexableDataField<string>("contact.SampleOrder.Skus", string.Join(",", skus)));
                fields.Add(new IndexableDataField<string>("contact.SampleOrder.Types", string.Join(",", types)));
            }
            return fields;
        }
    }
}