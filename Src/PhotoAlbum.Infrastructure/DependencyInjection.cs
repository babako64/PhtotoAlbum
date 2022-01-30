
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Infrastructure.Data;
using PhotoAlbum.Infrastructure.Repository;

namespace PhotoAlbum.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service,
            IConfiguration configuration)
        {

            service.AddDbContext<PhotoAlbumDbContext>(d =>
                d.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            service.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            service.AddScoped<IPhotoRepository, PhotoRepository>();
            service.AddScoped<IAlbumRepository, AlbumRepository>();
            service.AddScoped<ILocationRepository, LocationRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IMemberRepository, MemberRepository>();
            service.AddScoped<ITagRepository, TagRepository>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}