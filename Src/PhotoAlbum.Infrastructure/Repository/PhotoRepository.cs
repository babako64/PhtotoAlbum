using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Domain.Entities;
using PhotoAlbum.Infrastructure.Data;

namespace PhotoAlbum.Infrastructure.Repository
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        private readonly PhotoAlbumDbContext _dbContext;

        public PhotoRepository(PhotoAlbumDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(Photo entity)
        {

            try
            {
                 _dbContext.Photos.Update(entity);

                 await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException exception)
            {
                var entityEntry = exception.Entries.First();

                if (entityEntry.Entity is Photo)
                {
                    var databaseEntry = entityEntry.GetDatabaseValues();
                    var entry = (Photo)databaseEntry.ToObject();
                }
            }

        }
    }

}
