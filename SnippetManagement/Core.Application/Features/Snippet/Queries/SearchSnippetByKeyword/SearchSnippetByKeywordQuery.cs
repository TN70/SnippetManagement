using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Snippet.Queries.SearchSnippetByKeyword
{
    public class SearchSnippetByKeywordQuery : IRequest<PagedResponse<List<SnippetViewModel>>>
    {
        public string Keyword { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class SearchSnippetByKeywordHandler : IRequestHandler<SearchSnippetByKeywordQuery, PagedResponse<List<SnippetViewModel>>>
    {
        private readonly ISnippetRepositoryAsync _snippetRepository;
        private readonly IMapper _mapper;

        public SearchSnippetByKeywordHandler(ISnippetRepositoryAsync snippetRepository, IMapper mapper)
        {
            _snippetRepository = snippetRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<SnippetViewModel>>> Handle(SearchSnippetByKeywordQuery query, CancellationToken cancellationToken)
        {
            //Process 
            var data = await _snippetRepository.SearchSnippetByKeyword(query.Keyword, query.PageNumber, query.PageSize);

            //Setup view model
            var viewModel = _mapper.Map<List<SnippetViewModel>>(data);
            return new PagedResponse<List<SnippetViewModel>>(viewModel, query.PageNumber, query.PageSize);

        }
    }
}
