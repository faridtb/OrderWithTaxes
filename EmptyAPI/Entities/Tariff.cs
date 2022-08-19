using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyAPI.Entities
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double TaxFeePercent { get; set; }
    }
}
