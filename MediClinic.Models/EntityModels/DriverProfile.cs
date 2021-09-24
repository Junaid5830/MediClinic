using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverProfile
    {
        public DriverProfile()
        {
            DriverAttendance = new HashSet<DriverAttendance>();
            DriverAttendanceAlert = new HashSet<DriverAttendanceAlert>();
            DriverAvailability = new HashSet<DriverAvailability>();
            DriverCurrentLocation = new HashSet<DriverCurrentLocation>();
            DriverJobRequest = new HashSet<DriverJobRequest>();
            DriverLanguages = new HashSet<DriverLanguages>();
            JobNotificationThread = new HashSet<JobNotificationThread>();
            UserDevices = new HashSet<UserDevices>();
        }

        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string EmergencyPhone { get; set; }
        public string OtherPhone { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string SSNNumber { get; set; }
        public string DriverLicence { get; set; }
        public string LicenseState { get; set; }
        public string LicenseClass { get; set; }
        public int? GenderId { get; set; }
        public string Languages { get; set; }
        public string DriverImage { get; set; }
        public string DriverSignature { get; set; }
        public int? TransportId { get; set; }
        public string Password { get; set; }
        public bool? isActive { get; set; }
        public bool? IsOwnVehicle { get; set; }
        public TimeSpan? WorkingStartTime { get; set; }
        public TimeSpan? WorkingEndTime { get; set; }

        public virtual ICollection<DriverAttendance> DriverAttendance { get; set; }
        public virtual ICollection<DriverAttendanceAlert> DriverAttendanceAlert { get; set; }
        public virtual ICollection<DriverAvailability> DriverAvailability { get; set; }
        public virtual ICollection<DriverCurrentLocation> DriverCurrentLocation { get; set; }
        public virtual ICollection<DriverJobRequest> DriverJobRequest { get; set; }
        public virtual ICollection<DriverLanguages> DriverLanguages { get; set; }
        public virtual ICollection<JobNotificationThread> JobNotificationThread { get; set; }
        public virtual ICollection<UserDevices> UserDevices { get; set; }
    }
}
