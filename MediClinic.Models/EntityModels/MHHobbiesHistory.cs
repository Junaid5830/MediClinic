using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHHobbiesHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Hobbies { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
