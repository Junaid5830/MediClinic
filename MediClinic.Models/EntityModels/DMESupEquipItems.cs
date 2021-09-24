using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DMESupEquipItems
    {
        public DMESupEquipItems()
        {
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
        }

        public int DMESupEquipId { get; set; }
        public string ItemOrGroupName { get; set; }

        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
    }
}
