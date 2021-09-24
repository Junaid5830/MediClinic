using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderSpecialities
    {
        public ProviderSpecialities()
        {
            ProviderInfo = new HashSet<ProviderInfo>();
        }

        public int ProviderSpecialityId { get; set; }
        public string ProviderSpeciality { get; set; }

        public virtual ICollection<ProviderInfo> ProviderInfo { get; set; }
    }
}
