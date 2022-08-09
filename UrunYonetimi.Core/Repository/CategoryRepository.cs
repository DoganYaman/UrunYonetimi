using UrunYonetimi.Core.Infrastructure;
using UrunYonetimi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace UrunYonetimi.Core.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly UrunYonetimiContext _context = new UrunYonetimiContext();
        public IEnumerable<Data.Model.Category> GetAll()
        {
            return _context.Category.Select(x => x);
        }

        public Data.Model.Category GetById(int id)
        {
            return _context.Category.FirstOrDefault(x => x.CategoryId == id);
        }

        public Data.Model.Category Get(System.Linq.Expressions.Expression<Func<Data.Model.Category, bool>> expression)
        {
            return _context.Category.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.Category> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.Category, bool>> expression)
        {
            return _context.Category.Where(expression);
        }

        public void Insert(Data.Model.Category obj)
        {
            _context.Category.Add(obj);
        }

        public void Update(Data.Model.Category obj)
        {
             _context.Category.AddOrUpdate(obj);
    
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Category.Remove(category);
            }
            
        }

        public int Count()
        {
            return _context.Category.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
