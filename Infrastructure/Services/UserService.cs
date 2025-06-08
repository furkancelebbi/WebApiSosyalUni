using Application.DTOs.Users;
using Application.Exceptions;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Infrastructure.Services

{

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public UserService(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(UserRegisterDto dto)
        {
            var userExists = await _context.Users.AnyAsync(x => x.Email == dto.Email);
            if (userExists)
                throw new BadRequestException("Bu email adresi zaten kayıtlı.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User",
                RankScore = 0,
                UniversityId = dto.UniversityId
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await _context
                .Users
                .FirstOrDefaultAsync(x => x.Email.Equals(userLoginDto.Email));
            if (user is null)
                throw new BadRequestException("Kullanıcı bulunamadı.");


            var isPasswordCorrect = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.PasswordHash);
            if (!isPasswordCorrect)
                throw new BadRequestException("Şifre hatalı.");


            var token = _tokenService.CreateToken(user);

            return token;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.University) // Üniversite bilgisini de getir
                .ToListAsync();
        }

        public async Task ChangeUserRoleAsync(Guid userId, string newRole)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new BadRequestException("Kullanıcı bulunamadı.");

            if (newRole != "User" && newRole != "Admin")
                throw new BadRequestException("Geçersiz rol.");

            user.Role = newRole;
            await _context.SaveChangesAsync();
        }
        public async Task<List<User>> GetAdminsAsync()
        {
            return await _context.Users
                .Where(u => u.Role == "Admin")
                .ToListAsync();
        }

    }
}
