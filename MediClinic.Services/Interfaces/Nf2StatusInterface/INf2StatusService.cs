using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.Nf2StatusInterface
{
    public interface INf2StatusService
    {
        public List<Nf2Status> nf2StatusList();
        public Task<ResponseDto<List<Nf2StatusBasicDto>>> nf2Status();
        public Task<ResponseDto<int>> nf2StatusCreate(Nf2StatusBasicDto nf2StatusBasicDto);
        public Task<ResponseDto<bool>> nf2StatusDeleteById(int Id);
        public Task<ResponseDto<Nf2StatusBasicDto>> nf2StatusGetId(int Id);
        public Task<ResponseDto<bool>> nf2StatusUpdate(Nf2StatusBasicDto nf2StatusBasicDto);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    } 
}
