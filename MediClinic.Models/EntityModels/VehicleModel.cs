using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class VehicleModel
    {
        public VehicleModel()
        {
            TransportEms = new HashSet<TransportEms>();
        }

        public int VehicleModelId { get; set; }
        public string VehicleModel1 { get; set; }

        public virtual ICollection<TransportEms> TransportEms { get; set; }
    }
}
