using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Cintel.Reporting;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Pipelines.Contact
{
    public class Schema
    {
        public static ViewField<Guid> ContactId = new ViewField<Guid>("ContactId");
        public static ViewField<Guid> VisitId = new ViewField<Guid>("VisitId");
        public static ViewField<int> VisitIndex = new ViewField<int>("VisitIndex");
        public static ViewField<DateTime> VisitStartDateTime = new ViewField<DateTime>("VisitStartDateTime");
        public static ViewField<DateTime> VisitEndDateTime = new ViewField<DateTime>("VisitEndDateTime");
        public static ViewField<string> Title = new ViewField<string>("Title");
        public static ViewField<string> Sku = new ViewField<string>("Sku");
        public static ViewField<string> Type = new ViewField<string>("Type");
    }
}
