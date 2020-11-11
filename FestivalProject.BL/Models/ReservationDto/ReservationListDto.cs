using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.ReservationDto
{
    public class ReservationListDto : EntityBase
    {
        public ReservationStatus State { get; set; }
        public string Name { get; set; }
        public string FestivalName { get; set; }
    }
}
