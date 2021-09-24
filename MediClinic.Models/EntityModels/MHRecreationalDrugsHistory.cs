using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHRecreationalDrugsHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Drugs { get; set; }
        public string RecreationalDugsType { get; set; }
        public int? RecreationDrugsAmount { get; set; }
        public int? RecreationalDrugsLastUsed { get; set; }
        public string RecreationDrugsNotes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
