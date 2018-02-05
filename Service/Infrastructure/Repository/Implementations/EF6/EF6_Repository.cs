using RepositoryModel;
using System;
using System.Collections.Generic;

namespace EF6
{
    public class NSEF6_Repository<T> : IRepository<T> where T : BaseModel
    {
        public NSEF6_Repository()
        {
            _context = new EF6_DbContext();
        }

        private EF6_DbContext _context;

        public void Create(T model)
        {
            _context.Set<T>().Add(model);            
        }

        public void Delete(T model)
        {
            _context.Set<T>().Attach(model);
            _context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
        }

        public T Read(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>();
        }

        public void Update(T model)
        {
            _context.Set<T>().Attach(model);
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

       
    }
}
