using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DMEGroupItem
    {
        public DMEGroupItem()
        {
            DmeInventory = new HashSet<DmeInventory>();
            DmePatientsPrescription = new HashSet<DmePatientsPrescription>();
        }

        public int DMEGroupItemId { get; set; }
        public string CPTCode { get; set; }
        public string Description { get; set; }
        public string Fee { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedId { get; set; }
        public bool isActive { get; set; }
        public int? DMEGroupId { get; set; }

        public virtual DMEGroup DMEGroup { get; set; }
        public virtual ICollection<DmeInventory> DmeInventory { get; set; }
        public virtual ICollection<DmePatientsPrescription> DmePatientsPrescription { get; set; }
    }
}
