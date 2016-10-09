using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.SearchLogic.Interfaces
{
    public interface ISearchUtility<T> where T : SearchResultItem
    {
        Entities.SearchResults<T> SearchByTemplateId(IEnumerable<ID> templateId);
    }
}
