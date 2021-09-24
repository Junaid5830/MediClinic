using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.SubProviderDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.SubProviderInterface
{
    public interface ISubProviderService
    {
        public Task<ResponseDto<List<SubProviderBasicDto>>> subProvider();
        public Task<ResponseDto<bool>> subProviderCreate(SubProviderBasicDto subProviderBasicDto);

        public Task<ResponseDto<bool>> subProviderUpdate(SubProviderBasicDto subProviderBasicDto);

        public Task<ResponseDto<SubProviderBasicDto>> subProviderGetId(int Id);

        public Task<ResponseDto<bool>> subProviderDeleteById(int Id);
    }
}
