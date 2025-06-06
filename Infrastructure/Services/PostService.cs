using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;



public class PostService : IPostService
{
    private readonly AppDbContext _context;

    public PostService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PostDto>> GetAllAsync()
    {
        return await _context.Posts
            .Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<PostDto> GetByIdAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) throw new Exception("Post bulunamadı.");

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        };
    }

    public async Task CreateAsync(CreatePostDto dto, Guid userId)
    {
        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) throw new Exception("Post bulunamadı.");

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }
}
