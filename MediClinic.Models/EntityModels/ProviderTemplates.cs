using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderTemplates
    {
        public int ProviderTemplateId { get; set; }
        public string ProviderTemplate { get; set; }
        public int UserId { get; set; }
    }
}
