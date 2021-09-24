using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DoctorSpecialityLookup
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
