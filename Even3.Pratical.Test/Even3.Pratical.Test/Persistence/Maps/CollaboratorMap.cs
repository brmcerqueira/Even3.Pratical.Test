using Even3.Pratical.Test.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Even3.Pratical.Test.Persistence.Maps
{
    public class CollaboratorMap : EntityTypeConfiguration<Collaborator>
    {
        public CollaboratorMap()
        {
            ToTable("collaborator");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            Property(e => e.Email).HasColumnName("email").IsRequired().HasMaxLength(50);
            Property(e => e.Registration).HasColumnName("registration").IsRequired().HasMaxLength(10);
        }
    }
}