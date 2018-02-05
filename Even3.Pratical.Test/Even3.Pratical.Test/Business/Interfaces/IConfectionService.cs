namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IConfectionService<TKey, in TDto>
    {
        void Create(TDto dto);
        void Delete(TKey key);
    }
}
