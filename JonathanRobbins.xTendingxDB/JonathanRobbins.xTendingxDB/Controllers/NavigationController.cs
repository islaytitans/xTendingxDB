using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.CMS.Models.Navigation;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Exceptions;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationFactory _navigationFactory;

        public NavigationController(INavigationFactory navigationFactory)
        {
            _navigationFactory = navigationFactory;
        }

        [HttpGet]
        public ActionResult MainNavigation()
        {
            Item homeItem = null;

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