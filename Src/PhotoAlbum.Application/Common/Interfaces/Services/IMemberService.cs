using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Application.Common.Interfaces.Services
{
    public interface IMemberService
    {
        Task<MemberVm> Add(MemberModel model);
        Task<MemberVm> Update(MemberModel model);
        Task<MemberVm> GetById(Guid id);
        Task<ICollection<MemberVm>> GetAll();
        Task Delete(Guid id);
    }
}
