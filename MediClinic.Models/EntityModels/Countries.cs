using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Countries
    {
        public int id { get; set; }
        public string Sortname { get; set; }
        public string CountryName { get; set; }
        public string Phonecode { get; set; }
    }
}
