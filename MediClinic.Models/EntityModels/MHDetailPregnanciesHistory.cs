using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHDetailPregnanciesHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryType { get; set; }
        public string Gender { get; set; }
        public string Complications { get; set; }
        public int? NoOfPregnancies { get; set; }
        public int? NoOfLivingChildren { get; set; }
        public int? NoOfAbortions { get; set; }
        public int? NoOfMiscarriages { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
