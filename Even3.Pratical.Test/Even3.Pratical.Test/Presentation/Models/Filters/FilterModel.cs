using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;

namespace Even3.Pratical.Test.Presentation.Models.Filters
{
    public class FilterModel : IFilterDto
    {
        public int? Index { get; set; }
        public int? Count { get; set; }
    }
}