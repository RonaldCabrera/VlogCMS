using System.ComponentModel.DataAnnotations;

namespace VlogCMS.Api.Models.Dtos;

public record ImageDto(int BlogId, string Name, string? Description, IFormFile? Picture)
{

}