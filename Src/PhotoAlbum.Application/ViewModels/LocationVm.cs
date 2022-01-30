using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.ViewModels
{
    public class LocationVm
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ICollection<PhotoVm> Photos { get; set; }
    }
}
