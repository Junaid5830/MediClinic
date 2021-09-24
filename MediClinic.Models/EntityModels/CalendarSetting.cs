using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class CalendarSetting
    {
        public int CalendarSettingId { get; set; }
        public bool CalViewMonth { get; set; }
        public bool CalViewWeek { get; set; }
        public bool CalViewDay { get; set; }
    }
}
