using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace UrunYonetimi.Core.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly UrunYonetimiContext _context = new UrunYonetimiContext();

        public IEnumerable<Data.Model.Product> GetAll()
        {
            return _context.Product.Select(x => x);
        }

        public Data.Model.Product GetById(int id)
        {
            return _context.Product.FirstOrDefault(x => x.ProductId == id);
        }

        public Data.Model.Product Get(System.Linq.Expressions.Expression<Func<Data.Model.Product, bool>> expression)
        {
            return _context.Product.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.Product> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.Product, bool>> expression)
        {
            return _context.Product.Where(expression);
        }

        public void Insert(Data.Model.Product obj)
        {
            _context.Product.Add(obj);
        }

        public void Update(Data.Model.Product obj)
        {
            _context.Product.AddOrUpdate(obj);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
        }

        public int Count()
        {
            return _context.Product.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
