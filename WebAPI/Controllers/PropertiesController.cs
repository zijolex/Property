using Application.Features.Properties.Commands;
using Application.Features.Properties.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public PropertiesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }
        [HttpGet("add")]
        public async Task<IActionResult> AddNewProperty([FromBody] NewProperty newPropertyRequest)
        {

            bool isSuccessful = await _mediatrSender.Send(new CreatePropertyRequest(newPropertyRequest));
              if(isSuccessful)
            {
                return Ok("Property Successfully created ");

            }
            return BadRequest("Failed to create property");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdateProperty updateProperty)
        {
            bool isSuccessful = await _mediatrSender.Send(new UpdatePropertyRequest(updateProperty));
            if (isSuccessful)
            {
                return Ok("Property updated successfully.");
            }
            return NotFound("Property does not exists.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            PropertyDto propertyDto = await _mediatrSender.Send( new GetPropertyByIdRequest(id));
            if (propertyDto != null)
            {
                return Ok(propertyDto);
            }
            return NotFound("Property does not exists.");
        }
            [HttpGet("all")]
        public async Task<IActionResult>GetProperties()
        {
            List<PropertyDto> propertyDtos = await _mediatrSender.Send(new GetPropertiesRequest());
           if(propertyDtos != null)
            {
                return Ok(propertyDtos);
            }
            return NotFound("No Properties were found.");
          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProperty(int id)
        {
            bool isSuccessful = await _mediatrSender.Send(new DeletePropertyRequest(id));
            if (isSuccessful)
            {
                return Ok("Property deleted successfully.");
            }
            return NotFound("Property doest not exists.");
        }
    }
}
