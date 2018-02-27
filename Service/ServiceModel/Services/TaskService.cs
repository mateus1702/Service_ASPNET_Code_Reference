using DomainModel;
using ServiceModel.DTO;
using ServiceModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceModel.Services
{
    public class TaskService
    {
        public int CreateTask(TaskDTO dto)
        {
            var model = dto.ToModel();
            var repository = RepositoryFactory.Create<Task>();
            repository.Create(model);
            repository.SaveChanges();
            return model.Id;
        }

        public IEnumerable<TaskDTO> ListTasks(int userId)
        {
            var repository = RepositoryFactory.Create<Task>();
            return repository
                .ListTasksFromUser(userId)
                .Select(x=> new TaskDTO(x));
        }

        public TaskDTO ReadTask(int Id)
        {
            var repository = RepositoryFactory.Create<Task>();
            var model = repository.Read(Id);

            if (model != null)
                return new TaskDTO(model);
            else
                return null;
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

        public void UpdateTask(TaskDTO dto)
        {
            var repository = RepositoryFactory.Create<Task>();
            repository.Update(dto.ToModel());
            repository.SaveChanges();
        }
    }
}
