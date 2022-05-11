using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Snippet.Commands.DeleteSnippet
{
    public class DeleteSnippetCommand : IRequest<Response<SnippetViewModel>>
    {
        public int Id { get; set; }
    }
    public class DeleteSnippetHandler : IRequestHandler<DeleteSnippetCommand, Response<SnippetViewModel>>
    {
        private readonly ISnippetRepositoryAsync _snippetRespository;
        private readonly IMapper _mapper;

        public DeleteSnippetHandler(ISnippetRepositoryAsync snippetRespository, IMapper mapper)
        {
            _snippetRespository = snippetRespository;
            _mapper = mapper;
        }

        public async Task<Response<SnippetViewModel>> Handle(DeleteSnippetCommand request, CancellationToken cancellationToken)
        {
            //Process
            var snippet = await _snippetRespository.GetByIdAsync(request.Id);
            if (snippet == null || snippet.Status == Status.DELETED)
            {
                return new Response<SnippetViewModel>("Snipped " + request.Id + " is not found", 404);
            }

            snippet.Status = Status.DELETED;
            var data = await _snippetRespository.UpdateAsync(snippet);

            //Setup view model
            return new Response<SnippetViewModel>(null, "Delete successfully", 200);
        }
    }
}
