using RepositoryModel;
using System;

namespace DomainModel
{
    public class Task : BaseModel
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Owner { get; set; }

        public bool Done { get; set; }

        public bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(Name.Trim()))
            {
                isValid = false;
            }            

            return isValid;
        }
    }
}
