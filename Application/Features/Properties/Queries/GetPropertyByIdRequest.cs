using Application.Models;
using Application.PipelineBehaviours.Contracts;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries
{
    public class GetPropertyByIdRequest : IRequest<PropertyDto>, ICacheable
    {
        public int PropertyId { get; set; }
        public string CacheKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }

        public GetPropertyByIdRequest(int propertyId)
        {
            PropertyId = propertyId;
            CacheKey = $"GetPropertyById:{PropertyId}";
        }
    }

    public class GetPropertyByIdRequestHandler : IRequestHandler<GetPropertyByIdRequest, PropertyDto>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public GetPropertyByIdRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(GetPropertyByIdRequest request, CancellationToken cancellationToken)
        {
            Property propertyInDb = await _propertyRepo.GetByIdAsync(request.PropertyId);

            if (propertyInDb != null)
            {
                PropertyDto propertyDto = _mapper.Map<PropertyDto>(propertyInDb);
                return propertyDto;
            }
            return null;
        }
    }
}
