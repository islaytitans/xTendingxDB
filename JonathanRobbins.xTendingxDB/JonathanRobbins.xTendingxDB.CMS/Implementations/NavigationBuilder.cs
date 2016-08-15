using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.CMS.Models.Navigation;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig.FieldNames;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace JonathanRobbins.xTendingxDB.CMS.Implementations
{
    public class NavigationBuilder : INavigationBuilder
    {
        public IEnumerable<NavigationItem> GetFirstLevelChildren(Item rootItem, Item currentItem)
        {
            if (rootItem == null)
            {
                throw new ArgumentException("rootItem cannot be null", "rootItem");
            }

            var items = rootItem.Children.Where(i => i != null && i[Global.ShowInMainNavigation].Trim().Equals("1"));

            return items.Select(item =>
                new NavigationItem(item, item.ID.Equals(currentItem.ID) || item.Axes.IsAncestorOf(currentItem))).ToList();
        }

        public object GetThreeTierItems(Item rootItem)
        {
            if (rootItem == null)
            {
                throw new ArgumentException("rootItem cannot be null", "rootItem");
            }

            throw new NotImplementedException();
        }
    }
}
