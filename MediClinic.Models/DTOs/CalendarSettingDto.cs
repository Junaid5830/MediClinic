using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class CalendarSettingDto
    {
        public int CalendarSettingId { get; set; }
        public bool CalViewMonth { get; set; }
        public bool CalViewWeek { get; set; }
        public bool CalViewDay { get; set; }
    }
}
