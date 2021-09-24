using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DoctorSpeciality
    {
        public int Id { get; set; }
        public int? DoctorProfileId { get; set; }
        public int? SpecialityId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
