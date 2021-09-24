using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHAllergiesHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string AllergyTo { get; set; }
        public string Recation { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
