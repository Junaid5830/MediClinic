using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.EmailDto
{
    public class EmailBasicDto
    {
        [Required]
        [Display(Name = " Subject ")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = " Message ")]
        public string Body { get; set; }

        public string FromName { get; set; }
        public IFormFile attachmentFilename { get; set; }
        [Required]
        [Display(Name =" To ")]
        public string ToEmails { get; set; }
        public List<string> CCEmails { get; set; }
    }
}
