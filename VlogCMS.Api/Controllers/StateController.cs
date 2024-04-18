using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StateController(StateService stateService) : BaseController
{
    private readonly StateService _stateService = stateService;

    [HttpGet]
    public async Task<IEnumerable<State>> Index()
    {
        try
        {
            return await _stateService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<State?> Get(int id)
    {
        try
        {
            return await _stateService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] State entity)
    {
        try
        {
            await _stateService.UpsertAsync(entity);
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
            await _stateService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
