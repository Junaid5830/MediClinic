using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class IncomeExpenceCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryPrice { get; set; }
    }
}
