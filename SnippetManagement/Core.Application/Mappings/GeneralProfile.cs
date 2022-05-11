using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Features.Snippet.Commands.CreateSnippet;
using Core.Application.Features.Snippet.Commands.UpdateSnippet;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Snippet, SnippetViewModel>();
            CreateMap<CreateSnippetCommand, Snippet>().ForMember(x => x.Tags, otp => otp.Ignore()).ForMember(x => x.Links, otp => otp.Ignore());
            CreateMap<UpdateSnippetCommand, Snippet>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Link, LinkViewModel>();

        }
    }
}
