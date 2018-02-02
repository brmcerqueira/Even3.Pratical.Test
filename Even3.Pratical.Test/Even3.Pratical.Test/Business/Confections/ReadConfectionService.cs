using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Persistence.Interfaces;
using FluentValidation;
using System.Linq;

namespace Even3.Pratical.Test.Business.Confections
{
    internal abstract class ReadConfectionService<T, TDto> : AbstractConfectionService<T, TDto>, IReadConfectionService<TDto>
        where T : class
    {
        public ReadConfectionService(IDaoContext context, IValidator<TDto> validator = null) : base(context, validator)
        {
        }

        public virtual void Read(TDto dto)
        {
            EntityToDto(dto, LoadToRead(Dao).Single(FindOne(dto)));
        }

        protected virtual IDao<T> LoadToRead(IDao<T> dao)
        {
            return Load(dao);
        }

        protected abstract void EntityToDto(TDto dto, T entity);
    }
}