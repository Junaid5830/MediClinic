using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Interfaces.DepartmentsInterface
{
    public interface IDepartmentsService
    {
        public List<DepartmentsDto> getlist();
        public bool Add(DepartmentsDto departmentsDto);
        public bool Delete(int DepId);
        public DepartmentsDto GetDepartmentsById(int id);
    }
}
