using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientVehiclesDto
{
    public class PatientVehiclesBasicDto
    {
        public long PatientVehicleID { get; set; }
        [Required(ErrorMessage ="Vehicle Info is Required")]
        public string VehicleInfo { get; set; }
        [Required(ErrorMessage = "Vehicle License is Required")]
        public string VehicleLicense { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Vehicle Resigration State is Required")]
        public string VehicleResigrationState { get; set; }
        public int InsuranceProviderId { get; set; }
        public string Role { get; set; }
        public long UserId { get; set; }
        public bool IsDelete { get; set; }

    }
}
