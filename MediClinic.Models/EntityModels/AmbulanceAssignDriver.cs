using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class AmbulanceAssignDriver
    {
        public int Id { get; set; }
        public long DriverId { get; set; }
        public int TransportId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Employee Driver { get; set; }
        public virtual TransportEms Transport { get; set; }
    }
}
