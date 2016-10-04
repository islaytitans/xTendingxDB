using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.Core.SitecoreConfig.ItemIds;
using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.Core.SitecoreConfig
{
    public class Nodes
    {
        private static Item _siteRoot;
        public static Item SiteRoot
        {
            get
            {
                if (_siteRoot == null)
                {
                    _siteRoot = Sitecore.Context.Item.Axes.GetAncestors().FirstOrDefault(i => i.TemplateID.Equals(Templates.SiteRoot));
                }

                return _siteRoot;
            }
        }

        private static Item _siteHome;
        public static Item SiteHome
        {
            get
            {
                if (_siteHome == null)
                {
                    if (Sitecore.Context.Item.TemplateID.Equals(Templates.Home))
                    {
                        _siteHome = Sitecore.Context.Item;
                    }
                    else
                    {
                        _siteHome = Sitecore.Context.Item.Axes.GetAncestors().FirstOrDefault(i => i.TemplateID.Equals(Templates.Home));
                    }
                }

                return _siteHome;
            }
        }
    }
}
