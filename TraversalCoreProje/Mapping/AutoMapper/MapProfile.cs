using AutoMapper;
using DtoLayer.DTOs.AnnoucementDtos;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto,Announcement>().ReverseMap();
            CreateMap<AnnouncementDeleteDto,Announcement>().ReverseMap();
            CreateMap<AnnouncementGetUpdateDto,Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDto,Announcement>().ReverseMap();
        }
    }
}
