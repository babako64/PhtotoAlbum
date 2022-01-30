using System;
using System.Threading.Tasks;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Infrastructure.Data;

namespace PhotoAlbum.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotoAlbumDbContext _dbContext;

        public IPhotoRepository Photos { get; }
        public IAlbumRepository Albums { get; }
        public ILocationRepository Locations { get; }
        public ICommentRepository Comments { get; }
        public IMemberRepository Members { get; }
        public ITagRepository Tags { get; }

        public UnitOfWork(PhotoAlbumDbContext dbContext, IPhotoRepository photoRepository,
            IAlbumRepository albumRepository, ILocationRepository locationRepository, 
            ICommentRepository commentRepository, IMemberRepository memberRepository, ITagRepository tagRepository)
        {
            _dbContext = dbContext;

            Albums = albumRepository;
            Locations = locationRepository;
            Comments = commentRepository;
            Members = memberRepository;
            Tags = tagRepository;
            Photos = photoRepository;
        }

        public async Task<bool> Complete()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
