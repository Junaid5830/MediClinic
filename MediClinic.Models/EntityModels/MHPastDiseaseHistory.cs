using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHPastDiseaseHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
