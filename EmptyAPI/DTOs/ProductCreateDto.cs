﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyAPI.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int StockCount { get; set; }
        public double Price { get; set; }
    }
}
