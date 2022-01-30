using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.RequestModel
{
    public class TagModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<PhotoModel> Photos { get; set; }
    }
}
