using Even3.Pratical.Test.Business.Interfaces;
using System.Web.Http;

namespace Even3.Pratical.Test.Presentation.Controllers
{
    public class CollaboratorController : ApiController
    {
        private ICollaboratorService Service { get; }

        public CollaboratorController(ICollaboratorService service)
        {
            Service = service;
        }

        public string Get(string key)
        {
            return Service.GetCollaboratorName(key);
        }
    }
}