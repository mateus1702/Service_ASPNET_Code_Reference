using System;
using System.Collections.Generic;

namespace RepositoryModel
{
    public interface IRepository<T> where T : BaseModel
    {
        void Create(T model);

        void Update(T model);

        void Delete(T model);

        T Read(int Id);

        IEnumerable<T> List();

        void SaveChanges();
    }
}
