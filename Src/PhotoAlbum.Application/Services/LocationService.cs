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
    public class LocationService : ILocationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LocationVm> Add(LocationModel model)
        {

            var location = _mapper.Map<Location>(model);

            var locationAdded = await _unitOfWork.Locations.AddAsync(location);

            if (await _unitOfWork.Complete())
            {
                var locationVm = _mapper.Map<LocationVm>(locationAdded);
                return locationVm;
            }

            throw new Exception();
        }

        public async Task<LocationVm> Update(LocationModel model)
        {
            var location = await _unitOfWork.Locations.FirstAsync(p => p.Id == model.Id);
            if (location == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            _mapper.Map(model, location);

            await _unitOfWork.Locations.UpdateAsync(location);

            if (await _unitOfWork.Complete())
            {
                var locationVm = _mapper.Map<LocationVm>(location);
                return locationVm;
            }

            throw new Exception();
        }

        public async Task<LocationVm> GetById(Guid id)
        {
            var location = await _unitOfWork.Locations.FirstAsync(p => p.Id == id);
            if (location == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }


            var locationVm = _mapper.Map<LocationVm>(location);

            return locationVm;
        }

        public async Task<ICollection<LocationVm>> GetAll()
        {

            var locations = await _unitOfWork.Locations.GetAllAsync();

            var locationVms = _mapper.Map<ICollection<LocationVm>>(locations);

            return locationVms;
        }

        public async Task Delete(Guid id)
        {
            var location = await _unitOfWork.Locations.FirstAsync(p => p.Id == id);
            if (location == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            await _unitOfWork.Locations.DeleteAsync(location);

            if (!await _unitOfWork.Complete())
            {
                //TODO Create custom validation exception
                throw new Exception();
            }
        }
    }
}
