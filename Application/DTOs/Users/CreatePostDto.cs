public class CreatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid UniversityId { get; set; }
}

public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string UserFullName { get; set; }
    public DateTime CreatedAt { get; set; }
}
