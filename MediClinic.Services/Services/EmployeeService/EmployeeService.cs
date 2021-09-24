using AutoMapper;
using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.EmployeeInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public EmployeeService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<EmployeeBasicDto>> EmployeeCreate(EmployeeBasicDto employeeViewModal)
         {
            var result = false;
            var mapped = _mapper.Map<EmployeeBasicDto, Employee>(employeeViewModal);
            mapped.isActive = true;
            mapped.isdeleted = false;
            mapped.CreatedDate = DateTime.Now;
            var data = await _context.Employee.AddAsync(mapped);
            await _context.SaveChangesAsync();
            if (!(data is null))
            {
                result = true;
            }
            var entity = _mapper.Map<Employee, EmployeeBasicDto>(mapped);

            var response = new ResponseDto<EmployeeBasicDto>();
           
            response.Data = entity;
            return response;
        }

        public async Task<ResponseDto<EmployeeBasicDto>> EmployeeGetById(int Id)
        {
            var oldEntity = await _context.Employee.FirstOrDefaultAsync(x => x.Employee_id == Id);
            var mapped = _mapper.Map<Employee, EmployeeBasicDto>(oldEntity);
            var response = new ResponseDto<EmployeeBasicDto>();
            response.Data = mapped;
            return response;
        }

        public List<Employee> EmployeeList()
        {
            return _context.Employee.Include(p => p.EmploymentRole).Where(x => x.isActive == true&& x.isdeleted !=true).ToList();
        }

        public async Task<bool> EmployeetDeleteById(int Id)
        {
            var result = false;
            try
            {
               
                var oldEntity = await _context.Employee.FirstOrDefaultAsync(x => x.Employee_id == Id);
                oldEntity.isActive = false;
                await _context.SaveChangesAsync();
                if (oldEntity.UserId != null)
                {
                    var userOldEntity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == oldEntity.UserId);
                    userOldEntity.IsActive = false;
                    await _context.SaveChangesAsync();
                }
                

                result = true;
                return result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> EmployeeUpdate(EmployeeBasicDto employeeViewModal)
        {
            try
            {
                var mapped = _mapper.Map<EmployeeBasicDto, Employee>(employeeViewModal);
                mapped.isActive = true;
                if (mapped.EmploymentRoleId == 4)
                {
                    mapped.isUser = true;
                }
                var oldEntity = await _context.Employee.FindAsync(mapped.Employee_id);

                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Delete(int Empid)
        {
            Employee Emp = _context.Employee.Where(a => a.Employee_id== Empid).FirstOrDefault();
            if (Emp != null)
            {
                Emp.isdeleted = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<ResponseDto<bool>> EmailisExistorNot(string email)
        {
            bool isExist = false;

            var userRecord = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            var empRecord = await _context.Employee.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (!(userRecord is null) || !(empRecord is null))
            {
                isExist = true;
            }

            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "Email is already exist",
                Status = 3
            };
        }

        public async Task<ResponseDto<bool>> UserisExistorNot(string user, long? userId, string Email)
        {
            bool isExist = false;

            var record = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == user.ToLower());
            if (!(record is null))
            {
                isExist = true;
            }

            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "UserName/Email is already exist",
                Status = 3
            };
        }

        public Employee EmployeeDetailById(long Id)
        {
            return _context.Employee.Where(x => x.Employee_id == Id).FirstOrDefault();
        }

        public List<Employee> EmployeeClientList()
        {
            return _context.Employee.Include(p => p.EmploymentRole).Include(u => u.User).Where(x => x.isActive == true && x.isUser == true && x.EmploymentRoleId == 4).ToList();

        }

        public bool ClientActive(int Id)
        {
            var rec = _context.Users.FirstOrDefault(x => x.UserId == Id);
            if (!(rec is null))
            {
                rec.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ClientInActive(int Id)
        {
            var rec = _context.Users.FirstOrDefault(x => x.UserId == Id);
            if (!(rec is null))
            {
                rec.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #region For Api
        public async Task<ResponseDto<EmployeeDto>> UpdateDriverProfile(EmployeeDto employeeDto)
        {
            try
            {
                var mapped = _mapper.Map<EmployeeDto, Employee>(employeeDto);
                mapped.isActive = true;
                
                var oldEntity = await _context.Employee.FindAsync(mapped.Employee_id);

                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();

                var entity = _mapper.Map<Employee, EmployeeDto>(mapped);

                var response = new ResponseDto<EmployeeDto>();

                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}