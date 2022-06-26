using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.Admin.Controllers
{
    public class ProductFeatureController : Controller
    {
        IProductRepository _productRepository;
        IProductFeatureRepository _productFeatureRepository;
        public ProductFeatureController(IProductRepository productRepository, IProductFeatureRepository productFeatureRepository)
        {
            _productRepository = productRepository;
            _productFeatureRepository = productFeatureRepository;
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = GetCurrentProduct(id.Value);
            var productFeatures = product.ProductFeatures;

            ViewBag.SelectedProduct = product;

            return View(productFeatures);
        }

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = GetCurrentProduct(id.Value);
            var productFeature = product.ProductFeatures;

            ViewBag.SelectedProduct = product;


            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(int? id, ProductFeature productfeature)
        {

            productfeature.ProductId = id.Value;

            _productFeatureRepository.Insert(productfeature);
            _productFeatureRepository.Save();

            return RedirectToAction("Index", new { id = id.Value });
        }
       
        public ActionResult Edit(int? id, int? productId)
        {
            if (id == null || productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var product = GetCurrentProduct(productId.Value);
            var product = _productRepository.GetById(productId.Value);
            ViewBag.SelectedProduct = product;
            var productFeature = _productFeatureRepository.GetById(id.Value);

            if (productFeature == null)
            {
                return HttpNotFound();
            }

            return View(productFeature);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(ProductFeature productFeature)
        {
            if (!ModelState.IsValid)
            {
                return View(productFeature);
            }

            _productFeatureRepository.Update(productFeature);
            _productFeatureRepository.Save();

            return RedirectToAction("Index", new {id = productFeature.ProductId });
        }

        public ActionResult Details(int? id, int? productId)
        {
            if (id == null || productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = GetCurrentProduct(productId.Value);
            ViewBag.SelectedProduct = product;
            var productFeature = _productFeatureRepository.GetById(id.Value);

            if (productFeature == null)
            {
                return HttpNotFound();
            }

            return View(productFeature);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productFeature = _productFeatureRepository.GetById(id.Value);

            if (productFeature == null)
            {
                return HttpNotFound();
            }

            return View(productFeature);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            _productFeatureRepository.Delete(id);
            _productFeatureRepository.Save();

            return RedirectToAction("Index", new { id = collection["productId"] });
        }




        private Product GetCurrentProduct(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }
    }
}