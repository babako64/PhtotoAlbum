using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.Common.SettingModels;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageUploadSetting _imageUploadSetting;

        public PhotoService(IUnitOfWork unitOfWork, IMapper mapper, IImageUploadSetting imageUploadSetting)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageUploadSetting = imageUploadSetting;
        }

        public async Task<PhotoVm> AddPhoto(PhotoModel model)
        {

            var photo = _mapper.Map<Photo>(model);

            photo.Path = UploadImage(model.Image);

            var photoAdded = await _unitOfWork.Photos.AddAsync(photo);

            if (await _unitOfWork.Complete())
            {
                var photoVm = _mapper.Map<PhotoVm>(photoAdded);
                return photoVm;
            }

            throw new Exception();
        }

        public string UploadImage(IFormFile fromFile)
        {
            var randomImageName = Path.GetRandomFileName();
            var imagePath = Path.Combine(_imageUploadSetting.Path, randomImageName);
            using var fileStream = new FileStream(imagePath, FileMode.Create);
            fromFile.CopyTo(fileStream);
            fileStream.Close();

            return imagePath;
        }

        public async Task<PhotoVm> UpdatePhoto(PhotoModel photoModel)
        {
            var photo = await _unitOfWork.Photos.FirstAsync(p => p.Id == photoModel.Id);
            if (photo == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            _mapper.Map(photoModel, photo);

            await _unitOfWork.Photos.UpdateAsync(photo);

            if (await _unitOfWork.Complete())
            {
                var photoVm = _mapper.Map<PhotoVm>(photo);
                return photoVm;
            }

            throw new Exception();

        }



        public async Task<PhotoVm> GetPhotoById(Guid id)
        {
            var photo = await _unitOfWork.Photos.FirstAsync(p => p.Id == id);
            if (photo == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }


            var photoVm = _mapper.Map<PhotoVm>(photo);

            return photoVm;
        }

        public async Task<ICollection<PhotoVm>> GetAll()
        {

            var photos = await _unitOfWork.Photos.GetAllAsync();

            var photoVms = _mapper.Map<ICollection<PhotoVm>>(photos);

            return photoVms;
        }

        public async Task DeletePhoto(Guid id)
        {
            var photo = await _unitOfWork.Photos.FirstAsync(p => p.Id == id);
            if (photo == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            await _unitOfWork.Photos.DeleteAsync(photo);

            if (! await _unitOfWork.Complete())
            {
                //TODO Create custom validation exception
                throw new Exception();
            }
        }
    }
}
