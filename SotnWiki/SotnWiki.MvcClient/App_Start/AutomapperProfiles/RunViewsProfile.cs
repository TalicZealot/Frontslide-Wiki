using AutoMapper;
using SotnWiki.DTOs.RunViewsDTOs;
using SotnWiki.Models;

namespace SotnWiki.MvcClient.App_Start.AutomapperProfiles
{
    public class RunViewsProfile : Profile
    {
        public RunViewsProfile()
        {
            this.CreateMap<Run, LeaderboardRunDTO>()
                .ForMember(dest => dest.Runner, opts => opts.MapFrom(src => src.Runner))
                .ForMember(dest => dest.Time, opts => opts.MapFrom(src => src.Time))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date))
                .ForMember(dest => dest.Url, opts => opts.MapFrom(src => src.Url))
                .ForMember(dest => dest.Platform, opts => opts.MapFrom(src => src.Platform.ToString()));
        }
    }
}