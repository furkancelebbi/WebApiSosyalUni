using Application.DTOs.Users;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        public AnnouncementService(
            AppDbContext context,
            IEmailService emailService,
            IUserService userService)
        {
            _context = context;
            _emailService = emailService;
            _userService = userService;
        }



        public async Task CreateAnnouncementAsync(CreateAnnouncementDto dto, Guid adminId)
        {
            var announcement = new Announcement
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedBy = adminId
            };

            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();

            var users = await _userService.GetAllUsersAsync();
            foreach (var user in users)
            {
                await _emailService.SendEmailAsync(
                    user.Email,
                    $"Yeni duyuru: {dto.Title}",
                    $"<h1>{dto.Title}<h1><p>{dto.Content}</p>");
            }
        }

        public async Task<List<AnnouncementDto>> GetAllAsync()
        {
            return await _context.Announcements
                 .Select(a => new AnnouncementDto(a.Id, a.Title, a.Content, a.CreatedAt))
                 .ToListAsync();

        }
    }
}
