using System;

namespace DtoLayer.DTOs.AnnoucementDtos
{
    public class AnnouncementUpdateDto
    {
        public int AnnouncementID { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementDescription { get; set; }
        public DateTime AnnouncementDate { get; set; }
    }
}
