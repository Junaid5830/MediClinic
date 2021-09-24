using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHSurgicalHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Disease { get; set; }
        public string SurgeryType { get; set; }
        public string SurgeonName { get; set; }
        public int? Year { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
