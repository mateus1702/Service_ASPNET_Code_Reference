using DomainModel;
using System;
using System.Collections.Generic;

namespace ServiceModel
{
    public class TaskService
    {
        public int CreateTask(Task model)
        {
            if (!model.Validate())
            {
                throw new Exception("Invalid Task");
            }

            var repository = RepositoryFactory.Create<Task>();
            repository.Create(model);
            repository.SaveChanges();
            return model.Id;
        }

        public IEnumerable<Task> ListTasks()
        {
            var repository = RepositoryFactory.Create<Task>();
            return repository.List();
        }

        public Task ReadTask(int Id)
        {
            var repository = RepositoryFactory.Create<Task>();
            return repository.Read(Id);
        }

        public void DeleteTask(int Id)
        {
            var repository = RepositoryFactory.Create<Task>();
            var model = new Task()
            {
                Id = Id
            };
            repository.Delete(model);
            repository.SaveChanges();
        }       

        public void UpdateTask(Task model)
        {
            var repository = RepositoryFactory.Create<Task>();
            repository.Update(model);
            repository.SaveChanges();
        }
    }
}
