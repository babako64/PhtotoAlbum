using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.Common.Interfaces.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IPhotoRepository Photos { get; }
        IAlbumRepository Albums { get; }
        ILocationRepository Locations { get; }
        ICommentRepository Comments { get; }
        IMemberRepository Members { get; }
        ITagRepository Tags { get; }

        Task<bool> Complete();
    }
}
