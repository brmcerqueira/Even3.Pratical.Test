using System.Data.Entity.Migrations;

namespace Even3.Pratical.Test.Persistence
{
    internal sealed class MigrationsConfiguration : DbMigrationsConfiguration<DaoContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}