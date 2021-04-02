using PeopleManagement.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace PeopleManagement.Data.Configuration
{
    public class SubjectEntityTypeConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectEntityTypeConfiguration()
        {
            ToTable("Subjects");
            Property(g => g.SubjectName).IsRequired().HasMaxLength(10);
            Property(g => g.UserId).IsRequired();
        }
    }
}
