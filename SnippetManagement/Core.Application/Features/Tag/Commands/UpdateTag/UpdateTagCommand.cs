using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Tag.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<Response<TagViewModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Response<TagViewModel>>
    {
        private readonly ITagRepositoryAsync _tagRespository;
        private readonly IMapper _mapper;

        public UpdateTagHandler(ITagRepositoryAsync tagRespository, IMapper mapper)
        {
            _tagRespository = tagRespository;
            _mapper = mapper;
        }

        public async Task<Response<TagViewModel>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            //Process
            var tag = await _tagRespository.GetByIdAsync(request.Id);
            if (tag == null || tag.Status == Status.DELETED)
            {
                return new Response<TagViewModel>("Tag " + request.Id + " is not found", 404);
            }

            tag.Name = request.Name;
            var data = await _tagRespository.UpdateAsync(tag);
            if (data == null)
                return new Response<TagViewModel>("Update failed", 400);

            //Setup view model
            var viewModel = _mapper.Map<TagViewModel>(data);
            return new Response<TagViewModel>(null, "Update successfully", 200);
        }
    }
}
