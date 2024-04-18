using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using VlogCMS.Api.Data;
using VlogCMS.Api.Models;

namespace VlogCMS.Api.Services
{
    public class BlogService(AppDbContext context) : IEntityService<Blog>
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _dbContext.Blogs
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _dbContext.Blogs
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);
        }

        public async Task UpsertAsync(Blog blog)
        {
            blog.Slug = GenerateSlug(blog.Name);
            _dbContext.Update(blog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        private static string GenerateSlug(string input)
        {
            string cleanedInput = Regex.Replace(input, @"[^a-zA-Z0-9\s-ñÑ]", string.Empty);
            cleanedInput = cleanedInput.Replace(" ", "-").ToLower();
            cleanedInput = cleanedInput.Replace("ñ", "ny").Replace("Ñ", "NY");
            cleanedInput = Regex.Replace(cleanedInput, @"-+", "-");
            cleanedInput = cleanedInput.Trim('-');

            return cleanedInput;
        }
    }
}
