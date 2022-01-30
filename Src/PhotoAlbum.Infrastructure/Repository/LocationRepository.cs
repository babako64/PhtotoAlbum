using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Domain.Entities;
using PhotoAlbum.Infrastructure.Data;

namespace PhotoAlbum.Infrastructure.Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(PhotoAlbumDbContext dbContext) : base(dbContext)
        {
        }
    }
}
