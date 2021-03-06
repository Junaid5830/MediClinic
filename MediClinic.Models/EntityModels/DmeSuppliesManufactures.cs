using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DmeSuppliesManufactures
    {
        public DmeSuppliesManufactures()
        {
            DmeInventory = new HashSet<DmeInventory>();
        }

        public int Id { get; set; }
        public string Manufactures { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<DmeInventory> DmeInventory { get; set; }
    }
}
