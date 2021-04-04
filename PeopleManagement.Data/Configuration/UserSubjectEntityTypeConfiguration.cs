using PeopleManagement.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace PeopleManagement.Data.Configuration
{
    public class UserSubjectEntityTypeConfiguration : EntityTypeConfiguration<UserSubject>
    {
        public UserSubjectEntityTypeConfiguration()
        {
            ToTable("UsersSubjects").HasKey(k => k.Id);
            Property(g => g.SubjectId).IsRequired();
            Property(g => g.UserId).IsRequired();
        }
    }
}
