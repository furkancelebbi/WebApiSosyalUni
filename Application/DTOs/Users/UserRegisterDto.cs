namespace Application.DTOs.Users
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid UniversityId { get; set; }
    }
}
