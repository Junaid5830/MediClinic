using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.EmploymentTitleDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.EmploymentTitleInterface
{
    public interface IEmploymentTitleService
    {
        public Task<ResponseDto<int>> EmploymentTitle(EmploymentTitleBasicDto employmentTitleBasicDto);

        public Task<ResponseDto<bool>> EmploymentTitleUpdate(EmploymentTitleBasicDto employmentTitleBasicDto);

        public Task<ResponseDto<List<EmploymentTitleBasicDto>>> EmploymentTitleList();

        public Task<ResponseDto<EmploymentTitleBasicDto>> EmploymentTitleId(int Id);

        public Task<ResponseDto<bool>> EmploymentTitleDeleteId(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
