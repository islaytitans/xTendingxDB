using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonathanRobbins.xTendingxDB.Models.Generic;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace JonathanRobbins.xTendingxDB.Models.ContentShowcase
{
    public class Banner : DataBase
    { 
        public virtual string Title { get; set; }
        public virtual string Strapline { get; set; }
        public virtual Glass.Mapper.Sc.Fields.Link Link { get; set; }
        public virtual Glass.Mapper.Sc.Fields.Image Image { get; set; }
    }
}