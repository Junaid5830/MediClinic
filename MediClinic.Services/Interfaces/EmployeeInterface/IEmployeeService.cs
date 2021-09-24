using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.EmployeeInterface
{
    public interface IEmployeeService
    {
        public Task<ResponseDto<EmployeeBasicDto>> EmployeeCreate(EmployeeBasicDto employeeViewModal);
        public Task<ResponseDto<bool>> EmployeeUpdate(EmployeeBasicDto employeeViewModal);

        public Task<ResponseDto<EmployeeBasicDto>> EmployeeGetById(int Id);

        public Task<bool> EmployeetDeleteById(int Id);
    
        public List<Employee> EmployeeList();
        public List<Employee> EmployeeClientList();
        public Employee EmployeeDetailById(long Id);

        public Task<ResponseDto<bool>> EmailisExistorNot(string email);
        public Task<ResponseDto<bool>> UserisExistorNot(string user, long? userId, string Email);

        public bool ClientActive(int Id);
        public bool ClientInActive(int Id);
        public bool Delete(int Empid);
        #region For API
        public Task<ResponseDto<EmployeeDto>> UpdateDriverProfile(EmployeeDto employeeDto);
        #endregion
    }
}
