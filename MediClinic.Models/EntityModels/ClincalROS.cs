using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ClincalROS
    {
        public ClincalROS()
        {
            PatientClinicalNotes = new HashSet<PatientClinicalNotes>();
        }

        public int RosId { get; set; }
        public bool General { get; set; }
        public string GeneralText { get; set; }
        public string GeneralComment { get; set; }
        public bool Skin { get; set; }
        public string SkinText { get; set; }
        public string SkinComment { get; set; }
        public bool Heent { get; set; }
        public string HeentText { get; set; }
        public string HeentComment { get; set; }
        public bool? Neck { get; set; }
        public string NeckText { get; set; }
        public string NeckComment { get; set; }
        public bool Breast { get; set; }
        public string BreastText { get; set; }
        public string BreastComment { get; set; }
        public bool Cardiovascular { get; set; }
        public string CardiovascularText { get; set; }
        public string CardiovascularComment { get; set; }
        public bool Respiratory { get; set; }
        public string RespiratoryText { get; set; }
        public string RespiratoryComment { get; set; }
        public bool GI { get; set; }
        public string GIText { get; set; }
        public string GIComment { get; set; }
        public bool Urinary { get; set; }
        public string UrinaryText { get; set; }
        public string UrinaryComment { get; set; }
        public bool GenitalMale { get; set; }
        public string GenitalMaleText { get; set; }
        public string GenitalMaleComment { get; set; }
        public bool GenitalFemale { get; set; }
        public string GenitalFemaleText { get; set; }
        public string GenitalFemaleComment { get; set; }
        public bool Periph { get; set; }
        public string PeriphText { get; set; }
        public string PeriphComment { get; set; }
        public bool msk { get; set; }
        public string mskText { get; set; }
        public string mskComment { get; set; }
        public bool Neurological { get; set; }
        public string NeurologicalText { get; set; }
        public string NeurologicalComment { get; set; }
        public bool Endocrine { get; set; }
        public string EndocrineText { get; set; }
        public string EndocrineComment { get; set; }
        public bool Psychiatric { get; set; }
        public string PsychiatricText { get; set; }
        public string PsychiatricComment { get; set; }

        public virtual ICollection<PatientClinicalNotes> PatientClinicalNotes { get; set; }
    }
}
