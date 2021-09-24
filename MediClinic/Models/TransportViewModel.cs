using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class TransportViewModel
    {
        public TransportViewModel()
        {
            Transport = new TransportEmsDTO();
        }
        public TransportEmsDTO Transport { get; set; }
        public List<TransportEmsDTO> TransportList { get; set; }
        public VehicleMakeDto VehicleMake { get; set; }
        public VehicleModelDto VehicleModel { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public QuickRegisterPatientDto QuickRegister { get; set; }


        public IEnumerable<SelectListItem> VehicleTypeList { get; set; }
        public IEnumerable<SelectListItem> VehicleMakeList { get; set; }
        public IEnumerable<SelectListItem> VehicleModelList { get; set; }
        public IEnumerable<SelectListItem> patientLanguageList { get; set; }
        public IEnumerable<SelectListItem> VehiclesListForDropDown { get; set; }
        public List<DriverProfileDto> DriversDropDownList { get; set; }

        public DriverProfileDto DriverDto { get; set; }
        public List<LookupBasicDto> gender { get; set; }

        public List<DriverProfileDto> DriverList { get; set; }
        public List<DriverProfileDto> DriverListForAssign { get; set; }
        public List<DriverProfileDto> DriverJobStatus { get; set; }
        public List<DriverProfileDto> DriverJobRequestStatus { get; set; }

        public DriverJobRequestDto driverJobRequestDto { get; set; }

        public LatestJobDto LatestJobDto { get; set; }
        public List<PatientInfoListDto> patientListWithUsers { get; set; }

        public PatientInfoListDto patientCompleteInfo { get; set; }

        public DriverProfileApiDto profileWithTransport { get; set; }
        public TransportDetailsDto VehicleDetailDto { get; set; }
    }
}
