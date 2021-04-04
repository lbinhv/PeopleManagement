using PeopleManagement.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace PeopleManagement.Data.Configuration
{
    public class SubjectEntityTypeConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectEntityTypeConfiguration()
        {
            ToTable("Subjects").HasKey(k => k.SubjectId);
            Property(g => g.SubjectName).IsRequired().HasMaxLength(50);
        }
    }
}
