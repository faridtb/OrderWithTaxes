using EmptyAPI.Data;
using EmptyAPI.DTOs;
using EmptyAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyAPI.Controllers
{
    public class ProductController:BaseApiController
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto product)
        {
            if (product.Name == null) return BadRequest("Name can't be null");
            if (product.StockCount == 0) return BadRequest("StockCount can't be null");
            if (product.Price == 0) return BadRequest("Price can't be null");

            Product newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                StockCount = product.StockCount
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return Ok("Product created succesfully !");

        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
