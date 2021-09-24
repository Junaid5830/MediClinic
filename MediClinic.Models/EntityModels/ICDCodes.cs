using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ICDCodes
    {
        public ICDCodes()
        {
            Claims = new HashSet<Claims>();
            DME = new HashSet<DME>();
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
            Tests = new HashSet<Tests>();
        }

        public long ICDCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Claims> Claims { get; set; }
        public virtual ICollection<DME> DME { get; set; }
        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
