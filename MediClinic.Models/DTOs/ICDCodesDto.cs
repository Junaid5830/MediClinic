using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ICDCodesDto
    {
        public long ICDCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }

    }
}