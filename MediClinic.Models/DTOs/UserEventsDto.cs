using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class UserEventsDto
    {
        public int EventId { get; set; }
        public long? UserId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Start time is required")]
        public TimeSpan? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string EventTitle { get; set; }
        
    }
}
