using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientIncidentRoleDto
{
    public class PatientIncidentRoleBasicDto
    {
        public int PatientIncidentRoleId { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string PatientRoleInIncident { get; set; }

    }
}
