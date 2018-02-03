using System;

namespace Even3.Pratical.Test.Domain
{
    public class Shift
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Input { get; set; }
        public TimeSpan Output { get; set; }
        public TimeSpan Interval { get; set; }     
    }
}