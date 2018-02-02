using System;

namespace Even3.Pratical.Test.Persistence.Interfaces
{
    public interface IDaoContext : IDisposable
    {
        IDao<T> CreateDao<T>() where T : class;
        int SaveChanges();
    }
}
