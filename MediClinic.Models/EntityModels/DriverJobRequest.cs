using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverJobRequest
    {
        public DriverJobRequest()
        {
            DriverJobRequestStatus = new HashSet<DriverJobRequestStatus>();
        }

        public long CurrentRequestID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public int? DriverId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CallerPhoneNo { get; set; }
        public string CallerName { get; set; }
        public string DAddress { get; set; }
        public string DLatitude { get; set; }
        public string DLongitude { get; set; }
        public long? PatientId { get; set; }

        public virtual DriverProfile Driver { get; set; }
        public virtual PatientInfo Patient { get; set; }
        public virtual ICollection<DriverJobRequestStatus> DriverJobRequestStatus { get; set; }
    }
}
