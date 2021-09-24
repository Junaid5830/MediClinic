using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class RelatedFacilities
    {
        public RelatedFacilities()
        {
            ProviderInfo = new HashSet<ProviderInfo>();
        }

        public int RelatedFacilityId { get; set; }
        public string RelatedFacility { get; set; }

        public virtual ICollection<ProviderInfo> ProviderInfo { get; set; }
    }
}
