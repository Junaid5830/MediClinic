using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientRelationship
    {
        public PatientRelationship()
        {
            PatientEmergencyContact = new HashSet<PatientEmergencyContact>();
        }

        public int RelationshipId { get; set; }
        public string RelationshipName { get; set; }

        public virtual ICollection<PatientEmergencyContact> PatientEmergencyContact { get; set; }
    }
}
