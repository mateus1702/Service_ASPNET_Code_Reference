using DomainModel;
using ServiceModel.DTO;
using ServiceModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceModel.Services
{
    public class UserService
    {
        public int CreateUser(UserDTO dto)
        {
            var model = dto.ToModel();
            var repository = RepositoryFactory.Create<User>();
            repository.Create(model);
            repository.SaveChanges();
            return model.Id;
        }

        public IEnumerable<UserDTO> ListUsers()
        {
            var repository = RepositoryFactory.Create<User>();
            return repository.List()
                .ToList()
                .Select(x => new UserDTO(x));
        }

        public UserDTO ReadUser(int Id)
        {
            var repository = RepositoryFactory.Create<User>();
            var model = repository.ReadUser(Id);

            if (model != null)
                return new UserDTO(model);
            else
                return null;
        }

        public void DeleteUser(int Id)
        {
            var repository = RepositoryFactory.Create<User>();
            var model = new User()
            {
                Id = Id
            };
            repository.Delete(model);
            repository.SaveChanges();
        }

        public void UpdateUser(UserDTO model)
        {
            var repository = RepositoryFactory.Create<User>();
            repository.Update(model.ToModel());
            repository.SaveChanges();
        }
    }
}
