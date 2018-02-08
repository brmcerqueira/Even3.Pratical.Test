using Even3.Pratical.Test.Persistence.Interfaces;
using Even3.Pratical.Test.Properties;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace Even3.Pratical.Test.Persistence
{
    public class DaoContext : DbContext, IDaoContext
    {
        private ObjectContext objectContext;

        static DaoContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DaoContext>());
        }

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
                Database.Log = data => Debug.WriteLine(string.Format("DaoContext: {0}", data));
            #endif
        }

        public IDao<T> CreateDao<T>() where T : class
        {
            return new Dao<T>(objectContext.CreateObjectSet<T>(), e => (T)objectContext.GetObjectByKey(e));
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is UpdateException)
                {
                    if (ex.InnerException.InnerException is SqlException)
                    {
                        var sqlException = ex.InnerException.InnerException as SqlException;
                        if (sqlException.Number == 2601)
                        {
                            throw new InvalidOperationException(Resource.DuplicateEntityException);
                        }
                        throw ex.InnerException.InnerException;
                    }
                    throw ex.InnerException;
                }
                throw ex;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}