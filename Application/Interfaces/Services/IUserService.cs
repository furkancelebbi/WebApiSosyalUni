using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task RegisterAsync(UserRegisterDto userRegisterdto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);

    }
}
