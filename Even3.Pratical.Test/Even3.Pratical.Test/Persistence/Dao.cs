using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace Even3.Pratical.Test.Persistence
{
    public class Dao<T> : IQueryable<T>
        where T : class
    {
        private readonly ObjectSet<T> objectSet;
        private readonly Func<EntityKey, T> getObjectByKey;
        private readonly Func<IQueryable<T>> getQueryable;
        private readonly string qualifiedEntitySetName;

        public Dao(ObjectSet<T> objectSet, Func<EntityKey, T> getObjectByKey)
        {
            this.objectSet = objectSet;
            this.getObjectByKey = getObjectByKey;
            this.getQueryable = () => this.objectSet.AsQueryable();
            this.qualifiedEntitySetName = string.Format("{0}.{1}", objectSet.EntitySet.EntityContainer.Name, objectSet.EntitySet.Name);
        }

        private Dao(Func<IQueryable<T>> getQueryable)
        {
            this.getQueryable = getQueryable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return getQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.getQueryable().GetEnumerator();
        }

        public Type ElementType
        {
            get { return this.getQueryable().ElementType; }
        }

        public Expression Expression
        {
            get { return this.getQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.getQueryable().Provider; }
        }

        public Dao<T> Include<TProperty>(Expression<Func<T, TProperty>> path)
        {
            return new Dao<T>(() => getQueryable().Include(path));
        }

        public T GetReference(dynamic keys)
        {
            return getObjectByKey(new EntityKey(qualifiedEntitySetName, keys));
        }

        public T GetReference(Action<dynamic> action)
        {
            var expandoObject = new ExpandoObject();
            action(expandoObject);
            return GetReference(expandoObject);
        }

        public IEnumerable<T> GetReferences(params Action<dynamic>[] actions)
        {
            foreach (var item in actions)
            {
                var expandoObject = new ExpandoObject();
                item(expandoObject);
                yield return GetReference(expandoObject);
            }
        }

        public T Create()
        {
            return objectSet.CreateObject();
        }

        public void Add(T entity)
        {
            objectSet.AddObject(entity);
        }

        public void Delete(T entity)
        {
            objectSet.DeleteObject(entity);
        }
    }
}