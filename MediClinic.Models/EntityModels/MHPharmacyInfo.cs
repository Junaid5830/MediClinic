using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHPharmacyInfo
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public int? CountryId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ZipCode { get; set; }
    }
}
