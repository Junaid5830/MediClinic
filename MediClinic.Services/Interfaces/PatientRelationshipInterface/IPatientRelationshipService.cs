using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientRelationshipInterface
{
    public interface IPatientRelationshipService
    {
        public Task<ResponseDto<List<PatientRelationshipBasicDto>>> patientRelationship();
        public Task<ResponseDto<bool>> patientRelationshipCreate(PatientRelationshipBasicDto patientRelationshipBasicDto);

        public Task<ResponseDto<bool>> patientRelationshipUpdate(PatientRelationshipBasicDto patientRelationshipBasicDto);

        public Task<ResponseDto<PatientRelationshipBasicDto>> patientRelationshipGetId(int Id);

        public Task<ResponseDto<bool>> patientRelationshipDeleteById(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
        public Task<ResponseDto<int>> relationShip(PatientRelationshipBasicDto patientRelationshipBasicDto);
    }
}
