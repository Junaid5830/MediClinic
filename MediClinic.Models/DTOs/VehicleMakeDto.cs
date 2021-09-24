using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class VehicleMakeDto
    {
        public int VehicleMakeId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string VehicleMake1 { get; set; }
    }
}
