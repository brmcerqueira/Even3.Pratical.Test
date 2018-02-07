using Even3.Pratical.Test.Business.Interfaces;
using System.Collections;
using System.Web.Http;

namespace Even3.Pratical.Test.Presentation.Controllers
{
    public class MarkingController : ApiController
    {
       private IMarkingService Service { get; }

        public MarkingController(IMarkingService service)
        {
            Service = service;
        }

        public IEnumerable Get(long key)
        {
            return Service.Show(key);
        }
    }
}