using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.SoapNotesInterface
{
    public interface ISoapNotesService
    {
        public Task<ResponseDto<bool>> SoapNotesCreate(SoapNotesBasicDto soapNotesBasicDto);
        public Task<ResponseDto<bool>> SoapNotesUpdate(SoapNotesBasicDto soapNotesBasicDto);

        public Task<ResponseDto<SoapNotesBasicDto>> SoapNotesById(int Id);

        public Task<ResponseDto<bool>> SoapNotesDeleteById(int Id);

        public List<SoapNotesSurvey> SoapNotesList();
        Task<List<ICDDto>> ICDCodeList(bool withDetail);
        //public Task<ResponseDto<bool>> EmailisExistorNot(string email, long? userId, int RoleId);
        //public Task<ResponseDto<bool>> UserisExistorNot(string user, long? userId, int RoleId);
    }
}
