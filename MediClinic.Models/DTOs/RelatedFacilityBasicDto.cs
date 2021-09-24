using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.RelatedFacilityDto
{
    public class RelatedFacilityBasicDto
    {
        public int RelatedFacilityId { get; set; }
        [Required]
        public string RelatedFacility { get; set; }
        public string RelatedFacilityDescription { get; set; }
    }
}
