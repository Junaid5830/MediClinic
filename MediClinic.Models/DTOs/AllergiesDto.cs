using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
	public class AllergiesDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public int? ForiegnId { get; set; }
        public int? VisitId { get; set; }
	}
}
