using MediClinic.Models.DTOs.MedicalDiseaseTypeDto;
using MediClinic.Models.DTOs.PMHistory;
using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class PMHistoryViewModel
    {
        //DTO's
        public MHAllergiesHistoryDTO MHAllergiesHistory { get; set; }
        public MHSocialHistoryDTO MHSocialHistory { get; set; }
        public MHDetailPregnanciesHistoryDTO MHDetailPregnanciesHistory { get; set; }
        public MHExerciseHistoryDTO MHExerciseHistory { get; set; }
        public MHFamilyHistoryDTO MHFamilyHistory { get; set; }
        public MHHobbiesHistoryDTO MHHobbiesHistory { get; set; }
        public MHMyPhysicianDTO MHMyPhysician { get; set; }
        public MHPastDiseaseHistoryDTO MHPastDiseaseHistory { get; set; }
        public MHPharmacyInfoDTO MHPharmacyInfo { get; set; }
        public MHPastMedicationHistoryDTO MHPastMedicationHistory { get; set; }
        public MHPregnanciesHistoryDTO MHPregnanciesHistory { get; set; }
        public MHSurgicalHistoryDTO MHSurgicalHistory { get; set; }
        public MHRecreationalDrugsHistoryDTO MHRecreationalDrugsHistory { get; set; }
        public MHHospitalizationsInfoDTO MHHospitalizationsInfo { get; set; }

        public PatientViewModel PatientViewModel { get; set; }


        //Lists

        public IEnumerable<SelectListItem> DiseaseList { get; set; }

        public List<MHPastDiseaseHistory> GetMHPastDiseaseHistory { set; get; }


    }
}
