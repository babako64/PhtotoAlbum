using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.RequestModel
{
    public class AlbumModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int View { get; set; }

        public ICollection<PhotoModel> Photos { get; set; }
    }
}
