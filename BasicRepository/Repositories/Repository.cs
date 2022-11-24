using BasicRepository.Context;
using BasicRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicRepository.Repositories
{
    public class Repository<T> where T : class
    {

        MyContext _db;
        public Repository(MyContext db)
        {
            _db = db;
        }
        public List<T> Liste()
        {
            return Set().ToList();
        }
        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Find(string Id)
        {
            return Set().Find(Id);
        }
        public string Update(T entity)
        {
            try
            {
                Set().Update(entity);
                // _db.Entry(entity).State = EntityState.Modified; Bu da update yapmanın 2. yolu
                //return _model.ErrorMsg = "Hata Yok";
                return "OK"; 
            }
            catch (Exception ex)
            {
                //return _model.ErrorMsg = "Hata Var";
                return ex.Message;
            }
            
        }
        public bool Create(T entity)
        {
            try
            {
                //_db.Set<T>().Add(entity);
                Set().Add(entity);
                // _db.Entry(entity).State = EntityState.Added;
                return true;
            }
            catch (Exception)
            {

                return false;
            }   
        }
        public bool Delete(T entity)
        {
            try
            {
                //_db.Set<T>().Remove(entity);
                Set().Remove(entity);
                // _db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }
    }
}
