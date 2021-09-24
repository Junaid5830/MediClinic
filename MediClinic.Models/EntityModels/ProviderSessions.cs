using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderSessions
    {
        public ProviderSessions()
        {
            ProviderSlots = new HashSet<ProviderSlots>();
        }

        public long ProviderSessionId { get; set; }
        public int WeekDayId { get; set; }
        public long ProviderInfoId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? DateOfWeek { get; set; }
        public bool? IsActive { get; set; }

        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual WeekDays WeekDay { get; set; }
        public virtual ICollection<ProviderSlots> ProviderSlots { get; set; }
    }
}
