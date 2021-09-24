using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.TransportEmsInterface
{
    public interface ITransportEmsService
    {

        public Task<ResponseDto<bool>> EmailisExistorNot(string Email);
        public Task<ResponseDto<bool>> VehicleNumberExist(string Email);
        public Task<ResponseDto<TransportEmsDTO>> AddTransport(TransportEmsDTO transportEmsDTO);
        public List<TransportEmsDTO> getlist();
        public Task<TransportEmsDTO> GetTransportById(int transportId);
        public Task<TransportDetailsDto> GetTransportDetailsId(int transportId);
        public List<Models.DTOs.VehicleAttchmentsDto> GetVehicleAttachmentsById(int transportId);
        public bool Delete(int transportId);
        public int GetMaxLatestVehicle();
        public IEnumerable<SelectListItem> SelectAmbulacesForDropDow();
        public IEnumerable<SelectListItem> SelectSelectListForVehicleMake();
        public IEnumerable<SelectListItem> SelectListForVehicleModel();
        public IEnumerable<SelectListItem> SelectListForVehicleType();
        public IEnumerable<SelectListItem> SelectListForLangauges();
        public IEnumerable<SelectListItem> VehiclesListForDropDown();

        public Task<ResponseDto<VehicleTypeDto>> AddVehicleType(VehicleTypeDto vehicleType);
        public Task<ResponseDto<VehicleMakeDto>> AddVehicleMake(VehicleMakeDto vehicleMake);
        public Task<ResponseDto<VehicleModelDto>> AddVehicleModel(VehicleModelDto vehicleModel);

        public Task<ResponseDto<AmbulanceAssignDriverDto>> AssignAmbulanceToDriver(AmbulanceAssignDriverDto ambulanceAssignDriver);
        public Task<ResponseDto<bool>> AlreadyAssignedAmbulanceDriver(AmbulanceAssignDriverDto ambulanceAssignDriver);
        public Task<List<AmbulanceAssignDriverDto>> GetListOfDriverWithAssignedAmbulance();
        public Task<ResponseDto<AmbulanceAssignDriverDto>> GetByIdAssignedAmbulance(int Id);
        public Task<ResponseDto<bool>> DeleteAssignedAmbulance(int Id);

        public Task<List<AmbulanceWithDriver>> AvailabeAmbulance();

        public Task<ResponseDto<DriverJobRequestDto>> AssignDriverToPickUpPoint(DriverJobRequestDto driverJobRequestDto, string senderName);

        public Task<ResponseDto<DriverProfileDto>> DriveCreate(DriverProfileDto driverProfileDto, string[] languages);
        public Task<ResponseDto<bool>> DriveUpdate(DriverProfileDto driverProfileDto, string[] languages);
        public Task<ResponseDto<DriverProfileDto>> AddUpdateDriverWithOwnVehicle(DriverProfileDto driverProfile, TransportEmsDTO OwnVehicle);
        Task<DriverProfileDto> GetDriveById(int Id);
        public bool DriveDelete(int Id);
        public bool ChangeDriverStatus(int Id,bool status);
        public bool AmbulanceDelete(int Id);
        Task<ResponseDto<List<DriverProfileDto>>> DriverList();


        Task<ResponseDto<TransportEmsDTO>> GetTransportRecordByDriverId(int Id);

        Task<ResponseDto<List<DriverProfileDto>>> GetDriverDetailList(int? Id = null);
        Task<ResponseDto<List<DriverProfileDto>>> AvailableDriverListForResptionisit();
        Task<ResponseDto<List<DriverProfileDto>>> AvailableDriverJobStatus();
        Task<ResponseDto<List<DriverProfileDto>>> DriverJobRequestStatus();
        Task<ResponseDto<List<DriverProfileDto>>> SelectDriversForDropDow();

        Task<ResponseDto<List<DriverCurrentLocationBasicDto>>> DriverCurrentLocationForMap(long? driverId);

        Task<ResponseDto<List<DriverDirectionForMap>>> DriverDirectionForMap(long? driverId);

        #region API
        Task<ResponseDto<DriverProfileApiDto>> GetDriverDetailById(int? Id = null);
        Task<ResponseDto<DriverVehicleDetailDto>> DriverVehicleDetail(int Id);
        Task<ResponseDto<List<Models.ApiDtos.Langauges>>> LanguageList();
        Task<ResponseDto<DriverProfileUpdateDto>> DriverProfileUpdateApi(DriverProfileUpdateDto driverProfileUpdateDto);


        Task<ResponseDto<List<VehicleMake>>> GetVehicleMakers();
        Task<ResponseDto<List<VehicleModel>>> GetVehicleModels();
        Task<ResponseDto<List<VehicleType>>> GetVehicleTypes();
        Task<ResponseDto<bool>> UpdateTransportForAPI(UpdateTransportApiDto transportEmsDTO);

        #endregion
    }
}
