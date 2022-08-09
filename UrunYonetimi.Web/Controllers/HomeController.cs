using UrunYonetimi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.Web.Controllers
{
    public class HomeController : Controller
    {
        ICategoryRepository _categoryRepository;
        public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            var categoryList = _categoryRepository.GetAll().ToList();
            return View(categoryList);
        }

    }
}