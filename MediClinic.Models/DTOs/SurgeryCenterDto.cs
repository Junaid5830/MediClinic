using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class SurgeryCenterDto
    {
        public int SurgeryCenterId { get; set; }

        [Required (ErrorMessage ="*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string MRNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public int? Gender { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime? DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string GenderSC { get; set; }
        public long? PatientId { get; set; }
        public int? ProcedureId { get; set; }
        public int? ImagingId { get; set; }

        public int ProcedureNo { get; set; }
        public int ImagingNo { get; set; }
        public int GenderId { get; set; }
        public string  LastName { get; set; }
    }
}
