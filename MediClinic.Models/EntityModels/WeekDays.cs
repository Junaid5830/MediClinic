using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class WeekDays
    {
        public WeekDays()
        {
            ProviderSessions = new HashSet<ProviderSessions>();
        }

        public int WeekDayId { get; set; }
        public string WeekDayName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProviderSessions> ProviderSessions { get; set; }
    }
}
