using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(CommentService commentService) : BaseController
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
            await _commentService.UpsertAsync(entity);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Create(int id)
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
