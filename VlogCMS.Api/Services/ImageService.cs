using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlogCMS.Api.Data;
using VlogCMS.Api.Models;

namespace VlogCMS.Api.Services
{
    public class ImageService(AppDbContext context) : IEntityService<Image>
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _dbContext.Images
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _dbContext.Images
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);
        }

        public async Task UpsertAsync(Image entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Directory.GetCurrentDirectory() + "\\Media\\Images";

            string fileName = string.Empty;          
            if (file.Length > 0)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                fileName = $"{Guid.NewGuid()} {fileExtension}";
                using var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
