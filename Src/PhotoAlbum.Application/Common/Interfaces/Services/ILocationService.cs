using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Application.Common.Interfaces.Services
{
    public interface ILocationService
    {
        Task<LocationVm> Add(LocationModel photo);
        Task<LocationVm> Update(LocationModel photoModel);
        Task<LocationVm> GetById(Guid id);
        Task<ICollection<LocationVm>> GetAll();
        Task Delete(Guid id);
    }
}
