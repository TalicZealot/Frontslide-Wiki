using AutoMapper;
using SotnWiki.DTOs.EditViewsDTOs;
using SotnWiki.Models;

namespace SotnWiki.MvcClient.App_Start.AutomapperProfiles
{
    public class EditViewsProfile : Profile
    {
        public EditViewsProfile()
        {
            this.CreateMap<PageContentSubmission , EditsViewDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opts => opts.MapFrom(src => src.Content))
                .ForMember(dest => dest.PageId, opts => opts.MapFrom(src => src.PageEdit.Id));
        }
    }
}