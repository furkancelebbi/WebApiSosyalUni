public interface IPostService
{
    Task<List<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreatePostDto dto);
    Task DeleteAsync(Guid id);
}
