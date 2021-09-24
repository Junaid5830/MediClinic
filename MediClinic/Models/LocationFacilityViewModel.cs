using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoListDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class LocationFacilityViewModel
    {
        public CurrentLocationFacilityDto CurrentLocation { get; set; }



        public List<PatientInfoListDto> patientListWithUsers { get; set; }
    }
}
