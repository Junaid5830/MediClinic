using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderUIDTypes
    {
        public ProviderUIDTypes()
        {
            ProviderInfo = new HashSet<ProviderInfo>();
        }

        public int ProviderUIDTypeId { get; set; }
        public string ProviderUIDType { get; set; }

        public virtual ICollection<ProviderInfo> ProviderInfo { get; set; }
    }
}
