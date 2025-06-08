using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Create([FromBody] CreateUniversityDto dto)
        {
            if (await _context.Universities.AnyAsync(u => u.Name == dto.Name))
                return Conflict("Bu üniversite zaten kayıtlı");

            var university = new University
            {
                Id = Guid.NewGuid(),
                Name = dto.Name.Trim(),
                City = dto.City.Trim(),
                Address = dto.Address.Trim() // Dikkat: Artık "Address"
            };

            await _context.Universities.AddAsync(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(university), new { id = university.Id }, university);
        }
    }
}
