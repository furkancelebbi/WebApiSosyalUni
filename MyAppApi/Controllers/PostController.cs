﻿using Application.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    [Authorize]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized("Kullanıcı kimliği bulunamadı.");

        var userId = Guid.Parse(userIdClaim.Value);

        await _postService.CreateAsync(dto, userId);
        return Ok("Post oluşturuldu.");
    }


    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, UpdatePostDto dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized("Kullanıcı kimliği bulunamadı.");

        var userId = Guid.Parse(userIdClaim.Value);

        await _postService.UpdateAsync(id, dto, userId);
        return Ok("Post güncellendi.");
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized("Kullanıcı kimliği bulunamadı.");

        Guid userId = Guid.Parse(userIdClaim.Value);

        await _postService.DeleteAsync(id, userId);
        return Ok("Post silindi.");
    }



}
