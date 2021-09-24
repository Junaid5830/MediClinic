using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
      public class  DashboardCountDto
    {
        public int PatientCount { get; set; }
        public int ProviderCount { get; set; }
        public int today_total_patient { get; set; }
        public int today_total_patient_check_In { get; set; }
        public int today_total_patient_check_Out { get; set; }
        public int EmployeeCount { get; set; }
        public int TotalAssisstan { get; set; }
        public int today_total_patient_cancelled { get; set; }
    }
}
