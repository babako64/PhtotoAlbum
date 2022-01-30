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
    public class CommentService : ICommentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentVm> Add(CommentModel model)
        {

            var comment = _mapper.Map<Comment>(model);

            var commentAdded = await _unitOfWork.Comments.AddAsync(comment);

            if (await _unitOfWork.Complete())
            {
                var commentVm = _mapper.Map<CommentVm>(commentAdded);
                return commentVm;
            }

            throw new Exception();
        }

        public async Task<CommentVm> Update(CommentModel model)
        {
            var comment = await _unitOfWork.Comments.FirstAsync(p => p.Id == model.Id);
            if (comment == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            _mapper.Map(model, comment);

            await _unitOfWork.Comments.UpdateAsync(comment);

            if (await _unitOfWork.Complete())
            {
                var commentVm = _mapper.Map<CommentVm>(comment);
                return commentVm;
            }

            throw new Exception();
        }

        public async Task<CommentVm> GetById(Guid id)
        {
            var comment = await _unitOfWork.Comments.FirstAsync(p => p.Id == id);
            if (comment == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }


            var commentVm = _mapper.Map<CommentVm>(comment);

            return commentVm;
        }

        public async Task<ICollection<CommentVm>> GetAll()
        {

            var comments = await _unitOfWork.Comments.GetAllAsync();

            var commentVms = _mapper.Map<ICollection<CommentVm>>(comments);

            return commentVms;
        }

        public async Task Delete(Guid id)
        {
            var comment = await _unitOfWork.Comments.FirstAsync(p => p.Id == id);
            if (comment == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            await _unitOfWork.Comments.DeleteAsync(comment);

            if (!await _unitOfWork.Complete())
            {
                //TODO Create custom validation exception
                throw new Exception();
            }
        }
    }
}
