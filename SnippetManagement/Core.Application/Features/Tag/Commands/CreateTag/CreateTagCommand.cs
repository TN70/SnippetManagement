using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Tag.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<Response<TagViewModel>>
    {
        public string Name { get; set; }
        public int SnippetId { get; set; }
    }
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, Response<TagViewModel>>
    {
        private readonly ITagRepositoryAsync _tagRespository;
        private readonly IMapper _mapper;

        public CreateTagHandler(ITagRepositoryAsync tagRespository, IMapper mapper)
        {
            _tagRespository = tagRespository;
            _mapper = mapper;
        }

        public async Task<Response<TagViewModel>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            //Process
            var tag = new Core.Domain.Entities.Tag { Name = request.Name, SnippetId = request.SnippetId };
            var data = await _tagRespository.AddAsync(tag);

            //Setup view model
            var viewModel = _mapper.Map<TagViewModel>(data);
            return new Response<TagViewModel>(viewModel);
        }
    }
}
