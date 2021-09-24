using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHDiseases
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Disease { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
