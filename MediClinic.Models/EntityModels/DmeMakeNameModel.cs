using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DmeMakeNameModel
    {
        public DmeMakeNameModel()
        {
            DmeInventory = new HashSet<DmeInventory>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<DmeInventory> DmeInventory { get; set; }
    }
}
