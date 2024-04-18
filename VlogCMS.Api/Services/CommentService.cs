using Microsoft.EntityFrameworkCore;
using VlogCMS.Api.Data;
using VlogCMS.Api.Models;

namespace VlogCMS.Api.Services
{
    public class CommentService(AppDbContext context) : IEntityService<Comment>
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbContext.Comments
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);
        }

        public async Task UpsertAsync(Comment comment)
        {
            _dbContext.Update(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
