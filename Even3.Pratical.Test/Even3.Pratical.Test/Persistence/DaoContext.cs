using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Reflection;

namespace Even3.Pratical.Test.Persistence
{
    public class DaoContext : DbContext
    {
        private ObjectContext objectContext;

        public DaoContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Setup();
        }

        public DaoContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {
            Setup();
        }

        private void Setup()
        {
            Configuration.LazyLoadingEnabled = false;
            objectContext = ((IObjectContextAdapter)this).ObjectContext;
            #if DEBUG
                Debug.WriteLine(string.Format("Script: {0}", objectContext.CreateDatabaseScript()));
                Database.Log = data => Debug.WriteLine(string.Format("DaoContext: {0}", data));
            #endif
        }

        public Dao<T> CreateDao<T>() where T : class
        {
            return new Dao<T>(objectContext.CreateObjectSet<T>(), e => (T)objectContext.GetObjectByKey(e));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}