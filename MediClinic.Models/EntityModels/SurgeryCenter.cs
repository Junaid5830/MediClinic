using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class SurgeryCenter
    {
        public int SurgeryCenterId { get; set; }
        public string FirstName { get; set; }
        public string MRNumber { get; set; }
        public int? Gender { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public long? PatientId { get; set; }
        public int? ProcedureId { get; set; }
        public int? ImagingId { get; set; }

        public virtual Imaging Imaging { get; set; }
        public virtual PatientInfo Patient { get; set; }
        public virtual Procedures Procedure { get; set; }
    }
}
