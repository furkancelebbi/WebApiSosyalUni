using Application.DTOs.Users;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyAppApi.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var e = await _eventService.GetByIdAsync(id);
            return Ok(e);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            var userId = User.GetUserId();
            await _eventService.CreateAsync(dto, userId);
            return Ok(new { Message = "Event Oluşturuldu" });

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = User.GetUserId();
            await _eventService.DeleteAsync(userId, id);
            return NoContent();
        }
    }
}
