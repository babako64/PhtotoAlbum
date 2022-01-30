using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhotoAlbum.Domain.Common;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Infrastructure.Data
{
    public class PhotoAlbumDbContext : DbContext
    {

        public PhotoAlbumDbContext(DbContextOptions<PhotoAlbumDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhotoAlbumDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes().
                Where(e => typeof(IAuditableEntity).IsAssignableFrom(e.ClrType)))
            {
                if (!entityType.IsOwned())
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedBy");
                    modelBuilder.Entity(entityType.Name).Property<string>("LastModified");
                    modelBuilder.Entity(entityType.Name).Property<string>("ModifiedBy");
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
