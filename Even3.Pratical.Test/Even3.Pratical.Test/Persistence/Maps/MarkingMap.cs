using Even3.Pratical.Test.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Even3.Pratical.Test.Persistence.Maps
{
    public class MarkingMap : EntityTypeConfiguration<Marking>
    {
        public MarkingMap()
        {
            ToTable("marking");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(e => e.Collaborator).WithMany().Map(e => e.MapKey("collaboratorId"));
            Property(e => e.Date).HasColumnName("date").IsRequired();
        }
    }
}