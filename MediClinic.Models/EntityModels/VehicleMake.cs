using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class VehicleMake
    {
        public VehicleMake()
        {
            TransportEms = new HashSet<TransportEms>();
        }

        public int VehicleMakeId { get; set; }
        public string VehicleMake1 { get; set; }

        public virtual ICollection<TransportEms> TransportEms { get; set; }
    }
}
