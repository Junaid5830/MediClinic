using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.ApiDtos
{
    public class LatestJobDto
    {
        public string PickUpLatitude { get; set; }
        public string PickUpLongitutde { get; set; }
        public string DestinationLatitude { get; set; }
        public string DestinationLongitutde { get; set; }
        public string PickUpAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string CallerPhoneNo { get; set; }
        public string CallerName { get; set; }
        public long RequestId { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DriverId { get; set; }
    }
}
