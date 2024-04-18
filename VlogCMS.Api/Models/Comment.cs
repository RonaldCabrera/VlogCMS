using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VlogCMS.Api.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public required int Id { get; set; }

        [Required]
        public required int BlogId { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public required string Content { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Blog? Blog { get; set; } = null;
    }
}
