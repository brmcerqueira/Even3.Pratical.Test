using System.Linq;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;

namespace Even3.Pratical.Test.Business.Queries
{
    internal class CollaboratorQueryService : QueryService<Collaborator, ICollaboratorFilterDto>
    {
        public CollaboratorQueryService(IDaoContext context) : base(context)
        {
        }

        protected override IQueryable<Collaborator> Setup(ICollaboratorFilterDto dto, IQueryable<Collaborator> query)
        {
            if (!string.IsNullOrEmpty(dto.Name))
            {
                query = from ent in query
                        where ent.Name.Contains(dto.Name)
                        select ent;
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                query = from ent in query
                        where ent.Email.Contains(dto.Email)
                        select ent;
            }

            if (!string.IsNullOrEmpty(dto.Registration))
            {
                query = from ent in query
                        where ent.Registration.Contains(dto.Registration)
                        select ent;
            }

            return query.OrderBy(e => e.Name);
        }
    }
}