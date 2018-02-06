using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using Even3.Pratical.Test.Presentation.Models.Filters;

namespace Even3.Pratical.Test.Presentation.Controllers.Queries
{
    public class ShiftQueryController : QueryController<ShiftFilterModel, IQueryService<IShiftFilterDto>>
    {
        public ShiftQueryController(IQueryService<IShiftFilterDto> service) : base(service)
        {
        }
    }
}