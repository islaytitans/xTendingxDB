using Sitecore.Analytics.Rules.SegmentBuilder;
using Sitecore.ContentSearch.Analytics.Models;
using Sitecore.ContentSearch.Rules.Conditions;
using System;
using System.Linq.Expressions;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Rules.Conditions.Segmentation
{
    public class ProductsOrderedCondition<T> : TypedQueryableStringOperatorCondition<T, IndexedContact> where T : VisitorRuleContext<IndexedContact>
    {
        protected override Expression<Func<IndexedContact, bool>> GetResultPredicate(T ruleContext)
        {
            string fieldName = "contact.SampleOrder.Skus";

            return this.GetCompareExpression((Expression<Func<IndexedContact, string>>)(c => c[fieldName]), this.Value);
        }
    }
}