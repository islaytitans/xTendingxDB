using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Entities
{
    public class SampleOrder
    {
        public SampleOrder(Item productItem)
        {
            if (productItem == null)
            {
                return;
            }

            var typeName = Sitecore.Context.Database.GetItem(productItem["Type"])?["Title"];

            Title = productItem["Title"];
            Sku = productItem["Sku"];
            Type = typeName;
        }

        public SampleOrder()
        {
        }

        public string Title { get; set; }
        public string Sku { get; set; }
        public string Type { get; set; }
    }
}
