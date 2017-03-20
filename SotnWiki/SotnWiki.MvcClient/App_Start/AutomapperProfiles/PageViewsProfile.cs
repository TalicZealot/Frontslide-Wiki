using AutoMapper;
using SotnWiki.DTOs.PageViewsDTOs;
using SotnWiki.Models;

namespace SotnWiki.MvcClient.App_Start.AutomapperProfiles
{
    public class PageViewsProfile : Profile
    {
        public PageViewsProfile()
        {
            this.CreateMap<Page, PageViewDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opts => opts.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.LastEdit, opts => opts.MapFrom(src => src.LastEdit))
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.GeneralCharacter != null)); opts.MapFrom(x => "General"); })
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.CategoryCharacter != null)); opts.MapFrom(x => "Category"); })
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.GlitchCharacter != null)); opts.MapFrom(x => "Glitch"); });

            this.CreateMap<Page, PageSearchDTO>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opts => opts.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.LastEdit, opts => opts.MapFrom(src => src.LastEdit))
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.GeneralCharacter != null)); opts.MapFrom(x => "General"); })
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.CategoryCharacter != null)); opts.MapFrom(x => "Category"); })
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.GlitchCharacter != null)); opts.MapFrom(x => "Glitch"); });

            this.CreateMap<Page, SubmissionsDTO>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.GeneralCharacter != null)); opts.MapFrom(x => "General"); })
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.CategoryCharacter != null)); opts.MapFrom(x => "Category"); })
                .ForMember(dest => dest.Type, opts => { opts.Condition(src => (src.GlitchCharacter != null)); opts.MapFrom(x => "Glitch"); });
        }
    }
}