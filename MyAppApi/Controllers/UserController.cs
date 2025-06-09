using Application.DTOs.Users;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppApi.Extensions;
using Persistence.Context;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;

    public UserController(AppDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userId = User.GetUserId();
        var user = await _context.Users.FindAsync(userId);

        if (user is null)
            return NotFound("Kullanıcı bulunamadı.");

        return Ok(new
        {
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Role
        });
    }


    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUser()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPost("change-role")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> ChangeUserRole([FromBody] ChangeRoleRequest request)
    {
        try
        {
            await _userService.ChangeUserRoleAsync(request.UserId, request.NewRole);
            return Ok(new { Message = "Role başarıyla güncellendi" });

        }
        catch (DirectoryNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null)
            return NotFound("Kullanıcı bulunamadı.");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Ok(new { Message = "Kullaanıcı silindi" });



    }
}
