using DomainModel;
using RepositoryModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModel
{
    public abstract class Repository<T> : IUserRepository, ITaskRepository where T : BaseModel
    {
        public abstract void Create(T model);

        public abstract void Update(T model);

        public abstract void Delete(T model);

        public abstract T Read(int Id);

        public abstract IEnumerable<T> List();

        public abstract void SaveChanges();

        public abstract IEnumerable<Task> ListTasksFromUser(int userId);

        public abstract User ReadUser(int userId);
    }
}
