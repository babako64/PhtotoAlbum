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
    public class TagService : ITagService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<TagVm> Add(TagModel model)
        {

            var tag = _mapper.Map<Tag>(model);

            var tagAdded = await _unitOfWork.Tags.AddAsync(tag);

            if (await _unitOfWork.Complete())
            {
                var tagVm = _mapper.Map<TagVm>(tagAdded);
                return tagVm;
            }

            throw new Exception();
        }

        public async Task<TagVm> Update(TagModel model)
        {
            var tag = await _unitOfWork.Tags.FirstAsync(p => p.Id == model.Id);
            if (tag == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            _mapper.Map(model, tag);

            await _unitOfWork.Tags.UpdateAsync(tag);

            if (await _unitOfWork.Complete())
            {
                var tagVm = _mapper.Map<TagVm>(tag);
                return tagVm;
            }

            throw new Exception();
        }

        public async Task<TagVm> GetById(Guid id)
        {
            var tag = await _unitOfWork.Tags.FirstAsync(p => p.Id == id);
            if (tag == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }


            var tagVm = _mapper.Map<TagVm>(tag);

            return tagVm;
        }

        public async Task<ICollection<TagVm>> GetAll()
        {

            var tags = await _unitOfWork.Tags.GetAllAsync();

            var tagVms = _mapper.Map<ICollection<TagVm>>(tags);

            return tagVms;
        }

        public async Task Delete(Guid id)
        {
            var tag = await _unitOfWork.Tags.FirstAsync(p => p.Id == id);
            if (tag == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            await _unitOfWork.Tags.DeleteAsync(tag);

            if (!await _unitOfWork.Complete())
            {
                //TODO Create custom validation exception
                throw new Exception();
            }
        }
    }
}
