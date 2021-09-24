using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.SubContractorInfoInterface
{
	public interface ISubContractorInfoService
	{
    public Task<List<SubContractorInfoDto>> subContractorInfo(int? userid);
    public Task<ResponseDto<SubContractorInfoDto>> subContractorInfoCreate(SubContractorInfoDto SubContractorInfoDto);

    public Task<ResponseDto<bool>> subContractorInfoUpdate(SubContractorInfoDto SubContractorInfoDto);

    public Task<ResponseDto<SubContractorInfoDto>> subContractorInfoGetId(int Id);

    public Task<ResponseDto<SubContractorInfoDto>> subContractorInfoGetLastAdded();

    public Task<ResponseDto<bool>> subContractorInfoDeleteById(int Id);

    public Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId);
    //public Task<List<SubContractorInfoDto>> GetProviderList();
    public SubContractorInfo GetSubContractorUserId(long Id);

  }
}
