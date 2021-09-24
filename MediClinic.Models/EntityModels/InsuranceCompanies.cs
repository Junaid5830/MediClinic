using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class InsuranceCompanies
    {
        public InsuranceCompanies()
        {
            NF2AOBClaim = new HashSet<NF2AOBClaim>();
        }

        public int ComapnyID { get; set; }
        public string InsuranceCompanyName { get; set; }

        public virtual ICollection<NF2AOBClaim> NF2AOBClaim { get; set; }
    }
}
