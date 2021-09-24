using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ImagingInterface
{
    public interface IImagingService
    {
        public Task<bool> Add(ImagingDto imagingDto);
        public Task<List<PatientInfoBasicDto>> GetlistofPatients();

        public Task<List<ImagingDto>> GetImagingList();

        public Task<List<ImagingDto>> GetImagingListByVisits(long Id);

        public Task<ResponseDto<List<ImagingDto>>> PatientGetImagingList(long Id);

        public Task<List<ImagingDto>> ImagingVisitList(int Id);
        public bool Delete(int imagingId);

        public ImagingDto GetImagingById(int imgId);

        public Task<ResponseDto<ImagingDto>> AddSurgeryImaging(ImagingDto imagingDto);
    }
}
