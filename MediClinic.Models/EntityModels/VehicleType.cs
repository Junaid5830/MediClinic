using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            TransportEms = new HashSet<TransportEms>();
        }

        public int VehicleTypeId { get; set; }
        public string VehicleType1 { get; set; }

        public virtual ICollection<TransportEms> TransportEms { get; set; }
    }
}
