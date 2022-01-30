using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IUnitOfWork _unitOfWork;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }


        [HttpGet("{id}", Name = "GetAlbum")]
        public async Task<ActionResult<AlbumVm>> GetAlbum(Guid id)
        {
            return await _albumService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<AlbumVm>> CreateAlbum(AlbumModel model)
        {
           var albumVm = await _albumService.Add(model);
           return CreatedAtRoute("GetAlbum", new {id = albumVm.Id}, albumVm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(Guid id)
        {
            await _albumService.Delete(id);
            return Ok();
        }
    }
}
