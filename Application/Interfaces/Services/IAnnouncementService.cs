using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IAnnouncementService

    {
        Task CreateAnnouncementAsync(CreateAnnouncementDto dto, Guid adminId);
        Task<List<AnnouncementDto>> GetAllAsync();
    }
}
