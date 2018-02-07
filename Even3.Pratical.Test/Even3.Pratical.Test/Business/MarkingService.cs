using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;
using System;
using System.Collections;
using System.Linq;

namespace Even3.Pratical.Test.Business
{
    internal class MarkingService : IMarkingService
    {
        private IDaoContext Context { get; }

        public MarkingService(IDaoContext context)
        {
            Context = context;
        }
      
        public IEnumerable Show(long collaboratorId)
        {
            IQueryable<Marking> queryMarking = Context.CreateDao<Marking>();
            IQueryable<Shift> queryShift = Context.CreateDao<Shift>();

            var dictionary = (from mar in queryMarking
                    where mar.Collaborator.Id == collaboratorId
                    group mar by new { mar.Date.Year, mar.Date.Month, mar.Date.Day } into g
                    select g).ToDictionary(
                e => new DateTime( e.Key.Year, e.Key.Month, e.Key.Day), 
                e => e.Select(d => d.Date.TimeOfDay).OrderBy(d => d).ToArray());

            return dictionary.Select(e =>
            {
                var missingMarkingInfraction = false;
                var minimumIntervalInfraction = false;
                var minimumHoursInfraction = false;
                var maximumHoursInfraction = false;
                var earlyInfraction = false;
                var leaveInfraction = false;

                var shift = queryShift.SingleOrDefault(s => s.DayOfWeek == e.Key.DayOfWeek);

                if (shift != null)
                {
                    missingMarkingInfraction = e.Value.Length < 2 || (e.Value.Length % 2 != 0);

                    if (!missingMarkingInfraction)
                    {
                        var interval = TimeSpan.Zero;

                        if (e.Value.Length > 2)
                        {
                            var intoMarking = e.Value.Skip(1).Take(e.Value.Length - 2).ToArray();

                            for (int i = 0; i < intoMarking.Length; i += 2)
                            {
                                interval += intoMarking[i + 1] - intoMarking[i];
                            }

                            minimumIntervalInfraction = interval < shift.Interval;
                        }

                        var first = e.Value.First();
                        var last = e.Value.Last();

                        earlyInfraction = first < (shift.Input - TimeSpan.FromHours(1));
                        leaveInfraction = last > (shift.Output + TimeSpan.FromHours(1));

                        var total = last - first - interval;
                        minimumHoursInfraction = total < TimeSpan.FromHours(4);
                        maximumHoursInfraction = total > TimeSpan.FromHours(8);
                    }
                }

                return new
                {
                   Date = e.Key,
                   e.Key.DayOfWeek,
                   Markings = e.Value,
                   MissingMarkingInfraction = missingMarkingInfraction,
                   MinimumIntervalInfraction = minimumIntervalInfraction,
                   MinimumHoursInfraction = minimumHoursInfraction,
                   MaximumHoursInfraction = maximumHoursInfraction,
                   EarlyInfraction = earlyInfraction,
                   LeaveInfraction = leaveInfraction,
                };
            });
        }

        public void Register(long collaboratorId)
        {
            var daoMarking = Context.CreateDao<Marking>();
            var daoCollaborator = Context.CreateDao<Collaborator>();

            var entity = daoMarking.Create();

            entity.Date = DateTime.Now;
            entity.Collaborator = daoCollaborator.GetReference(e => e.Id = collaboratorId);

            daoMarking.Add(entity);

            Context.SaveChanges();
        }
    }
}