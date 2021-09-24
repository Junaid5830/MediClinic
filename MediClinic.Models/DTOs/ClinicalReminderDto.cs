using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ClinicalReminderDto
    {
        public int CRId { get; set; }
        [Required]
        [Display(Name = "Reminder Date")]
        public DateTime? ReminderDate { get; set; }
        [Required]
        [Display(Name = "Reminder Type")]
        public string ReminderType { get; set; }
        [Required]
        [Display(Name = "Reminder By")]
        public string ReminderBy { get; set; }
        [Required]
        [Display(Name = "Reminders")]
        public string Reminders { get; set; }
        [Required]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
        public string Reminder_By { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public IFormFile file{ get;set; }
        public int? VisitId { get; set; }

    }
}
