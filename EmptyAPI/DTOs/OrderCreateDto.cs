using EmptyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyAPI.DTOs
{
    public class OrderCreateDto
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string SegmentName { get; set; }
        public string CountryName { get; set; }
        public string ProductName { get; set; }
        public List<int> TarifIds { get; set; }
        public int ProductCount { get; set; }

    }
}
