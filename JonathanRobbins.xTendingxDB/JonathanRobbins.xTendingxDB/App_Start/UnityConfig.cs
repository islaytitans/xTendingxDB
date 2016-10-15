using System;
using JonathanRobbins.xTendingxDB.CMS.Contracts;
using JonathanRobbins.xTendingxDB.CMS.Implementations;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using JonathanRobbins.xTendingxDB.CMS.xDB.Repository;
using JonathanRobbins.xTendingxDB.Orders.Interfaces;
using JonathanRobbins.xTendingxDB.Orders.Repositories;
using JonathanRobbins.xTendingxDB.Products;
using JonathanRobbins.xTendingxDB.Products.Implementations;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using JonathanRobbins.xTendingxDB.Products.Providers;
using JonathanRobbins.xTendingxDB.SearchLogic.Implementations;
using JonathanRobbins.xTendingxDB.SearchLogic.Interfaces;
using Microsoft.Practices.Unity;
using Sitecore.ContentSearch.SearchTypes;

namespace JonathanRobbins.xTendingxDB.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.RegisterType<INavigationBuilder, NavigationBuilder>();
            container.RegisterType<INavigationFactory, NavigationFactory>();
            container.RegisterType<ISearchProvider<SearchResultItem>, ContentSearch<SearchResultItem>>(
                new InjectionConstructor(ProductConstants.ProductIndex, true));
            container.RegisterType<ISearchUtility<SearchResultItem>, SearchUtility<SearchResultItem>>(
                new InjectionConstructor(container.Resolve<ISearchProvider<SearchResultItem>>()));
            container.RegisterType<IProductRepository, ProductRepository>(
                new InjectionConstructor(container.Resolve<ISearchUtility<SearchResultItem>>()));
            container.RegisterType<IGoalRepository, GoalRepository>();
            container.RegisterType<IKeyInteractionsRepository, KeyInteractionsRepository>();
            container.RegisterType<IProductLinkProvider, ProductLinkProvider>();
            container.RegisterType<IOrderRepository, OrderRepository>();
        }
    }
}
