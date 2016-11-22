using Sitecore.Analytics.Rules.SegmentBuilder;
using Sitecore.ContentSearch.Analytics.Models;
using Sitecore.ContentSearch.Rules.Conditions;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq.Expressions;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Rules.Conditions.Segmentation
{
    public class ProductTypeCondition<T> : TypedQueryableStringOperatorCondition<T, IndexedContact> where T : VisitorRuleContext<IndexedContact>
    {
        protected override Expression<Func<IndexedContact, bool>> GetResultPredicate(T ruleContext)
        {
            string fieldName = "contact.SampleOrder.FavouriteType";

            return GetCompareExpression((Expression<Func<IndexedContact, string>>) (c => (string) c[(ObjectIndexerKey) fieldName]), Type);
        }

        public ProductTypeCondition()
        {
            Type = string.Empty;
            // Bug (Sitecore) - internal code requires an operator Id (not a string operator Id) for GetResultPredicate to be called
            //OperatorId = "{066602E2-ED1D-44C2-A698-7ED27FD3A2CC}";
        }

        public string Type { get; set; }
    }
}