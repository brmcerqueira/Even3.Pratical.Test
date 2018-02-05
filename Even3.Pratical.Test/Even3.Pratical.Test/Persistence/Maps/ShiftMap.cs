using Even3.Pratical.Test.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Even3.Pratical.Test.Persistence.Maps
{
    public class ShiftMap : EntityTypeConfiguration<Shift>
    {
        public ShiftMap()
        {
            ToTable("shift");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.DayOfWeek).HasColumnName("dayOfWeek").IsRequired();
            Property(e => e.Input).HasColumnName("input").IsRequired();
            Property(e => e.Output).HasColumnName("output").IsRequired();
            Property(e => e.Interval).HasColumnName("interval").IsRequired();
        }
    }
}