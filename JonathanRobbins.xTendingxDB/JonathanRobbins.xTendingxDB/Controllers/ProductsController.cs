using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using JonathanRobbins.xTendingxDB.Orders.Interfaces;
using JonathanRobbins.xTendingxDB.Products;
using JonathanRobbins.xTendingxDB.Products.Entities;
using JonathanRobbins.xTendingxDB.Products.Implementations;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using JonathanRobbins.xTendingxDB.SearchLogic.Implementations;
using JonathanRobbins.xTendingxDB.ViewModels;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Links;
using Sitecore.Mvc.Configuration;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class ProductsController : GlassController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductLinkProvider _productLinkProvider;
        private readonly IOrderRepository _orderRepository;

        public ProductsController(IProductRepository productRepository, IProductLinkProvider productLinkProvider, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _productLinkProvider = productLinkProvider;
            _orderRepository = orderRepository;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            var args = new ProductSearchArgs(0, 12);

            var products = _productRepository.Search(args);

            throw new NotImplementedException();
        }

        public ActionResult ProductListing()
        {
            var args = new ProductSearchArgs(0, 12);

            var products = _productRepository.Search(args);

            var productListingViewModels = new List<ProductListingVM>();

            foreach (Product product in products)
            {
                productListingViewModels.Add(new ProductListingVM(product));
            }

            return View("ProductListing", productListingViewModels);
        }

        public ActionResult GetProductDetailsByUrl()
        {
            string term = HttpContext.Request.Url.AbsolutePath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Last();

            term = WebUtility.HtmlDecode(term).Replace("-", " ");

            if (string.IsNullOrEmpty(term))
            {
                return View("ProductDetails");
            }

            var args = new ProductSearchArgs(0, 1)
            {
                Term = term,
            };

            var products = _productRepository.Search(args).ToList();

            if (products.Any())
            {
                var productDetailsVM = new ProductDetailsVM(products.FirstOrDefault());

                return View("ProductDetails", productDetailsVM);
            }
            else
            {
                return View("ProductDetails");
            }
        }

        [HttpPost]
        public ActionResult OrderSample(SampleOrderVM sampleOrderVm)
        {
            if (!ModelState.IsValid)
            {
                string url = HttpContext.Request.Url.AbsolutePath;
                return RedirectToRoute(MvcSettings.SitecoreRouteName, new { pathInfo = url.TrimStart(new char[] { '/' }) });
            }
            
            _orderRepository.Add();

            return PartialView("SampleOrderResults", true);
        }

        public ActionResult OrderSample()
        {
            return PartialView("SampleOrderForm");
        }
    }
}