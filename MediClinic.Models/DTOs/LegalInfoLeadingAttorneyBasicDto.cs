using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.LegalInfoLeadingAttorneyDto
{
	public class LegalInfoLeadingAttorneyBasicDto
	{
		public int LeadingAttorneyId { get; set; }
		[Required]
		[Display(Name ="Leading Attorney Name")]
		public string LeadingAttorneyName { get; set; }
	}
}
