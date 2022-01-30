using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Infrastructure.Configurations
{
    public class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(120);
            builder.Property(a => a.Description).HasMaxLength(255);

            builder.Property(a => a.Title).IsConcurrencyToken();
        }
    }
}
