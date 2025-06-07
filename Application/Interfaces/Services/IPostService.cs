using Application.DTOs.Users;

public interface IPostService
{
    Task<List<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreatePostDto dto, Guid userId);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, UpdatePostDto updatePostDto, Guid userId);
}
