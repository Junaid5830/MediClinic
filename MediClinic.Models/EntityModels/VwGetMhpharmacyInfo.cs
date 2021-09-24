using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class VwGetMhpharmacyInfo
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
