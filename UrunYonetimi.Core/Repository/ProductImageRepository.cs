using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace UrunYonetimi.Core.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly UrunYonetimiContext _context = new UrunYonetimiContext();

        public IEnumerable<Data.Model.ProductImage> GetAll()
        {
            return _context.ProductImage.Select(x => x);
        }

        public Data.Model.ProductImage GetById(int id)
        {
            return _context.ProductImage.FirstOrDefault(x => x.ProductImageId == id);
        }

        public Data.Model.ProductImage Get(System.Linq.Expressions.Expression<Func<Data.Model.ProductImage, bool>> expression)
        {
            return _context.ProductImage.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.ProductImage> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.ProductImage, bool>> expression)
        {
            return _context.ProductImage.Where(expression);
        }

        public void Insert(Data.Model.ProductImage obj)
        {
            _context.ProductImage.Add(obj);
        }

        public void Update(Data.Model.ProductImage obj)
        {
            _context.ProductImage.AddOrUpdate(obj);
        }

        public void Delete(int id)
        {
            var productImage = GetById(id);
            if (productImage != null)
            {
                _context.ProductImage.Remove(productImage);
            }
        }

        public int Count()
        {
            return _context.ProductImage.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
