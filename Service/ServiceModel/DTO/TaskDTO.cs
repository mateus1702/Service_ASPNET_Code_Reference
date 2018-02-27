using DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServiceModel.DTO
{
    public class TaskDTO
    {
        public TaskDTO() { }

        public TaskDTO(Task model)
        {
            Id = model.Id;
            Name = model.Name;
            Date = model.Date;
            Done = model.Done;
            UserId = model.UserId;
        }

        public Task ToModel()
        {
            return new Task()
            {
                Date = Date,
                Id = Id,
                Name = Name,
                Done = Done,
                UserId = UserId
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Done { get; set; }

        public int UserId { get; set; }
    }
}