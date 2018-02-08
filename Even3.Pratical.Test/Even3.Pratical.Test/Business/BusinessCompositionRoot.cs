using Even3.Pratical.Test.Business.Confections;
using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Filters;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using Even3.Pratical.Test.Business.Queries;
using LightInject;

namespace Even3.Pratical.Test.Business
{
    public class BusinessCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IQueryService<ICollaboratorFilterDto>, CollaboratorQueryService>();
            serviceRegistry.Register<IReadConfectionService<long, ICollaboratorSaveDto>, CollaboratorConfectionService>();
            serviceRegistry.Register<IQueryService<IShiftFilterDto>, ShiftQueryService>();
            serviceRegistry.Register<IReadConfectionService<int, IShiftSaveDto>, ShiftConfectionService>();
            serviceRegistry.Register<IMarkingService, MarkingService>();
            serviceRegistry.Register<ICollaboratorService, CollaboratorService>();      
        }
    }
}