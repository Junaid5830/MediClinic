using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientLanguage
    {
        public PatientLanguage()
        {
            DriverLanguages = new HashSet<DriverLanguages>();
            PatientInfo = new HashSet<PatientInfo>();
            UserLanguage = new HashSet<UserLanguage>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<DriverLanguages> DriverLanguages { get; set; }
        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
        public virtual ICollection<UserLanguage> UserLanguage { get; set; }
    }
}
