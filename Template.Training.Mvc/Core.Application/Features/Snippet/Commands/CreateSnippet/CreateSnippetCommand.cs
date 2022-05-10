using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Features.Snippet.Commands.CreateSnippet
{
    public class CreateSnippetCommand : IRequest<Response<SnippetViewModel>>
    {
        public string Description { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public List<string> Links { get; set; }
        public List<string> Tags { get; set; }
    }
    public class CreateSnippetHandler : IRequestHandler<CreateSnippetCommand, Response<SnippetViewModel>>
    {
        private readonly ISnippetRepositoryAsync _snippetRespository;
        private readonly ITagRepositoryAsync _tagRepository;
        private readonly ILinkRepositoryAsync _linkRepository;
        private readonly IMapper _mapper;

        public CreateSnippetHandler(ISnippetRepositoryAsync snippetRespository, IMapper mapper, ITagRepositoryAsync tagRepository, ILinkRepositoryAsync linkRepository)
        {
            _snippetRespository = snippetRespository;
            _tagRepository = tagRepository;
            _mapper = mapper;
            _linkRepository = linkRepository;
        }

        public async Task<Response<SnippetViewModel>> Handle(CreateSnippetCommand request, CancellationToken cancellationToken)
        {
            // Prepare data
            var model = _mapper.Map<Core.Domain.Entities.Snippet>(request);

            //Process
            var data = await _snippetRespository.AddAsync(model);
            var checkTags = new List<bool>();
            if (request.Tags.Any() && data != null)
            {
                foreach (var item in request.Tags)
                {
                    var tag = new Tag
                    {
                        SnippetId = data.Id,
                        Name = item,
                    };
                    var result = await _tagRepository.AddAsync(tag);
                    if (result == null) checkTags.Add(false);
                }
            }
            var checkLinks = new List<bool>();
            if (request.Links.Any())
            {
                foreach (var item in request.Links)
                {
                    var link = new Link
                    {
                        Value = item,
                        SnippetId = data.Id

                    };
                    var result = await _linkRepository.AddAsync(link);
                    if (result == null) checkLinks.Add(false);
                }
            }

            if (data == null || checkTags.Any() || checkLinks.Any())
                return new Response<SnippetViewModel>("Can't create Snippet", 400);

            //Setup view model
            var viewModel = _mapper.Map<SnippetViewModel>(data);
            return new Response<SnippetViewModel>(viewModel);
        }
    }
}
