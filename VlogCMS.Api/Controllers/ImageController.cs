using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Models.Dtos;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

// TODO: Get current user id
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ImageController(
    ImageService imageService,
    UserManager<IdentityUser> userManager) : BaseController(userManager)
{
    private readonly ImageService _imageService = imageService;

    [HttpGet]
    public async Task<IEnumerable<Image>> Index()
    {
        try
        {
            return await _imageService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<Image?> Get(int id)
    {
        try
        {
            return await _imageService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    [Authorize(Roles = "Admin,Premium")]
    public async Task<IActionResult> Create([FromForm] ImageDto entity)
    {
        try
        {
            var modelEntity = new Image
            {
                AuthorId = new Guid(CurrentUserId),
                BlogId = entity.BlogId,
                Name = entity.Name,
                Description = entity.Description,
                CreatedDate = DateTime.UtcNow,
            };

            if(entity.Picture is not null)
            {
                string imageUrl = await _imageService.UploadFileAsync(entity.Picture);
                modelEntity.Url = imageUrl;
            }
            
            await _imageService.UpsertAsync(modelEntity);
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
            await _imageService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
