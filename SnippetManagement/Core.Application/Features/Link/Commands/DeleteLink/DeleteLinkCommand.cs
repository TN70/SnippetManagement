using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Link.Commands.DeleteLink
{
    public class DeleteLinkCommand : IRequest<Response<LinkViewModel>>
    {
        public int Id { get; set; }
    }
    public class DeleteLinkHandler : IRequestHandler<DeleteLinkCommand, Response<LinkViewModel>>
    {
        private readonly ILinkRepositoryAsync _linkRespository;
        private readonly IMapper _mapper;

        public DeleteLinkHandler(ILinkRepositoryAsync linkRespository, IMapper mapper)
        {
            _linkRespository = linkRespository;
            _mapper = mapper;
        }

        public async Task<Response<LinkViewModel>> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            //Process
            var link = await _linkRespository.GetByIdAsync(request.Id);
            if (link == null || link.Status == Status.DELETED)
            {
                return new Response<LinkViewModel>("Link " + request.Id + " is not found", 404);
            }

            link.Status = Status.DELETED;
            var data = await _linkRespository.UpdateAsync(link);

            //Setup view model
            return new Response<LinkViewModel>(null, "Delete successfully", 200);
        }
    }
}
