using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ClinicViewDto
    {
        public int ProviderCount { get; set; }
        public int AssitanCount { get; set; }
        public int TestsCount { get; set; }
        public int IncidentReportStatusCount { get; set; }
        public int PharmacyCount { get; set; }
        public int SurgeryCenterCount { get; set; }
        public int RadiologyCount { get; set; }
        public int ActivePatienst { get; set; }
        public int InActivePatients { get; set; }
        public int NoFaultTotal { get; set; }
        public int TotalNurses { get; set; }

        public long TotalEmployee { get; set; }
        public int CheckInCount { get; set; }
    }
}
