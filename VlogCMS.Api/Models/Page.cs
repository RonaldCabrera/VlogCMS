using System.ComponentModel.DataAnnotations;

namespace VlogCMS.Api.Models
{
    public class Page
    {
        [Key]
        [Required]
        public required int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string AuthorId { get; set; }

        public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();
    }
}
