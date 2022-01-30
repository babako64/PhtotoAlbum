using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Domain.Common;

namespace PhotoAlbum.Domain.Entities
{
    public class Tag : EntityBase, IAuditableEntity
    {
        public string Title { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
