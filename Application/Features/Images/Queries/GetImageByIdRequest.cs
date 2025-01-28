using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries
{
    public class GetImageByIdRequest:IRequest<ImageDto>
    {
        public int ImageId { get; set; }

        public GetImageByIdRequest(int imageId)
        {
            ImageId = imageId;
        }
    }
    public class GetImageIdRequestHandler : IRequestHandler<GetImageByIdRequest, ImageDto>
    { 
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;
        public GetImageIdRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }


        public async Task<ImageDto>Handle(GetImageByIdRequest request,CancellationToken cancellationToken)
        {
            Image imageInDb = await _imageRepo.GetByIdAsync(request.ImageId);
            if (imageInDb != null)
            {
                ImageDto imageDto = _mapper.Map<ImageDto>(imageInDb);
                return imageDto;
            }
            return null;
        }
    }
}
