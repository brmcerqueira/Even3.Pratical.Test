using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
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
      
        public IEnumerable Show(string registration)
        {
            IQueryable<Marking> queryMarking = Context.CreateDao<Marking>();
            IQueryable<Shift> queryShift = Context.CreateDao<Shift>();

            var dictionary = (from mar in queryMarking
                    where mar.Collaborator.Registration == registration
                    group mar by new { mar.Date.Year, mar.Date.Month, mar.Date.Day } into g
                    select g).ToDictionary(
                e => new DateTime( e.Key.Year, e.Key.Month, e.Key.Day), 
                e => e.Select(d => d.Date.TimeOfDay).OrderBy(d => d).ToArray());

            return dictionary.GroupBy(m => new DateTime(m.Key.Year, m.Key.Month, 1)).Select(g =>
            new KeyValuePair<DateTime, IEnumerable>(g.Key,
                g.Select(e =>
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
                        Markings = e.Value.Select(t => string.Format("{0:hh\\:mm}", t)),
                        MissingMarkingInfraction = missingMarkingInfraction,
                        MinimumIntervalInfraction = minimumIntervalInfraction,
                        MinimumHoursInfraction = minimumHoursInfraction,
                        MaximumHoursInfraction = maximumHoursInfraction,
                        EarlyInfraction = earlyInfraction,
                        LeaveInfraction = leaveInfraction,
                    };
                })));
        }

        public void Register(string registration)
        {
            var daoMarking = Context.CreateDao<Marking>();
            var daoCollaborator = Context.CreateDao<Collaborator>();

            var entity = daoMarking.Create();

            entity.Date = DateTime.Now;
            entity.Collaborator = daoCollaborator.Single(e => e.Registration == registration);

            daoMarking.Add(entity);

            Context.SaveChanges();
        }
    }
}