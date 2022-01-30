using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Application.Common.Interfaces.Services
{
    public interface IPhotoService
    {
        Task<PhotoVm> AddPhoto(PhotoModel photo);
        Task<PhotoVm> UpdatePhoto(PhotoModel photoModel);
        Task<PhotoVm> GetPhotoById(Guid id);
        Task<ICollection<PhotoVm>> GetAll();
        Task DeletePhoto(Guid id);

    }
}
