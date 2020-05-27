using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace dotnetfundaScaffolding.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private dotnetfundaDbContext db = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this.db = new dotnetfundaDbContext();
            table = db.Set<T>();
        }
        public Repository(dotnetfundaDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            try
            {
                return table.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T SelectByID(object id)
        {
            try
            {
                return table.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(T obj)
        {
            try
            {
                table.Add(obj);
                db.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}