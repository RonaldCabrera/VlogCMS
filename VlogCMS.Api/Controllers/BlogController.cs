using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

// TODO: Get current user id
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BlogController(BlogService blogService) : Controller
{
    private readonly BlogService _blogService = blogService;

    [HttpGet]
    public async Task<IEnumerable<Blog>> Index()
    {
        try
        {
            return await _blogService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<Blog?> Get(int id)
    {
        try
        {
            return await _blogService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    [Authorize(Roles = "Admin,Premium")]
    public async Task<IActionResult> Create([FromBody] Blog entity)
    {
        try
        {
            await _blogService.UpsertAsync(entity);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Delete/{id}")]
    [Authorize(Roles = "Admin,Premium")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _blogService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Like/{id}")]
    public async Task<IActionResult> Like(int id)
    {
        try
        {
            await _blogService.LikeByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}