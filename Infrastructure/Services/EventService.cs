using Application.DTOs.Users;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateEventDto dto, Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null) throw new Exception("Kullanıcı geçersiz");

            var entity = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                UniversityId = dto.UniversityId,
                UserId = userId,
            };
        }

        public async Task DeleteAsync(Guid eventId, Guid userId)
        {
            var e = await _context.Events
                .FirstOrDefaultAsync(x => x.Id == eventId && x.UserId == userId)
                ?? throw new Exception("Event bulunamadı veya silme yetkiniz yok");
            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _context.Events
                .Include(e => e.University)
                .Include(e => e.User)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date,
                    UniversityName = e.University.Name,
                    CreatedBy = $"{e.User.FirstName} {e.User.LastName}",
                }).ToListAsync();
        }



        public async Task<EventDto> GetByIdAsync(Guid id)
        {
            var e = await _context.Events
                 .Include(x => x.University)
                 .Include(x => x.User)
                 .FirstOrDefaultAsync(x => x.Id == id)
                 ?? throw new Exception("Event bulunamadı");
            return new EventDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                UniversityName = e.University.Name,
                CreatedBy = $"{e.User.FirstName} {e.User.LastName}"
            };
        }
    }
}
