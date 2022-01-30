using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;
using PhotoAlbum.Domain.Entities;

namespace PhotoAlbum.Api.Controllers
{
    [Route("api/Photo")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }


        [HttpGet( "{id}",Name = "GetPhoto")]
        public async Task<ActionResult<PhotoVm>> GetPhotoById(Guid id)
        {
            var photoVm = await _photoService.GetPhotoById(id);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<PhotoVm>>> GetAll()
        {
            return Ok(await _photoService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<PhotoVm>> AddPhoto(PhotoModel model)
        {
            var photoVm = await _photoService.AddPhoto(model);

            return CreatedAtRoute("GetPhoto", new {id = photoVm.Id}, photoVm);
        }


    }
}
