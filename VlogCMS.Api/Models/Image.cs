using System.ComponentModel.DataAnnotations;

namespace VlogCMS.Api.Models
{
    public class Image
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int BlogId { get; set; }

        [Required]
        public required Guid AuthorId { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Url { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual Blog? Blog { get; set; } = null;
    }
}
