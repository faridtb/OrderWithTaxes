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
    public class CountryController : BaseApiController
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCountry(CountryCreateDto country)
        {
            if (country == null)  return BadRequest("Country Can't be null!");

            Country newCountry = new Country
            {
                MarketCapacity = country.MarketCapacity,
                Name = country.Name
            };

            _context.Countries.Add(newCountry);
            _context.SaveChanges();

            return Ok("Country Created!");
        }

        [HttpGet]
        public List<Country>  GetAllCountries()
        {
            return _context.Countries.ToList();
        }

    }
}
