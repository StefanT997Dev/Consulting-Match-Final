using System;

namespace Application.DTOs
{
    public class ScheduleDto
    {
        public string TargetConsultantId { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}