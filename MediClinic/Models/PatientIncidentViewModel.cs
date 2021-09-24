using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class PatientIncidentViewModel
    {
        public PatientIncidentViewModel()
        {
            patientIncidentList = new List<PatientIncidentRoleBasicDto>();
        }
        public int PatientIncidentRoleId { get; set; }
        [Required(ErrorMessage ="Role in Incident Required")]
        public string PatientRoleInIncident { get; set; }

        public List<PatientIncidentRoleBasicDto> patientIncidentList { get; set; }

    }
}
