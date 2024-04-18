using Microsoft.EntityFrameworkCore;
using VlogCMS.Api.Data;
using VlogCMS.Api.Models;

namespace VlogCMS.Api.Services
{
    public class PageService(AppDbContext context) : IEntityService<Page>
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Page>> GetAllAsync()
        {
            return await _dbContext.Pages
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Page> GetByIdAsync(int id)
        {
            return await _dbContext.Pages
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);
        }

        public async Task UpsertAsync(Page page)
        {
            _dbContext.Update(page);
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
