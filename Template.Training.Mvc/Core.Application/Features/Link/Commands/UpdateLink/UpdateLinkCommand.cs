using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Link.Commands.UpdateLink
{
    public class UpdateLinkCommand : IRequest<Response<LinkViewModel>>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class UpdateLinkHandler : IRequestHandler<UpdateLinkCommand, Response<LinkViewModel>>
    {
        private readonly ILinkRepositoryAsync _linkRespository;
        private readonly IMapper _mapper;

        public UpdateLinkHandler(ILinkRepositoryAsync linkRespository, IMapper mapper)
        {
            _linkRespository = linkRespository;
            _mapper = mapper;
        }

        public async Task<Response<LinkViewModel>> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            //Process
            var link = await _linkRespository.GetByIdAsync(request.Id);
            if (link == null || link.Status == Status.DELETED)
            {
                return new Response<LinkViewModel>("Link " + request.Id + " is not found", 404);
            }

            link.Value = request.Value;
            var data = await _linkRespository.UpdateAsync(link);
            if (data == null)
                return new Response<LinkViewModel>("Update failed", 400);

            //Setup view model
            var viewModel = _mapper.Map<LinkViewModel>(data);
            return new Response<LinkViewModel>(null, "Update successfully", 200);
        }
    }
}
