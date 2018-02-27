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
            modelBuilder.Entity<User>()
                .HasMany(x => x.Tasks)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Task>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true); ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
