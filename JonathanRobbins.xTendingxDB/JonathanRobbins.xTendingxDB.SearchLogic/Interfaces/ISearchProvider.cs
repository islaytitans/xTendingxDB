using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.SearchLogic.Entities;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.SearchLogic.Interfaces
{
    public interface ISearchProvider<T> where T : SearchResultItem
    {
        Entities.SearchResults<T> Search(SearchArgs templateIds = null);
    }
}
