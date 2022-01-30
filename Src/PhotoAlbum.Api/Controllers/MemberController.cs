using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;


        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }


        [HttpGet("{id}", Name = "GetMember")]
        public async Task<ActionResult<MemberVm>> GetMember(Guid id)
        {
            return await _memberService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<MemberVm>> CreateMember(MemberModel model)
        {
            var memberVm = await _memberService.Add(model);
            return CreatedAtRoute("GetMember", new { id = memberVm.Id }, memberVm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(Guid id)
        {
            await _memberService.Delete(id);
            return Ok();
        }

    }
}
