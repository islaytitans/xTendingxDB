using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using Glass.Mapper.Sc.Web.Mvc;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.CMS.Implementations;
using JonathanRobbins.xTendingxDB.CMS.Models.Navigation;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Exceptions;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class NavigationController : GlassController
    {
        private readonly INavigationFactory _navigationFactory;

        public NavigationController(INavigationFactory navigationFactory)
        {
            _navigationFactory = navigationFactory;
        }

        public NavigationController()
        {
            _navigationFactory = new NavigationFactory(new NavigationBuilder()); ;
        }

        [HttpGet]
        public ActionResult MainNavigation()
        {
            Item homeItem = Nodes.SiteHome;

            IEnumerable<NavigationItem> navigationItems = _navigationFactory.GetFirstLevelChildren(homeItem, Sitecore.Context.Item).ToList();

            return View(navigationItems);
        }

        [HttpPost]
        public ActionResult SubNavigation(string rootItemId)
        {
            if (string.IsNullOrWhiteSpace(rootItemId))
            {
                throw new ArgumentException("rootItemId cannot be null", "rootItemId");
            }

            Item rootItem = Sitecore.Context.Database.GetItem(rootItemId);

            if (rootItem == null)
            {
                throw new ItemNullException(rootItemId);
            }

            var navItems = _navigationFactory.GetThreeTierNavigation(rootItem, Sitecore.Context.Item);

            return View(navItems);
        }
    }
}