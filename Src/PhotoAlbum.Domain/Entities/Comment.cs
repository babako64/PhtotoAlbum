using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Domain.Common;

namespace PhotoAlbum.Domain.Entities
{
    public class Comment : EntityBase, IAuditableEntity
    {
        public DateTime PostDate { get; set; }
        public string Content { get; set; }

        public Guid PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
