using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using Even3.Pratical.Test.Persistence.Interfaces;
using System.Collections;
using System.Linq;

namespace Even3.Pratical.Test.Business.Queries
{
    internal abstract class QueryService<T, TFilterDto> : IQueryService<TFilterDto>
        where T : class
        where TFilterDto : IFilterDto
    {
        private IDao<T> dao;

        public QueryService(IDaoContext context)
        {
            dao = context.CreateDao<T>();
        }

        public IEnumerable Filter(TFilterDto dto)
        {
            var queryable = Setup(dto, Load(dao));

            if (dto.Index.HasValue)
            {
                queryable = queryable.Skip(dto.Index.Value);
            }

            if (dto.Count.HasValue)
            {
                queryable = queryable.Take(dto.Count.Value);
            }

            return queryable.ToList().Select(Transform);
        }

        protected virtual object Transform(T entity)
        {
            return entity;
        }

        protected virtual IQueryable<T> Setup(TFilterDto dto, IQueryable<T> query)
        {
            return query;
        }

        protected virtual IDao<T> Load(IDao<T> dao)
        {
            return dao;
        }
    }
}