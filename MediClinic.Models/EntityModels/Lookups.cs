using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Lookups
    {
        public Lookups()
        {
            DriverAttendance = new HashSet<DriverAttendance>();
            DriverJobRequestStatus = new HashSet<DriverJobRequestStatus>();
            JobNotificationThread = new HashSet<JobNotificationThread>();
            PatientInfo = new HashSet<PatientInfo>();
            ProviderInfoRentTypeNavigation = new HashSet<ProviderInfo>();
            ProviderInfoStatusNavigation = new HashSet<ProviderInfo>();
            ProviderInfoSuffixNavigation = new HashSet<ProviderInfo>();
            ProviderInfoTitleNavigation = new HashSet<ProviderInfo>();
            UserDevices = new HashSet<UserDevices>();
        }

        public int LookupId { get; set; }
        public string LookupValue { get; set; }
        public string LookupType { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<DriverAttendance> DriverAttendance { get; set; }
        public virtual ICollection<DriverJobRequestStatus> DriverJobRequestStatus { get; set; }
        public virtual ICollection<JobNotificationThread> JobNotificationThread { get; set; }
        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
        public virtual ICollection<ProviderInfo> ProviderInfoRentTypeNavigation { get; set; }
        public virtual ICollection<ProviderInfo> ProviderInfoStatusNavigation { get; set; }
        public virtual ICollection<ProviderInfo> ProviderInfoSuffixNavigation { get; set; }
        public virtual ICollection<ProviderInfo> ProviderInfoTitleNavigation { get; set; }
        public virtual ICollection<UserDevices> UserDevices { get; set; }
    }
}
