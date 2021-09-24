using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.IncidentReportStatusDto
{
    public class IncidentReportStatusBasicDto
    {
        public int IncidentReportId { get; set; }
        [Required]
        [Display(Name = "Report Status")]
        public string IncidentReportStatus1 { get; set; }

    }
}
