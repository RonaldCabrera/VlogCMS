using System.ComponentModel.DataAnnotations;

namespace VlogCMS.Api.Models.Dtos;

public record ImageDto
{
    [Required]
    public required int BlogId { get; set; }

    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? Picture { get; set; }
}