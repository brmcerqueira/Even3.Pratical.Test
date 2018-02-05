using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Presentation.Models.Filters;
using System.Web.Http;

namespace Even3.Pratical.Test.Presentation.Controllers.Queries
{
    public class QueryController<TFilterModel, TService> : ApiController
        where TFilterModel : FilterModel
        where TService : IQueryService<TFilterModel>
    {
        protected TService Service { get; private set; }

        public QueryController(TService service)
        {
            Service = service;
        }

        public virtual object Put(TFilterModel model)
        {
            return Service.Filter(model);
        }
    }
}