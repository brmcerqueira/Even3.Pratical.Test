using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;
using System.Linq;

namespace Even3.Pratical.Test.Business
{
    internal class CollaboratorService : ICollaboratorService
    {
        private IDaoContext Context { get; }

        public CollaboratorService(IDaoContext context)
        {
            Context = context;
        }

        public string GetCollaboratorName(string registration)
        {
            IQueryable<Collaborator> query = Context.CreateDao<Collaborator>();
            return (from col in query
                    where col.Registration == registration
                    select col.Name).SingleOrDefault();
        }
    }
}