using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class CPTCodesDto
    {
        public long CPTCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }

}
