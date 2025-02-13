﻿using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries
{
    public class GetImagesRequest : IRequest<List<ImageDto>>
    {
        //public string CacheKey { get; set; }
        //public GetImagesRequest()
        //{

        //    CacheKey = "GetImagesRequest";
        //}
    }
    public class GetImagesRequestHandler : IRequestHandler<GetImagesRequest, List<ImageDto>>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public GetImagesRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<List<ImageDto>> Handle(GetImagesRequest request, CancellationToken cancellationToken)
        {
            List<Image> images = await _imageRepo.GetAllAsync();
            if (images != null)
            {
                List<ImageDto> imageDtos = _mapper.Map<List<ImageDto>>(images);
                return imageDtos;
            }
            return null;
        }


    }
}
