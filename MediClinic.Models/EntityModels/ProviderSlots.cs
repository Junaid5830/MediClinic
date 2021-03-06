using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderSlots
    {
        public ProviderSlots()
        {
            PatientAppointments = new HashSet<PatientAppointments>();
        }

        public long SlotId { get; set; }
        public string Duration { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? DayOfWeek { get; set; }
        public long? ProviderInfoId { get; set; }
        public long? ProviderSessionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedId { get; set; }
        public long? PatientInfoId { get; set; }
        public bool IsBook { get; set; }

        public virtual PatientInfo PatientInfo { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual ProviderSessions ProviderSession { get; set; }
        public virtual ICollection<PatientAppointments> PatientAppointments { get; set; }
    }
}
