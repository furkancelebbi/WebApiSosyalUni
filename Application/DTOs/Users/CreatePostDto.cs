namespace Application.DTOs.Users
{
    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

public class CreatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid UniversityId { get; set; }
    public Domain.Entities.Post.PostType PostType { get; set; } // Yeni eklendi
}
public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string UserFullName { get; set; }
    public DateTime CreatedAt { get; set; }
}
