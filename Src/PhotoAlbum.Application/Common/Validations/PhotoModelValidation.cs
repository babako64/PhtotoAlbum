using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;

namespace PhotoAlbum.Application.Common.Validations
{
    public class PhotoModelValidation : AbstractValidator<PhotoModel>
    {
        private readonly IPhotoService _photoService;
        private readonly ICommentService _commentService;
        private readonly IAlbumService _albumService;
        private readonly IMemberService _memberService;
        private readonly ILocationService _locationService;

        public PhotoModelValidation(IPhotoService photoService, ICommentService commentService, 
            IAlbumService albumService, IMemberService memberService, ILocationService locationService)
        {
            _photoService = photoService;
            _commentService = commentService;
            _albumService = albumService;
            _memberService = memberService;
            _locationService = locationService;
            RuleFor(p => p.Title).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Title).MaximumLength(255);
            RuleFor(p => p.Member).MustAsync(MemberExists);
            RuleFor(p => p.Album).MustAsync(AlbumExists);
            RuleFor(p => p.Tags).MustAsync(TagExists);
            RuleFor(p => p.Location).MustAsync(LocationExists);
            RuleFor(p => p.Comments).MustAsync(CommentExists);
            RuleFor(p => p.Image).NotNull().SetValidator(new ImageValidator<PhotoModel, IFormFile>()).WithMessage("Images format is not valid");
        }

        private async Task<bool> CommentExists(ICollection<CommentModel> commentModels, CancellationToken arg2)
        {
            if (commentModels.All(c => c.Id == Guid.Empty)) return true;

            if (commentModels.All(c =>  c.Id != Guid.Empty && _commentService.GetById(c.Id).Result != null)) return true;

            return false;
        }

        private async Task<bool> LocationExists(LocationModel locationModel, CancellationToken arg2)
        {
            if (locationModel.Id != Guid.Empty && await _locationService.GetById(locationModel.Id) == null)
                return false;

            return true;
        }

        private Task<bool> TagExists(ICollection<TagModel> arg1, CancellationToken arg2)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> AlbumExists(AlbumModel arg1, CancellationToken arg2)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> MemberExists(MemberModel arg1, CancellationToken arg2)
        {
            throw new NotImplementedException();
        }

    }
}
