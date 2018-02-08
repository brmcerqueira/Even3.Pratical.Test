using System.Collections;

namespace Even3.Pratical.Test.Business.Interfaces
{
    public interface IMarkingService
    {
        IEnumerable Show(string registration);
        void Register(string registration);
        long StartTime();
    }
}
