using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using System;

namespace Even3.Pratical.Test.Presentation.Models.Savers
{
    public class ShiftSaveModel : IShiftSaveDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Input { get; set; }
        public TimeSpan Output { get; set; }
        public TimeSpan Interval { get; set; }
    }
}