using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace VlogCMS.Api.Models
{
    public class Blog
    {
        [Key]
        [Required]
        public required int Id { get; set; }

        [Required]
        public required int CategoryId { get; set; }

        [Required]
        public required string AuthorId { get; set; }

        [Required]
        public required int StateId { get; set; }
        
        [Required]
        public required int PageId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required string Slug { get; set; }

        [Required]
        public required int Likes { get; set; }

        public virtual Category? Category { get; set; } = null;
        public virtual State? State { get; set; } = null;
        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
