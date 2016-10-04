using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using JonathanRobbins.xTendingxDB.App_Start;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.CMS.Implementations;
using JonathanRobbins.xTendingxDB.CMS.Models.Navigation;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig;
using Microsoft.Practices.Unity;

namespace JonathanRobbins.xTendingxDB.Models.Navigation
{
    public class MainNavigation
    {
        private readonly IUnityContainer _container = UnityConfig.GetConfiguredContainer();

        private IEnumerable<NavigationItem> _menuItems;
        public IEnumerable<NavigationItem> MenuItems
        {
            get
            {
                if (_menuItems == null)
                {
                    var navigationFactory = _container.Resolve<INavigationFactory>();

                    _menuItems = navigationFactory.GetFirstLevelChildren(Nodes.SiteHome, Sitecore.Context.Item);
                }

                return _menuItems;
            }
        }
    }
}