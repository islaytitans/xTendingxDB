using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Syndication;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements
{
    public interface IBrochureDownload : IElement, IValidatable
    {
        string Id { get; set; }
        string Title { get; set; }
        string ProductTitle { get; set; }
        string ProductSku { get; set; }
    }
}
