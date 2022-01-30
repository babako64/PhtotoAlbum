using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhotoAlbum.Application.RequestModel
{
    public class PhotoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Privacy { get; set; }
        public DateTime UploadDate { get; set; }
        public string Path { get; set; }
        public int View { get; set; }
        public IFormFile Image { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
        public MemberModel Member { get; set; }
        public ICollection<TagModel> Tags { get; set; }
        public LocationModel Location { get; set; }
        public AlbumModel Album { get; set; }
    }
}
