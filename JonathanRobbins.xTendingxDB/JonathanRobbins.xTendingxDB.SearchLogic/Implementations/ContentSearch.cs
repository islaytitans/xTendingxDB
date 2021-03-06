﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.SearchLogic.Entities;
using JonathanRobbins.xTendingxDB.SearchLogic.Interfaces;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Pipelines;

namespace JonathanRobbins.xTendingxDB.SearchLogic.Implementations
{
    public class ContentSearch<T> : ISearchProvider<T> where T : SearchResultItem
    {
        private readonly ISearchIndex _searchIndex;
        private bool _trackSearch;

        public ContentSearch(string indexName, bool trackSearch = true)
        {
            _searchIndex = ContentSearchManager.GetIndex(indexName);
            _trackSearch = trackSearch;
        }

        public Entities.SearchResults<T> Search(SearchArgs searchArgs)
        {
            Entities.SearchResults<T> searchResults;

            var predicate = PredicateBuilder.True<T>();

            if (searchArgs.TemplateIds != null)
            {
                Expression<Func<T, bool>> templatePredicate = FilterTemplates(searchArgs.TemplateIds);
                predicate = predicate.And(templatePredicate);
            }

            if (!string.IsNullOrEmpty(searchArgs.Term))
            {
                Expression<Func<T, bool>> termPredicate = FilterTerms(searchArgs.Term);
                predicate = predicate.And(termPredicate);
            }

            predicate = predicate.And(s => s.Language == Sitecore.Context.Language.Name);

            using (var context = _searchIndex.CreateSearchContext())
            {
                Sitecore.ContentSearch.Linq.SearchResults<T> results = context.GetQueryable<T>().Where(predicate).Page(searchArgs.Page, searchArgs.PageSize).GetResults<T>();
                searchResults = new Entities.SearchResults<T>(results);
            }

            return searchResults;
        }

        public virtual Expression<Func<T, bool>> FilterTemplates(IEnumerable<ID> templateIds)
        {
            var predicate = PredicateBuilder.True<T>();

            foreach (ID templateId in templateIds)
            {
                Expression constant = Expression.Constant(templateId);
                ParameterExpression parameter = Expression.Parameter(typeof(T), "s");
                Expression property = Expression.Property(parameter, typeof(T).GetProperty("TemplateId"));
                Expression expression = Expression.Equal(property, constant);
                predicate = predicate.Or(Expression.Lambda<Func<T, bool>>(expression, parameter));
            }

            return predicate;
        }

        private Expression<Func<T, bool>> FilterTerms(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                throw new ArgumentNullException(nameof(term));
            }

            var predicate = PredicateBuilder.True<T>();

            predicate = predicate.Or(s => s.Name.Equals(term)).Boost(10);
            predicate = predicate.Or(s => s.Content.Equals(term));

            return predicate;
        }
    }
}
