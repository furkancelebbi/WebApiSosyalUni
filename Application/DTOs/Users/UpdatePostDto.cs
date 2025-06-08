namespace Application.DTOs.Users
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}