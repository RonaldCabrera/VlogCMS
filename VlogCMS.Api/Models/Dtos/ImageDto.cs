using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlogCMS.Api.Models.Dtos
{
    public class ImageDto
    {
        [Required]
        public required int BlogId { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
