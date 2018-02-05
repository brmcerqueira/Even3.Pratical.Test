namespace Even3.Pratical.Test.Business.Interfaces.Dtos.Filters
{
    public interface ICollaboratorFilterDto : IFilterDto
    {
        string Name { get; set; }
        string Email { get; set; }
        string Registration { get; set; }
    }
}
