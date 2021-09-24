using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.EmploymentStatusDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.EmploymentStatusInterface
{
    public interface IEmploymentStatusService
    {
        public Task<ResponseDto<int>> EmploymentStatus(EmploymentStatusBasicDto employmentStatusBasicDto);

        public Task<ResponseDto<bool>> EmploymentStatusUpdate(EmploymentStatusBasicDto employmentStatusBasicDto);
        public Task<ResponseDto<List<EmploymentStatusBasicDto>>> EmploymentStatusList();

        public Task<ResponseDto<EmploymentStatusBasicDto>> EmploymentStatusId(int Id);
        public Task<ResponseDto<bool>> EmploymentStatusDeleteId(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);


    }
}
