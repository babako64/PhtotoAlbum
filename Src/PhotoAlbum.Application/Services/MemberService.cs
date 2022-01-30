using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Application.Services
{
    public class MemberService : IMemberService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<MemberVm> Add(MemberModel model)
        {

            var member = _mapper.Map<Member>(model);

            var memberAdded = await _unitOfWork.Members.AddAsync(member);

            if (await _unitOfWork.Complete())
            {
                var memberVm = _mapper.Map<MemberVm>(memberAdded);
                return memberVm;
            }

            throw new Exception();
        }

        public async Task<MemberVm> Update(MemberModel model)
        {
            var member = await _unitOfWork.Members.FirstAsync(p => p.Id == model.Id);
            if (member == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            _mapper.Map(model, member);

            await _unitOfWork.Members.UpdateAsync(member);

            if (await _unitOfWork.Complete())
            {
                var memberVm = _mapper.Map<MemberVm>(member);
                return memberVm;
            }

            throw new Exception();
        }

        public async Task<MemberVm> GetById(Guid id)
        {
            var member = await _unitOfWork.Members.FirstAsync(p => p.Id == id);
            if (member == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }


            var memberVm = _mapper.Map<MemberVm>(member);

            return memberVm;
        }

        public async Task<ICollection<MemberVm>> GetAll()
        {

            var members = await _unitOfWork.Members.GetAllAsync();

            var memberVms = _mapper.Map<ICollection<MemberVm>>(members);

            return memberVms;
        }

        public async Task Delete(Guid id)
        {
            var member = await _unitOfWork.Members.FirstAsync(p => p.Id == id);
            if (member == null)
            {
                //TODO Create custom validation exception
                throw new Exception();
            }

            await _unitOfWork.Members.DeleteAsync(member);

            if (!await _unitOfWork.Complete())
            {
                //TODO Create custom validation exception
                throw new Exception();
            }
        }
    }
}
