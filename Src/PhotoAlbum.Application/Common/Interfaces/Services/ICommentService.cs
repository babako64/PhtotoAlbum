using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Application.Common.Interfaces.Services
{
    public interface ICommentService
    {
        Task<CommentVm> Add(CommentModel photo);
        Task<CommentVm> Update(CommentModel photoModel);
        Task<CommentVm> GetById(Guid id);
        Task<ICollection<CommentVm>> GetAll();
        Task Delete(Guid id);
    }
}
