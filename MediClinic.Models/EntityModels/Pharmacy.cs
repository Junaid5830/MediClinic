using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Pharmacy
    {
        public int P_ID { get; set; }
        public string PharmacyName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public int? Test_Test { get; set; }
    }
}
