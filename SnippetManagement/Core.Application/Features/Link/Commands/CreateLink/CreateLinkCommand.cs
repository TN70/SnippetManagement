using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Link.Commands.CreateLink
{
    public class CreateLinkCommand : IRequest<Response<LinkViewModel>>
    {
        public string Value { get; set; }
        public int SnippetId { get; set; }
    }
    public class CreateLinkHandler : IRequestHandler<CreateLinkCommand, Response<LinkViewModel>>
    {
        private readonly ILinkRepositoryAsync _linkRespository;
        private readonly IMapper _mapper;

        public CreateLinkHandler(ILinkRepositoryAsync linkRespository, IMapper mapper)
        {
            _linkRespository = linkRespository;
            _mapper = mapper;
        }

        public async Task<Response<LinkViewModel>> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            //Process
            var link = new Core.Domain.Entities.Link { Value = request.Value, SnippetId = request.SnippetId };
            var data = await _linkRespository.UpdateAsync(link);

            //Setup view model
            var viewModel = _mapper.Map<LinkViewModel>(data);
            return new Response<LinkViewModel>(viewModel);
        }
    }
}
