using System.Linq;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;

namespace Even3.Pratical.Test.Business.Queries
{
    internal class ShiftQueryService : QueryService<Shift, IShiftFilterDto>
    {
        public ShiftQueryService(IDaoContext context) : base(context)
        {
        }

        protected override IQueryable<Shift> Setup(IShiftFilterDto dto, IQueryable<Shift> query)
        {
            return query.OrderBy(e => e.DayOfWeek);
        }
    }
}