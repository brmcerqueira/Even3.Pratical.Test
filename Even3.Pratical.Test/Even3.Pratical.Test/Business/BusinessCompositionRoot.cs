using Even3.Pratical.Test.Business.Confections;
using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using LightInject;

namespace Even3.Pratical.Test.Business
{
    public class BusinessCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IReadConfectionService<long, ICollaboratorSaveDto>, CollaboratorConfectionService>();
        }
    }
}