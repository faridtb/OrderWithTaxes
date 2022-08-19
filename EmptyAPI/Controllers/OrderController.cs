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
    public class OrderController : BaseApiController
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateProduct(OrderCreateDto order)
        {
            // Tez bazar yoxlanish yoxsa lazimi deyerleri databasaden bir bir yoxlayib o terzde elave etmek lazimdir. ....
            if (order.CustomerName == null) return BadRequest("Customer name can't be null");
            if (order.CustomerPhone == null) return BadRequest("Customer phone can't be null");
            if (order.CountryName == null) return BadRequest("Country can't be null");
            if (order.ProductName == null) return BadRequest("Product can't be null");
            if (order.SegmentName == null) return BadRequest("Segment can't be null");
            if (order.TarifIds.Count < 1) return BadRequest("Minimum one tarif must be chossed");


            var segment = _context.Segments.FirstOrDefault(s => s.Name == order.SegmentName);
            if (segment == null) return BadRequest("Segment doesnt founded !");

            var country = _context.Countries.FirstOrDefault(c => c.Name == order.CountryName);
            if (country == null) return BadRequest("Country doesnt founded !");

            var product = _context.Products.FirstOrDefault(p => p.Name == order.ProductName);

            if (product == null) return BadRequest("Product doesnt exist our database");

            if (product.StockCount == 0) return BadRequest("Product stock is zero");

            if (order.ProductCount > product.StockCount) return BadRequest("Product doesnt exist bu qeder");


            Order newOrder = new Order
            {
                CountryName = order.CountryName,
                CustomerName = order.CustomerName,
                CustomerPhone = order.CustomerPhone,
                SegmentName = order.SegmentName,

            };

            newOrder.ProductName = product.Name;
            newOrder.ProductCount = order.ProductCount;

            List<Tariff> tariffs = new List<Tariff>();
            double resultTax = 0;

            foreach (var id in order.TarifIds)
            {
                var tarif = _context.Tariffs.FirstOrDefault(t => t.Id == id);
                if (tarif != null)
                {
                    tariffs.Add(tarif);
                    resultTax += tarif.TaxFeeSalt;
                }
            }

            newOrder.ProductPrice = product.Price - resultTax;

            newOrder.TotalPrice = order.ProductCount * newOrder.ProductPrice;

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            return Ok("Order Saved !");

        }


        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
