using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Factories;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using JonathanRobbins.xTendingxDB.Orders.Interfaces;
using JonathanRobbins.xTendingxDB.Products.Entities;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using JonathanRobbins.xTendingxDB.ViewModels;
using Sitecore.Analytics;
using Sitecore.Data.Items;
using Sitecore.Mvc.Configuration;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class ProductsController : GlassController
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IContactFactory _contactFactory;
        private readonly IKeyInteractionsRepository _keyInteractionsRepository;

        public ProductsController(IProductRepository productRepository, IProductLinkProvider productLinkProvider, IOrderRepository orderRepository, IContactFactory contactFactory, IKeyInteractionsRepository keyInteractionsRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _contactFactory = contactFactory;
            _keyInteractionsRepository = keyInteractionsRepository;
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
            var product = _productRepository.GetProductByUrl(HttpContext.Request.Url);

            if (product != null)
            {
                var productDetailsVM = new ProductDetailsVM(product);

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

            if (!Tracker.IsActive)
            {
                Tracker.StartTracking();
            }

            _orderRepository.Add();

            var contact = _contactFactory.GetOrCreateContact(sampleOrderVm.EmailAddress);

            var contactModel = Mapper.Map<ContactModel>(sampleOrderVm);

            _contactFactory.UpdateContact(contact, contactModel, "Sample Order");

            var product = _productRepository.GetProductByUrl(HttpContext.Request.Url);

            var sampleOrder = new SampleOrder(product.Item);

            _keyInteractionsRepository.Set(contact, sampleOrder);

            return PartialView("SampleOrderResults", true);
        }

        public ActionResult OrderSample()
        {
            return PartialView("SampleOrderForm");
        }
    }
}