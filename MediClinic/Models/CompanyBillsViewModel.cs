using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class CompanyBillsViewModel
    {
        public CompanyBillsDto companyBillsDto { get; set; }
        public List<CompanyBillsDto> companyBillsList { get; set; }
    }
}
