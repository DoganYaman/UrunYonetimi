using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetimi.Core.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); 
        T GetById(int id); 
        T Get(Expression<Func<T, bool>> expression); 
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression); 
        void Insert(T obj); // insert metodu..
        void Update(T obj); // Update metodu..
        void Delete(int id); // Delete metodu..
        int Count(); 
        void Save(); 


        /// IEnumerable<T> GetAll(); : 
        ///     Bununla bütün data yı çekebilelim diye..
        ///     
        /// T GetById(int id); :
        ///     Tek bir nesne dönen metod.. id alarak..
        ///     
        /// T Get(Expression<Func<T, bool>> expression); : 
        ///     Tek bir nesne dönecek olan ve bir expression sonucunda bu nesneyi dönecek olan metod..Expression un bir function u olacak.. Function ile T dönecek ve            boolean bir sonuca göre bu işlemi yapıcak..
        ///     
        /// IQueryable<T> GetMany(Expression<Func<T, bool>> expression); : 
        ///     Bir üstteki metod tek bir nesne dönmek için.. Bu ise aynısının, birden fazla nesnenin döneni için kullanacağımız bir metod olacak.. Aynı expression u aldım      ve sonuc olarak IQuerable<T> nesnesini geri döndürdü...
        /// int Count() : 
        ///     Tablonun sayısını dönen metod..
        /// 
        /// int Save() : 
        ///     Yapılan değişiklikleri kaydedicek, Context üzerindeki değişiklikleri kaydedicek metod..
    }
}
