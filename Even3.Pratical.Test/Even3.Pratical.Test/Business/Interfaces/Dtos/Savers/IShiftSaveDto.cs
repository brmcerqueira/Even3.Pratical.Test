using System;

namespace Even3.Pratical.Test.Business.Interfaces.Dtos.Savers
{
    public interface IShiftSaveDto
    {
        DayOfWeek DayOfWeek { get; set; }
        TimeSpan Input { get; set; }
        TimeSpan Output { get; set; }
        TimeSpan Interval { get; set; }
    }
}
