using System.Security.Claims;

namespace Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                throw new Exception("Kullanıcı kimliği bulunamadı.");

            return Guid.Parse(userIdClaim);
        }
    }
}
