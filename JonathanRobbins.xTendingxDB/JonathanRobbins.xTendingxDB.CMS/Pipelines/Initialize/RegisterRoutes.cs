using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace JonathanRobbins.xTendingxDB.CMS.Pipelines.Initialize
{
    public class RegisterRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute(
                "xTendingxDBTracking",
                "Tracking/{action}/{id}",
                new { controller = "Tracking", action = "Test", id = UrlParameter.Optional }
            );
        }
    }
}
