using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.FacilityLocation
{
    public interface IFacilityLocation
    {

        public Task<bool> AddUpdate(CurrentLocationFacilityDto currentLocationFacilityDto);
        public  Task<CurrentLocationFacilityDto> GetById(int Id);

        public  Task<List<CurrentLocationFacilityDto>> GetListLocation();
        public Task<List<CurrentLocationFacilityDto>> GetListLocationByPatientId(long? Id);
        public  Task<bool> Delete(int Id);


    }
}
