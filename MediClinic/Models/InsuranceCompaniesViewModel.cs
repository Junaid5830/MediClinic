using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class InsuranceCompaniesViewModel
    {
        public InsuranceCompaniesDto InsuranceCompany { get; set; }
        public List<InsuranceCompaniesDto>  InsuranceCompaniesList { get; set; }
    }
}
