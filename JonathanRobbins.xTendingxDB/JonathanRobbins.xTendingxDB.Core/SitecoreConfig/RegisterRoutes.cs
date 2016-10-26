using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace JonathanRobbins.xTendingxDB.Core.SitecoreConfig
{
    public class RegisterRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute(
                "xTendingxDBDefault",
                "tracking/{action}",
                new { controller = "Tracking" }
            );
        }
    }
}
