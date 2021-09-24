using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientMissingDto
{
    public class PatientMissingsDto
    {
        public string MissingFields { get; set; }
        public int PatientId { get; set; }
        public string CardHeading { get; set; }
        public List<string> MissingFieldsList { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string TabNumber { get; set; }
    }

}
