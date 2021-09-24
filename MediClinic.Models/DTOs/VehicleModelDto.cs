using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class VehicleModelDto
    {
        public int VehicleModelId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string VehicleModel1 { get; set; }
    }
}
