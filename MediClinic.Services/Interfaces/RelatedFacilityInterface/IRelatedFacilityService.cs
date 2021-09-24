using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.RelatedFacilityDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.RelatedFacilityInterface
{
    public interface IRelatedFacilityService
    {
        public Task<ResponseDto<List<RelatedFacilityBasicDto>>> relatedFacility();
        public List<RelatedFacilities> RelatedFacilityByName(string name);
        public Task<ResponseDto<int>> relatedFacilityCreate(RelatedFacilityBasicDto relatedFacilityBasicDto);

        public Task<ResponseDto<bool>> relatedFacilityUpdate(RelatedFacilityBasicDto relatedFacilityBasicDto);

        public Task<ResponseDto<RelatedFacilityBasicDto>> relatedFacilityGetId(int Id);

        public Task<ResponseDto<bool>> relatedFacilityDeleteById(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
