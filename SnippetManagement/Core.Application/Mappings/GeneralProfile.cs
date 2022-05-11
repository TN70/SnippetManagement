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
            CreateMap<CreateSnippetCommand, Snippet>();
            CreateMap<UpdateSnippetCommand, Snippet>();
        }
    }
}
