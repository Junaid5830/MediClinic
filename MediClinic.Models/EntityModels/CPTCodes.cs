using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class CPTCodes
    {
        public CPTCodes()
        {
            Claims = new HashSet<Claims>();
            DME = new HashSet<DME>();
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
            Tests = new HashSet<Tests>();
        }

        public long CPTCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Claims> Claims { get; set; }
        public virtual ICollection<DME> DME { get; set; }
        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
