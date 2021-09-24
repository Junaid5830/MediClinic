using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientRelationshipDto
{
    public class PatientRelationshipBasicDto
    {
        public int RelationshipId { get; set; }
        [Required]
        [Display(Name = "Relation Ship")]
        public string RelationshipName { get; set; }
    }
}
