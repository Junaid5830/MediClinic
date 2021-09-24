using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderTerms
    {
        public ProviderTerms()
        {
            ProviderInfo = new HashSet<ProviderInfo>();
        }

        public int ProviderTermId { get; set; }
        public string ProviderTerm { get; set; }

        public virtual ICollection<ProviderInfo> ProviderInfo { get; set; }
    }
}
