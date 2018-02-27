using DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServiceModel.DTO
{
    public class UserDTO
    {
        public UserDTO() { }

        public UserDTO(User model)
        {
            Id = model.Id;
            Name = model.Name;
            Tasks = model.Tasks != null ?
                model.Tasks.Select(x => new TaskDTO(x)).ToList() :
                new List<TaskDTO>();
        }

        public User ToModel()
        {
            return new User()
            {
                Id = Id,
                Name = Name,
                Tasks = Tasks != null ?
                    Tasks.Select(x => x.ToModel()).ToList() :
                    new List<Task>()
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<TaskDTO> Tasks { get; set; }
    }
}