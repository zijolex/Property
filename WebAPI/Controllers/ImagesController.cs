﻿using Application.Features.Images.Commands;
using Application.Features.Images.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public ImagesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewImage([FromBody] NewImage newImage)
        {
            bool isSuccessful = await _mediatrSender.Send(new CreateImageRequest(newImage));
            if (isSuccessful)
            {
                return Ok("Image created successfully.");
            }
            return BadRequest("Failed to create image.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateImage(UpdateImage updateImage)
        {
            bool isSuccessful = await _mediatrSender.Send(new UpdateImageRequest(updateImage));
            if (isSuccessful)
            {
                return Ok("Image updated successfully.");
            }
            return NotFound("Image does not exists.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            bool isSuccessfull = await _mediatrSender.Send(new DeleteImageRequest(id));
            if (isSuccessfull)
            {
                return Ok("Image deleted successfully.");
            }
            return NotFound("Image does not exists.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            ImageDto image = await _mediatrSender.Send(new GetImageByIdRequest(id));
            if (image != null)
            {
                return Ok(image);
            }
            return NotFound("Image does not exists.");
        }

        [HttpGet("all")]
        public async Task<IActionResult>GetImages()
        {
            List<ImageDto> images = await _mediatrSender.Send(new GetImagesRequest());
            if (images != null)
            {
                return Ok(images);

            }
            return NotFound("No Images where found.");
        }

    }
}
