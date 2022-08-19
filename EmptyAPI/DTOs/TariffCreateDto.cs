using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyAPI.DTOs
{
    public class TariffCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double TaxFeeSalt { get; set; }
    }
}
