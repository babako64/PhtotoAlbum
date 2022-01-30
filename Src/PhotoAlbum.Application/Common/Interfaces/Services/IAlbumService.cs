using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Application.Common.Interfaces.Services
{
    public interface IAlbumService
    {

        Task<AlbumVm> Add(AlbumModel model);
        Task<AlbumVm> Update(AlbumModel model);
        Task<AlbumVm> GetById(Guid id);
        Task<ICollection<AlbumVm>> GetAll();
        Task Delete(Guid id);

    }
}
