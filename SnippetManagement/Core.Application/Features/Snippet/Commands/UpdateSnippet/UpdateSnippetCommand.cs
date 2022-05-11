using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;

namespace Core.Application.Features.Snippet.Commands.UpdateSnippet
{
    public class UpdateSnippetCommand : IRequest<Response<SnippetViewModel>>
    {
        public int Id { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
    }
    public class UpdateSnippetHandler : IRequestHandler<UpdateSnippetCommand, Response<SnippetViewModel>>
    {
        private readonly ISnippetRespositoryAsync _snippetRespository;
        private readonly IMapper _mapper;

        public UpdateSnippetHandler(ISnippetRespositoryAsync snippetRespository, IMapper mapper)
        {
            _snippetRespository = snippetRespository;
            _mapper = mapper;
        }

        public async Task<Response<SnippetViewModel>> Handle(UpdateSnippetCommand request, CancellationToken cancellationToken)
        {
            //Process
            var snippet = await _snippetRespository.GetByIdAsync(request.Id);
            if (snippet == null)
            {
                return new Response<SnippetViewModel>("Snipped " + request.Id + " is not found", 404);
            }

            snippet.Tags = JsonConvert.SerializeObject(request.Tags);
            snippet.Description = request.Description;
            snippet.Origin = request.Origin;
            snippet.Name = request.Name;
            snippet.Language = request.Language;
            var data = await _snippetRespository.UpdateAsync(snippet);

            //Setup view model
            var viewModel = _mapper.Map<SnippetViewModel>(data);
            return new Response<SnippetViewModel>(viewModel);
        }
    }
}
