using MediClinic.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class AmbulanceAssignViewModel
    {
        public AmbulanceAssignViewModel()
        {
            ListAmbulanceDrivers = new List<AmbulanceAssignDriverDto>();
        }
        public AmbulanceAssignDriverDto AmbulanceAssignDriver { get; set; }
        public List<AmbulanceAssignDriverDto> ListAmbulanceDrivers { get; set; }
        public IEnumerable<SelectListItem> DriversList { get; set; }
        public IEnumerable<SelectListItem> AmbulanceList { get; set; }

        public List<AmbulanceWithDriver> availabeAmbulances { get; set; }

        public DriverJobRequestDto driverJobRequestDto { get; set; }
    }
}
