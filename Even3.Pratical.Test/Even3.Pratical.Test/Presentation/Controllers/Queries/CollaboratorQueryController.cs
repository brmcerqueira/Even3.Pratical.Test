using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using Even3.Pratical.Test.Presentation.Models.Filters;

namespace Even3.Pratical.Test.Presentation.Controllers.Queries
{
    public class CollaboratorQueryController : QueryController<CollaboratorFilterModel, IQueryService<ICollaboratorFilterDto>>
    {
        public CollaboratorQueryController(IQueryService<ICollaboratorFilterDto> service) : base(service)
        {
        }
    }
}