using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using System.Collections;

namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IQueryService<in TFilterDto>
        where TFilterDto : IFilterDto
    {
        IEnumerable Filter(TFilterDto dto);
    }
}
