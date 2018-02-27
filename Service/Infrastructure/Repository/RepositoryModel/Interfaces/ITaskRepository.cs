using DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepositoryModel.Interfaces
{
    public interface ITaskRepository 
    {
        IEnumerable<Task> ListTasksFromUser(int userId);
    }
}