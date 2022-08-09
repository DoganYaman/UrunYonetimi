﻿using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Data.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductImageRepository _productImageRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
        }
        
        public ActionResult Index()
        {
            var productList = _productRepository.GetAll().ToList();
            return View(productList);
        }

        public ActionResult Create()
        {
            SetCategoryList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase productImage)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (productImage != null && productImage.ContentLength > 0)
            {
                var img = new ProductImage();
                img.ImageName = Path.GetFileName(productImage.FileName);
                img.ContentType = productImage.ContentType;
                using (var reader = new BinaryReader(productImage.InputStream))
                {
                    img.Content = reader.ReadBytes(productImage.ContentLength);
                }

                product.ProductImages = new List<ProductImage> { img };
            }


            _productRepository.Insert(product);
            _productRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productRepository.GetById(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }

            SetCategoryList(product.CategoryId);


            return View(product);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase productImage)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _productRepository.Update(product);
            _productRepository.Save();

            if (productImage == null || productImage.ContentLength <= 0)
            {
                return RedirectToAction("Index");
            }

            var img = new ProductImage();

            img.ImageName = Path.GetFileName(productImage.FileName);
            img.ContentType = productImage.ContentType;

            using (var reader = new BinaryReader(productImage.InputStream))
            {
                img.Content = reader.ReadBytes(productImage.ContentLength);
                img.ProductId = product.ProductId;
            }

            var existingImage = _productRepository.GetById(product.ProductId).ProductImages;

            if (existingImage != null || existingImage.Count > 0)
            {
                //existingImage.ForEach(x => _productImageRepository.Delete(x.ProductImageId));

                foreach (var item in existingImage)
                {
                    _productImageRepository.Delete(item.ProductImageId);
                }
            }

            _productImageRepository.Insert(img);
            _productImageRepository.Save();


            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productRepository.GetById(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productRepository.GetById(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();

            return RedirectToAction("Index");
        }




        private void SetCategoryList(object category = null)
        {
            var categoryList = _categoryRepository.GetAll().ToList();
            var selectList = new SelectList(categoryList, "CategoryId", "CategoryName", category);
            ViewData.Add("CategoryId", selectList);
        }


    }
}