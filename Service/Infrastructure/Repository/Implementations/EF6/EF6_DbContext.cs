using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EF6
{
    public class EF6_DbContext : DbContext
    {
        public EF6_DbContext() : base("name=EntityFramework6")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
