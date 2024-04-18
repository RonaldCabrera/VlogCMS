using Microsoft.EntityFrameworkCore;
using VlogCMS.Api.Data;
using VlogCMS.Api.Models;

namespace VlogCMS.Api.Services
{
    public class StateService(AppDbContext context) : IEntityService<State>
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _dbContext.States
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await _dbContext.States
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);
        }

        public async Task UpsertAsync(State state)
        {
            _dbContext.Update(state);
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
