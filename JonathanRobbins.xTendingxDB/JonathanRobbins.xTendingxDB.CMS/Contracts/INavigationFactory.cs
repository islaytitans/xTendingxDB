using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.Models.Navigation;
using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.CMS.Contracts
{
    public interface INavigationFactory
    {
        IEnumerable<NavigationItem> GetFirstLevelChildren(Item rootItem, Item currentItem);
        object GetThreeTierNavigation(Item rootItem, Item currentItem);
    }
}
