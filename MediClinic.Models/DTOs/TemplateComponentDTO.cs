using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class Error
    {
        public string Msg { set; get; }
        public bool Status { set; get; }
    }
    public class TemplateComponentDTO
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string ComponentType { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "This field cannot be longer than {1} characters")]
        public string ComponentLabel { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field cannot be longer than {1} characters")]
        public string ComponentId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "This field cannot be longer than {1} characters")]
        public string ComponentPlaceholder { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field cannot be longer than {1} characters")]
        public string ComponentName { get; set; }

        public List<TemplateComponentDetailDTO> TemplateComponentDetailDTO { set; get; }
    }
}
