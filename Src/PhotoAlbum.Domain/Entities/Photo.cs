using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Domain.Common;

namespace PhotoAlbum.Domain.Entities
{
    public class Photo : EntityBase, IAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Privacy { get; set; }
        public DateTime UploadDate { get; set; }
        public string Path { get; set; }
        public int View { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
