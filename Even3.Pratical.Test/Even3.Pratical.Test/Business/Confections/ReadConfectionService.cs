using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Persistence.Interfaces;
using System;
using System.Linq;

namespace Even3.Pratical.Test.Business.Confections
{
    internal abstract class ReadConfectionService<T, TKey, TDto> : ConfectionService<T, TKey, TDto>, IReadConfectionService<TKey, TDto>
        where T : class
    {
        public ReadConfectionService(IDaoContext context) : base(context)
        {
        }

        public virtual void Read(TKey key, TDto dto)
        {
            EntityToDto(dto, LoadToRead(Dao).Single(FindOne(key)));
        }

        public virtual void Update(TKey key, TDto dto)
        {
            Validate(dto);

            var entity = LoadToUpdate(Dao).Single(FindOne(key));

            EntityFromDto(entity, dto, false);

            Context.SaveChanges();
        }

        protected virtual IDao<T> Load(IDao<T> dao)
        {
            return dao;
        }

        protected virtual IDao<T> LoadToRead(IDao<T> dao)
        {
            return Load(dao);
        }

        protected virtual IDao<T> LoadToUpdate(IDao<T> dao)
        {
            return Load(dao);
        }

        protected abstract Func<T, bool> FindOne(TKey key);

        protected abstract void EntityToDto(TDto dto, T entity);
    }
}