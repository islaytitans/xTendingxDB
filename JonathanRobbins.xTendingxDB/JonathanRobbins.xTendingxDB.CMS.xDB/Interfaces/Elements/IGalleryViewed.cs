using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Model.Framework;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements
{
    public interface IGalleryViewed : IElement, IValidatable
    {
        string Id { get; set; }
        string ProductTitle { get; set; }
        string ProductSku { get; set; }
        string Factions { get; set; }
        string ProductType { get; set; }
    }
}
