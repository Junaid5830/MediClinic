using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class UserLanguage
    {
        public int UserLanguageId { get; set; }
        public long? UserId { get; set; }
        public int? LanguageId { get; set; }

        public virtual PatientLanguage Language { get; set; }
        public virtual Users User { get; set; }
    }
}
