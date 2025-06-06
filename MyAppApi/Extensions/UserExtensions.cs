using System.Security.Claims;

namespace MyAppApi.Extensions
{
    public static class UserExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userId);
        }
    }
}
