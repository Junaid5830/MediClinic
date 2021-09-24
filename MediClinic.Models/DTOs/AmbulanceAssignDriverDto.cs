using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class AmbulanceAssignDriverDto
    {
        public int Id { get; set; }
        public long DriverId { get; set; }
        public int TransportId { get; set; }
        public DateTime? CreatedDate { get; set; }


        public string AmbulanceModelNumber { get; set; }
        public string AMbulanceNumberPlate { get; set; }
        public string DriverName { get; set; }

    }
    public class AmbulanceWithDriver
    {
        public long DriverId { get; set; }

        public int AssignId { get; set; }
        public int TransportId { get; set; }

        public string ModelNumber { get; set; }
        public string Status { get; set; }
        public string AmbulanceModelNumber { get; set; }
        public string AMbulanceNumberPlate { get; set; }
        public string DriverName { get; set; }

    }
}
