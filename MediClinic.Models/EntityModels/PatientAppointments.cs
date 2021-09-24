using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientAppointments
    {
        public PatientAppointments()
        {
            Notifications = new HashSet<Notifications>();
            Visits = new HashSet<Visits>();
        }

        public int AppointmentId { get; set; }
        public long? PatientInfoId { get; set; }
        public string AppointmentType { get; set; }
        public DateTime? ExactTime { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public long? ProviderInfoId { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ModifyBy { get; set; }
        public long? RecursionNo { get; set; }
        public bool? IsCompleted { get; set; }
        public long? SlotId { get; set; }
        public int? StatusId { get; set; }
        public int? DepartmentType { get; set; }

        public virtual PatientInfo PatientInfo { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual ProviderSlots Slot { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Visits> Visits { get; set; }
    }
}
