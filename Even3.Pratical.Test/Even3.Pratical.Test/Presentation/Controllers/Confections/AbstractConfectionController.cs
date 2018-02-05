using Even3.Pratical.Test.Business.Interfaces;
using System.Web.Http;

namespace Even3.Pratical.Test.Presentation.Controllers.Confections
{
    public abstract class AbstractConfectionController<T, TService> : ApiController
        where TService : IConfectionService<T>
    {
        protected TService Service { get; private set; }

        public AbstractConfectionController(TService service)
        {
            Service = service;
        }

        public virtual void Put(T model)
        {
            Service.Create(model);
        }
    }
}