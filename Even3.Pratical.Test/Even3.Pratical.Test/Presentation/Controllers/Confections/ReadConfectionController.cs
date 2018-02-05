using Even3.Pratical.Test.Business.Interfaces;
using System.Web.Http;

namespace Even3.Pratical.Test.Presentation.Controllers.Confections
{
    public abstract class ReadConfectionController<T, TKey, TService> : ConfectionController<T, TKey, TService>
        where T : new()
        where TService : IReadConfectionService<TKey, T>
    {
        public ReadConfectionController(TService service) : base(service)
        {
        }

        public virtual T Get(TKey key)
        {
            var model = new T();
            Service.Read(key, model);
            return model;
        }

        public virtual void Post(TKey key, [FromBody] T model)
        {
            Service.Update(key, model);
        }
    }
}