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
    public class TariffController : BaseApiController
    {
        private readonly AppDbContext _context;

        public TariffController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateTariff(TariffCreateDto tariff)
        {
            if (tariff == null) return BadRequest("Tariff Can't be null!");

            Tariff newTariff = new Tariff
            {
                Name = tariff.Name,
                Description = tariff.Description,
                TaxFeePercent = tariff.TaxFeePercent
            };

            _context.Tariffs.Add(newTariff);
            _context.SaveChanges();

            return Ok("Tariff Created!");
        }

        [HttpGet]
        public List<Tariff> GetAllTariffs()
        {
            return _context.Tariffs.ToList();
        }
    }
}
