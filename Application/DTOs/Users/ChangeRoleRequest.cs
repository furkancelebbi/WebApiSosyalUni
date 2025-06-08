namespace Application.DTOs.Users
{
    public class ChangeRoleRequest
    {
        public Guid UserId { get; set; }
        public String NewRole { get; set; }
    }

    public class UserProfileResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid UniversityId { get; set; }

    }
}
