using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Exceptions;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealEstateApp.Core.Application.Features.Agents.Commands.ChangeAgentStatus
{
    /// <summary>
    /// Parámetros para cambiar el estado de un agente
    /// </summary>  
    public class ChangeAgentStatusCommand : IRequest<Response<UserResponse>>
    {
        /// <example>1</example>
        [SwaggerParameter(Description = "El id del agente que se desea seleccionar")]
        public string Id { get; set; }

        /// <example>false</example>
        [SwaggerParameter(Description = "Activar o desactivar el agente")]
        public bool isActive { get; set; }
    }

    public class ChangeAgentStatusCommandHandler : IRequestHandler<ChangeAgentStatusCommand, Response<UserResponse>>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public ChangeAgentStatusCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;

            _mapper = mapper;
        }

        public async Task<Response<UserResponse>> Handle(ChangeAgentStatusCommand query, CancellationToken cancellationToken)
        {
            UserRequest userRequest = new();
            userRequest.Id = query.Id;
            var agent = await _accountService.UpdateIsActiveAgent(query.Id, query.isActive);

            if (agent == null || agent.HasError != false) throw new ApiException($"Agent not found.", (int)HttpStatusCode.NotFound);


            return new Response<UserResponse>(agent);
        }
    }
}
