using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.ViewModels;

namespace PhotoAlbum.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;


        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public async Task<ActionResult<LocationVm>> GetLocation(Guid id)
        {
            return await _locationService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<LocationVm>> CreateLocation(LocationModel model)
        {
            var locationVm = await _locationService.Add(model);
            return CreatedAtRoute("GetLocation", new { id = locationVm.Id }, locationVm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(Guid id)
        {
            await _locationService.Delete(id);
            return Ok();
        }
    }
}
