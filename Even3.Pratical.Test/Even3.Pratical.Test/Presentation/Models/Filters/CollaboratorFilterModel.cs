using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;

namespace Even3.Pratical.Test.Presentation.Models.Filters
{
    public class CollaboratorFilterModel : FilterModel, ICollaboratorFilterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Registration { get; set; }
    }
}