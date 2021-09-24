using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.UserInRolesDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class EmployeeViewModal
    {
        public EmployeeBasicDto employeeBasicDto { get; set; }
        public UsersBasicDto User { get; set; }
        public List<LookupBasicDto> gender { get; set; }

        public List<LookupBasicDto> maritalStatus { get; set; }

        public List<LookupBasicDto> RaceEthnicity { get; set; }

        public List<Employee> EmployeesList { get; set; }
        public List<UserInRolesBasicDto> UserRoleTypes { get; set; }
        public UserInRolesBasicDto UserRoleTypesDto { get; set; }

    }
}
