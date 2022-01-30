using System;
using System.Collections.Generic;

namespace PhotoAlbum.Application.ViewModels
{
    public class PhotoVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Privacy { get; set; }
        public DateTime UploadDate { get; set; }
        public string Path { get; set; }
        public int View { get; set; }

        public ICollection<CommentVm> Comments { get; set; }
        public MemberVm Member { get; set; }
        public ICollection<TagVm> Tags { get; set; }
        public LocationVm Location { get; set; }
        public AlbumVm Album { get; set; }
    }
}
