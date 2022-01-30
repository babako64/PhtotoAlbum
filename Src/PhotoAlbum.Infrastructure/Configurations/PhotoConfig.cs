
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Infrastructure.Configurations
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            
            builder.Property(p => p.Title).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(255);

            builder.HasMany(p => p.Comments).
                WithOne(c => c.Photo).HasForeignKey(c => c.PhotoId);

            builder.HasMany(p => p.Tags).
                WithMany(t => t.Photos).UsingEntity(join => join.ToTable("Photo_Album"));

            builder.HasOne(p => p.Member).
                WithMany(m => m.Photos).HasForeignKey(p => p.MemberId);

            builder.HasOne(p => p.Location).
                WithMany(l => l.Photos).HasForeignKey(p => p.LocationId);

            builder.HasOne(p => p.Album).
                WithMany(a => a.Photos).HasForeignKey(p => p.AlbumId);

        }
    }
}
