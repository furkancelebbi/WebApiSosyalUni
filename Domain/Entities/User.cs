namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public int RankScore { get; set; }
        public Guid UniversityId { get; set; }

        public University University { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<RankLog> RankLogs { get; set; }
    }
}
