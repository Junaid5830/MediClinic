using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class vw_GetMHPharmacyInfo
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public int? CountryId { get; set; }
        public string Address { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CountryName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
