using System.Collections;

namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IMarkingService
    {
        IEnumerable Show(long collaboratorId);
        void Register(long collaboratorId);
    }
}
