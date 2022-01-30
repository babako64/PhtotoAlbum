using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.ViewModels
{
    public class CommentVm
    {

        public Guid Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }

        public PhotoVm Photo { get; set; }

    }
}
