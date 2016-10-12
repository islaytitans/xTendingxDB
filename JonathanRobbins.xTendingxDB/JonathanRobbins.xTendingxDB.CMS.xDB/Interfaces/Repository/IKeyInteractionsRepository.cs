using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using Sitecore.Analytics.Tracking;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository
{
    public interface IKeyInteractionsRepository
    {
        KeyInteractionsModel Get(Contact contact);
        IEnumerable<BrochureDownload> GetBrochureDownloads(Contact contact);
        void Set(Contact contact, KeyInteractionsModel keyInteractionsModel);
        void Set(Contact contact, BrochureDownload brochureDownload);
    }
}
