using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Snippet.Queries.GetSnippetById
{
    public class GetSnippetByIdQuery : IRequest<Response<SnippetViewModel>>
    {
        public int Id { get; set; }
    }
    public class GetSnippetByIdHandler : IRequestHandler<GetSnippetByIdQuery, Response<SnippetViewModel>>
    {
        private readonly ISnippetRepositoryAsync _snippetRepository;
        private readonly IMapper _mapper;

        public GetSnippetByIdHandler(ISnippetRepositoryAsync snippetRepository, IMapper mapper)
        {
            _snippetRepository = snippetRepository;
            _mapper = mapper;
        }
        public async Task<Response<SnippetViewModel>> Handle(GetSnippetByIdQuery request, CancellationToken cancellationToken)
        {
            //Process 
            var snippet = await _snippetRepository.GetByIdAsync(request.Id);
            if (snippet == null || snippet.Status == Status.DELETED)
            {
                return new Response<SnippetViewModel>("Snipped " + request.Id + " is not found", 404);
            }

            //Setup view model
            var viewModel = _mapper.Map<SnippetViewModel>(snippet);
            return new Response<SnippetViewModel>(viewModel);
        }
    }
}
