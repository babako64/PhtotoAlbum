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
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.OwnsOne(m => m.Address);

            builder.Property(m => m.Name).HasMaxLength(50);
            builder.Property(m => m.Email).HasMaxLength(20);
        }
    }
}
