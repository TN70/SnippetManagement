using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;

namespace Core.Application.Features.Snippet.Commands.CreateSnippet
{
    public class CreateSnippetCommand : IRequest<Response<SnippetViewModel>>
    {
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
    }
    public class CreateSnippetHandler : IRequestHandler<CreateSnippetCommand, Response<SnippetViewModel>>
    {
        private readonly ISnippetRespositoryAsync _snippetRespository;
        private readonly IMapper _mapper;

        public CreateSnippetHandler(ISnippetRespositoryAsync snippetRespository, IMapper mapper)
        {
            _snippetRespository = snippetRespository;
            _mapper = mapper;
        }

        public async Task<Response<SnippetViewModel>> Handle(CreateSnippetCommand request, CancellationToken cancellationToken)
        {
            // Prepare data
            var model = _mapper.Map<Core.Domain.Entities.Snippet>(request);
            model.Tags = JsonConvert.SerializeObject(request.Tags);

            //Process
            var data = await _snippetRespository.AddAsync(model);

            //Setup view model
            var viewModel = _mapper.Map<SnippetViewModel>(data);
            return new Response<SnippetViewModel>(viewModel);
        }
    }
}
