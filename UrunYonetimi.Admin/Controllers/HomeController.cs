using UrunYonetimi.Admin.ViewModel;
using UrunYonetimi.Core.Infrastructure;
using System.Web.Mvc;

namespace UrunYonetimi.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductFeatureRepository _productFeatureRepository;

        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductImageRepository productImageRepository, IProductFeatureRepository productFeatureRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _productFeatureRepository = productFeatureRepository;
        }
        public ActionResult Index()
        {
            var pagemodel = new HomePageModel
            {
                CategoryCount = _categoryRepository.Count(),
                ProductCount = _productRepository.Count(),
                ProductImageCount = _productImageRepository.Count(),
                ProductFeatureCount = _productFeatureRepository.Count()
                
            };
            return View(pagemodel);
        }
    }
}