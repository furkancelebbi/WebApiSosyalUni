using Application.DTOs.Users;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task RegisterAsync(UserRegisterDto userRegisterdto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task<List<User>> GetAllUsersAsync();
        Task ChangeUserRoleAsync(Guid userId, string newRole);
        Task<List<User>> GetAdminsAsync();
    }
}
