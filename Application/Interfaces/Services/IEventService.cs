using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IEventService
    {
        Task<List<EventDto>> GetAllAsync();
        Task<EventDto> GetByIdAsync(Guid id);
        Task CreateAsync(CreateEventDto dto, Guid userId);
        Task DeleteAsync(Guid eventId, Guid userId);
    }
}
