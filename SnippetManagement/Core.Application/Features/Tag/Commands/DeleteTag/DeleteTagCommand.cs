using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Tag.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<Response<TagViewModel>>
    {
        public int Id { get; set; }
    }
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Response<TagViewModel>>
    {
        private readonly ITagRepositoryAsync _tagRespository;
        private readonly IMapper _mapper;

        public DeleteTagHandler(ITagRepositoryAsync tagRespository, IMapper mapper)
        {
            _tagRespository = tagRespository;
            _mapper = mapper;
        }

        public async Task<Response<TagViewModel>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            //Process
            var link = await _tagRespository.GetByIdAsync(request.Id);
            if (link == null || link.Status == Status.DELETED)
            {
                return new Response<TagViewModel>("Tag " + request.Id + " is not found", 404);
            }

            link.Status = Status.DELETED;
            var data = await _tagRespository.UpdateAsync(link);

            //Setup view model
            return new Response<TagViewModel>(null, "Delete successfully", 200);
        }
    }

}
