using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using JonathanRobbins.xTendingxDB.Models;
using JonathanRobbins.xTendingxDB.ViewModels;

namespace JonathanRobbins.xTendingxDB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureAutoMapper();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(config => 
            config.CreateMap<Comment, CommentVM>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Message, opts => opts.MapFrom(src => src.Message)));
        }
    }
}
