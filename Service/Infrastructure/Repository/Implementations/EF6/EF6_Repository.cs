using DomainModel;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF6
{
    public class NSEF6_Repository<T> : Repository<T> where T : BaseModel
    {
        public NSEF6_Repository()
        {
            _context = new EF6_DbContext();
        }

        private EF6_DbContext _context;

        public override void Create(T model)
        {
            _context.Set<T>().Add(model);
        }

        public override void Delete(T model)
        {
            _context.Set<T>().Attach(model);
            _context.Entry(model).State = EntityState.Deleted;
        }

        public override T Read(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public override IEnumerable<T> List()
        {
            return _context.Set<T>();
        }

        public override void Update(T model)
        {
            _context.Set<T>().Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public override void SaveChanges()
        {
            _context.SaveChanges();
        }

        public override IEnumerable<Task> ListTasksFromUser(int userId)
        {
            return _context.Set<Task>()
               .Where(x => x.UserId == userId);
        }

        public override User ReadUser(int userId)
        {
            return _context.Set<User>()
                .Include(x => x.Tasks)
                .FirstOrDefault(x => x.Id == userId);
        }
    }
}
