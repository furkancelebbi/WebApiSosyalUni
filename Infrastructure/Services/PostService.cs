using Application.DTOs.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;



public class PostService : IPostService
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
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
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı.");

        if (dto.PostType == Post.PostType.Event && user.Role != "Admin")
            throw new Exception("Etkinlik oluşturma yetkiniz yok.");

        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
            Type = dto.PostType
        };

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id, Guid userId)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            throw new Exception("Post bulunamadı");

        if (post.UserId != userId)
            throw new Exception("Bu postu silme yetkiniz yok.");

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(Guid id, UpdatePostDto dto, Guid userId)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            throw new Exception("Post bulunamadı.");

        if (post.UserId != userId)
            throw new UnauthorizedAccessException("Bu postu güncelleme yetkiniz yok.");

        post.Title = dto.Title;
        post.Content = dto.Content;

        await _context.SaveChangesAsync();
    }

}
