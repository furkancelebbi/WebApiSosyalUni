using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var post = await _postService.GetByIdAsync(id);
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        await _postService.CreateAsync(dto);
        return Ok("Post oluşturuldu.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _postService.DeleteAsync(id);
        return Ok("Post silindi.");
    }
}
