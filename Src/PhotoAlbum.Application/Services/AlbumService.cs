using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Application.Services
{
    public class AlbumService : IAlbumService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlbumService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlbumVm> Add(AlbumModel model)
        {

            var album = _mapper.Map<Album>(model);

            var albumAdded = await _unitOfWork.Albums.AddAsync(album);

            if (await _unitOfWork.Complete())
            {
                var albumVm = _mapper.Map<AlbumVm>(albumAdded);
                return albumVm;
            }

            throw new Exception();
        }

        public async Task<AlbumVm> Update(AlbumModel model)
        {
            var album = await _unitOfWork.Albums.FirstAsync(p => p.Id == model.Id);
            if (album == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            _mapper.Map(model, album);

            await _unitOfWork.Albums.UpdateAsync(album);

            if (await _unitOfWork.Complete())
            {
                var albumVm = _mapper.Map<AlbumVm>(album);
                return albumVm;
            }

            throw new Exception();
        }

        public async Task<AlbumVm> GetById(Guid id)
        {
            var album = await _unitOfWork.Albums.FirstAsync(p => p.Id == id);
            if (album == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }


            var albumVm = _mapper.Map<AlbumVm>(album);

            return albumVm;
        }

        public async Task<ICollection<AlbumVm>> GetAll()
        {

            var albums = await _unitOfWork.Albums.GetAllAsync();

            var albumVms = _mapper.Map<ICollection<AlbumVm>>(albums);

            return albumVms;
        }

        public async Task Delete(Guid id)
        {
            var album = await _unitOfWork.Albums.FirstAsync(p => p.Id == id);
            if (album == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            await _unitOfWork.Albums.DeleteAsync(album);

            if (!await _unitOfWork.Complete())
            {
                //TODO Create custom validation exception
                throw new Exception();
            }
        }

    }
}
