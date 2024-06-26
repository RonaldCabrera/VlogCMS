﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

// TODO: Get current user id
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CommentController(
    CommentService commentService, 
    UserManager<IdentityUser> userManager) : BaseController(userManager)
{
    private readonly CommentService _commentService = commentService;

    [HttpGet]
    public async Task<IEnumerable<Comment>> Index()
    {
        try
        {
            return await _commentService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<Comment?> Get(int id)
    {
        try
        {
            return await _commentService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Comment entity)
    {
        try
        {
            entity.UserId = new Guid(CurrentUserId);
            await _commentService.UpsertAsync(entity);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Delete/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _commentService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
