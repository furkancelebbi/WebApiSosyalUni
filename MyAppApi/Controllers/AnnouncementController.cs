using Application.DTOs.Users;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyAppApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnnouncementDto dto)
        {
            var adminId = User.GetUserId();
            await _announcementService.CreateAnnouncementAsync(dto, adminId);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var announcements = await _announcementService.GetAllAsync();
            return Ok(announcements);
        }
    }
}
