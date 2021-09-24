using MediClinic.Models.DTOs;
using System.Collections.Generic;

namespace MediClinic.Models
{
    public class DashbordViewModel
    {
        public DashboardCountDto Dashboarcount { get; set; }

        public List<DepartmentsDto> departmentsDto { get; set; }
    }
}
