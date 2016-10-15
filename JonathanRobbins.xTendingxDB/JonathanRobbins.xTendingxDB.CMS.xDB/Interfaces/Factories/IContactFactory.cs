using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Tracking;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Factories
{
    public interface IContactFactory
    {
        void UpdateContact(Contact contact, ContactModel contactModel, string entryName);
        Contact GetOrCreateContact(string emailAddress);

    }
}
