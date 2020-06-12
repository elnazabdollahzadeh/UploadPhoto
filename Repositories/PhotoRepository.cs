
using System.Collections.Generic;
using System.Threading.Tasks;
using UploadAPI.Context;
using UploadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UploadAPI.Repositories
{
    public class PhotoRepository: IPhotoReposiory
    {
        private DataContext _context;

        public PhotoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Photo> GetAll()
        {
            return _context.Photos;
        }

        public async Task<Photo> Add(Photo product)
        {
            await _context.Photos.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Photo> Find(int id)
        {
                var dbPhoto = await _context.Photos.SingleOrDefaultAsync(a => a.PhotoId == id);
                return dbPhoto;
        }

        public async Task<Photo> Remove(int id)
        {
            var product = await _context.Photos.SingleAsync(a => a.PhotoId == id);
            _context.Photos.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Photo> Update(Photo product)
        {
            _context.Photos.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Photos.AnyAsync(e => e.PhotoId == id);
        }
    }
}
