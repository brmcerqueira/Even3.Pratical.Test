namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IConfectionService<in TDto>
    {
        void Create(TDto dto);
    }
}
