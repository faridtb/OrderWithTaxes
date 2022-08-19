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
    public class SegmentController:BaseApiController
    {
        private readonly AppDbContext _context;

        public SegmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateSegment(SegmentCreateDto segment)
        {
            if (segment == null) return BadRequest("Country Can't be null!");

            Segment newSegment = new Segment
            {
                Name = segment.Name
            };

            _context.Segments.Add(newSegment);
            _context.SaveChanges();

            return Ok("Segment Created!");
        }

        [HttpGet]
        public List<Segment> GetAllSegments()
        {
            return _context.Segments.ToList();
        }

    }
}
