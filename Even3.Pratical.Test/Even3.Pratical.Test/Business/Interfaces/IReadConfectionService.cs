namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IReadConfectionService<TKey, in TDto> : IConfectionService<TDto>
    {
        void Read(TKey key, TDto dto);
        void Update(TKey key, TDto dto);
    }
}
