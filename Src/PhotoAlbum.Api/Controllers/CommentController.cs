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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}", Name = "GetComment")]
        public async Task<ActionResult<CommentVm>> GetComment(Guid id)
        {
            return await _commentService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CommentVm>> CreateComment(CommentModel model)
        {
            var commentVm = await _commentService.Add(model);
            return CreatedAtRoute("GetComment", new { id = commentVm.Id }, commentVm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(Guid id)
        {
            await _commentService.Delete(id);
            return Ok();
        }
    }
}
