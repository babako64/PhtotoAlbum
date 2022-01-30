using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Domain.Common;

namespace PhotoAlbum.Domain.Entities
{
    public class Album : EntityBase, IAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int View { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
