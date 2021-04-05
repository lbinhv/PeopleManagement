using PeopleManagement.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace PeopleManagement.Data.Configuration
{
    public class SerilogEntityTypeConfiguration : EntityTypeConfiguration<Serilog>
    {
        public SerilogEntityTypeConfiguration()
        {
            ToTable("Serilogs").HasKey(k => k.Id);
            Property(g => g.Message).IsOptional();
            Property(g => g.MessageTemplate).IsOptional();
            Property(g => g.Level).HasMaxLength(128).IsOptional();
            Property(g => g.TimeStamp).IsOptional();
            Property(g => g.Exception).IsOptional();
            Property(g => g.Properties).IsOptional();
        }
    }
}
