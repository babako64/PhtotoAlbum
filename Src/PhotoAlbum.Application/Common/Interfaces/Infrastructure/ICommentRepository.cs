using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Application.Common.Interfaces.Infrastructure
{
    public interface ICommentRepository : IAsyncRepository<Comment>
    {
    }
}
