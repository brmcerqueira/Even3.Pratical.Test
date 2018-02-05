using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using Even3.Pratical.Test.Presentation.Models.Savers;

namespace Even3.Pratical.Test.Presentation.Controllers.Confections
{
    public class CollaboratorConfectionController : ReadConfectionController<CollaboratorSaveModel, long, IReadConfectionService<long, ICollaboratorSaveDto>>
    {
        public CollaboratorConfectionController(IReadConfectionService<long, ICollaboratorSaveDto> service) : base(service)
        {
        }
    }
}