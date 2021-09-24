using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.LegalInfoLeadingParalegalDto
{
	public class LegalInfoLeadingParalegalBasicDto
	{

		public int LeadingParalegalId { get; set; }
		[Required]
		[Display(Name ="Paralegal Name")]
		public string LeadingParalegalName { get; set; }
	}
}
