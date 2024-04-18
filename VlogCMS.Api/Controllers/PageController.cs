using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PageController(PageService pageService) : BaseController
{
    private readonly PageService _pageService = pageService;

    [HttpGet]
    public async Task<IEnumerable<Page>> Index()
    {
        try
        {
            return await _pageService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<Page?> Get(int id)
    {
        try
        {
            return await _pageService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Page entity)
    {
        try
        {
            await _pageService.UpsertAsync(entity);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _pageService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
