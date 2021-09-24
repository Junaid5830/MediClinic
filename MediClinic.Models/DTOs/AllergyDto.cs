using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
	public class AllergyDto
	{
    public int AllergyId { get; set; }
    public int? AllergyTypeId { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }

    public virtual AllergyTypes AllergyType { get; set; }
  }
}
