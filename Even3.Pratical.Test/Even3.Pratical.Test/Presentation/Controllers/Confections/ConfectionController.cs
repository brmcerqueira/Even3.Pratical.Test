using Even3.Pratical.Test.Business.Interfaces;
using System.Web.Http;

namespace Even3.Pratical.Test.Presentation.Controllers.Confections
{
    public abstract class ConfectionController<T, TKey, TService> : ApiController
        where TService : IConfectionService<TKey, T>
    {
        protected TService Service { get; private set; }

        public ConfectionController(TService service)
        {
            Service = service;
        }

        public virtual void Put(T model)
        {
            Service.Create(model);
        }

        public virtual void Delete(TKey key)
        {
            Service.Delete(key);
        }
    }
}