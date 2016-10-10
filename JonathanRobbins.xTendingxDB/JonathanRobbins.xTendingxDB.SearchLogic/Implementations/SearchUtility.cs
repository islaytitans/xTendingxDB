using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.SearchLogic.Entities;
using JonathanRobbins.xTendingxDB.SearchLogic.Interfaces;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.SearchLogic.Implementations
{
    public class SearchUtility<T> : ISearchUtility<T> where T : SearchResultItem
    {
        private readonly ISearchProvider<T> _searchProvider;

        public SearchUtility(ISearchProvider<T> searchProvider)
        {
            _searchProvider = searchProvider;
        }

        public Entities.SearchResults<T> SearchByTemplateId(IEnumerable<ID> templateIds)
        {
            Entities.SearchResults<T> results;

            var searchArgs = new SearchArgs()
            {
                TemplateIds = templateIds
            };

            results = _searchProvider.Search(searchArgs);

            return results;
        }
    }
}
