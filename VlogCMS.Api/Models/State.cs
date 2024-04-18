using System.ComponentModel.DataAnnotations;

namespace VlogCMS.Api.Models
{
    public class State
    {
        [Key]
        [Required]
        public required int Id { get; set; }

        public required string Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();
    }
}
