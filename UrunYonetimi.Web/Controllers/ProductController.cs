using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var product = _productRepository.GetById(id.Value);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allCategory = _categoryRepository.GetAll().ToList();

            var pageModel = new ProductPageModel
            {
                CurrentProduct = product,
                CategoryList = allCategory
            };

            return View(pageModel);
        }
    }
}