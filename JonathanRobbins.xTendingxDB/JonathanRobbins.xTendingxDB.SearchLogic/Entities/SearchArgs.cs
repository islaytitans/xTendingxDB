using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.SearchLogic.Entities
{
    public class SearchArgs
    {
        public IEnumerable<ID> TemplateIds { get; set; }
        public string Term { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public SearchArgs(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
