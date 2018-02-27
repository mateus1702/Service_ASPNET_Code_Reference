using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DomainModel
{
    public class User: BaseModel
    {
        public string Name { get; set; }
        
        public IList<Task> Tasks { get; set; }
    }
}