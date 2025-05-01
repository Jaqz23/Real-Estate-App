using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Interfaces.Repositories;
using RealEstateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using RealEstateApp.Core.Domain.Entities;


namespace RealEstateApp.Core.Application.Features.PropertyTypes.Commands.CreatePropertyType
{
    /// <summary>
    /// Parámetros para crear un tipo de propiedad
    /// </summary>  
    public class CreatePropertyTypeCommand : IRequest<Response<int>>
    {
        /// <example>Casa</example>
        [SwaggerParameter(Description = "El tipo de propiedad")]
        public string Name { get; set; }

        /// <example>Casa de 3 habitaciones y 2 baños</example>
        [SwaggerParameter(Description = "La descripcion de el tipo de propiedad")]
        public string? Description { get; set; }
    }
    public class CreatePropertyTypeCommandHandler : IRequestHandler<CreatePropertyTypeCommand, Response<int>>
    {
        private readonly IPropertyTypeRepository _PropertyTypeRepository;
        private readonly IMapper _mapper;
        public CreatePropertyTypeCommandHandler(IPropertyTypeRepository PropertyTypeRepository, IMapper mapper)
        {
            _PropertyTypeRepository = PropertyTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            var PropertyType = _mapper.Map<PropertyType>(request);
            await _PropertyTypeRepository.AddAsync(PropertyType);
            return new Response<int>(PropertyType.Id);
        }
    }
}