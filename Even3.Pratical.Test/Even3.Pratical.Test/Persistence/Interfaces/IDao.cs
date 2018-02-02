using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Even3.Pratical.Test.Persistence.Interfaces
{
    public interface IDao<T> : IQueryable<T>
        where T : class
    {
        IDao<T> Include<TProperty>(Expression<Func<T, TProperty>> path);
        T GetReference(dynamic keys);
        T GetReference(Action<dynamic> action);
        IEnumerable<T> GetReferences(params Action<dynamic>[] actions);
        T Create();
        void Add(T entity);
        void Delete(T entity);
    }
}
