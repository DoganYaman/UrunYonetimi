using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace UrunYonetimi.Core.Repository
{
    public class ProductFeatureRepository : IProductFeatureRepository
    {
        private readonly UrunYonetimiContext _context = new UrunYonetimiContext();

        public IEnumerable<Data.Model.ProductFeature> GetAll()
        {
            return _context.ProductFeature.Select(x => x);
        }

        public Data.Model.ProductFeature GetById(int id)
        {
            return _context.ProductFeature.FirstOrDefault(x => x.ProductFeatureId == id);
        }

        public Data.Model.ProductFeature Get(System.Linq.Expressions.Expression<Func<Data.Model.ProductFeature, bool>> expression)
        {
            return _context.ProductFeature.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.ProductFeature> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.ProductFeature, bool>> expression)
        {
            return _context.ProductFeature.Where(expression);
        }

        public void Insert(Data.Model.ProductFeature obj)
        {
            _context.ProductFeature.Add(obj);
        }

        public void Update(Data.Model.ProductFeature obj)
        {
            _context.ProductFeature.AddOrUpdate(obj);
        }

        public void Delete(int id)
        {
            var productFeature = GetById(id);
            if (productFeature != null)
            {
                _context.ProductFeature.Remove(productFeature);
            }
        }

        public int Count()
        {
            return _context.ProductFeature.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
