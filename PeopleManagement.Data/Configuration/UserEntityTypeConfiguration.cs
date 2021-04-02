using PeopleManagement.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace PeopleManagement.Data.Configuration
{
    public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityTypeConfiguration()
        {
            ToTable("Users");
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.NRIC).IsRequired();
            Property(g => g.Gender).IsRequired();
        }
    }
}
