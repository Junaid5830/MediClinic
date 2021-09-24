using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DmeInventory
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int? ManufactureId { get; set; }
        public int? MakeNameModelId { get; set; }
        public string SerialNumber { get; set; }
        public string StockNumber { get; set; }
        public int? TotalInventoryQuantity { get; set; }
        public int? ExistingQuantity { get; set; }
        public int? SubGroupOf { get; set; }
        public int? CPTCode { get; set; }
        public bool? IsActive { get; set; }
        public string Model { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }

        public virtual DMEGroupItem CPTCodeNavigation { get; set; }
        public virtual DmeMakeNameModel MakeNameModel { get; set; }
        public virtual DmeSuppliesManufactures Manufacture { get; set; }
        public virtual DMEGroup SubGroupOfNavigation { get; set; }
    }
}
