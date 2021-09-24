using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Languages
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public bool IsVisible { get; set; }
    }
}
