using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DoctorSubSpecialityLookup
    {
        public int Id { get; set; }
        public string SubSpecialityName { get; set; }
        public int? SpecialityId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
