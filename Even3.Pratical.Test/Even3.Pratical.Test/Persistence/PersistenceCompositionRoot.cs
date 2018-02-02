using Even3.Pratical.Test.Persistence.Interfaces;
using LightInject;

namespace Even3.Pratical.Test.Persistence
{
    public sealed class PersistenceCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDaoContext>(f => new DaoContext("DefaultConnection"), new LogicalCallContextLifetime("DaoContext"));
        }
    }
}