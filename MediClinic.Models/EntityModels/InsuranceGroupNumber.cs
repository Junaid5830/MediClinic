using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class InsuranceGroupNumber
    {
        public InsuranceGroupNumber()
        {
            SecondaryInsurenceProvider = new HashSet<SecondaryInsurenceProvider>();
            TertiaryInsurenceProvider = new HashSet<TertiaryInsurenceProvider>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<SecondaryInsurenceProvider> SecondaryInsurenceProvider { get; set; }
        public virtual ICollection<TertiaryInsurenceProvider> TertiaryInsurenceProvider { get; set; }
    }
}
