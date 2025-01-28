using MediatR;
using Application.Models;
using Application.Repositories;
using Domain;
using AutoMapper;

namespace Application.Features.Properties.Queries
{
    public class GetPropertiesRequest: IRequest<List<PropertyDto>>
    {
    }

    public class GetPropertiesRequestHandler : IRequestHandler<GetPropertiesRequest, List<PropertyDto>>
        {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;


        public GetPropertiesRequestHandler(IPropertyRepo propertyRepo) {
            _propertyRepo = propertyRepo;
        }

        public async Task<List<PropertyDto>> Handle(GetPropertiesRequest request, CancellationToken cancellationToken)
        {
            List<Property> properties = await _propertyRepo.GetAllAsync();

            if (properties != null)
            { 
                //Mapper
                List<PropertyDto> propertyDtos =_mapper.Map<List<PropertyDto>>(properties);
                return propertyDtos; 
            }
            return null;
        }

    }

}
   
