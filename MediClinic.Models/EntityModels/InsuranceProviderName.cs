using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class InsuranceProviderName
    {
        public InsuranceProviderName()
        {
            SecondaryInsurenceProvider = new HashSet<SecondaryInsurenceProvider>();
            TertiaryInsurenceProvider = new HashSet<TertiaryInsurenceProvider>();
            VehicalsOrEntityInvolved = new HashSet<VehicalsOrEntityInvolved>();
        }

        public int ProviderId { get; set; }
        public string ProviderName { get; set; }

        public virtual ICollection<SecondaryInsurenceProvider> SecondaryInsurenceProvider { get; set; }
        public virtual ICollection<TertiaryInsurenceProvider> TertiaryInsurenceProvider { get; set; }
        public virtual ICollection<VehicalsOrEntityInvolved> VehicalsOrEntityInvolved { get; set; }
    }
}
