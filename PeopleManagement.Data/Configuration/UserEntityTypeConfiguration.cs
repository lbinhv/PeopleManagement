using PeopleManagement.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace PeopleManagement.Data.Configuration
{
    public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityTypeConfiguration()
        {
            ToTable("Users").HasKey(k => k.UserId);
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.NRIC).IsRequired().HasMaxLength(10);
            Property(g => g.Gender).IsRequired().HasMaxLength(1);
            Property(g => g.Birthday).IsRequired();
            Property(g => g.AvaiableDate).IsOptional();
            Property(g => g.DateCreated).IsOptional();
            Property(g => g.AvaiableDate).IsOptional();
        }
    }
}
