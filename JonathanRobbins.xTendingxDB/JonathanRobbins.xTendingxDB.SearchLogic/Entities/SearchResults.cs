using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch.Linq;

namespace JonathanRobbins.xTendingxDB.SearchLogic.Entities
{
    public class SearchResults<T>
    {
        public int TotalSearchResults { get; set; }
        public IEnumerable<SearchHit<T>> Hits { get; set; }
        public FacetResults Facets { get; set; }

        public SearchResults()
        {

        }

        public SearchResults(Sitecore.ContentSearch.Linq.SearchResults<T> searchResults)
        {
            TotalSearchResults = searchResults.TotalSearchResults;
            Hits = searchResults.Hits.ToList();
            Facets = searchResults.Facets;
        }
    }
}
