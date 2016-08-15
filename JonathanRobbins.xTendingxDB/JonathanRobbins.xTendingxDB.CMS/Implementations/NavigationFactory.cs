using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.CMS.Models.Navigation;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig.FieldNames;
using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.CMS.Implementations
{
    public class NavigationFactory : INavigationFactory
    {
        private readonly INavigationBuilder _navigationBuilder;

        public NavigationFactory(INavigationBuilder navigationBuilder)
        {
            _navigationBuilder = navigationBuilder;
        }

        public IEnumerable<NavigationItem> GetFirstLevelChildren(Item rootItem, Item currentItem)
        {
            if (rootItem == null)
            {
                throw new ArgumentNullException("rootItem", "rootItem cannot be null");
            }
            if (currentItem == null)
            {
                throw new ArgumentNullException("currentItem", "currentItem cannot be null");
            }

            return _navigationBuilder.GetFirstLevelChildren(rootItem, currentItem).ToList();
        }

        public object GetThreeTierNavigation(Item rootItem, Item currentItem)
        {
            if (rootItem == null)
            {
                throw new ArgumentNullException("rootItem", "rootItem cannot be null");
            }
            if (currentItem == null)
            {
                throw new ArgumentNullException("currentItem", "currentItem cannot be null");
            }

            List<NavigationItem> navigationItems = new List<NavigationItem>();

            Item firstLevelItem = (from item in Nodes.SiteHome.GetChildren()
                             where (item.Axes.IsAncestorOf(currentItem) || item.ID.Equals(currentItem.ID))
                                   && item[Global.ShowInSubNavigation].Trim().Equals("1")
                             select item).SingleOrDefault();

            if (firstLevelItem == null)
            {
                return navigationItems;
            }


            throw new NotImplementedException();
        }
    }
}
