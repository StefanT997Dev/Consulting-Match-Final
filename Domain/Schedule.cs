using System;

namespace Domain
{
    public class Schedule
    {
        public string ClientId { get; set; }
        public virtual AppUser Client { get; set; }
        public string ConsultantId { get; set; }
        public virtual AppUser Consultant { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}