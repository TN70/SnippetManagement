using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Snippet.Queries.GetAllSnippets
{
    public class GetAllSnippetsQuery : IRequest<PagedResponse<List<SnippetViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllSnippetsHandler : IRequestHandler<GetAllSnippetsQuery, PagedResponse<List<SnippetViewModel>>>
    {
        private readonly ISnippetRepositoryAsync _snippetRepository;
        private readonly IMapper _mapper;

        public GetAllSnippetsHandler(ISnippetRepositoryAsync snippetRepository, IMapper mapper)
        {
            _snippetRepository = snippetRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<SnippetViewModel>>> Handle(GetAllSnippetsQuery request, CancellationToken cancellationToken)
        {
            // Process
            var data = await _snippetRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

            //Setup view model
            var viewModel = _mapper.Map<List<SnippetViewModel>>(data);

            return new PagedResponse<List<SnippetViewModel>>(viewModel, request.PageNumber, request.PageSize);
        }
    }
}
