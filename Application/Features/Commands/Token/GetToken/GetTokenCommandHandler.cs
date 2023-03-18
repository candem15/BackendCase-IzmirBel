using Application.Abstractions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Token.GetToken
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommandRequest, GetTokenCommandResponse>
    {
        private readonly ITokenHandler tokenHandler;
        private readonly IMapper mapper;

        public GetTokenCommandHandler(ITokenHandler tokenHandler,IMapper mapper)
        {
            this.tokenHandler = tokenHandler;
            this.mapper = mapper;
        }
        public async Task<GetTokenCommandResponse> Handle(GetTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var result = tokenHandler.CreateAccessToken();

            return mapper.Map<GetTokenCommandResponse>(result);
        }
    }
}
