using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ClinicalReminder
    {
        public int CRId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string ReminderType { get; set; }
        public string ReminderBy { get; set; }
        public string Reminders { get; set; }
        public DateTime? DueDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Reminder_By { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
