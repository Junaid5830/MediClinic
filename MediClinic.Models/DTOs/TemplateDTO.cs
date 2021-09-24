using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class TemplateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field cannot be longer than {1} characters")]
        public string Name { get; set; }
        /*Visit Id only for Patient List don't use in any crud*/
        public int? VisitId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
