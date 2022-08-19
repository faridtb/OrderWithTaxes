using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public double TotalPrice { get; set; }
        public string SegmentName { get; set; }
        public string CountryName { get; set; }
        public string ProductName { get; set; }



    }
}
