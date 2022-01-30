using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.ViewModels
{
    public class AlbumVm
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int View { get; set; }

        public ICollection<PhotoVm> Photos { get; set; }

    }
}
