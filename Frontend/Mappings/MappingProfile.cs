using AutoMapper;
using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<UserLoginDto, UserLogin>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
          .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

      CreateMap<ProjectDto, Project>()
          .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
          .ForMember(dest => dest.ContentTypeId, opt => opt.MapFrom(src => src.ContentTypeId))
          .ForMember(dest => dest.Briefing, opt => opt.MapFrom(src => src.Briefing))
          .ForMember(dest => dest.Brainstorm, opt => opt.MapFrom(src => src.Brainstorm));

      CreateMap<ContentDto, Content>()
          .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
          .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
          .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body));
    }
  }
}
