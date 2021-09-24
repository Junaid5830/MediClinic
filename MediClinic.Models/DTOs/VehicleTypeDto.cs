using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class VehicleTypeDto
    {
        public int VehicleTypeId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string VehicleType1 { get; set; }
    }
}
