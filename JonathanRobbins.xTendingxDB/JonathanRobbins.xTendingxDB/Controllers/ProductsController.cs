using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonathanRobbins.xTendingxDB.Products;
using JonathanRobbins.xTendingxDB.Products.Entities;
using JonathanRobbins.xTendingxDB.Products.Implementations;
using JonathanRobbins.xTendingxDB.Products.Interfaces;
using JonathanRobbins.xTendingxDB.SearchLogic.Implementations;
using Sitecore.ContentSearch.SearchTypes;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            var args = new ProductSearchArgs(ProductConstants.ProductIndex);

            var products = _productRepository.Search(args);

            return View("ProductListing", products);
        }  
    }
}