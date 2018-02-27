using System;

namespace DomainModel
{
    public class Task : BaseModel
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Done { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
