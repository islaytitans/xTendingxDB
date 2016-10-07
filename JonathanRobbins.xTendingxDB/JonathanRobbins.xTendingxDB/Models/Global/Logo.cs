using JonathanRobbins.xTendingxDB.Models.Generic;
using Rendering = Sitecore.Mvc.Presentation.Rendering;

namespace JonathanRobbins.xTendingxDB.Models.Global
{
    public class Logo : DataBase
    {
        public virtual Glass.Mapper.Sc.Fields.Link Link { get; set; }
        public virtual Glass.Mapper.Sc.Fields.Image Image { get; set; }
    }
}