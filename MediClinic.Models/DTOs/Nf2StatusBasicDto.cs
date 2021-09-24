using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.Nf2StatusDto
{
    public class Nf2StatusBasicDto
    {
        public int Nf2Id { get; set; }
        [Required(ErrorMessage = "NF2 Name is required.")]
        [Display(Name ="NF2 Name")]
        public string Nf2Status1 { get; set; }

    }
}
