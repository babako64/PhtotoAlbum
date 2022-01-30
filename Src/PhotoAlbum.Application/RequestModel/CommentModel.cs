using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.RequestModel
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public PhotoModel Photo { get; set; }
    }
}
