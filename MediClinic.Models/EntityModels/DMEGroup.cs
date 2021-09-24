using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DMEGroup
    {
        public DMEGroup()
        {
            DMEGroupItem = new HashSet<DMEGroupItem>();
            DmeInventory = new HashSet<DmeInventory>();
        }

        public int DMEGroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedId { get; set; }
        public bool isActive { get; set; }

        public virtual ICollection<DMEGroupItem> DMEGroupItem { get; set; }
        public virtual ICollection<DmeInventory> DmeInventory { get; set; }
    }
}
