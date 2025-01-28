using Application.Models;
using Application.Repositories;
using Domain;
using MediatR;
using System.Numerics;

namespace Application.Features.Properties.Commands
{
    public  class UpdatePropertyRequest:IRequest<bool>
    {
        public UpdateProperty UpdateProperty { get; set; }

        public UpdatePropertyRequest(UpdateProperty updateProperty)
        {
            UpdateProperty = updateProperty;
        }
    }
    public class UpdatePropertyRequestHandler : IRequestHandler<UpdatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;

        public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo)
        {
            _propertyRepo = propertyRepo;
        }
        public async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {

            //Check if exists in db
            Property propertyInDb = await _propertyRepo.GetByIdAsync(request.UpdateProperty.Id);
            if (propertyInDb != null)
            {
                propertyInDb.Name = request.UpdateProperty.Name;
                propertyInDb.Louge = request.UpdateProperty.Louge;
                propertyInDb.Dining = request.UpdateProperty.Dining;
                propertyInDb.Rate = request.UpdateProperty.Rate;
                propertyInDb.Bathrooms = request.UpdateProperty.Bathrooms;
                propertyInDb.Bedrooms = request.UpdateProperty.Bedrooms;
                propertyInDb.Address = request.UpdateProperty.Address;
                propertyInDb.Descripion = request.UpdateProperty.Descripion;
                propertyInDb.ErfSize = request.UpdateProperty.ErfSize;
                propertyInDb.FloorSize = request.UpdateProperty.FloorSize;
                propertyInDb.Kitchens = request.UpdateProperty.Kitchens;
                propertyInDb.Levies = request.UpdateProperty.Levies;
                propertyInDb.PetsAllowed = request.UpdateProperty.PetsAllowed;
                propertyInDb.Price = request.UpdateProperty.Price;
                propertyInDb.Type = request.UpdateProperty.Type;

                await _propertyRepo.UpdateAsync(propertyInDb);
                return true;
            }
            return false;
        }
    
        
    }
}
