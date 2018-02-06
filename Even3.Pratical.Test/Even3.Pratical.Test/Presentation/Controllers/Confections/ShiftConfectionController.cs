using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using Even3.Pratical.Test.Presentation.Models.Savers;

namespace Even3.Pratical.Test.Presentation.Controllers.Confections
{
    public class ShiftConfectionController : ReadConfectionController<ShiftSaveModel, int, IReadConfectionService<int, IShiftSaveDto>>
    {
        public ShiftConfectionController(IReadConfectionService<int, IShiftSaveDto> service) : base(service)
        {
        }
    }
}