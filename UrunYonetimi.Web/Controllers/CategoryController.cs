using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       
        
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allCategory = _categoryRepository.GetAll().ToList();
            var category = allCategory.FirstOrDefault(x => x.CategoryId == id.Value);

            if (category== null)
            {
                return RedirectToAction("Index", "Home");
            }

            var products = category.Products.ToList();

            var pageModel = new CategoryPageModel
            {
                CurrentCategory = category,
                CategoryList = allCategory,
                ProductList = products
            };

            return View(pageModel);
        }






    }
}