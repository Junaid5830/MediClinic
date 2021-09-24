using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.IMEInterface
{
    public interface IimeInterface
    {
        public Task<bool> Add(ImeDto imeDt);

        public Task<ResponseDto<List<ImeDto>>> GetImeList();

        public Task<List<ImeDto>> GetIMEListByVisits(long Id);


        public Task<List<ImeDto>> ImagingVisitList(int Id);
        public bool Delete(int imeId);

        public ImeDto GetIMEById(int imId);

    }
}
