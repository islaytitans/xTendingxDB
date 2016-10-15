using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Model.Framework;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements
{
    public interface ISampleOrder : IElement, IValidatable
    {
        string Title { get; set; }
        string Sku { get; set; }
        string Type { get; set; }
    }
}
