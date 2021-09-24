using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.LegalInfoAttorneyNameDto
{
    public class LegalInfoAttorneyNameBasicDto
    {
        public int AttorneyId { get; set; }
        [Required]
        [Display(Name = "Attorny Name")]
        public string AttorneyName { get; set; }
    }
}
