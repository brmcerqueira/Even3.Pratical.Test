using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;

namespace Even3.Pratical.Test.Presentation.Models.Savers
{
    public class CollaboratorSaveModel : ICollaboratorSaveDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Registration { get; set; }
    }
}