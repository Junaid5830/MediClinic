using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
	public class AllergyTypeDto
	{
    public int AllergyTypeId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public int? VisitId { get; set; }

    public virtual ICollection<Allergies> allergies { get; set; }
  }
}
