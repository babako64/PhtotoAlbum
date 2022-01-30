using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Domain.Common;

namespace PhotoAlbum.Domain.Entities
{
    public class Member : EntityBase, IAuditableEntity
    {
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
