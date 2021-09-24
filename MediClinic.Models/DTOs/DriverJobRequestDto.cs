using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DriverJobRequestDto
    {
        public long CurrentRequestID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public long? DriverId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CallerPhoneNo { get; set; }
        public string CallerName { get; set; }
        public string DAddress { get; set; }
        public string DLatitude { get; set; }
        public string DLongitude { get; set; }
        public long? PatientId { get; set; }

    }
}
