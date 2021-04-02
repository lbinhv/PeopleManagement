using PeopleManagement.Data.Configuration;
using PeopleManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Data
{
    public class PeopleManagementEntities : DbContext
    {
        public PeopleManagementEntities() : base("PeopleManagementEntities") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual void CommitAsync()
        {
            base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new SubjectEntityTypeConfiguration());
        }
    }
}
