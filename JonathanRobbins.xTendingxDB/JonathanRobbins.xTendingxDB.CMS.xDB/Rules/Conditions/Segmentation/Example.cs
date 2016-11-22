using Sitecore.Analytics.Rules.SegmentBuilder;
using Sitecore.ContentSearch.Analytics.Models;
using Sitecore.ContentSearch.Rules.Conditions;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq.Expressions;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Rules.Conditions.Segmentation
{
    public class ExampleSystem<T> : TypedQueryableOperatorCondition<T, IndexedContact> where T : VisitorRuleContext<IndexedContact>
    {
        protected override Expression<Func<IndexedContact, bool>> GetResultPredicate(T ruleContext)
        {
            return GetCompareExpression<bool>(c => (bool)c[(ObjectIndexerKey)"contact.SampleOrder.Example"], true);
        }

        public ExampleSystem()
        {
            // Bug (Sitecore) - internal code requires an operator Id (not a string operator Id) for GetResultPredicate to be called
            OperatorId = "{066602E2-ED1D-44C2-A698-7ED27FD3A2CC}";
        }
    }
}