using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.ProviderSpecialityDto
{
    public class ProviderSpecialityBasicDto
    {
        public int ProviderSpecialityId { get; set; }
        [Required(ErrorMessage ="Speciality is required.")]
        public string ProviderSpeciality { get; set; }
    }
}
