namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IReadConfectionService<in TDto> : IConfectionService<TDto>
    {
        void Read(TDto dto);
    }
}
