using System;

namespace Even3.Pratical.Test.Domain
{
    public class Marking
    {
        public long Id { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public DateTime Date { get; set; }
    }
}