using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence.Context;

namespace MyAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UniversityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUniversityDto dto)
        {
            var university = new University
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                City = dto.City,
                Adress = dto.Adress
            };

            _context.Universities.Add(university);
            _context.SaveChanges();

            return Ok(new { university.Id, Message = "Üniversite başarıyla eklendi." });
        }
    }
}
