using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.CMS.Models.Navigation
{
    public class NavigationItem
    {
        public Item Item { get; set; }
        public bool Active { get; set; }

        public NavigationItem(Item item, bool active)
        {
            Item = item;
            Active = active;
        }
    }
}