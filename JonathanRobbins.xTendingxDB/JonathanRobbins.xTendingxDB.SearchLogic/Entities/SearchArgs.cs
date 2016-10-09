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
    }
}
