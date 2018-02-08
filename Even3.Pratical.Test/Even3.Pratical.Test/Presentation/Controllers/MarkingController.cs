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

        public IEnumerable Get(string key)
        {
            return Service.Show(key);
        }

        public void Put(string key)
        {
            Service.Register(key);
        }
        
        [HttpGet]
        public long StartTime()
        {
            return Service.StartTime();
        }
    }
}